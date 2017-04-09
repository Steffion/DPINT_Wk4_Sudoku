using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuBasis
{
    public class Position
    {
        public short X { get; set; }

        public short Y { get; set; }

        public short Value { get; set; }

        public Position()
        {
            X = -1;
            Y = -1;
            Value = -1;
        }
    }
}
