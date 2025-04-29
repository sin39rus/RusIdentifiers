using RusIdentifiers.Models.FNS;
using RusIdentifiersTests.Helpers;

namespace RusIdentifiersTests
{
    [TestClass()]
    public class KppTests
    {
        [TestMethod]
        public void CreateKpp()
        {
            _ = new Kpp("000000000");
            _ = new Kpp("802744679");
            _ = new Kpp("361401422");
            _ = new Kpp("331101368");
            _ = new Kpp("648245963");
            _ = new Kpp("457045666");
            _ = new Kpp("606744829");
            _ = new Kpp("871201723");
            _ = new Kpp("757544347");
            _ = new Kpp("892301620");
            _ = new Kpp("812643534");
            _ = new Kpp("365143275");
            _ = new Kpp("266243405");
            _ = new Kpp("422645788");
            _ = new Kpp("883843442");
            _ = new Kpp("237144719");
            _ = new Kpp("255745780");
            _ = new Kpp("822243455");
            _ = new Kpp("754144814");
            _ = new Kpp("078943954");
            _ = new Kpp("723545551");
            _ = new Kpp("237844126");
            _ = new Kpp("237701775");
            _ = new Kpp("713444264");
            _ = new Kpp("547501526");
            _ = new Kpp("475143654");
            _ = new Kpp("063444015");
            _ = new Kpp("709901888");
            _ = new Kpp("365243671");
            _ = new Kpp("586945961");
            _ = new Kpp("603901164");
        }

        [TestMethod]
        public void SerializeTest()
        {
            #region Arrange
            List<Kpp> kpps =
            [
                "457045666",
                "723545551"
            ];
            #endregion

            #region Action
            _ = Serializer.SerializeObject(kpps);
            #endregion
        }

        [TestMethod]
        public void DeserializeTest()
        {
            #region Arrange
            var xml = @"﻿<?xml version=""1.0"" encoding=""utf-8""?><ArrayOfKpp xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><Kpp value=""457045666""/><Kpp value=""723545551""/></ArrayOfKpp>";
            #endregion

            #region Action
            var result = Serializer.DeserializeObject<List<Kpp>>(xml);
            #endregion

            #region Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("457045666", result[0].ToString());
            Assert.AreEqual("723545551", result[1].ToString());
            #endregion
        }


        [TestMethod]
        public void ImplicitTests()
        {
            Kpp kpp1 = "709901888";
            Kpp kpp2 = "547501526";
            string result1 = kpp1;
            string result2 = kpp2;
            Assert.AreEqual("709901888", result1);
            Assert.AreEqual("547501526", result2);
        }

        [TestMethod]
        public void EqualsTest()
        {
            #region Arrange
            var value1 = new Kpp("709901888");
            var value2 = new Kpp("709901888");
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