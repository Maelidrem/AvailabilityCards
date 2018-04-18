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
            Card.CreateCards();
        }
    }
}
