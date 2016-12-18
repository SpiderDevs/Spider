using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Extensions.Mapper
{
    public static class MappingExtension
    {
        public static object Map(this object @this, Type result)
        {
            //TODO: check instance creation?????
            //Should be singlethon?
            return AutoMapper.Mapper.Instance.Map(@this, @this.GetType(), result);
        }

        public static T Map<T>(this object @this)
        {
            if (@this == null)
            {
                return default(T);
            }
            return (T)@this.Map(typeof(T));
        }

        public static T Map<TSource, T>(this TSource @this)
        {
            return AutoMapper.Mapper.Instance.Map<TSource, T>(@this);
        }
    }
}
