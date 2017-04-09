using SudokuBasis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DPINT_Week4.ViewModel
{
    public class ViewLocation : INotifyPropertyChanged
    {
        private SudokuGame game;
        private Position position;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewLocation(SudokuGame game, Position position)
        {
            this.game = game;
            this.position = position;
        }
        public short Value
        {
            get
            {
                return this.position.Value;
            }
            set
            {
                this.position.Value = value;
                this.game.SetValue(position);
                if (this.game.IsCompleted())
                {
                    MessageBoxResult result = MessageBox.Show("U heeft de sudoku opgelost.", "Gefeliciteerd!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    
                }
                OnPropertyChanged();
            }
        }

        public short X
        {
            get
            {
                return this.position.X;
            }
            set
            {
                ;
            }
        }

        public short Y
        {
            get
            {
                return this.position.Y;
            }
            set
            {
                ;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
