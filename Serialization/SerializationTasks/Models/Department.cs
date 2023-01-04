namespace SerializationTasks.Models
{
    [Serializable]
    public class Department
    {
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            var department = obj as Department;

            if (department is null)
            {
                return false;
            }

            return Name.Equals(department.Name) && Employees.SequenceEqual(department.Employees);
        }

        public override int GetHashCode()
        {
            return Employees is not null ? Employees.Count : base.GetHashCode();
        }
    }
}
