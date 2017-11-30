using NetCoders.Agenda.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trabalho.RegraDeNegocio;

namespace Trabalho.Controllers.Admin
{
    public class AgendaController : Controller
    {
        private AgendaService _service;

        public AgendaController()
        {
            _service = new AgendaService();
        }

        public ActionResult Index()
        {
            List<Dominio.Agenda> categoriasBanco = _service.ConsultaAgenda();

            List<AgendaViewModel> categoriasViewModel = new List<AgendaViewModel>();

            foreach (var agendaBanco in categoriasBanco)
            {
                categoriasViewModel.Add(new AgendaViewModel
                {
                    Codigo = agendaBanco.Codigo,
                    Bairro = agendaBanco.Bairro,
                    Cidade = agendaBanco.Cidade,
                    Endereco = agendaBanco.Endereco,
                    Nome = agendaBanco.Nome,
                    Telefone = agendaBanco.Telefone
                });
            }

            return View(categoriasViewModel);
        }

        public ActionResult Inserir()
        {
            return View();
        }

        public RedirectToRouteResult Excluir(int id)
        {
            _service.ApagarAgenda(id);

            return RedirectToAction("Index");
        }

        public ActionResult Detalhes(int id)
        {
            Dominio.Agenda categoriaDominio = _service.ConsultaAgenda(id);

            AgendaViewModel categoriaViewModel = new AgendaViewModel
            {
                Endereco = categoriaDominio.Endereco,
                Nome = categoriaDominio.Nome,
                Telefone = categoriaDominio.Telefone,
                Codigo = categoriaDominio.Codigo,
                Cidade = categoriaDominio.Cidade,
                Bairro = categoriaDominio.Bairro
            };

            return View(AgendaViewModel);
        }

        public ActionResult Alterar(int id)
        {
            Dominio.Agenda categoriaDominio = _service.ConsultaAgenda(id);

            AgendaViewModel categoriaViewModel = new AgendaViewModel
            {
                Endereco = categoriaDominio.Endereco,
                Nome = categoriaDominio.Nome,
                Telefone = categoriaDominio.Telefone,
                Codigo = categoriaDominio.Codigo,
                Cidade = categoriaDominio.Cidade,
                Bairro = categoriaDominio.Bairro
            };

            return View(categoriaViewModel);
        }

        public RedirectToRouteResult Salvar(AgendaViewModel agenda)
        {
            var categoriaDominio = new Dominio.Agenda
            {
                Bairro = agenda.Bairro,
                Cidade = agenda.Cidade,
                Codigo = agenda.Codigo,
                Telefone = agenda.Telefone,
                Nome = agenda.Nome,
                Endereco = agenda.Endereco
            };

            if (agenda.Codigo == 0)
            {
                int codigoGerado = _service.InserirAgenda(agendaDominio);
            }
            else
            {
                _service.AlterarAgenda(categoriaDominio);
            }


            return RedirectToAction("Index");
        }
    }
}