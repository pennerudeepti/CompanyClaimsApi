using Microsoft.AspNetCore.Mvc;
using CompanyClaimApi.Models;
using Microsoft.EntityFrameworkCore;
using CompanyClaimApi.Domain;

namespace CompanyClaimApi.Data
{
    public interface ICompanyClaimsRepository
    {   
        public CompanyDto GetCompany(int id);

        public List<CompanyClaimsDto> GetClaimsForCompany(int id);    

        public ClaimDto GetClaimDetails(string ucr);

    }
}
