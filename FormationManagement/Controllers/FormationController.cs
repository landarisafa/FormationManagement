using ClubManagement.Entities;
using ClubManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FormationManagement.Controllers
{
    [Route("api/[controller]/[action]")]  
    [ApiController]
    public class FormationController : ControllerBase
    {
        private readonly IFormationService _formationService;

        public FormationController(IFormationService formationService)
        {
            _formationService = formationService;
        }

        [HttpPost]
        public IActionResult AddFormation([FromBody] Formation formationToSave)
        {
            try
            {
                if (formationToSave == null)
                {
                    return BadRequest("Aucune Formation trouvé!");
                }
                Formation saveResultItem = _formationService.AddFormation(formationToSave);
                return Ok(saveResultItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
