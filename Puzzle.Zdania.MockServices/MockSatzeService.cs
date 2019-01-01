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
        {
            //  LoadDataInSourceCode();
            LoadDataFromXls("HelloWorld.xlsx");
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
                    catch { }
                }//pic.TopLeftCellAddress.RowNumber

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

        //private void LoadDataInSourceCode()
        //{
        //    satze = new List<Satz>
        //    {
        //        new Satz
        //        {
        //            Idnum = 1,
        //            Belohnung = "Co robi Gabryś?",
        //            Bild = "gabrys-architekt.jpg",
        //            SatzMitSemikolon = "Pokazuje swoj dom;Liczy na kalkulatorze;Pisze;Biega",
        //            Antwort = "Pokazuje swoj dom"
        //        },
        //        new Satz
        //        {
        //            Idnum = 2,
        //            Belohnung = "Co robi mis?",
        //            Bild = "mis ksiezyc spi.jpg",
        //            SatzMitSemikolon = "śpi;śpiewa;pływa",
        //            Antwort = "śpi"
        //        },
        //        new Satz
        //        {
        //            Idnum = 3,
        //            Belohnung = "Co to jest?",
        //            Bild = "bp.PNG",
        //            SatzMitSemikolon = "stacja benzynowa BP;przedszkole;dom;góra",
        //            Antwort = "stacja benzynowa BP"
        //        },
        //        new Satz
        //        {
        //            Idnum = 4,
        //            Belohnung = "Co robi chlopak?",
        //            Bild = "prezent.jpg",
        //            SatzMitSemikolon = "Daje prezent;Śpiewa;Skacze;Biegnie",
        //            Antwort = "Daje prezent"
        //        },
        //        new Satz
        //        {
        //            Idnum = 5,
        //            Belohnung = "Co to jest?",
        //            Bild = "pociag.png",
        //            SatzMitSemikolon = "Samochód;Samolot;Lody;Pociąg",
        //            Antwort = "Pociąg"
        //        },
        //        new Satz
        //        {
        //            Idnum = 6,
        //            Belohnung = "Jakie jest dziecko?",
        //            Bild = "dziecko_szczesliwe.jpg",
        //            SatzMitSemikolon = "Smutne;Zazdrosne;Szczęśliwe",
        //            Antwort = "Szczęśliwe"
        //        },
        //        new Satz
        //        {
        //            Idnum = 7,
        //            Belohnung = "Co robi Pani?",
        //            Bild = "beschäftigt.jpg",
        //            SatzMitSemikolon = "Śpiewa i tańczy;Pije i pisze;Biega i skacze",
        //            Antwort = "Pije i pisze"
        //        },
        //        new Satz
        //        {
        //            Idnum = 8,
        //            Belohnung = "Co robi chlopak?",
        //            Bild = "boso po plaży.jpg",
        //            SatzMitSemikolon = "Czyta książkę;Je czekoladę;Biegnie boso po plaży",
        //            Antwort = "Biegnie boso po plaży"
        //        },
        //        new Satz
        //        {
        //            Idnum = 9,
        //            Belohnung = "Co robi chlopak?",
        //            Bild = "chlopiec jezdzi na rowerze.jpg",
        //            SatzMitSemikolon = "Jeździ na rowerze;Odkurza;Wącha kwiatki",
        //            Antwort = "Jeździ na rowerze"
        //        },
        //        new Satz
        //        {
        //            Idnum = 10,
        //            Belohnung = "Jaki jest chłopczyk?",
        //            Bild = "chlopiec jezdzi na rowerze.jpg",
        //            SatzMitSemikolon = "Smutny;Wesoły",
        //            Antwort = "Wesoły"
        //        },
        //        new Satz
        //        {
        //            Idnum = 11,
        //            Belohnung = "Co robi dziewczynka?",
        //            Bild = "dziwczynka_plywa.jpg",
        //            SatzMitSemikolon = "Pływa;Śpiewa;Skacze;Biegnie",
        //            Antwort = "Pływa"
        //        },
        //        new Satz
        //        {
        //            Idnum = 12,
        //            Belohnung = "Jaki kolor skrzydełek ma dziewczynka?",
        //            Bild = "dziwczynka_plywa.jpg",
        //            SatzMitSemikolon = "Niebieski;Zielony;Różowy;Czarny",
        //            Antwort = "Różowy"
        //        },
        //        new Satz
        //        {
        //            Idnum = 13,
        //            Belohnung = "Z czym pływa dziwczynka?",
        //            Bild = "dziwczynka_plywa_z makaronem.jpg",
        //            SatzMitSemikolon = "Z piłką;Z kaczką;Z kołem;Z makaronem",
        //            Antwort = "Z makaronem"
        //        },
        //        new Satz
        //        {
        //            Idnum = 14,
        //            Belohnung = "Na czym siedzi dziewczynka?",
        //            Bild = "dziwczynka_siedzi_na_paczku.JPG",
        //            SatzMitSemikolon = "Na piłce;Na poduszcze;Na pączku",
        //            Antwort = "Na pączku"
        //        },
        //        new Satz
        //        {
        //            Idnum = 15,
        //            Belohnung = "Jaka jest pani?",
        //            Bild = "erkälten.jpg",
        //            SatzMitSemikolon = "Zdrowa;Szczęśliwa;Chora",
        //            Antwort = "Chora"
        //        },
        //        new Satz
        //        {
        //            Idnum = 16,
        //            Belohnung = "Na czym płyną ludzie?",
        //            Bild = "Flossfahrt(e).jpg",
        //            SatzMitSemikolon = "Na piłce;Na poduszcze;Na tratwie",
        //            Antwort = "Na tratwie"
        //        },
        //        new Satz
        //        {
        //            Idnum = 17,
        //            Belohnung = "Jaki jest Pan?",
        //            Bild = "freudig.jpg",
        //            SatzMitSemikolon = "Smutny;Zły;Szczęśliwy",
        //            Antwort = "Szczęśliwy"
        //        },
        //        new Satz
        //        {
        //            Idnum = 18,
        //            Belohnung = "Ilu ludzi biega?",
        //            Bild = "ludzie biegaja.jpg",
        //            SatzMitSemikolon = "Dużo;Mało",
        //            Antwort = "Dużo"
        //        },
        //        new Satz
        //        {
        //            Idnum = 19,
        //            Belohnung = "Co robi Pan?",
        //            Bild = "make pizza.jpg",
        //            SatzMitSemikolon = "Robi ciasto;Robi herbatę;Robi kawę",
        //            Antwort = "Robi ciasto"
        //        },
        //        new Satz
        //        {
        //            Idnum = 20,
        //            Belohnung = "Ilu ludzi biega?",
        //            Bild = "pan biega.jpg",
        //            SatzMitSemikolon = "Dużo;Jedne Pan",
        //            Antwort = "Jedne Pan"
        //        },
        //        new Satz
        //        {
        //            Idnum = 21,
        //            Belohnung = "Jaki kolor roweru ma Pan?",
        //            Bild = "pan jezdzi na rowerze.jpg",
        //            SatzMitSemikolon = "Żółty;Zielony;Czerwony;Niebieski",
        //            Antwort = "Żółty"
        //        },
        //        new Satz
        //        {
        //            Idnum = 22,
        //            Belohnung = "Co pije Pani?",
        //            Bild = "pani pije herbate.jpg",
        //            SatzMitSemikolon = "Herbatę;Kawę",
        //            Antwort = "Herbatę"
        //        },
        //        new Satz
        //        {
        //            Idnum = 23,
        //            Belohnung = "Jaka jest Pani?",
        //            Bild = "pani pije herbate.jpg",
        //            SatzMitSemikolon = "Smutna;Zła;Szczęśliwa",
        //            Antwort = "Szczęśliwa"
        //        },
        //        new Satz
        //        {
        //            Idnum = 24,
        //            Belohnung = "Jaka kolor włosów ma Pani?",
        //            Bild = "pani pije herbate.jpg",
        //            SatzMitSemikolon = "Czarne;Zielone;Blond",
        //            Antwort = "Czarne"
        //        },
        //        new Satz
        //        {
        //            Idnum = 25,
        //            Belohnung = "Jaki kolor roweru ma Pan?",
        //            Bild = "pani pije kawe.jpg",
        //            SatzMitSemikolon = "Żółty;Zielony;Czerwony;Blond",
        //            Antwort = "Blond"
        //        },
        //        new Satz
        //        {
        //            Idnum = 26,
        //            Belohnung = "Co wkłada Pan do piekarnika?",
        //            Bild = "pizza do pieca.jpg",
        //            SatzMitSemikolon = "Pizze;Bułki;Tort",
        //            Antwort = "Pizze"
        //        },
        //        new Satz
        //        {
        //            Idnum = 27,
        //            Belohnung = "Co Pani je?",
        //            Bild = "pizza eat.jpg",
        //            SatzMitSemikolon = "Chleb;Makaron;Pizze;Cukierka",
        //            Antwort = "Pizze"
        //        },
        //        new Satz
        //        {
        //            Idnum = 28,
        //            Belohnung = "Jaki kształt ma pizza?",
        //            Bild = "pizza haert.jpg",
        //            SatzMitSemikolon = "Okrągły;Kwadratowy;Serca",
        //            Antwort = "Serca"
        //        },
        //        new Satz
        //        {
        //            Idnum = 29,
        //            Belohnung = "Ilu jest Panów?",
        //            Bild = "pizza in air.jpg",
        //            SatzMitSemikolon = "Ośmiu;Siedmiu;Dwóch",
        //            Antwort = "Dwóch"
        //        },
        //        new Satz
        //        {
        //            Idnum = 30,
        //            Belohnung = "Co jest robione?",
        //            Bild = "pizza robimy.jpg",
        //            SatzMitSemikolon = "Chleb;Makaron;Pizza;Czekolada",
        //            Antwort = "Pizza"
        //        },
        //        new Satz
        //        {
        //            Idnum = 31,
        //            Belohnung = "Co to jest?",
        //            Bild = "pociag.png",
        //            SatzMitSemikolon = "Samochód;Samolot;Pizza;Pociąg",
        //            Antwort = "Pociąg"
        //        },
        //        new Satz
        //        {
        //            Idnum = 32,
        //            Belohnung = "Kogo goni Pan?",
        //            Bild = "Unpünktlichkeit.png",
        //            SatzMitSemikolon = "Samochód;Drzewo;Dom;Zegar",
        //            Antwort = "Zegar"
        //        },
        //    };
        //}


        public Satz Get(int id)
        {
            return satze.SingleOrDefault(s => s.Idnum == id);
        }

        public int Count()
        {
            return satze.Count;
        }
    }
}
