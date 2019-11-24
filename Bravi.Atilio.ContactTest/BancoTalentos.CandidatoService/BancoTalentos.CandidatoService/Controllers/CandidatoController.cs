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
    [Route("api/v{version:apiVersion}/candidatos")]
    public class CandidatoController : ControllerBase
    {
        private IContatoRepository _contatoRepository;
        public CandidatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        [HttpGet()]
        [Route("List")]
        public ActionResult<List<Contato>> Get()
        {
            try
            {
                List<Contato> contatos = _contatoRepository.Get()
                       .OrderByDescending(x => x.Id).ToList();
                return Ok(new BancoTalentosJson<List<Contato>>().GetOK(contatos));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BancoTalentosJson<Contato>().GetInternalServerError(ex));
            }
        }

        [HttpGet()]
        public ActionResult<Contato> Get([FromQuery] int? id, [FromQuery] string name)
        {
            try
            {
                IQueryable<Contato> contatoQuery = _contatoRepository.Get()
                       .AsNoTracking();
                if (id.HasValue)
                {
                    contatoQuery = contatoQuery.Where(x => x.Id == id.Value);
                }
                if (!string.IsNullOrEmpty(name))
                {
                    contatoQuery = contatoQuery.Where(x => x.Nome == name);
                }
                Contato contato = contatoQuery.FirstOrDefault();
                return Ok(new BancoTalentosJson<Contato>().GetOK(contato));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BancoTalentosJson<Contato>().GetInternalServerError(ex));
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contato contato)
        {
            try
            {
                if (contato == null)
                {
                    return BadRequest(new BancoTalentosJson<Contato>().GetBadRequestNull());
                }
                _contatoRepository.Add(contato);
                return Ok(new BancoTalentosJson<Contato>().GetOK(contato));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BancoTalentosJson<Contato>().GetInternalServerError(ex));
            }
        }

        [HttpPut()]
        public IActionResult Update([FromBody] Contato contato)
        {
            try
            {
                if (contato == null)
                {
                    return BadRequest(new BancoTalentosJson<Contato>().GetBadRequestNull());
                }
                _contatoRepository.Update(contato);
                return Ok(new BancoTalentosJson<Contato>().GetOK(contato));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BancoTalentosJson<Contato>().GetInternalServerError(ex));
            }
        }

        [HttpDelete("{id:int?}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Contato contato = _contatoRepository.Get()
                       .OrderByDescending(x => x.Id).ToList().FirstOrDefault(x=>x.Id==id);

                if (contato == null)
                {
                    return BadRequest(new BancoTalentosJson<Contato>().GetBadRequestNull());
                }
                _contatoRepository.Delete(contato);
                return Ok(new BancoTalentosJson<Contato>().GetOK(contato));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BancoTalentosJson<Contato>().GetInternalServerError(ex));
            }
        }
    }
}
