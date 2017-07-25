using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Library
{
    public class Matrix
    {
        private MatrixElement[,] _innerMatrix;
        public MatrixElement[,] Elements
        {
            get { return this._innerMatrix; }
        }
        public Tuple<int, int> Size
        {
            get
            {
                if (this._innerMatrix != null)
                    return new Tuple<int, int>(this._innerMatrix.GetLength(0), this._innerMatrix.GetLength(1));
                else
                    return new Tuple<int, int>(0, 0);
            }
        }
        public int Width
        {
            get
            {
                if (this._innerMatrix != null)
                    return this._innerMatrix.GetLength(1);
                else
                    return 0;
            }
        }
        public int Height
        {
            get
            {
                if (this._innerMatrix != null)
                    return this._innerMatrix.GetLength(0);
                else
                    return 0;
            }
        }

        public Matrix(int rows, int columns)
        {
            this._innerMatrix = new MatrixElement[rows, columns];
        }
        public void SetElement(MatrixElement element, int rowIndex, int colIndex)
        {
            if (element == null)
                throw new ArgumentException("Matrix element can not be null");
            if (rowIndex < 0)
                throw new ArgumentException("Row index can not be less than zero");
            if (colIndex < 0)
                throw new ArgumentException("Column index can not be less than zero");
            if (rowIndex > this._innerMatrix.GetLength(0))
                throw new ArgumentException(string.Format("Row index can not be greater than the Row Size ({0}) of the Matrix", this._innerMatrix.GetLength(0)));
            if (colIndex > this._innerMatrix.GetLength(1))
                throw new ArgumentException(string.Format("Column index can not be greater than the Column Size ({0}) of the Matrix", this._innerMatrix.GetLength(1)));
            this._innerMatrix[rowIndex, colIndex] = element;
        }
        public void AddRow(int rowIndex, MatrixElement[] row)
        {
            if (row == null || row.Length == 0)
                throw new ArgumentException("Row can not be empty");
            if (row.Length != this.Width)
                throw new ArgumentException("Row size does not match matrix column size");
            if (rowIndex < 0)
                throw new ArgumentException("Row index can not be less than zero");
            if (rowIndex > this.Height)
                throw new ArgumentException("Row index can not exceed row size");
            for (int c = 0; c < this.Width; c++)
                this._innerMatrix[rowIndex, c] = row[c];
        }
        public void AddColumn(int colIndex, MatrixElement[] col)
        {
            if (col == null || col.Length == 0)
                throw new ArgumentException("Column can not be empty");
            if (col.Length != this.Height)
                throw new ArgumentException("Column size does not match matrix row size");
            if (colIndex < 0)
                throw new ArgumentException("Column index can not be less than zero");
            if (colIndex > this.Height)
                throw new ArgumentException("Column index can not exceed column size");
            for (int r = 0; r < this.Height; r++)
                this._innerMatrix[r, colIndex] = col[r];
        }
        public MatrixElement GetElementAt(int rowIndex, int colIndex)
        {
            if (rowIndex < 0)
                throw new ArgumentException("Row index can not be less than zero");
            if (rowIndex > this._innerMatrix.GetLength(1))
                throw new ArgumentException("Row index can not exceed row size");
            if (colIndex < 0)
                throw new ArgumentException("Column index can not be less than zero");
            if (colIndex > this._innerMatrix.GetLength(0))
                throw new ArgumentException("Column index can not exceed column size");

            MatrixElement result = new MatrixElement(this._innerMatrix[rowIndex, colIndex].Real, this._innerMatrix[rowIndex, colIndex].Imaginary);
            return result;
        }
        public MatrixElement[] GetRow(int rowIndex)
        {
            MatrixElement[] result = new MatrixElement[this.Width];
            for (int c = 0; c < this.Width; c++)
                result[c] = this.GetElementAt(rowIndex, c);

            return result;
        }
        public MatrixElement[] GetColumn(int colIndex)
        {
            MatrixElement[] result = new MatrixElement[this.Height];
            for (int r = 0; r < this.Height; r++)
                result[r] = this.GetElementAt(r, colIndex);

            return result;
        }
        public Matrix Transpose()
        {
            Matrix result = new Matrix(this.Width, this.Height);
            for (int r = 0; r < this.Height; r++)
            {
                MatrixElement[] row = this.GetRow(r);
                result.AddColumn(r, row);
            }

            return result;
        }
        public Matrix Cofactor()
        {
            if (this.Width != this.Height)
                throw new ArgumentException("Can not calculate the Cofactor of a non-square matrix");
            Matrix result = new Matrix(this.Height, this.Width);
            for (int r = 0; r < this.Height; r++)
                for (int c = 0; c < this.Width; c++)
                {
                    Matrix sub = this.GetSubMatrix(this, r, c);
                    MatrixElement me = GetDeterminantRecursive(sub);
                    me *= (float)Math.Pow(-1, r + c);
                    result.SetElement(me, r, c);
                }

            return result;
        }

        public Matrix Inverse()
        {
            if (this._innerMatrix.GetLength(0) != this._innerMatrix.GetLength(1))
                throw new InvalidOperationException("Non-square matrices do not have inverses");
            MatrixElement det = this.Determinant();
            if (det.Real == 0 && det.Imaginary == 0)
                throw new Exception("Can not calculate inverse of a zero-determinant matrix");
            Matrix cofactor = this.Cofactor();
            Matrix tCofactor = cofactor.Transpose();
            Matrix result = tCofactor * (1f / det);

            return result;
        }
        public MatrixElement Determinant()
        {
            return this.GetDeterminantRecursive(this);
        }
        internal MatrixElement GetDeterminantRecursive(Matrix matrix)
        {
            if (matrix.Width == 2 && matrix.Height == 2)    //2x2 matrix
                return (matrix.GetElementAt(0, 0) * matrix.GetElementAt(1, 1)) - (matrix.GetElementAt(1, 0) * matrix.GetElementAt(0, 1));
            else
            {
                MatrixElement result = new MatrixElement(0, 0);
                for (int c = 0; c < matrix.Width; c++)
                {
                    MatrixElement me = matrix.GetElementAt(0, c);
                    Matrix subMatrix = GetSubMatrix(matrix, 0, c);
                    float pow = (float)Math.Pow(-1, c);
                    MatrixElement sub = GetDeterminantRecursive(subMatrix);
                    MatrixElement subResult = me * pow * sub;
                    result += subResult;
                    //result += (me * (float)Math.Pow(-1, c) * GetDeterminantRecursive(subMatrix));
                }

                return result;
            }
        }
        internal Matrix GetSubMatrix(Matrix matrix, int rowIndex, int colIndex)
        {
            if (matrix == null || matrix.Width == 0 || matrix.Height == 0)
                throw new ArgumentException("Matrix can not be null");
            if (rowIndex < 0)
                throw new ArgumentException("Row index can not be less than zero");
            if (rowIndex > matrix.Height)
                throw new ArgumentException("Row index can not exceed row size");
            if (colIndex < 0)
                throw new ArgumentException("Column index can not be less than zero");
            if (colIndex > matrix.Width)
                throw new ArgumentException("Column index can not exceed column size");
            Matrix result = new Matrix(matrix.Height - 1, matrix.Width - 1);
            int ri = 0;
            int ci = 0;
            for (int r = 0; r < matrix.Height; r++)
            {
                for (int c = 0; c < matrix.Width; c++)
                {
                    if (r != rowIndex && c != colIndex)
                    {
                        result.SetElement(matrix.GetElementAt(r, c), ri, ci);
                        ci++;
                        if (ci == result.Width)
                        {
                            ci = 0;
                            ri++;
                        }
                    }
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix matrix, MatrixElement me)
        {
            if (matrix == null)
                throw new ArgumentException("Matrix can not be null");
            if (me == null)
                throw new ArgumentException("Matrix element can not be null");
            for (int r = 0; r < matrix.Height; r++)
                for (int c = 0; c < matrix.Width; c++)
                    matrix.SetElement(matrix.GetElementAt(r, c) * me, r, c);

            return matrix;
        }
        public static Matrix operator *(MatrixElement me, Matrix matrix)
        {
            return matrix * me;
        }
        public static Matrix operator *(Matrix matrix, float a)
        {
            if (matrix == null)
                throw new ArgumentException("Matrix can not be null");
            for (int r = 0; r < matrix.Height; r++)
                for (int c = 0; c < matrix.Width; c++)
                    matrix.SetElement(matrix.GetElementAt(r, c) * a, r, c);

            return matrix;
        }
        public static Matrix operator *(float a, Matrix matrix)
        {
            return matrix * a;
        }
    }
}
