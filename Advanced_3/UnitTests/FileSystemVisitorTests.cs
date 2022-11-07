using Library;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace UnitTests
{
    public class Tests
    {
        private string _directory;

        [SetUp]
        public void Setup()
        {
            _directory = "D";
            string inner = "D/Inner";
            string inner2 = "D/Inner2";
            string innerDeep = "D/Inner/InnerDeep";

            Directory.CreateDirectory(_directory);
            Directory.CreateDirectory(inner);
            Directory.CreateDirectory(inner2);
            Directory.CreateDirectory(innerDeep);
        }

        [Test, Order(1)]
        public void GetTree_WhenDirectoryExist_ShouldReturnCorrectRoot()
        {
            // Arrange
            var visitor = new FileSystemVisitor(_directory);

            // Act
            var tree = visitor.GetTree();

            // Assert
            Assert.AreEqual("D", tree.Name);
        }

        [Test, Order(100)]
        public void GetTree_WhenDirectoryExist_ShouldReturnAllFiles()
        {
            // Arrange
            var visitor = new FileSystemVisitor(_directory);

            // Act
            var tree = visitor.GetTree();

            // Assert
            var inner = tree.GetChildren().First();
            var inner2 = tree.GetChildren().Last();
            var innerDeep = inner.GetChildren().First();

            Assert.IsTrue(tree.IsComposite());
            Assert.AreEqual("D", tree.Name);
            Assert.AreEqual("Inner", inner.Name);
            Assert.AreEqual("Inner2", inner2.Name);
            Assert.AreEqual("InnerDeep", innerDeep.Name);
        }
    }
}