using EReconciliation.Business.Abstract;
using EReconciliation.Entities.Concrete;
using EReconciliation.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EReconciliation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyAccountController : ControllerBase
    {
        private readonly ICurrencyAccountService _currencyAccountService;

        public CurrencyAccountController(ICurrencyAccountService currencyAccountService)
        {
            _currencyAccountService = currencyAccountService;
        }

        [HttpPost("addFromExcel")]
        public IActionResult AddFromExcel(CurrencyAccountExcelDto currencyAccount)
        {
            if (currencyAccount.File.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + ".xlsx";
                var filePath = $"({Directory.GetCurrentDirectory()}/Content/{fileName})";
                using (FileStream stream = System.IO.File.Create(filePath))
                {
                    currencyAccount.File.CopyTo(stream);
                    stream.Flush();
                }

                var result = _currencyAccountService.AddToExcel(filePath);

                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result.Message);
            }

            return BadRequest("Dosya seçimi yapmadınız");
        }

        [HttpPost("add")]
        public IActionResult Add(CurrencyAccount currencyAccount)
        {
            var result = _currencyAccountService.Add(currencyAccount);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(CurrencyAccount currencyAccount)
        {
            var result = _currencyAccountService.Update(currencyAccount);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpPost("delete")]
        public IActionResult Delete(CurrencyAccount currencyAccount)
        {
            var result = _currencyAccountService.Delete(currencyAccount);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _currencyAccountService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("getlist")]
        public IActionResult GetList(int companyId)
        {
            var result = _currencyAccountService.GetList(companyId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
