using SudokuBasis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SudokuGame game = new SudokuGame();
            game.NewGame();

            foreach (Position p in game.GetBoard())
            {
                Console.WriteLine(p.Value);
            }
            Console.ReadLine();
        }
    }
}
