
namespace KOGRankCalc
{
    class Result
    {
        public long contestRound { get; set; }
        public double point { get; set; }
        public long placing { get; set; }

        public Result(long contestRound, long placing, double point)
        {
            this.contestRound = contestRound;
            this.point = point;
            this.placing = placing;
        }
    }
}
