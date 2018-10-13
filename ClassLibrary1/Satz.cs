﻿using System;

namespace Puzzle.Zdania.Model
{
    public class Satz : Base
    {
        private int _idnum;
        private string _satzMitSemikolon;
        private string _belohnung;
        private string _bild;

        public int Idnum
        {
            get { return _idnum; }
            set { _idnum = value; }
        }

        public string Bild
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
            set { _belohnung = value; }
        }
    }
}