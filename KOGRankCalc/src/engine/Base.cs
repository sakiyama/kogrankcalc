using System;
using System.Linq;
using System.Collections.Generic;

namespace KOGRankCalc
{
    class Base
    {
        //エラーメッセージ
        public string ErrMsg { get; set; }
    }

    static class Extensions
    {
        public static void Times(this long thisNum, Action<long> func)
        {
            for (long currNum = 0; currNum < thisNum; currNum++)
            {
                func(currNum);
            }
        }

        public static void EachWithIndex<T>(
          this List<T> self, Action<T, int> block)
        {
            for (int i = 0; i < self.Count; i++)
            {
                block(self[i], i);
            }
        }

        public static void EachWithIndex<T>(
          this T[] self, Action<T, int> block)
        {
            for (int i = 0; i < self.Length; i++)
            {
                block(self[i], i);
            }
        }
        public static void Each<T>(this T[] self, Action<T> block)
        {
            foreach (T currItem in self)
            {
                block(currItem);
            }
        }
    }
}
