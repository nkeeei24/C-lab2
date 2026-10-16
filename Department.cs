using System;
using System.Collections.Generic;

namespace Lab2
{
    /// <summary>
    /// Отдел: название, начальник и список всех сотрудников.
    /// </summary>
    public class Department
    {
        private readonly List<Employee> _employees;
        private string _name = string.Empty;
        private Employee? _chief;

        public Department(string name)
        {
            _employees = new List<Employee>();
            Name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Название отдела не может быть пустым.", nameof(value));
                }

                _name = value.Trim();
            }
        }

        public Employee? Chief
        {
            get
            {
                return _chief;
            }

            set
            {
                if (value != null && value.Department != this)
                {
                    throw new ArgumentException(
                        "Начальником может быть только сотрудник этого отдела.",
                        nameof(value));
                }

                _chief = value;
            }
        }

        // Возвращаем копию списка, чтобы снаружи нельзя было испортить состав отдела.
        public List<Employee> Employees
        {
            get
            {
                return new List<Employee>(_employees);
            }
        }

        // Вызывается из конструктора Employee, поэтому доступен только внутри проекта.
        internal void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public override string ToString()
        {
            string chiefName = _chief == null ? "не назначен" : _chief.Name;

            return $"Отдел {_name}, начальник: {chiefName}, сотрудников: {_employees.Count}";
        }
    }
}
