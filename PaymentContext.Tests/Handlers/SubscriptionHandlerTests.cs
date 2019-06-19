using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
  [TestClass]
  public class SubscriptionHandlerTests
  {
    //Red, Green, Refactor
    [TestMethod]
    public void ShouldReturnErrorWhenDocumentExists()
    {
      var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
      var command = new CreateBoletoSubscriptionCommand();
      command.FirstName = "Treta";
      command.LastName = "Teste";
      command.Document = "99999999999";
      command.Email = "treta@mail.com";
      command.BarCode = "12345656";
      command.BoletoNumber = "123123123";
      command.PaymentNumber = "1231231231";
      command.PaidDate = DateTime.Now;
      command.ExpireDate = DateTime.Now.AddMonths(1);
      command.Total = 10;
      command.TotalPaid = 10;
      command.Payer = "Treta Corp";
      command.PayerDocument = "91823901893";
      command.PayerDocumentType = Domain.Enums.EDocumentType.CPF;
      command.PayerEmail = "treta@mail.com";
      command.Street = "asdsad";
      command.Number = "asdasd";
      command.Neighborhood = "asdasd";
      command.City = "asdasd";
      command.State = "asdad";
      command.Country = "asdasd";
      command.ZipCode = "12312312";

      handler.Handle(command);
      Assert.AreEqual(false, handler.Valid);
    }
  }
}

