using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Library
{
    public class MatrixElement
    {
        public float Real { get; set; }
        public float Imaginary { get; set; }

        public MatrixElement(float real, float imaginary)
        {
            this.Real = real;
            this.Imaginary = imaginary;
        }
        public MatrixElement(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Invalid (empty) element");
            if (value.IndexOf(':') == -1)
                this.Real = float.Parse(value);
            else
            {
                string[] sarr = value.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (sarr.Length != 2)
                    throw new ArgumentException("Invalid complex number definition");
                this.Real = float.Parse(sarr[0]);
                this.Imaginary = float.Parse(sarr[1]);
            }
        }
        public MatrixElement Conjugate()
        {
            MatrixElement result = new MatrixElement(this.Real, -1 * this.Imaginary);

            return result;
        }
        public float AbsoluteValue()
        {
            return (float)Math.Sqrt(this.Real * this.Real + this.Imaginary * this.Imaginary);
        }
        public override string ToString()
        {
            return string.Format("{0} + {1}i", this.Real, this.Imaginary);
        }

        public static MatrixElement operator *(MatrixElement a, MatrixElement b)
        {
            if (a == null)
                throw new ArgumentException("First matrix element can not be null");
            if (b == null)
                throw new ArgumentException("Second matrix element can not be null");
            MatrixElement result = new MatrixElement(0, 0);
            result.Real = (a.Real * b.Real) - (a.Imaginary * b.Imaginary);
            result.Imaginary = (a.Real * b.Imaginary) + (a.Imaginary * b.Real);

            return result;
        }
        public static MatrixElement operator *(MatrixElement a, float b)
        {
            if (a == null)
                throw new ArgumentException("Matrix element can not be null");
            a.Real *= b;
            a.Imaginary *= b;

            return a;
        }
        public static MatrixElement operator /(MatrixElement a, MatrixElement b)
        {
            if (a == null)
                throw new ArgumentException("First matrix element can not be null");
            if (b == null)
                throw new ArgumentException("Second matrix element can not be null");
            MatrixElement nominator = a * b.Conjugate();
            MatrixElement denominator = b * b.Conjugate();
            float denom = denominator.AbsoluteValue();

            return nominator / denom;
        }
        public static MatrixElement operator /(MatrixElement a, float b)
        {
            if (a == null)
                throw new ArgumentException("Matrix element can not be null");
            if (b == 0)
                throw new DivideByZeroException("Divident can not be zero");
            a.Real /= b;
            a.Imaginary /= b;

            return a;
        }
        public static MatrixElement operator /(float a, MatrixElement b)
        {
            if (b == null)
                throw new ArgumentException("Matrix element can not be null");
            if (a == 0)
                return new MatrixElement(0, 0);
            MatrixElement _a = new MatrixElement(a, 0);

            return _a / b;
        }
        public static MatrixElement operator +(MatrixElement a, MatrixElement b)
        {
            if (a == null)
                throw new ArgumentException("First matrix element can not be null");
            if (b == null)
                throw new ArgumentException("Second matrix element can not be null");

            return new MatrixElement(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }
        public static MatrixElement operator -(MatrixElement a, MatrixElement b)
        {
            if (a == null)
                throw new ArgumentException("First matrix element can not be null");
            if (b == null)
                throw new ArgumentException("Second matrix element can not be null");
            b *= -1;
            return new MatrixElement(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }
    }
}
