using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.AcessoDados;
using Trabalho.Dominio;

namespace Trabalho.RegraDeNegocio
{
    public class AgendaService
    {
        AgendaRepositorio _repositorio = new AgendaRepositorio();

        public List<Agenda> ConsultaAgenda()
        {
            return _repositorio.ConsultaAgenda();
        }

        public int InserirAgenda(Agenda agenda)
        {
            return _repositorio.InserirAgenda(agenda);
        }

        public void AlterarAgenda(Agenda agenda)
        {
            _repositorio.AlterarAgenda(agenda);
        }

        public void ApagarAgenda(int codigoAgenda)
        {
            _repositorio.ApagarAgenda(codigoAgenda);
        }

        public Agenda ConsultaAgenda(int codigoAgenda)
        {
            return _repositorio.ConsultaAgenda(codigoAgenda);
        }
    }
}
