using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
  [TestClass]
  public class DocumentTests
  {
    //Red, Green, Refactor
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
      var doc = new Document("123", EDocumentType.CNPJ);
      Assert.IsTrue(doc.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCNPJIsInvalid()
    {
      var doc = new Document("12345678901234", EDocumentType.CNPJ);
      Assert.IsTrue(doc.Valid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
      var doc = new Document("123", EDocumentType.CPF);
      Assert.IsTrue(doc.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCPFIsInvalid()
    {
      var doc = new Document("09876543210", EDocumentType.CPF);
      Assert.IsTrue(doc.Valid);
    }
  }
}
