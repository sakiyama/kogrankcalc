using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KOGRankCalc
{
    /// <summary>
    /// RegistrationServiceからRankingに名前変更
    /// </summary>
    class Ranking
    {
        private readonly Encoding Encoding = Encoding.GetEncoding("shift_jis");

        public List<Player> Result
        {
            get
            {
                var players = Players.Values.ToList();
                players.Sort(
                    delegate(Player player1, Player player2)
                    {
                        return (int)(player2.TotalPoint - player1.TotalPoint);
                    });
                return players;

            }
        }

        public Dictionary<string, Player> Players = new Dictionary<string, Player>();
        public int TotalRound = 0;

        internal void Import(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                throw new EngineException("ファイルが見つかりません<" + path + ">");
            }

            using (var reader = new StreamReader(path, Encoding))
            {
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLine();

                    var player = new Player(TotalRound, line);
                    if (Players.ContainsKey(player.IdCode))
                    {
                        if (Players[player.IdCode].JpName != player.JpName)
                        {
                            var message = string.Format(@"IDが同じで名前の違う人がいます。round{0} : name{1}", TotalRound, player.JpName);
                            throw new EngineException(message);
                        }
                        Players[player.IdCode].Results.AddRange(player.Results);
                    }
                    else
                    {
                        Players.Add(player.IdCode, player);
                    }
                }
            }
            TotalRound++;
        }

        internal void Export(string filePath)
        {
            try
            {
                using (var writer = new System.IO.StreamWriter(
                    filePath,
                    false,
                    Encoding))
                {
                    writer.WriteLine(Player.CsvTitle(TotalRound));
                    var lastPoint = double.MaxValue;
                    var lastRank = 0;
                    var rank = 0;
                    for (var i = 0; i < Result.Count; i++)
                    {
                        if (lastPoint == Result[i].TotalPoint)
                        {
                            rank = lastRank;
                        }
                        else
                        {
                            rank = i + 1;
                        }

                        writer.WriteLine(Result[i].ToCsv(rank, TotalRound));
                        lastPoint = Result[i].TotalPoint;
                        lastRank = rank;
                    }
                }
                MessageBox.Show("ファイル出力終了しました。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
