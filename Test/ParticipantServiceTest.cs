using KOGRankCalc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
    
    
    /// <summary>
    ///ParticipantServiceTest のテスト クラスです。すべての
    ///ParticipantServiceTest 単体テストをここに含めます
    ///</summary>
    [TestClass()]
    public class ParticipantServiceTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///現在のテストの実行についての情報および機能を
        ///提供するテスト コンテキストを取得または設定します。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 追加のテスト属性
        // 
        //テストを作成するときに、次の追加属性を使用することができます:
        //
        //クラスの最初のテストを実行する前にコードを実行するには、ClassInitialize を使用
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //クラスのすべてのテストを実行した後にコードを実行するには、ClassCleanup を使用
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //各テストを実行する前にコードを実行するには、TestInitialize を使用
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //各テストを実行した後にコードを実行するには、TestCleanup を使用
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Validate のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("KOGRankCalc.exe")]
        public void ValidateTest()
        {
            ParticipantService_Accessor target = new ParticipantService_Accessor();
            target.Add( "Matthias Dandois", "マティアス　ダンドワ","P001");
            target.Add("Moto Sasaki", "佐々木　モト", "P002");

            string jpName = "佐々木　モト";
            string enName = "Moto Sasaki";
            string idCode = "P002";
            Participant_Accessor expected = null; // TODO: 適切な値に初期化してください
            Participant_Accessor actual = null;
            try
            {
                actual = target.Validate(jpName, enName, idCode);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        [DeploymentItem("KOGRankCalc.exe")]
        public void Validate2Test()
        {
            ParticipantService_Accessor target = new ParticipantService_Accessor();
            target.Add("Matthias Dandois", "マティアス　ダンドワ", "P001");
            target.Add("Moto Sasaki", "佐々木　モト", "P002");

            string jpName = "佐々木　モト";
            string enName = "Moto Sasaki";
            string idCode = "P001";
            Participant_Accessor expected = null; // TODO: 適切な値に初期化してください
            Participant_Accessor actual = null;
            try
            {
                actual = target.Validate(jpName, enName, idCode);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        [DeploymentItem("KOGRankCalc.exe")]
        public void Validate3Test()
        {
            ParticipantService_Accessor target = new ParticipantService_Accessor();
            target.Add("Matthias Dandois", "マティアス　ダンドワ", "P001");
            target.Add("Moto Sasaki", "佐々木　モト", "P002");

            string jpName = "アレックス　じゅめりん";
            string enName = "Alex Jumelin";
            string idCode = "P003";
            Participant_Accessor expected = null; // TODO: 適切な値に初期化してください
            Participant_Accessor actual = null;
            try
            {
                actual = target.Validate(jpName, enName, idCode);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                return;
            }
        }

    }
}
