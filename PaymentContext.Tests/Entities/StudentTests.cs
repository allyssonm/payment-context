using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entites;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
  [TestClass]
  public class StudentTests
  {
    private readonly Student _student;
    private readonly Subscription _subscription;
    private readonly Name _name;
    private Document _document;
    private readonly Email _email;
    private Address _address;

    public StudentTests()
    {
      _name = new Name("Bruce", "Wayne");
      _document = new Document("012345678910", EDocumentType.CPF);
      _email = new Email("bruce@dc.com");
      _address = new Address("A", "7", "CI", "CWB", "PR", "BR", "8282828");
      _student = new Student(_name, _document, _email);
      _subscription = new Subscription(null);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
      var payment = new PayPalPayment("1234", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "TRETA CORP", _document, _address, _email);
      _subscription.AddPayment(payment);
      _student.AddSubscription(_subscription);
      _student.AddSubscription(_subscription);

      Assert.IsTrue(_student.Invalid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadSubscriptionHasNoPayment()
    {
      _student.AddSubscription(_subscription);
      Assert.IsTrue(_student.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenAddSubscription()
    {
      var payment = new PayPalPayment("1237774", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "TRETA CORP", _document, _address, _email);
      _subscription.AddPayment(payment);
      _student.AddSubscription(_subscription);
      Assert.IsTrue(_student.Valid);
    }
  }
}
