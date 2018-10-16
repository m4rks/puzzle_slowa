using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzle.Zdania.Model
{
    public abstract class Point : Base
    {
        private int _xPosition;
        private int _yPosition;

        public int X
        {
            get { return _xPosition; }
            set
            {
                _xPosition = value;
                OnPropertyChanged();
            }
        }

        public int Y
        {
            get { return _yPosition; }
            set
            {
                _yPosition = value;
                OnPropertyChanged();
            }
        }
    }
}
