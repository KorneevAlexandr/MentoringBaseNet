namespace SerializationTasks.Models
{
    [Serializable]
    public class Employee
    {
        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            var employee = obj as Employee;

            if (employee is null)
            {
                return false;
            }

            return Name.Equals(employee.Name);
        }

        public override int GetHashCode()
        {
            return Name is not null ? Name.Length : base.GetHashCode();
        }
    }
}
