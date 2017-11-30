using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho.Models
{
    public class AgendaViewModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int Telefone { get; set; }
    }
}