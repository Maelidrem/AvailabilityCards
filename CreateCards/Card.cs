// ReSharper disable PossibleLossOfFraction
namespace CreateCards
{
    using System.Collections.Generic;
    using System.Drawing;

    using Newtonsoft.Json;

    public static class Card
    {
        public static Image CreateCardsFromJson(string json, Size dimensions, int resolution = -1)
        {
            CardData data;

            try
            {
                data = JsonConvert.DeserializeObject<CardData>(json);
            }
            catch
            {
                return null;
            }

            List<Color> backColors = new List<Color>
            {
                Color.FromArgb(99, 219, 148),
                Color.FromArgb(255, 119, 73),
                Color.FromArgb(255, 33, 37)
            };

            List<Color> nameColors = new List<Color>
            {
                Color.White,
                Color.White,
                Color.White
            };

            List<Color> textColors = new List<Color>
            {
                Color.Black,
                Color.Black,
                Color.Black
            };

            List<List<Image>> images = new List<List<Image>>
            {
                new List<Image>
                {
                    Card.Create(dimensions, backColors[0], nameColors[0], textColors[0], data.Name, data.TextGreenA, data.FooterGreen, resolution),
                    Card.Create(dimensions, backColors[0], nameColors[0], textColors[0], data.Name, data.TextGreenB, data.FooterGreen, resolution),
                    Card.Create(dimensions, backColors[0], nameColors[0], textColors[0], data.Name, data.TextGreenC, data.FooterGreen, resolution)
                },
                new List<Image>
                {
                    Card.Create(dimensions, backColors[1], nameColors[1], textColors[1], data.Name, data.TextOrangeA, data.FooterOrange, resolution),
                    Card.Create(dimensions, backColors[1], nameColors[1], textColors[1], data.Name, data.TextOrangeB, data.FooterOrange, resolution),
                    Card.Create(dimensions, backColors[1], nameColors[1], textColors[1], data.Name, data.TextOrangeC, data.FooterOrange, resolution)
                },
                new List<Image>
                {
                    Card.Create(dimensions, backColors[2], nameColors[2], textColors[2], data.Name, data.TextRedA, data.FooterRed, resolution),
                    Card.Create(dimensions, backColors[2], nameColors[2], textColors[2], data.Name, data.TextRedB, data.FooterRed, resolution),
                    Card.Create(dimensions, backColors[2], nameColors[2], textColors[2], data.Name, data.TextRedC, data.FooterRed, resolution)
                }
            };

            int width = images[0][0].Width;
            int height = images[0][0].Height;
            const int margin = 2;
            Image image = new Bitmap(3 * width + 4 * margin, 3 * height + 4 * margin);
            if (resolution > 0)
            {
                ((Bitmap)image).SetResolution(resolution, resolution);
            }

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

            Image imageA4 = new Bitmap(2480, 3508);
            if (resolution > 0)
            {
                ((Bitmap)imageA4).SetResolution(resolution, resolution);
            }

            using (Graphics g = Graphics.FromImage(imageA4))
            {
                g.Clear(Color.White);
                g.DrawImage(image, (imageA4.Size.Width - image.Size.Width) / 2, (imageA4.Size.Height - image.Size.Height) / 2);
            }

            return imageA4;
        }

        public static Image Create(Size imageSize, Color backColor, Color nameColor, Color textColor, string header, List<string> body, string footer, int resolution)
        {
            const int linePad = 60;
            const string fontName = "MS Sans Serif";
            const FontStyle fontStyle = FontStyle.Regular;
            const int interLine = 10;
            const GraphicsUnit graphicUnit = GraphicsUnit.Point;
            Pen pen = new Pen(Color.Black);

            Image image = new Bitmap(imageSize.Width, imageSize.Height);
            if (resolution > 0)
            {
                ((Bitmap)image).SetResolution(resolution, resolution);
            }

            Graphics drawing = Graphics.FromImage(image);
            drawing.Clear(backColor);
            Brush nameBrush = new SolidBrush(nameColor);
            Brush textBrush = new SolidBrush(textColor);

            Font font;
            SizeF textSize = imageSize;
            if (!string.IsNullOrEmpty(header))
            {
                font = Card.GetFontSize(imageSize, drawing, 10, fontName, fontStyle, graphicUnit, header);
                textSize = drawing.MeasureString(header, font);
                drawing.DrawString(header, font, nameBrush, (image.Width - textSize.Width) / 2, interLine);
                drawing.DrawLine(pen, new Point(linePad, (int)(interLine / 2 + textSize.Height)), new Point(image.Width - linePad, (int)(interLine / 2 + textSize.Height)));
            }

            if (body != null && body.Count != 0)
            {
                int startBody = (int)(2 * interLine + textSize.Height);
                foreach (string element in body)
                {
                    if (string.IsNullOrEmpty(element))
                    {
                        continue;
                    }

                    font = Card.GetFontSize(imageSize, drawing, 20, fontName, fontStyle, graphicUnit, element);
                    textSize = drawing.MeasureString(element, font);
                    drawing.DrawString(element, font, textBrush, (image.Width - textSize.Width) / 2, startBody);
                    startBody += (int)(interLine + textSize.Height);
                }
            }

            if (!string.IsNullOrEmpty(footer))
            {
                font = Card.GetFontSize(imageSize, drawing, 100, fontName, fontStyle, graphicUnit, footer);
                textSize = drawing.MeasureString(footer, font);
                drawing.DrawString(footer, font, nameBrush, (image.Width - textSize.Width) / 2, imageSize.Height - 10 - textSize.Height);
                drawing.DrawLine(pen,
                                 new Point(linePad, (int)(imageSize.Height - 10 - textSize.Height - interLine / 2)),
                                 new Point(image.Width - linePad, (int)(imageSize.Height - 10 - textSize.Height - interLine / 2)));
            }

            drawing.Save();

            textBrush.Dispose();
            nameBrush.Dispose();
            drawing.Dispose();
            return image;
        }

        private static Font GetFontSize(Size imageSize, Graphics drawing, int borders, string fontName, FontStyle fontStyle, GraphicsUnit graphicUnit, string text)
        {
            float fontSize = 1;
            int pixelsLeft = imageSize.Width;
            while (pixelsLeft >= borders)
            {
                fontSize += 0.5F;
                Font font = new Font(fontName, fontSize, fontStyle, graphicUnit);
                SizeF textSize = drawing.MeasureString(text, font);
                pixelsLeft = imageSize.Width - (int)textSize.Width;
            }

            fontSize -= 0.5F;
            return new Font(fontName, fontSize, fontStyle, graphicUnit);
        }
    }
}