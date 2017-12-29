using System;
using System.Collections.Generic;

namespace WebApi_Contatos.Models
{
    public interface IContatosRepositorio
    {
        void Adicionar(Contato item);
        IEnumerable<Contato> GetTodos();
        Contato Encontrar(String chave);
        void Remover(string Id);
        void Atualizar(Contato item);
    }
}
