﻿using System.Collections.Generic;

namespace EmployeeData
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }
        public List<Employee> Employees { get; set; }  = new List<Employee>();
    }
}
