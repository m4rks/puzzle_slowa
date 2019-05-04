using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using Puzzle.Zdania.IServices;
using Puzzle.Zdania.Model;

namespace Puzzle.Zdania.MockServices
{
    public class MockSatzeService : ISatzeService
    {
        private IList<Satz> satze;

        public MockSatzeService()
        {}

        public Satz GetFile(string NameOfTask)
        {
            LoadDataFromXls(@"C:\Users\mmichalak\source\repos\_auto\puzzle_slowa\Puzzle.Zdania.WPFClient\bin\Debug\" + NameOfTask + ".xlsx");
            return satze.SingleOrDefault(s => s.Idnum == 1);
        }

        public Satz GetNextTask(int numberOfTask)
        {
            return satze.SingleOrDefault(s => s.Idnum == numberOfTask);
        }
        private void LoadDataFromXls(string filePath)
        {
            using (var excelWorkbook = new XLWorkbook(filePath))
            {
                satze = new List<Satz>();
                int imageCounter = 0;
                Dictionary<int, ClosedXML.Excel.Drawings.IXLPicture> PicturesByCellAddress = new Dictionary<int, ClosedXML.Excel.Drawings.IXLPicture>();
                foreach (ClosedXML.Excel.Drawings.IXLPicture pic in excelWorkbook.Worksheet(1).Pictures)
                {
                    try
                    {
                        var aaa = pic.Placement;
                        PicturesByCellAddress.Add(pic.TopLeftCell.Address.RowNumber, pic);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.ToString());
                    }
                }

                Image imagen = null;
                int i = 0;
                MemoryStream ms = new MemoryStream();

                var nonEmptyDataRows = excelWorkbook.Worksheet(1).RowsUsed();
                foreach (var dataRow in nonEmptyDataRows)
                {

                    //for row number check
                    if (dataRow.RowNumber() >= 2 && dataRow.RowNumber() <= 100)
                    {
                        ClosedXML.Excel.Drawings.IXLPicture foto;
                        foto = PicturesByCellAddress[dataRow.RowNumber()];
                        Console.WriteLine(i.ToString());
                        ms = foto.ImageStream;
                        //System.Drawing.Bitmap dImg = new System.Drawing.Bitmap(ms);
                        //dImg.Save(dImg, System.Drawing.Imaging.ImageFormat.Jpeg);
                        System.Windows.Media.Imaging.BitmapImage bImg = new System.Windows.Media.Imaging.BitmapImage();
                        bImg.BeginInit();
                        bImg.StreamSource = new MemoryStream(ms.ToArray());
                        bImg.EndInit();

                        Satz readSatz = new Satz()
                        {
                            Idnum = Convert.ToInt32(dataRow.Cell(1).Value),
                            Belohnung = dataRow.Cell(2).Value.ToString(),
                            Bild = bImg,
                            SatzMitSemikolon = dataRow.Cell(4).Value.ToString(),
                            Antwort = dataRow.Cell(5).Value.ToString()
                        };
                        satze.Add(readSatz);
                    }
                }
            }
        }

        public int Count()
        {
            return satze.Count;
        }
    }
}
