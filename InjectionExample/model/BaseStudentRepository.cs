using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace InjectionExample.model
{
    abstract class BaseStudentRepository : IStudentRepository, IDisposable
    {
        protected SqlConnection DatabaseConnection { get; private set; }
         
        public BaseStudentRepository()
        {
            string connectionString = Properties.Settings.Default.connection_string;
            DatabaseConnection = new SqlConnection(connectionString);
        }

        public List<Student> ResetStudentsTable()
        {
            SqlCommand cmd = DatabaseConnection.CreateCommand();
            cmd.CommandText = "[dbo].[ResetStudentsTable]";
            cmd.CommandType = CommandType.StoredProcedure;

            return runSqlCmd(cmd);
        }

        protected List<Student> runSqlCmd(SqlCommand cmd)
        {
            using SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            using DataTable dataTable = new DataTable("Students");
            dataAdapter.Fill(dataTable);

            List <Student> students = new List<Student>();
            foreach(DataRow dataRow in dataTable.Rows)
            {
                Student student = new Student
                {
                    StudentID = (int)dataRow["StudentID"],
                    FirstName = dataRow["FirstName"].ToString(),
                    LastName = dataRow["LastName"].ToString(),
                    Phone = dataRow["Phone"].ToString(),
                    DOB = (DateTime)dataRow["DOB"]
                };
                students.Add(student);
            }

            return students;
        }


        public abstract List<Student> GetStudents();
        public abstract List<Student> GetStudentsByLastName(string lastName);


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DatabaseConnection.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BaseStudentRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
