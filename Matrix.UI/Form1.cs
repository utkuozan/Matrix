using Matrix.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix.UI
{
    public partial class Form1 : Form
    {
        private int _rowCount = 0;
        private int _colCount = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateMatrixGrid();
        }
        private void matrixSize_ValueChanged(object sender, EventArgs e)
        {
            UpdateMatrixGrid();
        }
        private void UpdateMatrixGrid()
        {
            this._rowCount = (int)txtRows.Value;
            this._colCount = (int)txtCols.Value;
            pnlMain.Controls.Clear();
            for (int r = 0; r < this._rowCount; r++)
                for (int c = 0; c < this._colCount; c++)
                {
                    TextBox txtCell = new TextBox();
                    txtCell.Name = string.Format("txt_{0}_{1}", r, c);
                    txtCell.Text = "0:0";
                    txtCell.TextAlign = HorizontalAlignment.Center;
                    Font fnt = new Font(new FontFamily("Microsoft Sans Serif"), 10, FontStyle.Bold);
                    txtCell.Font = fnt;
                    txtCell.Width = 75;
                    txtCell.Height = 22;
                    txtCell.Left = 10 + (c * 80);
                    txtCell.Top = 10 + (r * 25);
                    pnlMain.Controls.Add(txtCell);
                }
        }
        private void btnInverse_Click(object sender, EventArgs e)
        {
            Matrix.Library.Matrix m = new Library.Matrix(this._rowCount, this._colCount);
            for (int r = 0; r < this._rowCount; r++)
            {
                MatrixElement[] marr = new MatrixElement[this._colCount];
                for (int c = 0; c < this._colCount; c++)
                {
                    TextBox txtCell = pnlMain.Controls[string.Format("txt_{0}_{1}", r, c)] as TextBox;
                    if (txtCell != null)
                        marr[c] = new MatrixElement(txtCell.Text);
                }
                m.AddRow(r, marr);
            }
            Matrix.Library.Matrix i = m.Inverse();
            frmInverse frmI = new frmInverse(i);
            frmI.ShowDialog();
        }
    }
}
