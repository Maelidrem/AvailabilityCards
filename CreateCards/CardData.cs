namespace CreateCards
{
    using System.Collections.Generic;

    public class CardData
    {
        public CardData()
        {
            this.Name = string.Empty;
            this.FooterGreen = string.Empty;
            this.FooterOrange = string.Empty;
            this.FooterRed = string.Empty;
            this.TextGreenA = new List<string>();
            this.TextGreenB = new List<string>();
            this.TextGreenC = new List<string>();
            this.TextOrangeA = new List<string>();
            this.TextOrangeB = new List<string>();
            this.TextOrangeC = new List<string>();
            this.TextRedA = new List<string>();
            this.TextRedB = new List<string>();
            this.TextRedC = new List<string>();
        }

        public string Name { get; set; }
        public string FooterGreen { get; set; }
        public string FooterOrange { get; set; }
        public string FooterRed { get; set; }
        public List<string> TextGreenA { get; set; }
        public List<string> TextGreenB { get; set; }
        public List<string> TextGreenC { get; set; }
        public List<string> TextOrangeA { get; set; }
        public List<string> TextOrangeB { get; set; }
        public List<string> TextOrangeC { get; set; }
        public List<string> TextRedA { get; set; }
        public List<string> TextRedB { get; set; }
        public List<string> TextRedC { get; set; }
    }
}