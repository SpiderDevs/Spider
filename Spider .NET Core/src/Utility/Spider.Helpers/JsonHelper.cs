using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Spider.Helpers
{
    public static class JsonHelper
    {
        public static string ToJson<T>(T input)
        {
            return JsonConvert.SerializeObject(input);
        }

        public static T FromJson<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        public static object FromJson(string input, Type type)
        {
            return JsonConvert.DeserializeObject(input, type);
        }
    }

}
