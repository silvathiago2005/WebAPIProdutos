using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi_Contatos.Models;

namespace WebApi_Contatos.Controllers
{
    [Route("api/[controller]")]//Este atributo é usado para definir um roteamento para acessar a WebApi
    public class ContatosController : Controller
    {
        public IContatosRepositorio contatosRepo { get; set; }//É instanciada usando uma injeção de dependências que é configurada em service.cs
        public ContatosController(IContatosRepositorio _repo)
        {
            contatosRepo = _repo;
        }
        [HttpGet]
        public IEnumerable<Contato> GetTodos(){//GetTodos - É um metodo HttpGet para obter todos os contatos
            return contatosRepo.GetTodos();
        }
        [HttpGet("{id}",Name = "GetContatos")]
        public IActionResult GetPorId(string Id)
        {
            var item = contatosRepo.Encontrar(Id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        [HttpPost]
        public IActionResult Criar([FromBody] Contato item)
        {
            if(item == null)
            {
                return BadRequest();
            }
            contatosRepo.Adicionar(item);
            return CreatedAtRoute("GetContatos", new { Controller = "Contatos", id = item.Telefone }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(string id, [FromBody] Contato item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = contatosRepo.Encontrar(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            contatosRepo.Atualizar(item);
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public void Deletar(string id)
        {
           contatosRepo.Remover(id);
        }
    }
}
