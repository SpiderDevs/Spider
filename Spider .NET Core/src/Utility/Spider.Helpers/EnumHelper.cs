using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Helpers
{
    public static class EnumHelper
    {
        public static string[] GetNames<T>()
        {
            return Enum.GetNames(typeof(T));
        }

        public static T GetEnum<T>(string name)
        {
           return (T)Enum.Parse(typeof(T), name);
        }
    }
}
