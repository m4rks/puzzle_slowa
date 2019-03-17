using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using MvvmDialogs;
using Puzzle.Zdania.Common4;
using Puzzle.Zdania.IServices;
using Puzzle.Zdania.MockServices;
using Puzzle.Zdania.Model;
using TimerService = Puzzle.Zdania.MockServices.TimerService;


namespace Puzzle.Zdania.ViewModels
{

    public class PuzzleZdaniaViewModel : BaseViewModel
    {
        #region Fields
        private TimerService _timer;
        private readonly ISatzeService satzeService;
        private readonly IPuzzleService puzzleService;
        private readonly IDialogService dialogService;
        #endregion

        #region Private Methods

        private void Load()
        {
            Satz = satzeService.Get(1);
            Puzzles = puzzleService.Get(Satz.SatzMitSemikolon);
            //       SourceUri = GenerateSourceUri(Satz.Bild);

        }

        private string GenerateSourceUri(string nameOfImages)
        {
            String exePath = System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
            string dir = Path.GetDirectoryName(exePath) + "\\Images\\" + nameOfImages;
            return dir;
        }

        void SetzeDieNachsteAufgabe(int numberOfNextTask)
        {
            Satz = satzeService.Get(numberOfNextTask);
            Puzzles = puzzleService.Get(Satz.SatzMitSemikolon);
        }
        #endregion

        #region Public Property / Command
        private string _sourceUri;

        public string SourceUri
        {
            get { return _sourceUri; }
            set
            {
                _sourceUri = value;
                OnPropertyChanged();
            }
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



        private void GetAnswer(object parameter)
        {
            //Segment segment = parameter as Satz;
            string antwort = (string)parameter;
            if (antwort == Satz.Antwort)
            {
                int numberOfCurrentlyTask = Satz.Idnum + 1;
                if (numberOfCurrentlyTask <= satzeService.Count())
                { SetzeDieNachsteAufgabe(numberOfCurrentlyTask); }
                else
                {
                    dialogService.ShowMessageBox(this, "KONIEC - powiedz SKOŃCZYŁEM!");
                    Application.Current.Shutdown();
                }
            }
            else
            {
                Trace.WriteLine("ng");
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
            if (tick % 4 == 0 && tick > 2)
            {
                //SetzeDieNachsteAufgabe();
            }
        }
        #endregion

        #region Constructor

        public PuzzleZdaniaViewModel() : this(new MockSatzeService(), new PuzzleService(), new DialogService())
        {
        }

        public PuzzleZdaniaViewModel(ISatzeService satzeService, IPuzzleService puzzleService, IDialogService dialogService)
        {
            InitializeServices();
            _timer.RunServiceAsync(); //todo on command 
            this.satzeService = satzeService;
            this.puzzleService = puzzleService;
            this.dialogService = dialogService;
            Load();

        }

        #endregion

        #region Commands
        public ICommand GetAnswerCommand
        {
            get
            {
                return new RelayCommand(p=>GetAnswer(p));
            }
        }


        #endregion

        public ICommand FireCommand { get; set; }

        private void FireMissile(Object obj)
        {
            Debug.WriteLine("fire");


        }

        private void CloseWindow(IClosable window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
    }

    public class RelayCommand2 : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand2(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }


    public interface IClosable
    {
        void Close();
    }
}
