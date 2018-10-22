using System;
using System.Collections.Generic;
using System.IO;
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
        #region Fields
        private TimerService _timer;
        private readonly ISatzeService satzeService;
        private readonly IPuzzleService puzzleService;
        #endregion

        #region Private Methods

        private void Load()
        {
            Satz = satzeService.Get(1);
            Puzzles = puzzleService.Get(Satz.SatzMitSemikolon);
            SourceUri = GenerateSourceUri(Satz.Bild);
        }

        private string GenerateSourceUri(string nameOfImages)
        {

            String exePath = System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
            string dir = Path.GetDirectoryName(exePath) + "\\Images\\" + nameOfImages;
            return dir;

        }
        #endregion

        #region Property
        private string _sourceUri;
        
        public string SourceUri
        {
            get { return _sourceUri; }
            set { _sourceUri = value; OnPropertyChanged(); }
        }

        private Satz _satz;
        public Satz Satz
        {
            get { return _satz; }
            set
            {
                _satz = value;
                OnPropertyChanged();
            }
        }

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
            if (tick % 12 == 0)
            {
                int numberOfCurrentlyTask = Satz.Idnum;
                Satz = satzeService.Get(numberOfCurrentlyTask++);
                Puzzles = puzzleService.Get(Satz.SatzMitSemikolon);
                SourceUri = GenerateSourceUri(Satz.Bild);
            }
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

        #region Commands

        

        #endregion

    }

}
