using NUnit.Framework;
using CompanyClaimApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using CompanyClaimApi.Data;
using CompanyClaimApi.Models;
using CompanyClaimApi.Domain;

using System.Text.Json;

namespace CompanyClaimApiUnitTest
{
    [TestFixture]
    public class CompanyClaimsTest
    {
        private Mock<ICompanyClaimsRepository> _companyClaimsRepositoryMock;
        private CompanyClaimsController _companyClaimsController;

        [SetUp]
        public void SetUp()
        {
            _companyClaimsRepositoryMock = new Mock<ICompanyClaimsRepository>();
            _companyClaimsController = new CompanyClaimsController(_companyClaimsRepositoryMock.Object);
        }

        //Unit test case for single company
        [Test]
        public void GetSingleCompany()
        {
            // Arrange
            var expectedCompany = new CompanyDto { Id = 1, Name = "Company A", Address1 = "Company A Address line 1", Address2 = "Company A Address Line2", Address3 = "Company A Address Line3", Postcode = "Company A Postcode", Country = "UK", Active = true, InsuranceEndDate = DateTime.UtcNow.AddDays(30) };
            _companyClaimsRepositoryMock.Setup(r => r.GetCompany(1)).Returns(expectedCompany);

            // Act
            var result = _companyClaimsController.GetCompany(1);

            // Assert
            Assert.IsNotNull(result);

            var expectJson = JsonSerializer.Serialize(expectedCompany);

            var actualJson = ((ObjectResult)result).Value;

            Assert.AreEqual(expectJson, actualJson);
        }

        //Unit test case for claim detail
        [Test]
        public void GetClaimDetail()
        {
            // Arrange         
            var expectedClaim = new ClaimDto
            {
                ClaimId = 3,
                UCR = "UCR-789",
                CompanyId = 2,
                ClaimDate = DateTime.UtcNow.AddDays(-3),
                LossDate = DateTime.UtcNow.AddDays(-30),
                AssuredName = "Bob Smith",
                IncurredLoss = 300.0m,
                Closed = true
            };

            _companyClaimsRepositoryMock.Setup(r => r.GetClaimDetails("UCR-789")).Returns(expectedClaim);

            // Act
            var result = _companyClaimsController.GetClaimDetails("UCR-789");

            // Assert
            Assert.IsNotNull(result);

            var expectJson = JsonSerializer.Serialize(expectedClaim);

            var actualJson = ((ObjectResult)result).Value;

            Assert.AreEqual(expectJson, actualJson);
        }

    }

 
}