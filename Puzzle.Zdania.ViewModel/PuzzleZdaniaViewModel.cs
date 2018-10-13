using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Puzzle.Zdania.IServices;
using Puzzle.Zdania.MockServices;
using Puzzle.Zdania.Model;


namespace Puzzle.Zdania.ViewModel
{
    public class PuzzleZdaniaViewModel : BaseViewModel
    {
        private readonly ISatzeService satzeService;

        public PuzzleZdaniaViewModel() : this(new MockSatzeService())
        {
        }

        public PuzzleZdaniaViewModel(ISatzeService satzeService)
        {
            this.satzeService = satzeService;

        }
    }
}
