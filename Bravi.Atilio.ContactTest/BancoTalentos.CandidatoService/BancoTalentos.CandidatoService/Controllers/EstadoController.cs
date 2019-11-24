using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoTalentos.CandidatoService.Model;
using BancoTalentos.CandidatoService.Model.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BancoTalentos.CandidatoService.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Estados")]
    public class EstadoController : ControllerBase
    {
        private IEstadoRepository _EstadoRepository;
        public EstadoController(IEstadoRepository EstadoRepository)
        {
            _EstadoRepository = EstadoRepository;
        }

        [HttpGet()]
        [Route("List")]
        public ActionResult<List<Estado>> Get()
        {
            try
            {
                List<Estado> Estados = _EstadoRepository.Get()
                       .OrderByDescending(x => x.Name).ToList();
                return Ok(new BancoTalentosJson<List<Estado>>().GetOK(Estados));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BancoTalentosJson<Estado>().GetInternalServerError(ex));
            }
        }
    }
}
