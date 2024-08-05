﻿namespace Backend.DataObjects
{
    public class EmployeeBO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public decimal Salary { get; set; }
    }
}
