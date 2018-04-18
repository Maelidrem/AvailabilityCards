namespace AvailabilityCards
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;

    using CreateCards;

    public partial class Cards : Form
    {
        public Cards()
        {
            this.InitializeComponent();
        }

        private Image image = null;
        private void OnLoad(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "json files (*.json)|*.json|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            this.image = ofd.ShowDialog() == DialogResult.OK ? Card.CreateCards(ofd.FileName) : null;
            this.SetButtonState();
        }

        private void SetButtonState()
        {
            this.btnPreview.Enabled = this.image != null;
            this.btnSave.Enabled = this.image != null;
        }

        private void OnPreview(object sender, EventArgs e)
        {
            if (this.image == null)
            {
                return;
            }

            PreviewCards preview = new PreviewCards(this.image);
            preview.Show();
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (this.image == null)
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
                this.image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            this.image = null;
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
