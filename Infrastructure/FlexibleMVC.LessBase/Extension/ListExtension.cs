using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.LessBase.Extension
{
    public static class ListExtension
    {
        //排序去重
        public static SortedSet<T> ToSortedSet<T>(this List<T> list)
        {
            var sortedSet = new SortedSet<T>();

            if (list == null)
                return sortedSet;
            
            foreach (var item in list)
            {
                sortedSet.Add(item);
            }

            return sortedSet;
        }

    }
}
