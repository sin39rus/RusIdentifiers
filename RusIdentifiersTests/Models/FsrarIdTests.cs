using RusIdentifiers.Exceptions;
using RusIdentifiers.Models.FSRAR;

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

            Assert.ThrowsException<RusIdentifiersArgumentNullException>(() =>
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
    }
}