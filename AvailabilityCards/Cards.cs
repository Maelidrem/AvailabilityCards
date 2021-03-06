﻿namespace AvailabilityCards
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using CreateCards;

    using Newtonsoft.Json;

    public partial class Cards : Form
    {
        private readonly Dictionary<CardDataType, string> defaultDisplayedText = new Dictionary<CardDataType, string>
        {
            {CardDataType.Name, "Please Enter Your Name"},
            {CardDataType.TextGreenA, "Please Enter The Text To Be Displayed On The First Green Card"},
            {CardDataType.TextGreenB, "Please Enter The Text To Be Displayed On The Second Green Card"},
            {CardDataType.TextGreenC, "Please Enter The Text To Be Displayed On The Third Green Card"},
            {CardDataType.FooterGreen, "Please Enter The Footer For Green Cards"},
            {CardDataType.TextOrangeA, "Please Enter The Text To Be Displayed On The First Orange Card"},
            {CardDataType.TextOrangeB, "Please Enter The Text To Be Displayed On The Second Orange Card"},
            {CardDataType.TextOrangeC, "Please Enter The Text To Be Displayed On The Third Orange Card"},
            {CardDataType.FooterOrange, "Please Enter The Footer For Orange Cards"},
            {CardDataType.TextRedA, "Please Enter The Text To Be Displayed On The First Red Card"},
            {CardDataType.TextRedB, "Please Enter The Text To Be Displayed On The Second Red Card"},
            {CardDataType.TextRedC, "Please Enter The Text To Be Displayed On The Third Red Card"},
            {CardDataType.FooterRed, "Please Enter The Footer For Red Cards"}
        };

        private readonly Bitmap emptyImage;
        private CardData currentData = new CardData();

        public Cards()
        {
            this.InitializeComponent();
            this.InitTextBoxes();
            this.emptyImage = new Bitmap(this.pctCards.Width, this.pctCards.Height);
        }

        public Image CurrentImage { get; set; }

        Image GetResizedImage(Image image, int width, int height)
        {
            double y = image.Height;
            double x = image.Width;

            double factor = 1;
            if (width > 0)
            {
                factor = width / x;
            }
            else if (height > 0)
            {
                factor = height / y;
            }
            System.IO.MemoryStream outStream = new System.IO.MemoryStream();
            Bitmap imgOut = new Bitmap((int)(x * factor), (int)(y * factor));

            imgOut.SetResolution(72, 72);

            Graphics g = Graphics.FromImage(imgOut);
            g.Clear(Color.White);
            g.DrawImage(image, new Rectangle(0, 0, (int)(factor * x), (int)(factor * y)), new Rectangle(0, 0, (int)x, (int)y), GraphicsUnit.Pixel);

            return imgOut;
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box == null)
            {
                return;
            }

            CardDataType type = (CardDataType)box.Tag;
            if (box.Text == this.defaultDisplayedText[type])
            {
                return;
            }

            this.UpdateCardData(type, box.Text);
        }

        private int resolution = 300;
        private void UpdatePreview()
        {
            this.CurrentImage = Card.CreateCardsFromJson(JsonConvert.SerializeObject(this.currentData), this.resolution);
            this.PaintImage(this.GetResizedImage(this.CurrentImage, this.pctCards.Width, this.pctCards.Height));
        }

        private void PaintImage(Image image)
        {
            RectangleF rectSource = new RectangleF(0, 0, this.CurrentImage.Width, this.CurrentImage.Height);
            RectangleF rectDestination = new RectangleF(0, 0, this.pctCards.Width, this.pctCards.Height);

            using (Graphics g = Graphics.FromImage(image))
            {
                g.DrawImage(image, new PointF(0, 0));
            }

            this.pctCards.Image = image;
        }

        private void UpdateCardData(CardDataType type, string text)
        {
            string[] tmpTxt = text.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            switch (type)
            {
                case CardDataType.Name:
                    this.currentData.Name = text;
                    break;
                case CardDataType.FooterGreen:
                    this.currentData.FooterGreen = text;
                    break;
                case CardDataType.FooterOrange:
                    this.currentData.FooterOrange = text;
                    break;
                case CardDataType.FooterRed:
                    this.currentData.FooterRed = text;
                    break;
                case CardDataType.TextGreenA:
                    this.currentData.TextGreenA = tmpTxt.ToList();
                    break;
                case CardDataType.TextGreenB:
                    this.currentData.TextGreenB = tmpTxt.ToList();
                    break;
                case CardDataType.TextGreenC:
                    this.currentData.TextGreenC = tmpTxt.ToList();
                    break;
                case CardDataType.TextOrangeA:
                    this.currentData.TextOrangeA = tmpTxt.ToList();
                    break;
                case CardDataType.TextOrangeB:
                    this.currentData.TextOrangeB = tmpTxt.ToList();
                    break;
                case CardDataType.TextOrangeC:
                    this.currentData.TextOrangeC = tmpTxt.ToList();
                    break;
                case CardDataType.TextRedA:
                    this.currentData.TextRedA = tmpTxt.ToList();
                    break;
                case CardDataType.TextRedB:
                    this.currentData.TextRedB = tmpTxt.ToList();
                    break;
                case CardDataType.TextRedC:
                    this.currentData.TextRedC = tmpTxt.ToList();
                    break;
            }
        }

        private void OnTextLeave(object sender, EventArgs e)
        {
            this.UpdatePreview();
            TextBox box = sender as TextBox;
            if (box == null || box.Text.Length != 0)
            {
                return;
            }

            CardDataType type = (CardDataType)box.Tag;
            box.Text = this.defaultDisplayedText[type];
            box.ForeColor = SystemColors.GrayText;
        }

        private void OnTextEnter(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box == null)
            {
                return;
            }

            CardDataType type = (CardDataType)box.Tag;
            if (box.Text != this.defaultDisplayedText[type])
            {
                return;
            }

            box.Text = string.Empty;
            box.ForeColor = SystemColors.WindowText;
        }

        private void InitTextBoxes()
        {
            this.tbName.Tag = CardDataType.Name;
            this.tbGreenA.Tag = CardDataType.TextGreenA;
            this.tbGreenB.Tag = CardDataType.TextGreenB;
            this.tbGreenC.Tag = CardDataType.TextGreenC;
            this.tbFooterGreen.Tag = CardDataType.FooterGreen;
            this.tbOrangeA.Tag = CardDataType.TextOrangeA;
            this.tbOrangeB.Tag = CardDataType.TextOrangeB;
            this.tbOrangeC.Tag = CardDataType.TextOrangeC;
            this.tbFooterOrange.Tag = CardDataType.FooterOrange;
            this.tbRedA.Tag = CardDataType.TextRedA;
            this.tbRedB.Tag = CardDataType.TextRedB;
            this.tbRedC.Tag = CardDataType.TextRedC;
            this.tbFooterRed.Tag = CardDataType.FooterRed;

            this.tbName.ForeColor = SystemColors.GrayText;
            this.tbGreenA.ForeColor = SystemColors.GrayText;
            this.tbGreenB.ForeColor = SystemColors.GrayText;
            this.tbGreenC.ForeColor = SystemColors.GrayText;
            this.tbFooterGreen.ForeColor = SystemColors.GrayText;
            this.tbOrangeA.ForeColor = SystemColors.GrayText;
            this.tbOrangeB.ForeColor = SystemColors.GrayText;
            this.tbOrangeC.ForeColor = SystemColors.GrayText;
            this.tbFooterOrange.ForeColor = SystemColors.GrayText;
            this.tbRedA.ForeColor = SystemColors.GrayText;
            this.tbRedB.ForeColor = SystemColors.GrayText;
            this.tbRedC.ForeColor = SystemColors.GrayText;
            this.tbFooterRed.ForeColor = SystemColors.GrayText;

            this.tbName.Text = this.defaultDisplayedText[CardDataType.Name];
            this.tbGreenA.Text = this.defaultDisplayedText[CardDataType.TextGreenA];
            this.tbGreenB.Text = this.defaultDisplayedText[CardDataType.TextGreenB];
            this.tbGreenC.Text = this.defaultDisplayedText[CardDataType.TextGreenC];
            this.tbFooterGreen.Text = this.defaultDisplayedText[CardDataType.FooterGreen];
            this.tbOrangeA.Text = this.defaultDisplayedText[CardDataType.TextOrangeA];
            this.tbOrangeB.Text = this.defaultDisplayedText[CardDataType.TextOrangeB];
            this.tbOrangeC.Text = this.defaultDisplayedText[CardDataType.TextOrangeC];
            this.tbFooterOrange.Text = this.defaultDisplayedText[CardDataType.FooterOrange];
            this.tbRedA.Text = this.defaultDisplayedText[CardDataType.TextRedA];
            this.tbRedB.Text = this.defaultDisplayedText[CardDataType.TextRedB];
            this.tbRedC.Text = this.defaultDisplayedText[CardDataType.TextRedC];
            this.tbFooterRed.Text = this.defaultDisplayedText[CardDataType.FooterRed];

            this.tbName.TextChanged += this.OnTextChanged;
            this.tbGreenA.TextChanged += this.OnTextChanged;
            this.tbGreenB.TextChanged += this.OnTextChanged;
            this.tbGreenC.TextChanged += this.OnTextChanged;
            this.tbFooterGreen.TextChanged += this.OnTextChanged;
            this.tbOrangeA.TextChanged += this.OnTextChanged;
            this.tbOrangeB.TextChanged += this.OnTextChanged;
            this.tbOrangeC.TextChanged += this.OnTextChanged;
            this.tbFooterOrange.TextChanged += this.OnTextChanged;
            this.tbRedA.TextChanged += this.OnTextChanged;
            this.tbRedB.TextChanged += this.OnTextChanged;
            this.tbRedC.TextChanged += this.OnTextChanged;
            this.tbFooterRed.TextChanged += this.OnTextChanged;

            this.tbName.Leave += this.OnTextLeave;
            this.tbGreenA.Leave += this.OnTextLeave;
            this.tbGreenB.Leave += this.OnTextLeave;
            this.tbGreenC.Leave += this.OnTextLeave;
            this.tbFooterGreen.Leave += this.OnTextLeave;
            this.tbOrangeA.Leave += this.OnTextLeave;
            this.tbOrangeB.Leave += this.OnTextLeave;
            this.tbOrangeC.Leave += this.OnTextLeave;
            this.tbFooterOrange.Leave += this.OnTextLeave;
            this.tbRedA.Leave += this.OnTextLeave;
            this.tbRedB.Leave += this.OnTextLeave;
            this.tbRedC.Leave += this.OnTextLeave;
            this.tbFooterRed.Leave += this.OnTextLeave;

            this.tbName.Enter += this.OnTextEnter;
            this.tbGreenA.Enter += this.OnTextEnter;
            this.tbGreenB.Enter += this.OnTextEnter;
            this.tbGreenC.Enter += this.OnTextEnter;
            this.tbFooterGreen.Enter += this.OnTextEnter;
            this.tbOrangeA.Enter += this.OnTextEnter;
            this.tbOrangeB.Enter += this.OnTextEnter;
            this.tbOrangeC.Enter += this.OnTextEnter;
            this.tbFooterOrange.Enter += this.OnTextEnter;
            this.tbRedA.Enter += this.OnTextEnter;
            this.tbRedB.Enter += this.OnTextEnter;
            this.tbRedC.Enter += this.OnTextEnter;
            this.tbFooterRed.Enter += this.OnTextEnter;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = @"json files (*.json)|*.json|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (ofd.ShowDialog() != DialogResult.OK ||
                string.IsNullOrEmpty(ofd.FileName))
            {
                return;
            }

            string json;
            using (StreamReader r = new StreamReader(ofd.FileName))
            {
                json = r.ReadToEnd();
            }

            if (string.IsNullOrEmpty(json))
            {
                return;
            }

            this.currentData = JsonConvert.DeserializeObject<CardData>(json);
            this.UpdateText();
            this.UpdatePreview();
        }

        private void UpdateText()
        {
            this.tbName.Text = this.currentData.Name;
            this.tbGreenA.Text = string.Join(Environment.NewLine, this.currentData.TextGreenA);
            this.tbGreenB.Text = string.Join(Environment.NewLine, this.currentData.TextGreenB);
            this.tbGreenC.Text = string.Join(Environment.NewLine, this.currentData.TextGreenC);
            this.tbOrangeA.Text = string.Join(Environment.NewLine, this.currentData.TextOrangeA);
            this.tbOrangeB.Text = string.Join(Environment.NewLine, this.currentData.TextOrangeB);
            this.tbOrangeC.Text = string.Join(Environment.NewLine, this.currentData.TextOrangeC);
            this.tbRedA.Text = string.Join(Environment.NewLine, this.currentData.TextRedA);
            this.tbRedB.Text = string.Join(Environment.NewLine, this.currentData.TextRedB);
            this.tbRedC.Text = string.Join(Environment.NewLine, this.currentData.TextRedC);
            this.tbFooterGreen.Text = this.currentData.FooterGreen;
            this.tbFooterOrange.Text = this.currentData.FooterOrange;
            this.tbFooterRed.Text = this.currentData.FooterRed;
        }

        private void OnSaveJson(object sender, EventArgs e)
        {
            if (this.currentData == null)
            {
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = @"json files (*.json)|*.json",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string json = JsonConvert.SerializeObject(this.currentData,Formatting.Indented);
                using (StreamWriter writer = File.CreateText(sfd.FileName))
                {
                    writer.Write(json);
                }
            }
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (this.CurrentImage == null)
            {
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = @"jpg files (*.jpg)|*.jpg",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Image imgToSave = Card.CreateCardsFromJson(JsonConvert.SerializeObject(this.currentData), this.resolution);
                imgToSave.Save(sfd.FileName, ImageFormat.Jpeg);
            }

            this.CurrentImage = null;
        }
    }
}