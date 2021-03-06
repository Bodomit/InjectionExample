﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace InjectionExample.model.repos
{
    class BetterStudentRepository : BadStudentRepository
    {
        public override List<Student> GetStudentsByLastName(string lastName)
        {
            SqlCommand cmd = DatabaseConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM [dbo].[Students] WHERE LastName LIKE @lastName";
            cmd.Parameters.AddWithValue("lastName", lastName);
            return base.runSqlCmd(cmd);
        }
    }
}
