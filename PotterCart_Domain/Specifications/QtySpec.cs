using System.Collections.Generic;
using System.Linq;
using DDDTW.SharedModules.BaseClasses;
using PotterCart_Domain.Models;

namespace PotterCart_Domain.Specifications
{
    public class QtySpec : Specification<IReadOnlyCollection<Book>>
    {
        public QtySpec(IReadOnlyCollection<Book> books) : base(b => books.Any(s => s.Qty <= 0) == false)
        {
        }
    }
}