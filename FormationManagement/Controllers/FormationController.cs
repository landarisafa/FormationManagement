using ClubManagement.Entities;
using ClubManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                List<Formation> List = _formationService.GetListFormations();
                return Ok(List);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{idFormation}")]
        public IActionResult Get(string idFormation)
        {
            try
            {
                Formation formation = _formationService.GetFormationById(idFormation);
                return Ok(formation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Formation formationToUpdate)
        {
            try
            {
                Formation formation = await _formationService.UpdateFormation(formationToUpdate);
                return Ok(formation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{idFormation}")]
        public IActionResult Delete(string idFormation)
        {
            try
            {
                Formation formation = _formationService.DeleteFormation(idFormation);
                return Ok(formation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
