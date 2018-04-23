namespace CreateCards
{
    using System;

    public class CardDataEventArgs : EventArgs
    {
        public CardDataType DataType { get; set; }
        public string Value { get; set; }
    }
}