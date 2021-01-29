using FluentAssertions;
using NUnit.Framework;
using PotterCart_Domain_Test.SeedData;

namespace PotterCart_Domain_Test
{
    [TestFixture]
    public class BookTest
    {
        [Test]
        public void the_same_book()
        {
            var book1 = PotterBooks.First(1);
            var book2 = PotterBooks.First(2);

            book1.Should().Be(book2);
        }

        [Test]
        public void the_different_books()
        {
            var book1 = PotterBooks.First(1);
            var book2 = PotterBooks.Second(1);

            book1.Should().NotBe(book2);
        }
    }
}