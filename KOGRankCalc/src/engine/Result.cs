
namespace KOGRankCalc
{
    class Result : Base
    {
        public long contestRound { get; set; }
        public double point { get; set; }
        public long placing { get; set; }
        public string idCode { get; set; }

        public Result(string idCode, long contestRound, double point, long placing)
        {
            this.idCode = idCode;
            this.contestRound = contestRound;
            this.point = point;
            this.placing = placing;
        }

    }
}
