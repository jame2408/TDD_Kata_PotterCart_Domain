using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using PotterCart_Domain.Models;
using PotterCart_Domain_Test.SeedData;

namespace PotterCart_Domain_Test
{
    [TestFixture]
    public class ISBNTest
    {
        [Test]
        public void convert_ISBN_string()
        {
            var isbn = new ISBN(978, 957, 331, 724, 1);
            isbn.ToString().Should().Be("978-957-331-724-1");
        }

        [Test]
        public void split_ISBN_string()
        {
            var isbn = new ISBN("978-957-331-724-1");
            isbn.Prefix.Should().Be(978);
            isbn.Group.Should().Be(957);
            isbn.Publisher.Should().Be(331);
            isbn.Title.Should().Be(724);
            isbn.CheckDigit.Should().Be(1);
        }

        [Test]
        public void check_the_same_ISBN()
        {
            var isbn1 = new ISBN("978-957-331-724-1");
            var isbn2 = new ISBN("978-957-331-724-1");
            isbn1.Should().Be(isbn2);
        }
    }
}