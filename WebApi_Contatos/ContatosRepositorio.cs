using System;
using System.Collections.Generic;
using WebApi_Contatos.Models;

namespace WebApi_Contatos
{
    public class ContatosRepositorio : IContatosRepositorio
    {
        static List<Contato> listaContatos = new List<Contato>();
        public void Adicionar(Contato item)
        {
            listaContatos.Add(item);
        }

        public IEnumerable<Contato> GetTodos()
        {
            return listaContatos;
        }

        public Contato Encontrar(string chave)
        {
            return listaContatos.Find(e => e.Telefone.Equals(chave));
        }

        public void Remover(string Id)
        {
            var itemARemover = listaContatos.Find(r => r.Telefone == Id);
            if (listaContatos != null)
                listaContatos.Remove(itemARemover);
        }

        public void Atualizar(Contato item)
        {
            var itemAtualizar = listaContatos.Find(r => r.Telefone == item.Telefone);
            if (itemAtualizar != null)
            {
                itemAtualizar.Nome = item.Nome;
                itemAtualizar.Sobrenome = item.Sobrenome;
                itemAtualizar.IsParente = item.IsParente;
                itemAtualizar.Empresa = item.Empresa;
                itemAtualizar.Email = item.Email;
                itemAtualizar.Telefone = item.Telefone;
                itemAtualizar.Nascimento = item.Nascimento;
            }
        }
    }
}
