﻿using EReconciliation.Business.Abstract;
using EReconciliation.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EReconciliation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("getcompanylist")]

        public IActionResult GetCompanyList()
        {
            var result = _companyService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("addcompany")]
        public IActionResult AddCompany(Company company)
        {
            var result = _companyService.Add(company);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

    }
}
