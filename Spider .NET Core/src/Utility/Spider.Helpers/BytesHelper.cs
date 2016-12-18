using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Helpers
{
    public static class BytesHelper
    {
        public static string BytesToString(byte[] input)
        {
            return Convert.ToBase64String(input);
        }

        public static byte[] StringToBytes(string input)
        {
            return Convert.FromBase64String(input);
        }

    }
}
