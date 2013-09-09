using System.Collections.Generic;
using System.Linq;
using System;

namespace KOGRankCalc
{
    class ResultService
    {
        List<Result> results = new List<Result>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ResultService()
        {
        }

        /// <summary>
        /// データのクリア
        /// </summary>
        public void Clear()
        {
            results = new List<Result>();
        }

        /// <summary>
        /// リザルトを追加
        /// </summary>
        /// <param name="IdCode"></param>
        /// <param name="contestRound"></param>
        /// <param name="point"></param>
        /// <param name="placing"></param>
        public Result Add(string idCode, long contestRound, double point, long placing)
        {
            Result result = new Result(idCode, contestRound, point, placing);
            results.Add(result);
            return result;
        }

        /// <summary>
        /// 同様のリザルトが存在するか？
        /// </summary>
        /// <param name="contestRound"></param>
        /// <param name="IdCode"></param>
        /// <returns></returns>
        public bool IsExist(long contestRound, string idCode)
        {
            var ret = from x in results
                      where x.contestRound == contestRound && x.idCode == idCode
                      select x.idCode;

            //該当ラウンドのリザルトがあったらスキップ
            return (null != ret) ? true : false;
        }

        /// <summary>
        /// リザルトを取得
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Rank> GetRanks()
        {
            double lastTotal = -1;
            long lastRank = 1;

            foreach (var rank in (from x in results
                                  group x by new { x.idCode } into xx
                                  select new
                                  {
                                      xx.Key.idCode,
                                      Score = xx.Sum(s => s.point),
                                      Results = (from xxx in xx where xxx.idCode == xx.Key.idCode select xxx)
                                  }).OrderByDescending(i => i.Score)
                                .Select((n, k) => new Rank(n.idCode, k + 1, n.Results.ToList())))
            {
                //同点の場合は同順位
                if (lastTotal == rank.Total)
                {
                    rank.Ranking = lastRank;
                }
                lastTotal = rank.Total;
                lastRank = rank.Ranking;
                yield return rank;
            }
        }

    }
}
