using NUnit.Framework;
using SerializationTasks.Models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SerializationTests
{
    public class CarSerializableTests
    {
		[Test]
		public void Serialize_WhenUseISerializableType_ShoulContainSerializableData()
		{
			// Arrange
			var car = new Car("Bentley", 2022);
			var binaryFormatter = new BinaryFormatter();
			var stream = new MemoryStream();

            // Act
            binaryFormatter.Serialize(stream, car);

            // Assert
            stream.Position = 0;
            var actual = Encoding.ASCII.GetString(stream.ToArray());

            Assert.True(actual.Contains(nameof(Car.Brand)));
            Assert.True(actual.Contains(nameof(Car.Year)));
        }
    }
}
