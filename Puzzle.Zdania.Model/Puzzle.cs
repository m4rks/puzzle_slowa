using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzle.Zdania.Model
{
    public class Puzzle : Point
    {
        private int _idNum;
        public int IdNum
        {
            get { return _idNum; }
            set { _idNum = value; }
        }

        private string _textField;
        public string TextField
        {
            get { return _textField; }
            set { _textField = value; }
        }

        private int _order;

        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }
    }
}