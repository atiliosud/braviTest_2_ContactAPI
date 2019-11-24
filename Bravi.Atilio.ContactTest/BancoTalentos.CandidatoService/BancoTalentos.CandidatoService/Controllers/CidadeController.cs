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
    [Route("api/v{version:apiVersion}/cidades")]
    public class CidadeController : ControllerBase
    {
        private ICidadeRepository _cidadeRepository;
        public CidadeController(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        [HttpGet()]
        [Route("List")]
        public ActionResult<List<Cidade>> Get()
        {
            try
            {
                List<Cidade> cidades = _cidadeRepository.Get()
                       .Include(x => x.Estado)
                       .OrderByDescending(x => x.Nome).ToList();
                return Ok(new BancoTalentosJson<List<Cidade>>().GetOK(cidades));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BancoTalentosJson<Cidade>().GetInternalServerError(ex));
            }
        }

        [HttpGet()]
        public ActionResult<Cidade> Get([FromQuery] int? contatoId)
        {
            try
            {
                IQueryable<Cidade> cidadeQuery = _cidadeRepository.Get()
                       .Include(x => x.Estado)
                       .AsNoTracking();
                if (contatoId.HasValue)
                {
                    cidadeQuery = cidadeQuery.Where(x => x.Contato.Id == contatoId);
                }
                Cidade cidade = cidadeQuery.FirstOrDefault();
                return Ok(new BancoTalentosJson<Cidade>().GetOK(cidade));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BancoTalentosJson<Cidade>().GetInternalServerError(ex));
            }
        }
    }
}
