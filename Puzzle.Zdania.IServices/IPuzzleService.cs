using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.Zdania.Model;

namespace Puzzle.Zdania.IServices
{
    public interface IPuzzleService
    {
        ICollection<Model.Puzzle> Get(string Satze);
    }
}
