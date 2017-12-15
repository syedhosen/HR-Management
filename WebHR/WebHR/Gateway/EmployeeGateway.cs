using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebHR.Models;

namespace WebHR.Gateway
{
    public class EmployeeGateway : CommonGateway
    {
        public int Save(Employee employee)
        {
            Query = "INSERT INTO Employee(CompanyName,StationName,DepartmentName,EmployeeType,EmployeeCategory,Designation,WorkShift,Grade,FirstName,LastName,Username,Password)" +
                    " VALUES(@CompanyName,@StationName,@DepartmentName,@EmployeeType,@EmployeeCategory,@Designation,@WorkShift,@Grade,@FirstName,@LastName,@Username,@Password)";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("CompanyName", SqlDbType.VarChar);
            Command.Parameters["CompanyName"].Value = employee.CompanyName;

            Command.Parameters.Add("StationName", SqlDbType.VarChar);
            Command.Parameters["StationName"].Value = employee.StationName;

            Command.Parameters.Add("DepartmentName", SqlDbType.VarChar);
            Command.Parameters["DepartmentName"].Value = employee.DepartmentName;

            Command.Parameters.Add("EmployeeType", SqlDbType.VarChar);
            Command.Parameters["EmployeeType"].Value = employee.EmployeeType;

            Command.Parameters.Add("EmployeeCategory", SqlDbType.VarChar);
            Command.Parameters["EmployeeCategory"].Value = employee.EmployeeCategory;

            Command.Parameters.Add("Designation", SqlDbType.VarChar);
            Command.Parameters["Designation"].Value = employee.Designation;

            Command.Parameters.Add("WorkShift", SqlDbType.VarChar);
            Command.Parameters["WorkShift"].Value = employee.WorkShift;

            Command.Parameters.Add("Grade", SqlDbType.VarChar);
            Command.Parameters["Grade"].Value = employee.Grade;

            Command.Parameters.Add("FirstName", SqlDbType.VarChar);
            Command.Parameters["FirstName"].Value = employee.FirstName;

            Command.Parameters.Add("LastName", SqlDbType.VarChar);
            Command.Parameters["LastName"].Value = employee.LastName;

            Command.Parameters.Add("Username", SqlDbType.VarChar);
            Command.Parameters["Username"].Value = employee.Username;

            Command.Parameters.Add("Password", SqlDbType.VarChar);
            Command.Parameters["Password"].Value = employee.Password;

            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public List<Employee> GetAll()
        {
            Query = "SELECT FirstName, LastName, CompanyName, StationName, DepartmentName, EmployeeType, EmployeeCategory, Designation, WorkShift, Grade FROM Employee";
            SqlCommand Command = new SqlCommand(Query, Connection);
            List<Employee> employeeList = new List<Employee>();
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            while (reader.Read())
            {
                Employee employee = new Employee();

                employee.FirstName = reader["FirstName"].ToString();
                employee.LastName = reader["LastName"].ToString();
                employee.CompanyName = reader["CompanyName"].ToString();
                employee.StationName = reader["StationName"].ToString();
                employee.DepartmentName = reader["DepartmentName"].ToString();
                employee.EmployeeType = reader["EmployeeType"].ToString();
                employee.EmployeeCategory = reader["EmployeeCategory"].ToString();
                employee.Designation = reader["Designation"].ToString();
                employee.WorkShift = reader["WorkShift"].ToString();
                employee.Grade = reader["Grade"].ToString();
                employeeList.Add(employee);
            }

            reader.Close();
            return employeeList;
        }
    }
}