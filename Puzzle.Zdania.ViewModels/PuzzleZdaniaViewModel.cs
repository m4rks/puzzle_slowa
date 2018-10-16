using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Puzzle.Zdania.IServices;
using Puzzle.Zdania.MockServices;
using Puzzle.Zdania.Model;
using ServicesSample.Services;
using TimerService = Puzzle.Zdania.MockServices.TimerService;


namespace Puzzle.Zdania.ViewModels
{
    public class PuzzleZdaniaViewModel : BaseViewModel
    {
        #region Members
        private TimerService _timer;
        private readonly ISatzeService satzeService;
        private readonly IPuzzleService puzzleService;
        #endregion

        #region Private Methods
        private void Load()
        {
            Satz = satzeService.Get(1);
            Puzzles = puzzleService.Get(Satz.SatzMitSemikolon);
            Puzzles2 = new List<Model.Puzzle> { new Model.Puzzle { IdNum = 1, Order = 1, TextField = "ds", X = 0, Y = 0 } };
        }
        #endregion

        #region Property
        public Satz Satz { get; set; }

        private IList<Model.Puzzle> puzzles2;
        public List<Model.Puzzle> Puzzles2 { get; set; }

        private ICollection<Model.Puzzle> puzzles;
        public ICollection<Model.Puzzle> Puzzles
        {
            get
            {
                return puzzles;
            }
            set
            {
                puzzles = value;
                OnPropertyChanged();
            }
        }

        public bool myVisibility
        {
            get { return false; }
        }

        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }

            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged("Message");
                }
            }
        }

        #endregion

        #region InitializeServices
        private void InitializeServices()
        {
            _timer = new TimerService();
            _timer.SleepTime = 1000;//1s
            _timer.Tick += _timer_Tick;
        }

        void _timer_Tick(object sender, int tick)
        {
            Message = string.Format("Tick #{0}", tick);
        }
        #endregion
 
        #region Constructor

        public PuzzleZdaniaViewModel() : this(new MockSatzeService(), new PuzzleService())
        {
        }

        public PuzzleZdaniaViewModel(ISatzeService satzeService, IPuzzleService puzzleService)
        {
            InitializeServices();
            _timer.RunServiceAsync(); //todo on command 
            this.satzeService = satzeService;
            this.puzzleService = puzzleService;
            Load();
        }
        #endregion
    }

}
