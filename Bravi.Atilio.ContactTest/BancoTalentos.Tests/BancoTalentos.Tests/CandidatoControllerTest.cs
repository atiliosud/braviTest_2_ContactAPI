using BancoTalentos.CandidatoService.Controllers;
using BancoTalentos.CandidatoService.Model;
using BancoTalentos.CandidatoService.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace BancoTalentos.Tests
{
    public class CandidatoControllerTest
    {
        CandidatoController _controller;
        IContatoRepository _repository;
        
        public CandidatoControllerTest(IContatoRepository candidatoRepository)
        {
            _repository = candidatoRepository;
            _controller = new CandidatoController(candidatoRepository);
        }

        [Fact]
        public void GetList()
        {
            var okResult = _controller.Get();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var candidato = new Contato()
            {
                Nome = "Atilio Camargo",
                UltimoNome ="Moreira",
                Email = "atiliosud@gmail.com",
                DataCriacao = DateTime.Now,
            };

            // Act
            var createdResponse = _controller.Create(candidato) as CreatedAtActionResult;
            var item = createdResponse.Value as Contato;

            // Assert
            Assert.IsType<Contato>(item);
            Assert.Equal("Atilio Camargo", item.Nome);
        }
    }
}
