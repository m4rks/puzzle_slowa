using System;
using Puzzle.Zdania.Model;

namespace Puzzle.Zdania.IServices
{
    public interface ISatzeService
    {
        Satz GetFile(string NameOfTask);
        Satz GetNextTask(int numberOfNextTask);

        int Count();

    }
}
