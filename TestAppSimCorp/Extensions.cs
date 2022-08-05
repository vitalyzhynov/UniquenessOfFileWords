using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppSimCorp
{
    public static class Extensions
    {
        public static string PrettyPrint(this Dictionary<string, int> dictionary)
        {
            string result = string.Empty;

            if (dictionary != null)
            {
                foreach (string key in dictionary.Keys)
                {
                    result += $"{key} : {dictionary[key]}" + Environment.NewLine;
                }
            }

            return result;
        }
    }
}
