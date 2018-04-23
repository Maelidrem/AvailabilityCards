namespace AvailabilityCards
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;
    using System.Linq;

    using CreateCards;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public partial class Cards : Form
    {
        CardData currentData = new CardData();
        private void OnTextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                CardDataType type = (CardDataType)(((TextBox)sender).Tag);
                if (((TextBox)sender).Text != this.defaultDisplayedText[type])
                {
                    this.UpdateCardData(type, ((TextBox)sender).Text);
                    this.UpdatePreview();
                }
            }
        }
        public Image CurrentImage { get; set; }

        private void UpdatePreview()
        {
            this.CurrentImage = Card.CreateCardsFromJson(JsonConvert.SerializeObject(this.currentData), new Size(this.pctCards.Width, this.pctCards.Height));
            this.PaintImage();
        }

        private Bitmap emptyImage;

        private void PaintImage()
        {
            RectangleF rectSource = new RectangleF(0, 0, this.CurrentImage.Width, this.CurrentImage.Height);
            RectangleF rectDestination = new RectangleF(0, 0, this.pctCards.Width, this.pctCards.Height);
            
            using (Graphics g = Graphics.FromImage(this.emptyImage))
            {
                g.DrawImage(this.CurrentImage, rectDestination, rectSource, GraphicsUnit.Pixel);
            }

            this.pctCards.Image = this.CurrentImage;
        }

        private void UpdateCardData(CardDataType type, string text)
        {
            string[] tmpTxt = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
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
            if (sender is TextBox && ((TextBox)sender).Text.Length == 0)
            {
                CardDataType type = (CardDataType)(((TextBox)sender).Tag);
                ((TextBox)sender).Text = this.defaultDisplayedText[type];
                ((TextBox)sender).ForeColor = SystemColors.GrayText;
            }
        }

        private void OnTextEnter(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                CardDataType type = (CardDataType)(((TextBox)sender).Tag);
                if (((TextBox)sender).Text == this.defaultDisplayedText[type])
                {
                    ((TextBox)sender).Text = string.Empty;
                    ((TextBox)sender).ForeColor = SystemColors.WindowText;
                }
            }
        }

        private Dictionary<CardDataType, string> defaultDisplayedText = new Dictionary<CardDataType, string>
        {
            { CardDataType.Name, "Please Enter Your Name" },
            { CardDataType.TextGreenA, "Please Enter The Text To Be Displayed On The First Green Card" },
            { CardDataType.TextGreenB, "Please Enter The Text To Be Displayed On The Second Green Card" },
            { CardDataType.TextGreenC, "Please Enter The Text To Be Displayed On The Third Green Card" },
            { CardDataType.FooterGreen, "Please Enter The Footer For Green Cards" },
            { CardDataType.TextOrangeA, "Please Enter The Text To Be Displayed On The First Orange Card" },
            { CardDataType.TextOrangeB, "Please Enter The Text To Be Displayed On The Second Orange Card" },
            { CardDataType.TextOrangeC, "Please Enter The Text To Be Displayed On The Third Orange Card" },
            { CardDataType.FooterOrange, "Please Enter The Footer For Orange Cards" },
            { CardDataType.TextRedA, "Please Enter The Text To Be Displayed On The First Red Card" },
            { CardDataType.TextRedB, "Please Enter The Text To Be Displayed On The Second Red Card" },
            { CardDataType.TextRedC, "Please Enter The Text To Be Displayed On The Third Red Card" },
            { CardDataType.FooterRed, "Please Enter The Footer For Red Cards" },
        };
        
        public Cards()
        {
            this.InitializeComponent();
            this.InitTextBoxes();
            this.emptyImage = new Bitmap(this.pctCards.Width, this.pctCards.Height);
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

            this.tbName.TextChanged += new EventHandler(this.OnTextChanged);
            this.tbGreenA.TextChanged += new EventHandler(this.OnTextChanged);
            this.tbGreenB.TextChanged += new EventHandler(this.OnTextChanged);
            this.tbGreenC.TextChanged += new EventHandler(this.OnTextChanged);
            this.tbFooterGreen.TextChanged += new EventHandler(this.OnTextChanged);
            this.tbOrangeA.TextChanged += new EventHandler(this.OnTextChanged);
            this.tbOrangeB.TextChanged += new EventHandler(this.OnTextChanged);
            this.tbOrangeC.TextChanged += new EventHandler(this.OnTextChanged);
            this.tbFooterOrange.TextChanged += new EventHandler(this.OnTextChanged);
            this.tbRedA.TextChanged += new EventHandler(this.OnTextChanged);
            this.tbRedB.TextChanged += new EventHandler(this.OnTextChanged);
            this.tbRedC.TextChanged += new EventHandler(this.OnTextChanged);
            this.tbFooterRed.TextChanged += new EventHandler(this.OnTextChanged);

            this.tbName.Leave += new EventHandler(this.OnTextLeave);
            this.tbGreenA.Leave += new EventHandler(this.OnTextLeave);
            this.tbGreenB.Leave += new EventHandler(this.OnTextLeave);
            this.tbGreenC.Leave += new EventHandler(this.OnTextLeave);
            this.tbFooterGreen.Leave += new EventHandler(this.OnTextLeave);
            this.tbOrangeA.Leave += new EventHandler(this.OnTextLeave);
            this.tbOrangeB.Leave += new EventHandler(this.OnTextLeave);
            this.tbOrangeC.Leave += new EventHandler(this.OnTextLeave);
            this.tbFooterOrange.Leave += new EventHandler(this.OnTextLeave);
            this.tbRedA.Leave += new EventHandler(this.OnTextLeave);
            this.tbRedB.Leave += new EventHandler(this.OnTextLeave);
            this.tbRedC.Leave += new EventHandler(this.OnTextLeave);
            this.tbFooterRed.Leave += new EventHandler(this.OnTextLeave);

            this.tbName.Enter += new EventHandler(this.OnTextEnter);
            this.tbGreenA.Enter += new EventHandler(this.OnTextEnter);
            this.tbGreenB.Enter += new EventHandler(this.OnTextEnter);
            this.tbGreenC.Enter += new EventHandler(this.OnTextEnter);
            this.tbFooterGreen.Enter += new EventHandler(this.OnTextEnter);
            this.tbOrangeA.Enter += new EventHandler(this.OnTextEnter);
            this.tbOrangeB.Enter += new EventHandler(this.OnTextEnter);
            this.tbOrangeC.Enter += new EventHandler(this.OnTextEnter);
            this.tbFooterOrange.Enter += new EventHandler(this.OnTextEnter); 
            this.tbRedA.Enter += new EventHandler(this.OnTextEnter);
            this.tbRedB.Enter += new EventHandler(this.OnTextEnter);
            this.tbRedC.Enter += new EventHandler(this.OnTextEnter);
            this.tbFooterRed.Enter += new EventHandler(this.OnTextEnter);

            //this.tbName.
            //this.tbGreenA.
            //this.tbGreenB.
            //this.tbGreenC.
            //this.tbFooterGreen.
            //this.tbOrangeA.
            //this.tbOrangeB.
            //this.tbOrangeC.
            //this.tbFooterOrange.
            //this.tbRedA.
            //this.tbRedB.
            //this.tbRedC.
            //this.tbFooterRed.
        }

        private void OnLoad(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "json files (*.json)|*.json|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName) )
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
            this.UpdatePreview();
            this.SetButtonState();
        }

        private void SetButtonState()
        {
            this.btnPreview.Enabled = this.CurrentImage != null;
            this.btnSave.Enabled = this.CurrentImage != null;
        }

        private void OnPreview(object sender, EventArgs e)
        {
            if (this.CurrentImage == null)
            {
                return;
            }

            PreviewCards preview = new PreviewCards(this.CurrentImage);
            preview.Show();
        }

        private const int resolution = 300;
        private void OnSave(object sender, EventArgs e)
        {
            if (this.CurrentImage == null)
            {
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "jpg files (*.jpg)|*.jpg",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                const float inchInMm = 25.4F;
                Size sizeInMm = new Size(49, 75);
                Size imageSize = new Size((int)(sizeInMm.Width / inchInMm * resolution), (int)(sizeInMm.Height / inchInMm * resolution));
                Image imgToSave = Card.CreateCardsFromJson(JsonConvert.SerializeObject(this.currentData), imageSize, resolution);
                imgToSave.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            this.CurrentImage = null;
            this.SetButtonState();
        }

        private void OnSample(object sender, EventArgs e)
        {
            string json;
            string jsonFile = AppDomain.CurrentDomain.BaseDirectory + @"/sample.json";
            using (StreamReader r = new StreamReader(jsonFile))
            {
                json = r.ReadToEnd();
            }

            ViewSample sample = new ViewSample(json);
            sample.Show();
        }
    }
}
