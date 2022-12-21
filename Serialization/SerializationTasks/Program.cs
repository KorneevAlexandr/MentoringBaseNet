
using SerializationTasks.Models;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

const string JsonFileName = "jsonEx.json";
const string XmlFileName = "xmlEx.xml";
const string BinaryFileName = "binaryEx.dat";

var department = new Department
{
    Name = "EPAM",
    Employees = new List<Employee>
    {
        new Employee { Name = "Alex" },
        new Employee { Name = "Maks" }
    }
};

var json = JsonSerialize(department, JsonFileName);
var xml = XmlSerialize(department, XmlFileName);
var bin = BinarySerialize(department, BinaryFileName);

Console.ReadLine();

static Department JsonSerialize(Department department, string fileName)
{
    using Stream stream = new FileStream(fileName, FileMode.Create);
    JsonSerializer.Serialize(stream, department);
    stream.Position = 0;

    return JsonSerializer.Deserialize<Department>(stream);
}

static Department XmlSerialize(Department department, string fileName)
{
    using Stream stream = new FileStream(fileName, FileMode.Create);
    var serializer = new XmlSerializer(typeof(Department));
    serializer.Serialize(stream, department);
    stream.Position = 0;

    var result = serializer.Deserialize(stream) as Department;
    return result;
}


static Department BinarySerialize(Department department, string fileName)
{
    using Stream stream = new FileStream(fileName, FileMode.Create);
    var formatter = new BinaryFormatter();
    formatter.Serialize(stream, department);
    stream.Position = 0;

    var result = formatter.Deserialize(stream) as Department;
    return result;
}
