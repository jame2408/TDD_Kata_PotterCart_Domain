using System.Collections.Generic;
using DDDTW.SharedModules.BaseClasses;
using DDDTW.SharedModules.Interfaces;

namespace PotterCart_Domain.Models
{
    public class ISBN : ValueObject<ISBN>, IEntityId
    {
        public int Prefix { get; private set; }
        public int Group { get; private set; }
        public int Publisher { get; private set; }
        public int Title { get; private set; }
        public int CheckDigit { get; private set; }

        public ISBN(string code)
        {
            code = code.Replace("-", "");
            Prefix = int.Parse(code[..3]);
            Group = int.Parse(code[3..6]);
            Publisher = int.Parse(code[6..9]);
            Title = int.Parse(code[9..12]);
            CheckDigit = int.Parse(code[^1..]);
        }

        public ISBN(int prefix, int @group, int publisher, int title, int checkDigit)
        {
            Prefix = prefix;
            Group = @group;
            Publisher = publisher;
            Title = title;
            CheckDigit = checkDigit;
        }

        public override string ToString()
        {
            return $"{Prefix}-{Group}-{Publisher}-{Title}-{CheckDigit}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Prefix;
            yield return Group;
            yield return Publisher;
            yield return Title;
            yield return CheckDigit;
        }
    }
}