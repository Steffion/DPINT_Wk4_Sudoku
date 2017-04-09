using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SudokuBasis;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;

namespace DPINT_Week4.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        private SudokuGame sudoku;

        public ObservableCollection<ViewLocation> Locations { get; set; }

        public RelayCommand NewGameCommand { get; private set; }
        public RelayCommand CheatCommand { get; private set; }
        public RelayCommand CheckCommand { get; private set; }


        public MainViewModel()
        {
            Locations = new ObservableCollection<ViewLocation>();
            this.sudoku = new SudokuGame();

            this.sudoku.NewGame();

            for (int i = 0; i < 81; i++)
            {

                Position p = new Position()
                {
                    X = (short)((i / 9) + 1),
                    Y = (short)((i % 9) + 1)
                };
                this.sudoku.GetValue(p);
                Locations.Add(new ViewLocation(sudoku, p));
            }

            NewGameCommand = new RelayCommand(NewGame, DummyTrue);
            CheckCommand = new RelayCommand(CheckGame, DummyTrue);
            CheatCommand = new RelayCommand(CheatGame, DummyTrue);
        }

        public bool DummyTrue()
        {
            return true;
        }

        public void NewGame()
        {
            this.sudoku.NewGame();

            for (int i = 0; i < 81; i++)
            {

                Position p = new Position()
                {
                    X = (short)((i / 9) + 1),
                    Y = (short)((i % 9) + 1)
                };
                this.sudoku.GetValue(p);
                Locations[i].Value = p.Value;
            }
        }

        public void CheckGame()
        {
            MessageBox.Show(sudoku.IsValid().ToString());
        }

        public void CheatGame()
        {
            Position pos = sudoku.GetHint();

            //x en y zijn om de een of andere rede omgekeerd
            //MessageBox.Show(pos.X + "=Y;" + pos.Y + "=X: VALUE = " + pos.Value);

            //tel de hoeveelheid die opgelost moet worden
            int unsolvedCount = 0;
            foreach (ViewLocation loc in Locations)
            {
                if (loc.Value == 0)
                {
                    unsolvedCount++;
                }
            }

            //Alles behalve 2 moet opgelost worden
            int solveCount = unsolvedCount - 2;
            for (int x = 0; x < solveCount; x++)
            {
                Position position = sudoku.GetHint();
                ViewLocation loc = Locations.Where(l => l.X == position.X && l.Y == position.Y).First();

                loc.Value = position.Value;
            }

        }
    }
}