namespace AvailabilityCards
{
    using System.Drawing;
    using System.Windows.Forms;

    public partial class ViewSample : Form
    {
        public ViewSample(string json)
        {
            this.InitializeComponent();
            this.Size = new Size(350, 750);
            this.textBox1.Text = json;
        }
    }
}
