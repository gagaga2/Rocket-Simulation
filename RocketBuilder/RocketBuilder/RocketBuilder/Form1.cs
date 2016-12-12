using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RocketBuilder
{
    public partial class Form1 : Form
    {
        int RocketPosition = 0;
        double altitude = 0;
        double mass = 1;
        double fuel = 1;
        double rocketBaseWidth;
        double rocketHeight;
        double rocketEfficency;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void UpdatePreview(int degree)
        {
            RocketPosition = degree;
            tbxPosition.Text = degree.ToString();
            if (degree <= 360)
            {
                trbPosition.Value = degree;
            }
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
            graphics.FillEllipse(Brushes.Green, earthRectangle);
            graphics.FillEllipse(Brushes.White, positionRectangle);
        }

        private void trbPosition_Scroll(object sender, EventArgs e)
        {
            UpdatePreview(trbPosition.Value);
        }

        
        private void tbxPosition_ValueChanged(object sender, EventArgs e)
        {
            
            UpdatePreview(decimal.ToInt32(tbxPosition.Value));
        }

        private void tbxAltitude_ValueChanged(object sender, EventArgs e)
        {
            altitude = decimal.ToDouble(tbxAltitude.Value);
        }

        private void tbxHeight_ValueChanged(object sender, EventArgs e)
        {
            rocketHeight = decimal.ToDouble(tbxHeight.Value);
        }

        private void tbxWidth_ValueChanged(object sender, EventArgs e)
        {
            rocketBaseWidth = decimal.ToDouble(tbxWidth.Value);
        }

        private void tbxEfficiency_ValueChanged(object sender, EventArgs e)
        {
            rocketEfficency = decimal.ToDouble(tbxEfficiency.Value);
            //https://en.wikipedia.org/wiki/Specific_impulse ??
        }

        private void tbxFuel_ValueChanged(object sender, EventArgs e)
        {
            fuel = decimal.ToDouble(tbxFuel.Value);
            mass = Math.Round(fuel * 1.15f);
            lblTotalMass.Text = mass.ToString();
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {

            //area av en kon.
            double area = Math.PI * (rocketBaseWidth / 2) * ((rocketBaseWidth / 2) + Math.Sqrt(Math.Pow(rocketHeight, 2) + Math.Pow((rocketBaseWidth / 2), 2)));

            //gör en parameter-string med alla värden som ska skickas med till Rocket.exe
            string args = " " + RocketPosition.ToString() +
                          " " + altitude.ToString() +
                          " " + fuel.ToString() +
                          " " + mass.ToString() +
                          " " + rocketEfficency.ToString() +
                          " " + area.ToString();


            //Gå till den högsta mappen och hitta sedan vägen till rocket.exe
            string currentDir = Environment.CurrentDirectory.ToString();
            currentDir = Directory.GetParent(currentDir).FullName;
            currentDir = Directory.GetParent(currentDir).FullName;
            currentDir = Directory.GetParent(currentDir).FullName;
            currentDir = Directory.GetParent(currentDir).FullName;
            currentDir = Directory.GetParent(currentDir).FullName;

            string rocketexePath = Directory.GetFiles(currentDir, "rocket.exe", SearchOption.AllDirectories).FirstOrDefault();
            
            if(rocketexePath == null)
            {
                Console.WriteLine("Kan inte hitta rocket");
            }
            else
            {
                Console.WriteLine(rocketexePath + " error");
                //starta rocket.exe med parametrarna
                var proc = System.Diagnostics.Process.Start(rocketexePath, args);
            }
        }
    }
}
