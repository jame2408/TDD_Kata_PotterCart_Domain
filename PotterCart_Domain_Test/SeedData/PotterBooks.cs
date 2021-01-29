using PotterCart_Domain.Models;

namespace PotterCart_Domain_Test.SeedData
{
    internal static class PotterBooks
    {
        public static Book First(int qty)
        {
            return new Book()
            {
                Isbn = new ISBN("978-957-331-724-1"),
                Title = @"神秘的魔法石",
                Series = 1,
                Qty = qty
            };
        }

        public static Book Second(int qty)
        {
            return new Book()
            {
                Isbn = new ISBN("978-957-331-758-6"),
                Title = @"消失的密室",
                Series = 2,
                Qty = qty
            };
        }

        public static Book Third(int qty)
        {
            return new Book()
            {
                Isbn = new ISBN("978-957-331-800-2"),
                Title = @"阿茲卡班的逃犯",
                Series = 3,
                Qty = qty
            };
        }

        public static Book Fourth(int qty)
        {
            return new Book()
            {
                Isbn = new ISBN("978-957-331-831-6"),
                Title = @"火盃的考驗",
                Series = 4,
                Qty = qty
            };
        }

        public static Book Fifth(int qty)
        {
            return new Book()
            {
                Isbn = new ISBN("978-957-331-986-3"),
                Title = @"鳳凰會的密令",
                Series = 5,
                Qty = qty
            };
        }
    }
}