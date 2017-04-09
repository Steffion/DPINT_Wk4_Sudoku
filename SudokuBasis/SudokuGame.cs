using Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuBasis
{
    public class SudokuGame
    {
        private IGame game;

        public SudokuGame()
        {
            game = new Game();
        }

        public void NewGame()
        {
            game.create();
        }

        public bool SetValue(Position position)
        {
            int success;
            game.set(position.X, position.Y, position.Value, out success);
            return success == 1;
        }

        public void GetValue(Position position)
        {
            short val;
            game.get(position.X, position.Y, out val);
            position.Value = val;
        }

        public bool IsValid()
        {
            int isValid;
            game.isValid(out isValid);
            return isValid == 1;
        }

        public bool IsCompleted()
        {
            if (!IsValid())
            {
                return false;
            }
            int count = 0;
            foreach (Position p in GetBoard())
            {
                if (p.Value > 0)
                {
                    count++;
                }
            }
            return count == 81;
        }

        public bool Read()
        {
            int succeeded;
            game.read(out succeeded);
            return succeeded == 1;
        }

        public List<Position> GetBoard()
        {
            List<Position> positions = new List<Position>(81);
            for (short x = 1; x <= 9; x++)
            {
                for (short y = 1; y <= 9; y++)
                {
                    Position p = new Position()
                    {
                        X = x,
                        Y = y
                    };
                    positions.Add(p);
                    GetValue(p);
                }
            }
            return positions;
        }

        public bool Write()
        {
            int succeeded;
            game.write(out succeeded);
            return succeeded == 1;
        }

        public Position GetHint() {
            short x;
            short y;
            short value;
            int succeeded;

            game.hint(out x, out y, out value, out succeeded);

            if (succeeded != 1)
            {
                return null;
            }

            return new Position()
            {
                X = x,
                Y = y,
                Value = value
            };
        }
    }
}
