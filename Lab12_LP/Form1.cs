using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab12_LP
{
    public partial class Form1 : Form
    {
        public enum ColorPart
        {
            Red,
            Green,
            Blue,
            Gray
        }

        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
        }
        public int[,] ToByte(Image img, ColorPart part)
        {
            var bmp = new Bitmap(img);
            var mass = new int[bmp.Width, bmp.Height];
            for (var j = 0; j < img.Height; j++)
            {
                for (var i = 0; i < img.Width; i++)
                {
                    switch (part)
                    {
                        case ColorPart.Red:
                            mass[i, j] = bmp.GetPixel(i, j).R;
                            break;
                        case ColorPart.Green:
                            mass[i, j] = bmp.GetPixel(i, j).G;
                            break;
                        case ColorPart.Blue:
                            mass[i, j] = bmp.GetPixel(i, j).B;
                            break;
                        case ColorPart.Gray:
                            mass[i, j] = (bmp.GetPixel(i, j).R + bmp.GetPixel(i, j).G + bmp.GetPixel(i, j).B) / 3;
                            break;
                    }
                }
            }
            return mass;
        }

        public Image ToImage1(int[,] img, ColorPart part)
        {
            var bmp = new Bitmap(img.GetLength(0), img.GetLength(1));
            for (var j = 0; j < bmp.Height/2; j++)
            {
                for (var i = 0; i < bmp.Width/2; i++)
                {
                    switch (part)
                    {
                        case ColorPart.Red:
                            bmp.SetPixel(i, j, Color.FromArgb(img[i, j], 0, 0));
                            break;
                    }
                }
            }
            return bmp;
        }
        public Image ToImage2(int[,] img, ColorPart part)
        {
            var bmp = new Bitmap(img.GetLength(0), img.GetLength(1));
            for (var j = bmp.Height/2; j < bmp.Height; j++)
            {
                for (var i = 0; i < bmp.Width/2; i++)
                {
                    switch (part)
                    {                        
                        case ColorPart.Green:
                            bmp.SetPixel(i, j, Color.FromArgb(0, img[i, j], 0));
                            break;
                    }
                }
            }
            return bmp;
        }
        public Image ToImage3(int[,] img, ColorPart part)
        {
            var bmp = new Bitmap(img.GetLength(0), img.GetLength(1));
            for (var j = 0; j < bmp.Height/2; j++)
            {
                for (var i = bmp.Width / 2; i < bmp.Width; i++)
                {
                    switch (part)
                    {                   
                        case ColorPart.Blue:
                            bmp.SetPixel(i, j, Color.FromArgb(0, 0, img[i, j]));
                            break;

                    }
                }
            }
            return bmp;
        }
        public Image ToImage4(int[,] img, ColorPart part)
        {
            var bmp = new Bitmap(img.GetLength(0), img.GetLength(1));
            for (var j = bmp.Height / 2; j < bmp.Height; j++)
            {
                for (var i = bmp.Width/2; i < bmp.Width; i++)
                {
                    switch (part)
                    {

                        case ColorPart.Gray:
                            var value = img[i, j];
                            bmp.SetPixel(i, j, Color.FromArgb(value, value, value));
                            break;
                    }
                }
            }
            return bmp;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Когда выберите картинку, нужно будет немного подождать. Хотя, если ПК мощный, ждать не нужно)");
            label1.Text = "Изначальная картинка";
            label2.Text = "Канал R";
            label3.Text = "Канал G";
            label4.Text = "Канал B";
            label5.Text = "Градации серого";
            // Описываем объект класса OpenFileDialog 
            OpenFileDialog dialog = new OpenFileDialog();
            // Задаем расширения файлов 
            dialog.Filter = "Image files (*.BMP, *.JPG, " + "*.GIF, *.PNG)|*.bmp;*.jpg;*.gif;*.png";
            // Вызываем диалог и проверяем выбран ли файл 
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Загружаем изображение из выбранного файла  
                pictureBox1.Load(dialog.FileName);
                pictureBox2.Image = ToImage1(ToByte(pictureBox1.Image, ColorPart.Red), ColorPart.Red);
                pictureBox3.Image = ToImage2(ToByte(pictureBox1.Image, ColorPart.Green), ColorPart.Green);
                pictureBox4.Image = ToImage3(ToByte(pictureBox1.Image, ColorPart.Blue), ColorPart.Blue);
                pictureBox5.Image = ToImage4(ToByte(pictureBox1.Image, ColorPart.Gray), ColorPart.Gray);
            }
        }
    }
}
