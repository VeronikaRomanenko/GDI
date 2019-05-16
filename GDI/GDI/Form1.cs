using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            SizeChanged += Form1_SizeChanged;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Использование класса Pen
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Brushes.Coral, 10);
            pen.DashStyle = DashStyle.Dot;
            graphics.DrawEllipse(pen, 50, 70, 170, 100);
            //Пример использования кистей Brush
            Rectangle rect1 = new Rectangle(50, 170, 300, 80);
            Rectangle rect2 = new Rectangle(50, 270, 300, 80);
            Rectangle rect3 = new Rectangle(50, 370, 300, 80);
            Rectangle rect4 = new Rectangle(270, 50, 300, 80);

            LinearGradientBrush linearGradientBrush =
                new LinearGradientBrush(rect1, Color.Red, Color.Green, 0.0f, true);
            HatchBrush hatchBrush =
                new HatchBrush(HatchStyle.Cross, Color.Coral);
            TextureBrush textureBrush = new TextureBrush(Image.FromFile(""));//путь к файлу
            SolidBrush solidBrush = new SolidBrush(Color.Azure);

            graphics.FillRectangle(linearGradientBrush, rect1);
            graphics.FillRectangle(hatchBrush, rect2);
            graphics.FillRectangle(textureBrush, rect3);
            graphics.FillRectangle(solidBrush, rect4);

            //Шрифты и класс Font
            Font font1 = new Font("Vardana", 12);
            Font font2 = new Font("Vardana", 12, FontStyle.Bold);
            Font font3 = new Font("Vardana", 12, FontStyle.Bold | FontStyle.Italic);
            graphics.DrawString("Это не палка, это пайп!!", font3, linearGradientBrush, 370, 150);
            //Работа с изображением
            Image image = Image.FromFile("");//путь к файлу
            graphics.DrawImage(image, this.ClientRectangle);

            //Зачистка
            graphics.Dispose();
        }
    }
}