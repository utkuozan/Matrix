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
    public partial class frmInverse : Form
    {
        private Matrix.Library.Matrix _m;

        public frmInverse(Matrix.Library.Matrix m)
        {
            InitializeComponent();
            this._m = m;
        }

        private void frmInverse_Load(object sender, EventArgs e)
        {
            for (int r = 0; r < this._m.Height; r++)
                for (int c = 0; c < this._m.Width; c++)
                {
                    TextBox txtCell = new TextBox();
                    txtCell.Name = string.Format("txt_{0}_{1}", r, c);
                    MatrixElement me = this._m.GetElementAt(r, c);
                    txtCell.Text = string.Format("{0}:{1}", me.Real, me.Imaginary);
                    txtCell.TextAlign = HorizontalAlignment.Center;
                    Font fnt = new Font(new FontFamily("Microsoft Sans Serif"), 10, FontStyle.Bold);
                    txtCell.Font = fnt;
                    txtCell.Width = 75;
                    txtCell.Height = 22;
                    txtCell.Left = 5 + (c * 80);
                    txtCell.Top = 5 + (r * 25);
                    this.Controls.Add(txtCell);
                }
        }
    }
}
