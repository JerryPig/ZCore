
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.AutoMapper
{
    public static class AutoMapperHelper
    {
        public static T MapTo<T>(this object obj)
        {
            if (obj == null) return default(T);
            Mapper.Initialize(x => x.CreateMap(obj.GetType(),typeof(T)));
            return Mapper.Map<T>(obj);
        }

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            Mapper.Initialize(x => x.CreateMap<TSource, TDestination>());
            return Mapper.Map<List<TDestination>>(source);
        }
    }
}
