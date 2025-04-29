using RusIdentifiersTests.Helpers;
using RusIdentifiers.Models.FNS;

namespace RusIdentifiersTests
{
    [TestClass()]
    public class InnTests
    {
        [TestMethod]
        public void CreateInn()
        {
            _ = new Inn("000000000000");
            _ = new Inn("592858264558");
            _ = new Inn("061881161242");
            _ = new Inn("722957296054");
            _ = new Inn("547535106103");
            _ = new Inn("310688186902");
            _ = new Inn("308377538412");
            _ = new Inn("188850893406");
            _ = new Inn("017775604290");
            _ = new Inn("672566255179");
            _ = new Inn("016548547407");
            _ = new Inn("213772702523");
            _ = new Inn("833527313904");
            _ = new Inn("296108996528");
            _ = new Inn("513302093328");
            _ = new Inn("897984042320");
            _ = new Inn("745938911633");
            _ = new Inn("272504421347");
            _ = new Inn("863744754359");
            _ = new Inn("498957915030");
            _ = new Inn("926411146100");
            _ = new Inn("916344732396");
            _ = new Inn("308941823834");
            _ = new Inn("806916525256");
            _ = new Inn("449713774401");
            _ = new Inn("473803682834");
            _ = new Inn("789587457570");
            _ = new Inn("403617289893");
            _ = new Inn("109949521782");
            _ = new Inn("909152441900");
            _ = new Inn("501009354659");
            _ = new Inn("440228332634");
            _ = new Inn("187102965614");
            _ = new Inn("231462036939");
            _ = new Inn("243708087485");
            _ = new Inn("551899768772");
            _ = new Inn("303416414051");
            _ = new Inn("029824668613");
            _ = new Inn("073325768980");
            _ = new Inn("353591238442");
            _ = new Inn("241887644062");
            _ = new Inn("254217257800");
            _ = new Inn("719299130020");
            _ = new Inn("581833324623");
            _ = new Inn("275112529105");
            _ = new Inn("539166566230");
            _ = new Inn("568873797915");
            _ = new Inn("483807044275");
            _ = new Inn("523802881309");
            _ = new Inn("423957441717");
            _ = new Inn("538508515712");
            _ = new Inn("0000000000");
            _ = new Inn("1013342652");
            _ = new Inn("0782500550");
            _ = new Inn("2573921894");
            _ = new Inn("5186592253");
            _ = new Inn("7922519821");
            _ = new Inn("1311640140");
            _ = new Inn("2534823445");
            _ = new Inn("5593042216");
            _ = new Inn("3824237691");
            _ = new Inn("8380519482");
            _ = new Inn("1923553334");
            _ = new Inn("4250945475");
            _ = new Inn("4683697590");
            _ = new Inn("9215432913");
            _ = new Inn("4761361695");
            _ = new Inn("0774917213");
            _ = new Inn("3107706531");
            _ = new Inn("4828086364");
            _ = new Inn("0839538054");
            _ = new Inn("0622510399");
            _ = new Inn("1442296469");
            _ = new Inn("7985331501");
            _ = new Inn("8717947907");
            _ = new Inn("8873148595");
            _ = new Inn("4018192815");
            _ = new Inn("6633833890");
            _ = new Inn("3955195533");
            _ = new Inn("8710104827");
            _ = new Inn("0754548293");
            _ = new Inn("5160579970");
            _ = new Inn("0419643708");
            _ = new Inn("4982243971");
            _ = new Inn("4012591228");
            _ = new Inn("6469221533");
            _ = new Inn("8546352505");
            _ = new Inn("1251939278");
            _ = new Inn("4538551852");
            _ = new Inn("4607152298");
            _ = new Inn("2678793921");
            _ = new Inn("2596466835");
            _ = new Inn("6655372635");
            _ = new Inn("6931110039");
            _ = new Inn("5137803550");
            _ = new Inn("5634820147");
            _ = new Inn("5568674028");
            _ = new Inn("7256112563");
            _ = new Inn("6410542520");
            _ = new Inn("4360837105");
            _ = new Inn("1752413687");
            _ = new Inn("5810826813");
        }

        [TestMethod]
        public void ImplicitTests()
        {
            Inn innFl = "592858264558";
            Inn innUl = "7922519821";
            string resultFl = innFl;
            string resultUl = innUl;
            Assert.AreEqual("592858264558", resultFl);
            Assert.AreEqual("7922519821", resultUl);
        }


        [TestMethod]
        public void SerializeTest()
        {
            List<Inn> inns =
            [
                "592858264558",
                "9215432913"
            ];
            Serializer.SerializeObject(inns);
        }

        [TestMethod]
        public void DeserializeTest()
        {
            var xml = @"﻿<?xml version=""1.0"" encoding=""utf-8""?><ArrayOfInn xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><Inn value=""592858264558""/><Inn value=""9215432913""/></ArrayOfInn>";
            var result = Serializer.DeserializeObject<List<Inn>>(xml);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("592858264558", (string)result[0]);
            Assert.AreEqual("9215432913", (string)result[1]);
        }

        [TestMethod]
        public void EqualsTest()
        {
            #region Arrange
            var value1 = new Inn("592858264558");
            var value2 = new Inn("592858264558");
            #endregion
            #region Action
            var result = value1 == value2;
            #endregion
            #region Assert
            Assert.IsTrue(result);
            #endregion
        }
    }
}