using FluentAssertions;
using NUnit.Framework;
using PotterCart_Domain.Models;
using PotterCart_Domain_Test.SeedData;
using System.Collections.Generic;

namespace PotterCart_Domain_Test
{
    [TestFixture]
    internal class PotterCartTest
    {
        private static void BooksAmountShouldBe(IReadOnlyCollection<Book> books, decimal expected)
        {
            new PotterCart().Create(books).Amount().Should().Be(expected);
        }

        [Test]
        public void when_no_buy_book_then_amount_should_be_0()
        {
            BooksAmountShouldBe(books: new List<Book>(), expected: 0m);
        }

        [Test]
        public void when_buy_a_book_then_amount_should_be_100()
        {
            BooksAmountShouldBe(
                books: new List<Book>
                {
                    PotterBooks.First(1)
                },
                expected: 100m);
        }

        [Test]
        public void when_buy_two_different_series_books_then_amount_should_be_190()
        {
            BooksAmountShouldBe(
                books: new List<Book>
                {
                    PotterBooks.First(1),
                    PotterBooks.Second(1),
                },
                expected: 190m);
        }

        [Test]
        public void when_buy_three_different_series_books_then_amount_should_be_270()
        {
            BooksAmountShouldBe(
                books: new List<Book>
                {
                    PotterBooks.First(1),
                    PotterBooks.Second(1),
                    PotterBooks.Third(1),
                },
                expected: 270m);
        }

        [Test]
        public void when_buy_four_different_series_books_then_amount_should_be_320()
        {
            BooksAmountShouldBe(
                books: new List<Book>
                {
                    PotterBooks.First(1),
                    PotterBooks.Second(1),
                    PotterBooks.Third(1),
                    PotterBooks.Fourth(1),
                },
                expected: 320m);
        }

        [Test]
        public void when_buy_five_different_series_books_then_amount_should_be_375()
        {
            BooksAmountShouldBe(
                books: new List<Book>
                {
                    PotterBooks.First(1),
                    PotterBooks.Second(1),
                    PotterBooks.Third(1),
                    PotterBooks.Fourth(1),
                    PotterBooks.Fifth(1),
                },
                expected: 375m);
        }

        [Test]
        public void when_buy_two_the_same_series_books_then_amount_should_be_200()
        {
            BooksAmountShouldBe(
                books: new List<Book>
                {
                    PotterBooks.First(2),
                },
                expected: 200m);
        }

        [Test]
        public void when_buy_two_the_same_series_books_and_one_different_series_book_then_amount_should_be_290()
        {
            BooksAmountShouldBe(
                books: new List<Book>
                {
                    PotterBooks.First(2),
                    PotterBooks.Second(1),
                },
                expected: 290m);
        }

        /// <summary>
        /// 特殊例外：用 5 + 3 優惠方案價格 645 元，若使用 4 + 4 優惠方案價格 640 元。
        /// </summary>
        [Test]
        public void when_buy_five_different_series_books_and_three_different_series_books_then_amount_should_be_640()
        {
            BooksAmountShouldBe(
                books: new List<Book>
                {
                    PotterBooks.First(2),
                    PotterBooks.Second(2),
                    PotterBooks.Third(2),
                    PotterBooks.Fourth(1),
                    PotterBooks.Fifth(1),
                },
                expected: 640m);
        }
    }
}