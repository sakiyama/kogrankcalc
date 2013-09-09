
namespace KOGRankCalc
{
    class Participant : Base
    {
        public string JpName { get; set; }
        public string EnName { get; set; }
        public ResultService resultService;
        public string IdCode { get; set; }

        public Participant()
        {
        }

        public Participant(string jpName, string enName, string idCode)
        {
            this.JpName = jpName;
            this.EnName = enName;
            this.IdCode = idCode;
        }

        public override string ToString()
        {
            return "<" + IdCode + "> " + JpName;
        }
    }
}
