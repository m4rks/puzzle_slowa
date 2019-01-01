using System;
using System.Drawing;
using System.Net.Mime;
using System.Windows.Media.Imaging;

namespace Puzzle.Zdania.Model
{

    public class Satz : Point
    {
        private int _idnum;
        private string _satzMitSemikolon;
        private string _belohnung;
        private BitmapImage _bild;
        private string _antwort;


        public int Idnum
        {
            get { return _idnum; }
            set { _idnum = value; }
        }

        public BitmapImage Bild
        {
            get { return _bild; }
            set { _bild = value; }
        }

        public string SatzMitSemikolon
        {
            get { return _satzMitSemikolon; }
            set { _satzMitSemikolon = value; }

        }

        public string Belohnung
        {
            get { return _belohnung; }
            set
            {
                _belohnung = value;
            }
        }

        public string Antwort
        {
            get { return _antwort; }
            set { _antwort = value; }
        }
    }
}
