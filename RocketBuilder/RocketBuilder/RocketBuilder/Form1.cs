using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RocketBuilder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void btn1_Click(object sender, EventArgs e)
        {

        }

        private void UpdatePreview(int degree)
        {
            tbxPosition.Text = degree.ToString();
            trbPosition.Value = degree;

            double radians = degree * (Math.PI / 180);
            int earthRadian = 50;
            int positionRadian = 5;
            int heightOverSea = 25;

            Point pbxCenter = new Point((pbxPreview.Width / 2), (pbxPreview.Height / 2));
            Graphics graphics = pbxPreview.CreateGraphics();

            Rectangle earthRectangle = new Rectangle(pbxCenter.X - (earthRadian / 2),
                                                     pbxCenter.Y - (earthRadian / 2),
                                                     earthRadian,
                                                     earthRadian);

            Rectangle positionRectangle = new Rectangle(pbxCenter.X - (positionRadian / 2) + (int)(Math.Cos(radians) * heightOverSea),
                                                        pbxCenter.Y - (positionRadian / 2) - (int)(Math.Sin(radians) * heightOverSea),
                                                        positionRadian,
                                                        positionRadian);

            pbxPreview.Refresh();
            graphics.FillEllipse(Brushes.Black, earthRectangle);
            graphics.FillEllipse(Brushes.Red, positionRectangle);
        }

        private void trbPosition_Scroll(object sender, EventArgs e)
        {
            UpdatePreview(trbPosition.Value);
        }

        private void tbxPosition_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            bool tryParseText = int.TryParse(tbxPosition.Text, out value);
            UpdatePreview(value);
        }

        private void tbxHeight_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            bool tryParseText = int.TryParse(tbxPosition.Text, out value);
            UpdatePreview(value);
        }
    }
}
