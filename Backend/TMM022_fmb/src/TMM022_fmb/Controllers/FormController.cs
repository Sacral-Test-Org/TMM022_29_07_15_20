using Microsoft.AspNetCore.Mvc;
using TMM022_fmb.Services;
using TMM022_fmb.DTOs;

namespace TMM022_fmb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpGet("initialize")] 
        public ActionResult<FormInitializationDTO> InitializeForm()
        {
            var formInitializationData = _formService.InitializeForm();
            return Ok(formInitializationData);
        }
    }
}