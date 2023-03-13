using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyClaimApi.Data;
using CompanyClaimApi.Models;
using CompanyClaimApi.Domain;
using System.Text.Json;

namespace CompanyClaimApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyClaimsController : ControllerBase
    {      
        private readonly ICompanyClaimsRepository _companyClaimsRepository;
    
        public CompanyClaimsController(ICompanyClaimsRepository companyClaimsRepository)
        {
            _companyClaimsRepository = companyClaimsRepository;
        }

        //Single company endpoint to retrieve active insurance policy
       
        [HttpGet("company/{companyId}")]
        public IActionResult GetCompany(int id)
        {          
           return Ok(JsonSerializer.Serialize(_companyClaimsRepository.GetCompany(id)));
        }
       
        //Endpoint to get all claims against the company
        [HttpGet("company/{companyId}/claims")]
        public IActionResult GetClaimsForCompany(int id)
        {
            return Ok(JsonSerializer.Serialize(_companyClaimsRepository.GetClaimsForCompany(id)));
        }
       
        //End point to retrieve claim details by the ucr
        [HttpGet("claim/{ucr}")]
        public IActionResult GetClaimDetails(string ucr)
        {
            return Ok(JsonSerializer.Serialize(_companyClaimsRepository.GetClaimDetails(ucr)));
        }
    }
}
