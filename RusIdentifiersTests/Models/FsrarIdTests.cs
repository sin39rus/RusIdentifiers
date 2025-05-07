using RusIdentifiers.Exceptions;
using RusIdentifiers.Models.FNS;
using RusIdentifiers.Models.FSRAR;
using RusIdentifiersTests.Helpers;

namespace RusIdentifiersTests
{
    [TestClass()]
    public class FsrarIdTests
    {
        [TestMethod]
        public void CreateValidFsrarId()
        {
            _ = new FsrarId("000000000000");
            _ = new FsrarId("020000024278");
            _ = new FsrarId("020000031756");
            _ = new FsrarId("020000034999");
            _ = new FsrarId("020000713566");
            _ = new FsrarId("030000736447");
            _ = new FsrarId("030000736840");
            _ = new FsrarId("030000737949");
            _ = new FsrarId("030000739241");
            _ = new FsrarId("030000739242");
        }

        [TestMethod]
        public void CreateNotValidFsrarId()
        {
            Assert.ThrowsException<RusIdentifiersArgumentException>(() =>
            {
                _ = new FsrarId("02000002427");
            });
            Assert.ThrowsException<RusIdentifiersArgumentException>(() =>
            {
                _ = new FsrarId("0200000242723");
            });
            Assert.ThrowsException<RusIdentifiersArgumentException>(() =>
            {
                _ = new FsrarId("A02000002422");
            });

            Assert.ThrowsException<RusIdentifiersArgumentException>(() =>
            {
                _ = new FsrarId("");
            });
            Assert.ThrowsException<RusIdentifiersArgumentNullException>(() =>
            {
                _ = new FsrarId(null);
            });
        }

        [TestMethod]
        public void ImplicitTests()
        {
            FsrarId id = "020000031756";
            Assert.AreEqual("020000031756", id.ToString());
        }

        [TestMethod]
        public void SerializeTest()
        {
            List<FsrarId> ids =
            [
                "020000031756",
                "030000736840"
            ];
            var xml = Serializer.SerializeObject(ids);
            var result = Serializer.DeserializeObject<List<FsrarId>>(xml);
        }

        [TestMethod]
        public void DeserializeTest()
        {
            var xml = @"<?xml version=""1.0"" encoding=""utf-8""?><ArrayOfFsrarId xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><FsrarId value=""020000031756"" /><FsrarId value=""030000736840"" /></ArrayOfFsrarId>";

            var result = Serializer.DeserializeObject<List<FsrarId>>(xml);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("020000031756", (string)result[0]);
            Assert.AreEqual("030000736840", (string)result[1]);
        }
    }
}