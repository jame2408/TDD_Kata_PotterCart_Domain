using System;
using DDDTW.SharedModules.BaseClasses;

namespace PotterCart_Domain.Exceptions
{
    public class QtyLessThanOrEqualToZeroException : BaseException
    {
        public QtyLessThanOrEqualToZeroException
            (string source, Enum errorCode, string errorMsg = null, Exception inner = null) 
            : base(source, errorCode, errorMsg ?? "Book's qty is not less than or equal to zero.", inner)
        {
        }
    }
}