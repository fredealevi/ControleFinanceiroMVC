using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controle_Financeiro.ContextDb;
using Controle_Financeiro.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controle_Financeiro.Controllers
{
    public class ReservaEmergenciaController : Controller
    {
        private readonly BancoDbContext _tabela;
        public ReservaEmergenciaController(BancoDbContext banco)
        {
            _tabela = banco;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var depositos = _tabela.ReservaEmergencia.ToList();

            return View(depositos);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ReservaEmergencia reserva)
        {
            if(ModelState.IsValid)
            {
                _tabela.ReservaEmergencia.Add(reserva);
                _tabela.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(reserva);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var reserva = _tabela.ReservaEmergencia.Find(id);

            if(reserva == null) 
                return NotFound();

            return View(reserva);
        }

        [HttpPost]
        public IActionResult Editar(ReservaEmergencia reservaAtualizada)
        {
            var reservaEmergencia = _tabela.ReservaEmergencia.Find(reservaAtualizada.Id);

            reservaEmergencia.Valor = reservaAtualizada.Valor;
            reservaEmergencia.Tipo = reservaAtualizada.Tipo;

            _tabela.ReservaEmergencia.Update(reservaEmergencia);
            _tabela.SaveChanges();

            return RedirectToAction(nameof(Index)); 
        }

        [HttpGet]
        public IActionResult Detalhes(int id)
        {
            var reserva = _tabela.ReservaEmergencia.Find(id);

            if (reserva == null)
                return RedirectToAction(nameof(Index));

            return View(reserva);
        }

        [HttpGet]
        public IActionResult Deletar(int id)
        {
            var reserva = _tabela.ReservaEmergencia.Find(id);

            if( reserva == null)
                return RedirectToAction(nameof(Index));
            
            return View(reserva);
        }

        [HttpPost]
        public IActionResult Deletar(ReservaEmergencia reserva)
        {
            var reservaDeletar = _tabela.ReservaEmergencia.Find(reserva.Id);

            _tabela.ReservaEmergencia.Remove(reservaDeletar);
            _tabela.SaveChanges();

            return RedirectToAction(nameof(Index));
        }   

    }

}