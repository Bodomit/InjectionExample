using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace InjectionExample.model
{
    class BadStudentRepository : BaseStudentRepository
    {
        public override List<Student> GetStudents()
        {

            SqlCommand cmd = DatabaseConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM[dbo].[Students]";

            return base.runSqlCmd(cmd);

        }

        #region Warning Surpression
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "<Pending>")]
        #endregion

        public override List<Student> GetStudentsByLastName(string lastName)
        {
            SqlCommand cmd = DatabaseConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM[dbo].[Students] WHERE LastName == " + lastName;

            return base.runSqlCmd(cmd);
        }
    }
}
