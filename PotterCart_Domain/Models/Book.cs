using System.Collections.Generic;
using DDDTW.SharedModules.BaseClasses;

namespace PotterCart_Domain.Models
{
    public class Book : ValueObject<Book>
    {
        public ISBN Isbn { get; set; }
        public string Title { get; set; }
        public int Series { get; set; }
        public int Qty { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Isbn;
            yield return Title;
            yield return Series;
        }
    }
}