using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyContent
{
    public static class StringExtension
    {
        public static bool RegexMatch(this string me,string pat)
        {
            return Regex.Match(me, pat).Success;
        }
    }
}
