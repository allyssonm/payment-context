using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entites;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries
{
  [TestClass]
  public class StudentQueriesTests
  {
    private IList<Student> _students;

    public StudentQueriesTests()
    {
        for (int i = 0; i < 10; i++)
        {
            _students.Add(
              new Student(
                new Name("Student", i.ToString()),
                new Document($"1111111111{i.ToString()}", Domain.Enums.EDocumentType.CPF),
                new Email($"{i.ToString()}@mail.com")
              )
            );
        }
    }

    //Red, Green, Refactor
    [TestMethod]
    public void ShouldReturnNullWhenDocumentNotExists()
    {
      var exp = StudentQueries.GetStudentInfo("12345678910");
      var student = _students.AsQueryable().Where(exp).FirstOrDefault();

      Assert.AreEqual(null, student);
    }

        [TestMethod]
    public void ShouldReturnStudentWhenDocumentExists()
    {
      var exp = StudentQueries.GetStudentInfo("11111111111");
      var student = _students.AsQueryable().Where(exp).FirstOrDefault();

      Assert.AreEqual(null, student);
    }
  }
}
