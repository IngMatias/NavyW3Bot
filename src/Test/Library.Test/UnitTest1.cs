using NUnit.Framework;
using Library;

namespace Library.Test
{
    public class Tests
    {
        private Class1 class1;

        [SetUp]
        public void Setup()
        {
            this.class1 = new Class1();
        }

        [Test]
        public void Test1()
        {
            Assert.IsNotNull(this.class1);
        }
    }
}