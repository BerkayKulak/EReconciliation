using EReconciliation.Business.Abstract;
using EReconciliation.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EReconciliation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountReconciliationsController : ControllerBase
    {
        private readonly IAccountReconciliationService _accountReconciliationsService;

        public AccountReconciliationsController(IAccountReconciliationService accountReconciliationsService)
        {
            _accountReconciliationsService = accountReconciliationsService;
        }


        [HttpPost("addFromExcel")]
        public IActionResult AddFromExcel(IFormFile file, int companyId)
        {
            if (file.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + ".xlsx";
                var filePath = $"{Directory.GetCurrentDirectory()}/Content/{fileName}";
                using (FileStream stream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }

                var result = _accountReconciliationsService.AddToExcel(filePath, companyId);

                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result.Message);
            }

            return BadRequest("Dosya seçimi yapmadınız");
        }

        [HttpPost("add")]
        public IActionResult Add(AccountReconciliation accountReconciliation)
        {
            var result = _accountReconciliationsService.Add(accountReconciliation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("update")]
        public IActionResult Update(AccountReconciliation accountReconciliation)
        {
            var result = _accountReconciliationsService.Update(accountReconciliation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("delete")]
        public IActionResult Delete(AccountReconciliation accountReconciliation)
        {
            var result = _accountReconciliationsService.Delete(accountReconciliation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _accountReconciliationsService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getlist")]
        public IActionResult GetList(int companyId)
        {
            var result = _accountReconciliationsService.GetList(companyId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
