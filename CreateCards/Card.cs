// ReSharper disable PossibleLossOfFraction
namespace CreateCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing;

    public static class Card
    {
        public static Image Create(int resolution, Color backColor, Color nameColor, Color textColor, string header, List<string> body, string footer)
        {
            const int linePad = 25;
            const float inchInMm = 25.4F;
            const string fontName = "MS Sans Serif";
            const FontStyle fontStyle = FontStyle.Regular;
            const int interLine = 10;
            const GraphicsUnit graphicUnit = GraphicsUnit.Point;
            Pen pen = new Pen(Color.Black);
            Size sizeInMm = new Size(45, 70);
            Size imageSize = new Size((int)(sizeInMm.Width / inchInMm * resolution), (int)(sizeInMm.Height / inchInMm * resolution));

            Image image = new Bitmap(imageSize.Width, imageSize.Height);
            ((Bitmap)image).SetResolution(resolution, resolution);

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
                font = Card.GetFontSize(imageSize, drawing, 50, fontName, fontStyle, graphicUnit, footer);
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
