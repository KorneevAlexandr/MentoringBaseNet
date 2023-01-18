using NUnit.Framework;
using SerializationTasks.Models;
using SerializationTasks.Serializers;
using System.Collections.Generic;

namespace SerializationTests
{
    public class SerializersTests
    {
        private const string JsonFileName = "jsonEx.json";
        private const string XmlFileName = "xmlEx.xml";
        private const string BinaryFileName = "binaryEx.dat";

        private readonly static Department Department = new()
        {
            Name = "EPAM",
            Employees = new List<Employee>
            {
                new Employee { Name = "Alex" },
                new Employee { Name = "Maks" }
            }
        };

        private static object[] Serializers =
        {
            new object[] { new JsonFileSerializer(), JsonFileName },
            new object[] { new XmlFileSerializer(), XmlFileName },
            new object[] { new BinaryFileSerializer(), BinaryFileName }
        };

        [TestCaseSource(nameof(Serializers))]
        public void Serialize_WhenValueCorrect_ShouldReturnSameValue(IFileSerializer serializer, string fileName)
        {
            // Arrange, Act
            var actual = serializer.Serialize(Department, fileName);

            // Assert
            Assert.AreEqual(Department, actual);
        }
    }
}