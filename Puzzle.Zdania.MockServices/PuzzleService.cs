using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.Zdania.IServices;

namespace Puzzle.Zdania.MockServices
{
    public class PuzzleService : IPuzzleService
    {
        private IList<Model.Puzzle> puzzle;

        public PuzzleService()
        {
            puzzle = new List<Model.Puzzle>
            {
               new Model.Puzzle { IdNum = 1,Order = 1,TextField = "smutny", X = 0, Y = 0},
               new Model.Puzzle { IdNum = 2,Order = 2,TextField = "smutny2", X = 0, Y = 1},
               new Model.Puzzle { IdNum = 3,Order = 3,TextField = "smutny3", X = 1, Y = 1},
               new Model.Puzzle { IdNum = 4,Order = 4,TextField = "smutny4", X = 1, Y = 0},
            };
        }

        public ICollection<Model.Puzzle> Get(string Satze)
        {
            return puzzle;
        }
    }
}
