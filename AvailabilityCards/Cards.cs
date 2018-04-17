namespace AvailabilityCards
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;

    using CreateCards;

    using Newtonsoft.Json;

    public partial class Cards : Form
    {
        public Cards()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string json;
            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/test.json"))
            {
                json = r.ReadToEnd();
            }

            if (string.IsNullOrEmpty(json))
            {
                return;
            }

            CardData data = JsonConvert.DeserializeObject<CardData>(json);

            const int resolution = 300;
            List<Color> backColors = new List<Color>
            {
                Color.FromArgb(99, 219, 148),
                Color.FromArgb(255, 119, 73),
                Color.FromArgb(255, 33, 37)
            };

            List<Color> nameColors = new List<Color>
            {
                Color.FromArgb(219, 141, 99),
                Color.FromArgb(73, 73, 255),
                Color.FromArgb(33, 255, 248)
            };

            List<Color> textColors = new List<Color>
            {
                Color.FromArgb(219, 99, 135),
                Color.FromArgb(73, 255, 76),
                Color.FromArgb(148, 255, 33)
            };

            List<List<Image>> images = new List<List<Image>>
            {
                new List<Image>
                {
                    Card.Create(resolution, backColors[0], nameColors[0], textColors[0], data.Name, data.TextGreenA, data.FooterGreen),
                    Card.Create(resolution, backColors[0], nameColors[0], textColors[0], data.Name, data.TextGreenB, data.FooterGreen),
                    Card.Create(resolution, backColors[0], nameColors[0], textColors[0], data.Name, data.TextGreenC, data.FooterGreen)
                },
                new List<Image>
                {
                    Card.Create(resolution, backColors[1], nameColors[1], textColors[1], data.Name, data.TextOrangeA, data.FooterOrange),
                    Card.Create(resolution, backColors[1], nameColors[1], textColors[1], data.Name, data.TextOrangeB, data.FooterOrange),
                    Card.Create(resolution, backColors[1], nameColors[1], textColors[1], data.Name, data.TextOrangeC, data.FooterOrange)
                },
                new List<Image>
                {
                    Card.Create(resolution, backColors[2], nameColors[2], textColors[2], data.Name, data.TextRedA, data.FooterRed),
                    Card.Create(resolution, backColors[2], nameColors[2], textColors[2], data.Name, data.TextRedB, data.FooterRed),
                    Card.Create(resolution, backColors[2], nameColors[2], textColors[2], data.Name, data.TextRedC, data.FooterRed)
                },
            };

            int width = images[0][0].Width;
            int height = images[0][0].Height;
            const int margin = 2;
            Image image = new Bitmap(3 * width + 4 * margin, 3 * height + 4 * margin);
            ((Bitmap)image).SetResolution(resolution, resolution);

            using (Graphics g = Graphics.FromImage(image))
            {
                g.Clear(Color.Black);
                g.DrawImage(images[0][0], margin, margin);
                g.DrawImage(images[0][1], 2 * margin + width, margin);
                g.DrawImage(images[0][2], 3 * margin + 2 * width, margin);
                g.DrawImage(images[1][0], margin, 2 * margin + height);
                g.DrawImage(images[1][1], 2 * margin + width, 2 * margin + height);
                g.DrawImage(images[1][2], 3 * margin + 2 * width, 2 * margin + height);
                g.DrawImage(images[2][0], margin, 3 * margin + 2 * height);
                g.DrawImage(images[2][1], 2 * margin + width, 3 * margin + 2 * height);
                g.DrawImage(images[2][2], 3 * margin + 2 * width, 3 * margin + 2 * height);
            }

            image.Save(@"d:\cards.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
