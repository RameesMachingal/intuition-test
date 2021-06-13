using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    /// <summary>
    /// Class employee
    /// </summary>
    public class Employee
    {
        #region Private Members

        private int _id;
        private string _firstName;
        private string _lastName;
        private List<Employee> _employees;
        #endregion

        #region Public Properties

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        #endregion

        #region Constructor

        public Employee(int employeeID, string firstName, string lastName)
        {
            _id = employeeID;
            _firstName = firstName;
            _lastName = lastName;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Adds an Employee
        /// </summary>
        /// <param name="employee">employee</param>
        public void AddEmployee(Employee employee)
        {
            try
            {
                _employees.Add(employee);
            }
            catch
            {
                // To Do: Catch the exception and log it here
                throw new Exception("Failure in adding an employee");
            }
        }

        /// <summary>
        /// Gets an employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetEmployee(int id)
        {
            try
            {
                return _employees.First(e => e.ID == id);
            }
            catch
            {
                // To Do: Log the exception
                throw new Exception("No employee by id: " + id);
            }
        }

        /// <summary>
        /// Gets all the employees ordered by employee id
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetOrderedEmployeeArray()
        {
            try
            {
                return _employees.OrderBy(e => e.ID);
            }
            catch
            {
                throw new Exception("No employee exists");
            }
        }
        #endregion
    }
}
