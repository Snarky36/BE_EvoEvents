using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities.RegEx
{
    public static class RegularExpression
    {
        public static readonly string EmailFormat = @"^\s*\w+@\w+\.[Cc][Oo][Mm]\s*$";
        public static readonly string AlphaWhiteSpacesDash = @"^(\s*([A-Za-z]+\s*-?))*((\s)*[A-Za-z]+\s*)$";
        public static readonly string Alphanumeric = @"\s*[a-zA-Z0-9]{2,}\s*$";
        public static readonly string NoWhiteSpaces = @"^\S*$";
    }
}
