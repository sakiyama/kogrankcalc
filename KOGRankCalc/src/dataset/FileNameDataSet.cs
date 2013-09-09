using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KOGRankCalc
{
    //データグリッドビューファイルリスト制御用DataSet
    class FileNameDataSet
    {
        public string fileFullPath { get; set; }
        public int contestRound { get; set; }

        public FileNameDataSet()
        {
        }

        public FileNameDataSet(int contestRound, string fileFullPath)
        {
            this.contestRound = contestRound;
            this.fileFullPath = fileFullPath;
        }

    }
}