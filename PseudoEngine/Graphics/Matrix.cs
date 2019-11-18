using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.Graphics
{
    public class Matrix
    {

        public double this[int x, int y]
        {
            get { return _matrix[x, y]; }
            set { _matrix[x, y] = value; }
        }

        private double[,] _matrix;

        public Matrix(double[,] matrix)
        {
            _matrix = matrix;
        }
        public Matrix(Matrix matrix)
        {
            _matrix = matrix._matrix;
        }


        public Matrix Clone()
        {
            return new Matrix(this);
        }

        public Matrix Multiply(Matrix matrix)
        {
            if (_matrix.GetLength(1) != matrix._matrix.Length)
                throw new InvalidOperationException("Can't Multiply Matrices, invalid INDEX Length.");

            var result = new double[3,matrix._matrix.GetLength(1)];

            for(var col = 0; col < matrix._matrix.GetLength(1); col++)
            {
                for (var row = 0; row < _matrix.GetLength(0); row++)
                {
                    for (var i = 0; i < matrix._matrix.GetLength(0); i++)
                    {
                        result[row, col] += _matrix[row, i] * matrix._matrix[i, col];
                    }
                }
            }

            _matrix = result;
            return this;
        }

    }
}
