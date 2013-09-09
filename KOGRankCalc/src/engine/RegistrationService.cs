﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace KOGRankCalc
{
    class RegistrationService : Base
    {
        /// <summary>
        /// For Singleton
        /// </summary>
        private static RegistrationService instance = new RegistrationService();

        /// <summary>
        /// CSVデータindex定義
        /// </summary>
        public static long CSV_DATA_RANK = 0;
        public static long CSV_DATA_JPNAME = 1;
        public static long CSV_DATA_ENNAME = 2;
        public static long CSV_DATA_IDCODE = 3;
        public static long CSV_DATA_POINT = 4;

        /// <summary>
        /// csvデータ総数
        /// </summary>
        public static long CSV_DATA_TOTAL = 4;

        /// <summary>
        /// CSVデータ区切り文字
        /// </summary>
        static private char DELIMITER = ',';

        private ParticipantService participantService = new ParticipantService();
        private ResultService resultService = new ResultService();

        public static RegistrationService getInstance()
        {
            return instance;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private RegistrationService()
        {
        }

        /// <summary>
        /// データのクリア
        /// </summary>
        public void Clear()
        {
            participantService.Clear();
            resultService.Clear();

        }

        /// <summary>
        /// レコードの追加
        /// </summary>
        /// <param name="contestRound"></param>
        /// <param name="csvline_strings"></param>
        public void Add(long contestRound, string[] csvline_strings)
        {
            try
            {
                if(false == participantService.IsExist(
                    csvline_strings[RegistrationService.CSV_DATA_JPNAME],
                    csvline_strings[RegistrationService.CSV_DATA_IDCODE]))
                {
                    //存在していなければ参加者を登録
                    participantService.Add(
                        csvline_strings[RegistrationService.CSV_DATA_JPNAME],
                        csvline_strings[RegistrationService.CSV_DATA_ENNAME],
                        csvline_strings[RegistrationService.CSV_DATA_IDCODE]);
                }

                //リザルトを登録
                resultService.Add(
                    csvline_strings[RegistrationService.CSV_DATA_IDCODE],
                    contestRound,
                    double.Parse(csvline_strings[RegistrationService.CSV_DATA_POINT]),
                    long.Parse(csvline_strings[RegistrationService.CSV_DATA_RANK]));

            }
            catch (EngineException)
            {
                throw;
            }

        }

        //データバリデーション
        private bool Validation(string[] csv_data, long dataCount)
        {
            if (csv_data.GetLength(0) <= dataCount)
            {
                ErrMsg = "データ数が不正です。<" + dataCount + 1 + ">";
                throw new EngineException(ErrMsg);
            }

            return true;
        }

        //１行分のデータを各文字列配列に格納
        private string[] ParseCsvLine(string csvline_strings)
        {
            return csvline_strings.Split(RegistrationService.DELIMITER);
        }

        //CSVの各行を読み込んで、List<string>に格納
        private List<string> ReadCSVLines(string path, string encoding = "SHIFT-JIS")
        {
            StreamReader sr = null;
            List<string> strRet = new List<string>();
            try
            {
                // CSVファイルオープン
                sr = new StreamReader(path, System.Text.Encoding.GetEncoding(encoding));

                String lin = "";
                do
                {
                    lin = sr.ReadLine();
                    if (lin != null)
                    {
                        strRet.Add(lin);
                    }
                } while (lin != null);
            }
            finally
            {
                if (null != sr)
                {
                    // CSVファイルクローズ
                    sr.Close();
                }
            }
            return strRet;

        }

        /// <summary>
        /// CSVをインポート
        /// </summary>
        /// <param name="contestRound"></param>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        public void ImportCSV(long contestRound, string path, string encoding = "SHIFT-JIS")
        {
            List<string> csvLines = null;

            if (!System.IO.File.Exists(path))
            {
                ErrMsg = "ファイルが見つかりません<" + path + ">";
                throw new EngineException(ErrMsg);
            }

            csvLines = ReadCSVLines(path, encoding);

            string[] csvParams = null;
            foreach (string eachLine in csvLines)
            {
                csvParams = ParseCsvLine(eachLine);
                Validation(csvParams, RegistrationService.CSV_DATA_TOTAL);
                Add(contestRound, csvParams);
            }
        }

        /// <summary>
        /// CSVにリザルトを出力
        /// </summary>
        /// <returns></returns>
        public string ExportCSV(long roundCnt)
        {
            //出力バッファ
            StringBuilder output = new StringBuilder();

            bool title_row = false;
            foreach (Rank rank in resultService.GetRanks())
            {
                //タイトル行描画
                if (false == title_row)
                {
                    output.Append(GetTitle(rank, roundCnt));
                    title_row = true;
                }
                //リザルト描画
                output.Append(GetRankData(rank, roundCnt));
            }

            return output.ToString();
        }

        /// <summary>
        /// ランキングデータを出力
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        public string GetRankData(Rank rank, long roundCnt)
        {
            Participant participant = null;
            participant = participantService.getParticipant(rank.IdCode);

            var items = new List<string>();
            items.Add(rank.Ranking.ToString());
            items.Add(participant.JpName);
            items.Add(participant.EnName);
            items.Add(participant.IdCode);

            var list = rank.Results.OrderBy(s => s.contestRound).ToDictionary(x => x.contestRound);

            for (long idx = 1; idx <= roundCnt; idx++)
            {
                if (!list.ContainsKey(idx))
                {
                    items.Add("0");
                }
                else
                {
                    items.Add(list[idx].point.ToString());
                }
            }

            items.Add(rank.Total.ToString());

            return string.Join(RegistrationService.DELIMITER.ToString(), items) + Environment.NewLine;
        }

        public string GetTitle(Rank rank, long roundCnt)
        {
            var items = new List<string> { "Ranking", "名前", "Name", "KOG#" };
            for (var i = 0; i < rank.Results.Count; i++)
            {
                items.Add("Round " + (i + 1));
            }
            items.Add("Total");
            // charなのでtoString()しなくてはならなくなります↓
            return string.Join(RegistrationService.DELIMITER.ToString(), items) + Environment.NewLine;
        }
    }
}