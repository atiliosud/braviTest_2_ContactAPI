using BancoTalentos.CandidatoService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoTalentos.CandidatoService.DataAccess.Context
{
    public class DbInitializer : IDisposable
    {
        ContatoContext _context;

        public void Dispose()
        {
            _context.Dispose();
            _context = null;

        }

        public DbInitializer(ContatoContext context)
        {
            _context = context;
            _context.Database.Migrate();
        }

        public void Seed()
        {
            SeedStates();
        }

        
        private void SeedStates()
        {
            #region BR
            _context.Estado.Add(new Estado { Codigo =  "AC", Name = "Acre" });
            _context.Estado.Add(new Estado { Codigo =  "AL", Name = "Alagoas" });
            _context.Estado.Add(new Estado { Codigo =  "AM", Name = "Amazonas" });
            _context.Estado.Add(new Estado { Codigo =  "AP", Name = "Amapá" });
            _context.Estado.Add(new Estado { Codigo =  "BA", Name = "Bahia" });
            _context.Estado.Add(new Estado { Codigo =  "CE", Name = "Ceará" });
            _context.Estado.Add(new Estado { Codigo =  "DF", Name = "Distrito Federal" });
            _context.Estado.Add(new Estado { Codigo =  "ES", Name = "Espírito Santo" });
            _context.Estado.Add(new Estado { Codigo =  "GO", Name = "Goiás" });
            _context.Estado.Add(new Estado { Codigo =  "MA", Name = "Maranhão" });
            _context.Estado.Add(new Estado { Codigo =  "MG", Name = "Minas Gerais" });
            _context.Estado.Add(new Estado { Codigo =  "MS", Name = "Mato Grosso do Sul" });
            _context.Estado.Add(new Estado { Codigo =  "MT", Name = "Mato Grosso" });
            _context.Estado.Add(new Estado { Codigo =  "PA", Name = "Pará" });
            _context.Estado.Add(new Estado { Codigo =  "PB", Name = "Paraíba" });
            _context.Estado.Add(new Estado { Codigo =  "PE", Name = "Pernambuco" });
            _context.Estado.Add(new Estado { Codigo =  "PI", Name = "Piauí" });
            _context.Estado.Add(new Estado { Codigo =  "PR", Name = "Paraná" });
            _context.Estado.Add(new Estado { Codigo =  "RJ", Name = "Rio de Janeiro" });
            _context.Estado.Add(new Estado { Codigo =  "RN", Name = "Rio Grande do Norte" });
            _context.Estado.Add(new Estado { Codigo =  "RO", Name = "Rondônia" });
            _context.Estado.Add(new Estado { Codigo =  "RR", Name = "Roraima" });
            _context.Estado.Add(new Estado { Codigo =  "RS", Name = "Rio Grande do Sul" });
            _context.Estado.Add(new Estado { Codigo =  "SC", Name = "Santa Catarina" });
            _context.Estado.Add(new Estado { Codigo =  "SE", Name = "Sergipe" });
            _context.Estado.Add(new Estado { Codigo =  "SP", Name = "São Paulo" });
            _context.Estado.Add(new Estado { Codigo =  "TO", Name = "Tocantins" });
            #endregion

            _context.SaveChanges();
        }
    }
}
