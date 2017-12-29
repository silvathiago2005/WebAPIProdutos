﻿using System;
namespace WebApi_Contatos.Models
{
    public class Contato
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public bool IsParente { get; set; }
        public string Empresa { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime Nascimento { get; set; }
    }
}