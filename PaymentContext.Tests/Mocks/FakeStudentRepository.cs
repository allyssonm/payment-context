using PaymentContext.Domain.Entites;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks
{
  public class FakeStudentRepository : IStudentRepository
  {
    public void CreateSubscription(Student student)
    {

    }

    public bool DocumentExists(string document)
    {
      if (document == "99999999999")
        return true;

      return false;
    }

    public bool EmailExists(string email)
    {
      if (email == "email@mail.com")
        return true;

      return false;
    }
  }
}