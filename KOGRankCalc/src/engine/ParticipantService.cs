using System.Collections.Generic;
using System.Linq;

namespace KOGRankCalc
{
    class ParticipantService
    {
        //ユーザー
        List<Participant> participants = new List<Participant>();

        public ParticipantService()
        {
        }

        /// <summary>
        /// Participantオブジェクト生成
        /// </summary>
        /// <param name="JpName"></param>
        /// <param name="EnName"></param>
        /// <param name="IdCode"></param>
        public Participant Add(string jpName, string enName, string idCode)
        {
            var participant = Validate(jpName, enName, idCode);
            participants.Add(participant);

            return participant;
        }

        /// <summary>
        /// 同様の参加者が存在するか？
        /// </summary>
        /// <param name="contestRound"></param>
        /// <param name="IdCode"></param>
        /// <returns></returns>
        public bool IsExist(string jpName, string idCode)
        {
            int count = (from x in participants
                         where x.JpName == jpName && x.IdCode == idCode
                         select x.IdCode).Count();

            //該当ラウンドのリザルトがあったらスキップ
            return (0 == count) ? false : true;
        }

        /// <summary>
        /// 参加者追加時のバリデーション
        /// </summary>
        /// <param name="JpName"></param>
        /// <param name="EnName"></param>
        /// <param name="IdCode"></param>
        /// <returns></returns>
        private Participant Validate(string jpName, string enName, string idCode)
        {
            //同名なのに、IDが違う場合はエラー
            var pret = participants.Find(x => x.JpName == jpName && x.IdCode != idCode);
            if (null != pret)
            {
                throw new EngineException("同名でIDが異なります => 既存データ<" + pret.ToString() + "> 検索データ<" + idCode + ">");
            }

            //違う名前なのに、IDが同じ場合もエラー
            pret = participants.Find(x => x.JpName != jpName && x.IdCode == idCode);
            if (null != pret)
            {
                throw new EngineException("違う名前で、IDが同じです => " + pret.ToString() + "> 検索データ<" + jpName + ">");
            }

            return new Participant(jpName, enName, idCode);
        }

        /// <summary>
        /// 参加者を返却する
        /// <remarks>
        /// idCodeに該当する参加者を返却する
        /// </remarks>
        /// </summary>
        /// <param name="IdCode"></param>
        /// <returns></returns>
        public Participant getParticipant(string idCode)
        {
            var pret = participants.Single(x => x.IdCode == idCode);
            if (null == pret)
            {
                throw new EngineException("データが見つかりません => " + pret.ToString());
            }
            return pret;
        }
    }
}
