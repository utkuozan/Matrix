using Matrix.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Matrix.Library.Matrix m = new Library.Matrix(4, 4);
            //m.AddRow(0, new MatrixElement[4]
            //{
            //    new MatrixElement(3,0), new MatrixElement(0,0), new MatrixElement(2,0), new MatrixElement(-1,0)
            //});
            //m.AddRow(1, new MatrixElement[4]
            //{
            //    new MatrixElement(1,0), new MatrixElement(2,0), new MatrixElement(0,0), new MatrixElement(-2,0)
            //});
            //m.AddRow(2, new MatrixElement[4]
            //{
            //    new MatrixElement(4,0), new MatrixElement(0,0), new MatrixElement(6,0), new MatrixElement(-3,0)
            //});
            //m.AddRow(3, new MatrixElement[4]
            //{
            //    new MatrixElement(5,0), new MatrixElement(0,0), new MatrixElement(2,0), new MatrixElement(0,0)
            //});
            //Matrix.Library.Matrix im = m.GetSubMatrix(m, 0, 0);


            //Matrix.Library.Matrix m = new Library.Matrix(3, 3);
            //m.AddRow(0, new MatrixElement[3]
            //{
            //    new MatrixElement(5,0), new MatrixElement(3,0), new MatrixElement(7,0)
            //});
            //m.AddRow(1, new MatrixElement[3]
            //{
            //    new MatrixElement(2,0), new MatrixElement(4,0), new MatrixElement(9,0)
            //});
            //m.AddRow(2, new MatrixElement[3]
            //{
            //    new MatrixElement(3,0), new MatrixElement(6,0), new MatrixElement(4,0)
            //});



            //Matrix.Library.Matrix m = new Library.Matrix(5, 5);
            //m.AddRow(0, new MatrixElement[5]
            //{
            //    new MatrixElement(3,0), new MatrixElement(0,0), new MatrixElement(0,0), new MatrixElement(3,0), new MatrixElement(0,0)
            //});
            //m.AddRow(1, new MatrixElement[5]
            //{
            //    new MatrixElement(-3,0), new MatrixElement(0,0), new MatrixElement(-2,0), new MatrixElement(0,0), new MatrixElement(0,0)
            //});
            //m.AddRow(2, new MatrixElement[5]
            //{
            //    new MatrixElement(0,0), new MatrixElement(-1,0), new MatrixElement(0,0), new MatrixElement(0,0), new MatrixElement(-3,0)
            //});
            //m.AddRow(3, new MatrixElement[5]
            //{
            //    new MatrixElement(0,0), new MatrixElement(0,0), new MatrixElement(0,0), new MatrixElement(3,0), new MatrixElement(3,0)
            //});
            //m.AddRow(4, new MatrixElement[5]
            //{
            //    new MatrixElement(0,0), new MatrixElement(-1,0), new MatrixElement(2,0), new MatrixElement(0,0), new MatrixElement(0,0)
            //});


            //Matrix.Library.Matrix m = new Library.Matrix(4, 4);
            //m.AddRow(0, new MatrixElement[4]
            //{
            //    new MatrixElement(0,0), new MatrixElement(-2,0), new MatrixElement(3,0), new MatrixElement(0,0)
            //});
            //m.AddRow(1, new MatrixElement[4]
            //{
            //    new MatrixElement(-1,0), new MatrixElement(0,0), new MatrixElement(0,0), new MatrixElement(-3,0)
            //});
            //m.AddRow(2, new MatrixElement[4]
            //{
            //    new MatrixElement(0,0), new MatrixElement(-2,0), new MatrixElement(0,0), new MatrixElement(-3,0)
            //});
            //m.AddRow(3, new MatrixElement[4]
            //{
            //    new MatrixElement(-1,0), new MatrixElement(2,0), new MatrixElement(0,0), new MatrixElement(0,0)
            //});


            //Matrix.Library.Matrix m = new Library.Matrix(5, 5);
            //m.AddRow(0, new MatrixElement[5]
            //{
            //    new MatrixElement(0,0), new MatrixElement(6,0), new MatrixElement(-2,0), new MatrixElement(-1,0), new MatrixElement(5,0)
            //});
            //m.AddRow(1, new MatrixElement[5]
            //{
            //    new MatrixElement(0,0), new MatrixElement(0,0), new MatrixElement(0,0), new MatrixElement(-9,0), new MatrixElement(-7,0)
            //});
            //m.AddRow(2, new MatrixElement[5]
            //{
            //    new MatrixElement(0,0), new MatrixElement(15,0), new MatrixElement(35,0), new MatrixElement(0,0), new MatrixElement(0,0)
            //});
            //m.AddRow(3, new MatrixElement[5]
            //{
            //    new MatrixElement(0,0), new MatrixElement(-1,0), new MatrixElement(-11,0), new MatrixElement(-2,0), new MatrixElement(1,0)
            //});
            //m.AddRow(4, new MatrixElement[5]
            //{
            //    new MatrixElement(-2,0), new MatrixElement(-2,0), new MatrixElement(3,0), new MatrixElement(0,0), new MatrixElement(-2,0)
            //});


            //Matrix.Library.Matrix m = new Library.Matrix(2, 3);
            //m.AddRow(0, new MatrixElement[3]
            //{
            //    new MatrixElement(1,0), new MatrixElement(2,0), new MatrixElement(3,0)
            //});
            //m.AddRow(1, new MatrixElement[3]
            //{
            //    new MatrixElement(4,0), new MatrixElement(5,0), new MatrixElement(6,0)
            //});


            //Matrix.Library.Matrix m = new Library.Matrix(4, 4);
            //m.AddRow(0, new MatrixElement[4]
            //{
            //    new MatrixElement(1,0), new MatrixElement(4,0), new MatrixElement(-1,0), new MatrixElement(0,0)
            //});
            //m.AddRow(1, new MatrixElement[4]
            //{
            //    new MatrixElement(2,0), new MatrixElement(3,0), new MatrixElement(5,0), new MatrixElement(-2,0)
            //});
            //m.AddRow(2, new MatrixElement[4]
            //{
            //    new MatrixElement(0,0), new MatrixElement(3,0), new MatrixElement(1,0), new MatrixElement(6,0)
            //});
            //m.AddRow(3, new MatrixElement[4]
            //{
            //    new MatrixElement(3,0), new MatrixElement(0,0), new MatrixElement(2,0), new MatrixElement(1,0)
            //});


            Matrix.Library.Matrix m = new Library.Matrix(3, 3);
            m.AddRow(0, new MatrixElement[3]
            {
                new MatrixElement(3,0), new MatrixElement(0,0), new MatrixElement(2,0)
            });
            m.AddRow(1, new MatrixElement[3]
            {
                new MatrixElement(2,0), new MatrixElement(0,0), new MatrixElement(-2,0)
            });
            m.AddRow(2, new MatrixElement[3]
            {
                new MatrixElement(0,0), new MatrixElement(1,0), new MatrixElement(1,0)
            });

            Matrix.Library.Matrix inv = m.Inverse();

            //MatrixElement me = m.Determinant();
            //Matrix.Library.Matrix t = m.Transpose();
            //Matrix.Library.Matrix t = m.Cofactor();
        }
    }



}
