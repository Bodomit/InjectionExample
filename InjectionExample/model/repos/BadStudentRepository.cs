using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace InjectionExample.model.repos
{
    class BadStudentRepository : BaseStudentRepository
    {
        public override List<Student> GetStudents()
        {

            SqlCommand cmd = DatabaseConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM [dbo].[Students]";

            return base.runSqlCmd(cmd);
        }

        public override List<Student> GetStudentsByLastName(string lastName)
        {
            SqlCommand cmd = DatabaseConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM [dbo].[Students] WHERE LastName LIKE '" + lastName + "'";

            return base.runSqlCmd(cmd);
        }
    }
}
