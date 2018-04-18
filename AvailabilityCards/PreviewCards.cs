namespace AvailabilityCards
{
    using System.Drawing;
    using System.Windows.Forms;

    public partial class PreviewCards : Form
    {
        private Image image;
        public PreviewCards(Image image)
        {
            this.image = image;
            this.InitializeComponent();
            this.Paint += new PaintEventHandler(this.OnPaint);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            RectangleF srcRect = new RectangleF(0, 0, this.image.Size.Width, this.image.Size.Height);
            RectangleF destRect = new RectangleF(0, 0, this.image.Size.Width / 4, this.image.Size.Height / 4);
            this.Size = new Size((int)destRect.Width, (int)destRect.Height);
            Graphics graphicsObj = e.Graphics;
            graphicsObj.DrawImage(this.image, destRect, srcRect, GraphicsUnit.Pixel);
            graphicsObj.Dispose();
        }
    }
}
