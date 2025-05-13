using RusIdentifiers.Exceptions;
using RusIdentifiers.FSRAR;
using RusIdentifiersTests.Helpers;

namespace RusIdentifiersTests
{
    [TestClass()]
    public class AlcoCodeTests
    {
        [TestMethod]
        public void CreateValidFsrarId()
        {
            _ = new AlcoCode("0000000000000000000");
            _ = new AlcoCode("0000000000021872113");
            _ = new AlcoCode("0000000000021872117");
            _ = new AlcoCode("0000000000021872119");
            _ = new AlcoCode("0000000000021897039");
            _ = new AlcoCode("0000000000021961263");
            _ = new AlcoCode("0000000000022009747");
            _ = new AlcoCode("0000000000022009752");
            _ = new AlcoCode("0000000000022009755");
            _ = new AlcoCode("0000000000022009756");
            _ = new AlcoCode("0000000000022439323");
            _ = new AlcoCode("0000000000022439327");
            _ = new AlcoCode("0000000000022439331");
            _ = new AlcoCode("0000000000022439446");
            _ = new AlcoCode("0000000000022492511");
            _ = new AlcoCode("0000000000022594828");
            _ = new AlcoCode("0000000000022594830");

        }

        [TestMethod]
        public void CreateNotValidFsrarId()
        {
            Assert.ThrowsException<RusIdentifiersArgumentException>(() =>
            {
                _ = new AlcoCode("00000000000220097561");
            });
            Assert.ThrowsException<RusIdentifiersArgumentException>(() =>
            {
                _ = new AlcoCode("000000000002200975");
            });
            Assert.ThrowsException<RusIdentifiersArgumentException>(() =>
            {
                _ = new AlcoCode("A000000000022439446");
            });
            Assert.ThrowsException<RusIdentifiersArgumentException>(() =>
            {
                _ = new AlcoCode("");
            });
            Assert.ThrowsException<RusIdentifiersArgumentNullException>(() =>
            {
                _ = new AlcoCode(null);
            });
        }

        [TestMethod]
        public void ImplicitTests()
        {
            AlcoCode alcoCode = "0000000000022009756";
            Assert.AreEqual("0000000000022009756", alcoCode.ToString());
        }

        [TestMethod]
        public void SerializeTest()
        {
            List<AlcoCode> ids =
            [
                "0000000000022009756",
                "0000000000022594830"
            ];
            _ = Serializer.SerializeObject(ids);
        }

        [TestMethod]
        public void DeserializeTest()
        {
            var xml = @"<?xml version=""1.0"" encoding=""utf-8""?><ArrayOfAlcoCode xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><AlcoCode value=""0000000000022009756"" /><AlcoCode value=""0000000000022594830"" /></ArrayOfAlcoCode>";

            var result = Serializer.DeserializeObject<List<AlcoCode>>(xml);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("0000000000022009756", (string)result[0]);
            Assert.AreEqual("0000000000022594830", (string)result[1]);
        }
    }
}