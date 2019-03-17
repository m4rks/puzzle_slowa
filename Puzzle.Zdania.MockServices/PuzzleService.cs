using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Puzzle.Zdania.IServices;
using Puzzle = Puzzle.Zdania.Model.Puzzle;

namespace Puzzle.Zdania.MockServices
{
    public class PuzzleService : IPuzzleService
    {
        private IList<Model.Puzzle> puzzle;

        public PuzzleService()
        {
        }
        public ICollection<Model.Puzzle> Get(string Satze)
        {
            int i = 0;
            puzzle = new List<Model.Puzzle>();  //Liste der Elemente
            var list = new List<int> { 0, 1, 2, 3 };   //der schlechteste Code 
            var result = GetPermutations(list, 2);
            Random rnd = new Random();
            var randomList = result.OrderBy(x => rnd.Next()).Take(list.Count());
            
            foreach (string satz in Satze.Split(';'))
            {
                puzzle.Add(new Model.Puzzle() { IdNum = i, Order = i, TextField = satz, X = randomList.ElementAt(i).ElementAt(0), Y = randomList.ElementAt(i).ElementAt(1) });
                i++;
            }
            return puzzle;
        }
        #region Private Methods



        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations(items.Skip(i), count - 1))
                        yield return new T[] { item }.Concat(result);
                }

                ++i;
            }
        }

        #endregion

    }
}
