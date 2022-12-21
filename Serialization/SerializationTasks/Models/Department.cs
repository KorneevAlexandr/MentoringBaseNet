using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationTasks.Models
{
    [Serializable]
    public class Department
    {
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
