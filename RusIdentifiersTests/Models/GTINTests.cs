using RusIdentifiersTests.Helpers;
using RusIdentifiers.CRPT;
using RusIdentifiers.Exceptions;

namespace RusIdentifiersTests
{
    [TestClass()]
    public class GTINTests
    {
        [TestMethod]
        public void CreateGTIN()
        {
            _ = new GTIN("4650068810057");
            _ = new GTIN("04650068810057");
            _ = new GTIN("04603727743166");
            _ = new GTIN("04607047840055");
            _ = new GTIN("04607179833406");
            _ = new GTIN("04607179832072");
            _ = new GTIN("04607190621044");
            _ = new GTIN("04607052403351");
            _ = new GTIN("04607022661590");
            _ = new GTIN("04607004893322");
            _ = new GTIN("04607161624593");
            _ = new GTIN("04607016276748");
            _ = new GTIN("04606419024963");
            _ = new GTIN("04607037122352");
            _ = new GTIN("04607022662573");
            _ = new GTIN("04650060852277");
            _ = new GTIN("04620018341009");
            _ = new GTIN("04607004890680");
            _ = new GTIN("04620006003469");
            _ = new GTIN("07610563998299");
            _ = new GTIN("04605627011994");
            _ = new GTIN("04607029480460");
            _ = new GTIN("07610563996752");
            _ = new GTIN("04630086154692");
            _ = new GTIN("04630086157136");
            _ = new GTIN("04620006004510");
            _ = new GTIN("04620006004398");
            _ = new GTIN("04607022663785");
            _ = new GTIN("04605627012113");
            _ = new GTIN("04606419015428");
            _ = new GTIN("04690228006906");
            _ = new GTIN("04607016275314");
            _ = new GTIN("04650060854240");
            _ = new GTIN("04607016275291");
            _ = new GTIN("04607178790090");
            _ = new GTIN("04607016276731");
            _ = new GTIN("04607179833185");
            _ = new GTIN("04607004890673");
            _ = new GTIN("04607016275383");
            _ = new GTIN("04601751024916");
            _ = new GTIN("04600605033005");
            _ = new GTIN("04601662006162");
            _ = new GTIN("04607108093543");
            _ = new GTIN("04680126680223");
            _ = new GTIN("04610154300176");
            _ = new GTIN("04640001731099");
            _ = new GTIN("04607004891717");
            _ = new GTIN("04607023233246");
            _ = new GTIN("04605627012137");
            _ = new GTIN("04630024915255");
            _ = new GTIN("08000430133035");
            _ = new GTIN("04607047840482");
            _ = new GTIN("04605922024286");
            _ = new GTIN("04620006004565");
            _ = new GTIN("04620006003698");
            _ = new GTIN("07610617605197");
            _ = new GTIN("04620021193725");
            _ = new GTIN("04606419005870");
            _ = new GTIN("04607004890093");
            _ = new GTIN("04607168442169");
            _ = new GTIN("04690228006845");
            _ = new GTIN("04607004891397");
            _ = new GTIN("04620006003476");
            _ = new GTIN("04630012981347");
            _ = new GTIN("04606419021719");
            _ = new GTIN("04680000190039");
            _ = new GTIN("04605627006563");
            _ = new GTIN("04605922024385");
            _ = new GTIN("04607109474723");
            _ = new GTIN("04607053473698");
            _ = new GTIN("04605627004194");
            _ = new GTIN("04607052403986");
            _ = new GTIN("04607052403979");
        }

        [TestMethod]
        public void TestFieldGTIN()
        {
            var gtin1 = new GTIN("4650068810057");
            var gtin2 = new GTIN("04650068810057");

            Assert.AreEqual(465, gtin1.CoutnryCode);
            Assert.AreEqual(68, gtin1.ManufacturerCode);
            Assert.AreEqual(81005, gtin1.ProductCode);

            Assert.AreEqual(465, gtin2.CoutnryCode);
            Assert.AreEqual(68, gtin2.ManufacturerCode);
            Assert.AreEqual(81005, gtin2.ProductCode);
        }

        [TestMethod]
        public void CreateNotValidGtinsTests()
        {
            Assert.ThrowsException<RusIdentifiersArgumentException>(() => { GTIN gtin = ""; });
            Assert.ThrowsException<RusIdentifiersArgumentNullException>(() => { GTIN gtin = new GTIN(null); });
            Assert.ThrowsException<RusIdentifiersArgumentException>(() => { GTIN gtin = "04650068810056"; });
            Assert.ThrowsException<RusIdentifiersArgumentException>(() => { GTIN gtin = "04650068810050"; });
            Assert.ThrowsException<RusIdentifiersArgumentException>(() => { GTIN gtin = "04650068810059"; });
            Assert.ThrowsException<RusIdentifiersArgumentException>(() => { GTIN gtin = "04650068810058"; });
            Assert.ThrowsException<RusIdentifiersArgumentException>(() => { GTIN gtin = "04650068810055"; });
            Assert.ThrowsException<RusIdentifiersArgumentException>(() => { GTIN gtin = "04650068810054"; });
            Assert.ThrowsException<RusIdentifiersArgumentException>(() => { GTIN gtin = "046500688100"; });
            Assert.ThrowsException<RusIdentifiersArgumentException>(() => { GTIN gtin = "650068810057"; });
            Assert.ThrowsException<RusIdentifiersArgumentException>(() => { GTIN gtin = "046O0068810057"; });
        }

        [TestMethod]
        public void ImplicitTests()
        {
            GTIN gtin1 = "04650068810057";
            string resultGtin1 = gtin1;
            Assert.AreEqual("04650068810057", resultGtin1);

            GTIN gtin2 = "4650068810057";
            string resultGtin2 = gtin2;
            Assert.AreEqual("04650068810057", resultGtin2);
        }

        [TestMethod]
        public void SerializeTest()
        {
            List<GTIN> gtins =
            [
                "04650068810057",
                "4650068810057"
            ];
            var xml = Serializer.SerializeObject(gtins);
            var result = Serializer.DeserializeObject<List<GTIN>>(xml);
        }

        [TestMethod]
        public void DeserializeTest()
        {
            var xml = @"<?xml version=""1.0"" encoding=""UTF-8""?><ArrayOfGTIN xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""><GTIN value=""04650068810057""/><GTIN value=""04650068810057""/></ArrayOfGTIN>";
            var result = Serializer.DeserializeObject<List<GTIN>>(xml);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("04650068810057", (string)result[0]);
            Assert.AreEqual("04650068810057", (string)result[1]);
        }

        [TestMethod]
        public void EqualsTest()
        {
            #region Arrange
            var value1 = new GTIN("04650068810057");
            var value2 = new GTIN("4650068810057");
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