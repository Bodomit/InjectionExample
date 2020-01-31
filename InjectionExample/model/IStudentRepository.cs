using System;
using System.Collections.Generic;
using System.Text;

namespace InjectionExample.model
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
        List<Student> GetStudentsByLastName(string lastName);
        List<Student> ResetStudentsTable();
    }
}
