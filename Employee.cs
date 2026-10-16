using System;

namespace Lab2
{
    /// <summary>
    /// Сотрудник: имя и отдел, в котором он работает.
    /// </summary>
    public class Employee
    {
        private readonly Department _department;
        private string _name = string.Empty;

        public Employee(string name, Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }

            Name = name;
            _department = department;

            // Сотрудник сам добавляет себя в список сотрудников отдела.
            _department.AddEmployee(this);
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
                    throw new ArgumentException("Имя сотрудника не может быть пустым.", nameof(value));
                }

                _name = value.Trim();
            }
        }

        public Department Department
        {
            get
            {
                return _department;
            }
        }

        public bool IsChief
        {
            get
            {
                return ReferenceEquals(_department.Chief, this);
            }
        }

        public override string ToString()
        {
            if (IsChief)
            {
                return $"{_name} начальник отдела {_department.Name}";
            }

            Employee? chief = _department.Chief;

            if (chief == null)
            {
                return $"{_name} работает в отделе {_department.Name}, начальник пока не назначен";
            }

            return $"{_name} работает в отделе {_department.Name}, начальник которого {chief.Name}";
        }
    }
}
