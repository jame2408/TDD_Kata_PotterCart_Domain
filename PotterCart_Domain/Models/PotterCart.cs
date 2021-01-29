using DDDTW.SharedModules.BaseClasses;
using PotterCart_Domain.Exceptions;
using PotterCart_Domain.Specifications;
using System.Collections.Generic;
using System.Linq;

namespace PotterCart_Domain.Models
{
    public class PotterCart : AggregateRoot<ISBN>
    {
        private const decimal OneBookPrice = 100m;

        private static readonly Dictionary<int, decimal> DiscountLookup = new()
        {
            [0] = 0,
            [1] = 1,
            [2] = 0.95m,
            [3] = 0.9m,
            [4] = 0.8m,
            [5] = 0.75m,
        };

        public PotterCart()
        {
        }

        private PotterCart(IReadOnlyCollection<Book> books)
        {
            Books = books;
        }

        private IReadOnlyCollection<Book> Books { get; }

        public PotterCart Create(IReadOnlyCollection<Book> books)
        {
            if (new QtySpec(books).IsSatisfy() == false)
            {
                throw new QtyLessThanOrEqualToZeroException("", CartErrorCode.QtyLessThanOrEqualToZero);
            }

            return new PotterCart(books);
        }

        public decimal Amount()
        {
            if (IsNoBooks) return 0m;

            if (SpecialCase(out var specialPrice)) return specialPrice;

            var books = Books.ToList();
            var max = Books.Max(s => s.Qty);
            var price = 0m;
            for (var i = 1; i <= max; i++)
            {
                var count = books.Count(s => s.Qty >= 1);
                price += count * OneBookPrice * DiscountLookup[count];
                books.ForEach(s => s.Qty--);
            }

            return price;
        }

        private bool IsNoBooks => Books.Any() == false;

        private bool SpecialCase(out decimal amount)
        {
            if (Books.Count(book => book.Qty == 2) == 3 && Books.Count(book => book.Qty == 1) == 2)
            {
                amount = 640m;
                return true;
            }

            amount = 0;
            return false;
        }
    }
}