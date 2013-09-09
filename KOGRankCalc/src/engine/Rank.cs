using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KOGRankCalc
{
    class Rank : Base
    {
        public string IdCode { get; set; }
        public long Ranking { get; set; }
        public List<Result> Results { get; set; }
        public double Total
        {
            get
            {
                return (double)(from x in Results where x.idCode == IdCode select x.point).Sum();
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="idCode"></param>
        /// <param name="rank"></param>
        /// <param name="results"></param>
        public Rank(string idCode, long ranking, List<Result> results)
        {
            IdCode = idCode;
            Ranking = ranking;
            Results = results.OrderBy(s => s.contestRound).ToList<Result>();
        }
    }
}
