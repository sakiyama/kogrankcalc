using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KOGRankCalc
{
    /// <summary>
    /// ParticipantとRankが同じようなものなので合体
    /// </summary>
    class Player
    {
        public string JpName { get; set; }
        public string EnName { get; set; }
        public string IdCode { get; set; }
        public List<Result> Results = new List<Result>();
        public double TotalPoint
        {
            get
            {
                double total = 0;
                foreach (var result in Results)
                {
                    total += result.point;
                }
                return total;
            }
        }
        /// <summary>
        /// CSVデータ区切り文字
        /// </summary>
        private static readonly string Delimiter = @",";
        /// <summary>
        /// CSVデータindex定義
        /// </summary>
        private enum csv
        {
            rank = 0, jpName, enName, idCode, point, count
        }
        public Player(int round, string line)
        {
            var csvParams = line.Split(Delimiter.ToCharArray());
            if (csvParams.Length != (int)csv.count)
            {
                throw new EngineException("データ数が不正です。<" + csvParams.Length + 1 + ">");
            }
            this.IdCode = csvParams[(int)csv.idCode];
            this.JpName = csvParams[(int)csv.jpName];
            this.EnName = csvParams[(int)csv.enName];
            this.Results.Add(new Result(
                round,
                long.Parse(csvParams[(int)csv.rank]),
                double.Parse(csvParams[(int)csv.point])
            ));
        }

        internal static string CsvTitle(int totalRound)
        {
            var csv = string.Empty;
            foreach (var item in new string[] { "Ranking", "名前", "Name", "KOG#" })
            {
                csv += item + Delimiter;
            }
            for (var i = 0; i < totalRound; i++)
            {
                csv += @"Round " + (i + 1) + Delimiter;
            }

            csv += "Total";

            return csv;
        }

        public string ToCsv(int rank, int totalRound)
        {
            var csv = string.Empty;
            foreach (var item in new string[]{
                rank.ToString(), this.JpName , this.EnName , this.IdCode
            })
            {
                csv += item + Delimiter;
            }

            for (var i = 0; i < totalRound; i++)
            {
                var found = this.Results.Find(result => result.contestRound == i);
                if (found == null)
                {
                    csv += @"0";
                }
                else
                {
                    csv += found.point;
                }
                csv += Delimiter;
            }

            csv += this.TotalPoint;
            return csv;
        }
    }
}
