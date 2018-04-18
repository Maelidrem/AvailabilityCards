namespace CreateCards
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Test
    {
        [Test]
        public void CreateCards()
        {
            Card.CreateCards(AppDomain.CurrentDomain.BaseDirectory + @"/test.json");
            Assert.IsTrue(true);
        }
    }
}
