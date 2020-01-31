using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace InjectionExample.model
{
    class BestStudentRepository : BaseStudentRepository
    {
        public override List<Student> GetStudents()
        {

            SqlCommand cmd = DatabaseConnection.CreateCommand();
            cmd.CommandText = "[dbo].[GetAllStudents]";
            cmd.CommandType = CommandType.StoredProcedure;

            return base.runSqlCmd(cmd);
        }

        public override List<Student> GetStudentsByLastName(string lastName)
        {
            SqlCommand cmd = DatabaseConnection.CreateCommand();
            cmd.CommandText = "[dbo].[GetStudentsByLastName]";
            cmd.Parameters.AddWithValue("LastName", lastName);
            cmd.CommandType = CommandType.StoredProcedure;

            return base.runSqlCmd(cmd);
        }
    }
}
