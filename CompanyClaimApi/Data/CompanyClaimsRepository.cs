using CompanyClaimApi.Models;
using CompanyClaimApi.Data;
using CompanyClaimApi.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using NuGet.Protocol;

namespace CompanyClaimApi.Data
{
    public class CompanyClaimsRepository : ICompanyClaimsRepository
    {
        private readonly List<Claim> _claims;
        private readonly List<ClaimType> _claimTypes;
        private readonly List<Company> _companies;

        public CompanyClaimsRepository()
        {
            // Generate test data
            _claimTypes = new List<ClaimType>
            {
                new ClaimType {Id = 1, Name = "Type A"},
                new ClaimType {Id = 2, Name = "Type B"},
                new ClaimType {Id = 3, Name = "Type C"}
            };

            _companies = new List<Company>
            {
                new Company {Id = 1, Name = "Company A", Address1 = "Company A Address line 1", Address2 = "Company A Address Line2", Address3 = "Company A Address Line3", Postcode= "Company A Postcode", Country="UK", Active = true, InsuranceEndDate = DateTime.UtcNow.AddDays(30)},
                new Company {Id = 2, Name = "Company B", Address1 = "Company B Address line 1", Address2 = "Company B Address Line2", Address3 = "Company B Address Line3", Postcode= "Company B Postcode", Country="UK", Active = false, InsuranceEndDate = DateTime.UtcNow.AddDays(-30)}
            };

            _claims = new List<Claim>
            {
                new Claim
                {
                    ClaimId = 1,
                    UCR = "UCR-123",
                    CompanyId = 1,
                    ClaimDate = DateTime.UtcNow.AddDays(-10),
                    LossDate = DateTime.UtcNow.AddDays(-15),
                    AssuredName = "John Doe",
                    IncurredLoss = 100.0m,
                    Closed = false,
                    TypeId = 1
                },
                new Claim
                {
                    ClaimId = 2,
                    UCR = "UCR-456",
                    CompanyId = 1,
                    ClaimDate = DateTime.UtcNow.AddDays(-5),
                    LossDate = DateTime.UtcNow.AddDays(-20),
                    AssuredName = "Jane Doe",
                    IncurredLoss = 200.0m,
                    Closed = false,
                    TypeId = 2
                },
                new Claim
                {
                    ClaimId = 3,
                    UCR = "UCR-789",
                    CompanyId = 2,
                    ClaimDate = DateTime.UtcNow.AddDays(-3),
                    LossDate = DateTime.UtcNow.AddDays(-30),
                    AssuredName = "Bob Smith",
                    IncurredLoss = 300.0m,
                    Closed = true,
                    TypeId = 3
                }
            };
        }
     
        public CompanyDto GetCompany(int companyId)
        {
            var company = _companies.FirstOrDefault(c => c.Id == companyId);
            if (company == null)
            {
               return CompanyNotFound();
               //return NotFound(HttpStatusCode.NotFound, "Company does not exist.");
            }

            var response = new CompanyDto
            {
                Id = company.Id,
                Name = company.Name,
                Active = company.Active,
                HasActiveInsurancePolicy = company.InsuranceEndDate >= DateTime.UtcNow
            };

            return response;
        } 
      
        public List<CompanyClaimsDto> GetClaimsForCompany(int companyId)
        {
            var claims = _claims.Where(c => c.CompanyId == companyId).ToList();

            if (claims.Count == 0)
            {
                return CompanyClaimsNotFound();
            }

            var response = claims.Select(c => new CompanyClaimsDto
            {
                CompanyId = companyId,
                CompanyName = _companies.FirstOrDefault(t => t.Id == c.CompanyId)?.Name,
                ClaimId = c.ClaimId,
                UCR = c.UCR                
            }).ToList();

            return response;
        }
       
        public ClaimDto GetClaimDetails(string ucr)
        {
            var claim = _claims.Where(c => c.UCR == ucr).FirstOrDefault();

            if (claim == null)
            {
                return ClaimDetailNotFound();
            }

            var response = new ClaimDto
            {
                ClaimId = claim.ClaimId,
                UCR = claim.UCR,
                ClaimDate = claim.ClaimDate,
                LossDate = claim.LossDate,
                AssuredName = claim.AssuredName,
                IncurredLoss = claim.IncurredLoss,
                Closed = claim.Closed,
                Type = _claimTypes.FirstOrDefault(t => t.Id == claim.TypeId)?.Name,
                DaysOld = (DateTime.UtcNow - claim.ClaimDate).Days
            };

            return response;
        }

        private List<CompanyClaimsDto> CompanyClaimsNotFound()
        {
            throw new NotImplementedException();
        }

        private CompanyDto CompanyNotFound()
        {
           throw new NotImplementedException();            
        }

        private ClaimDto ClaimDetailNotFound()
        {
            throw new NotImplementedException();
        }

    }
}
