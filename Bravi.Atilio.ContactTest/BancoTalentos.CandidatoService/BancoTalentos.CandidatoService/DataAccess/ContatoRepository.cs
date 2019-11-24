using BancoTalentos.CandidatoService.DataAccess.Context;
using BancoTalentos.CandidatoService.Model;
using BancoTalentos.CandidatoService.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoTalentos.CandidatoService.DataAccess
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(ContatoContext context) : base(context)
        {

        }
    }
}
