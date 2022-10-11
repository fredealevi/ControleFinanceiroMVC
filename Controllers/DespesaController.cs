using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controle_Financeiro.ContextDb;
using Controle_Financeiro.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controle_Financeiro.Controllers
{
    public class DespesaController : Controller
    {
        private readonly BancoDbContext _tabela;
        public DespesaController(BancoDbContext context)
        {
            _tabela = context;
        }

        public IActionResult Index()
        {
            var despesas = _tabela.Despesas.ToList();

            return View(despesas);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                _tabela.Despesas.Add(despesa);
                _tabela.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(despesa);
        }

        [HttpGet]
        public IActionResult Editar(int Id)
        {
            var despesa = _tabela.Despesas.Find(Id);

            if (despesa == null)
                return NotFound();

            return View(despesa);
     
        }

        [HttpPost]
        public IActionResult Editar(Despesa despesaAtualizada)
        {
            var despesa = _tabela.Despesas.Find(despesaAtualizada.Id);

            despesa.Descricao = despesaAtualizada.Descricao;
            despesa.Valor = despesaAtualizada.Valor;

            _tabela.Despesas.Update(despesa);
            _tabela.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detalhes (int Id)
        {
            var despesa = _tabela.Despesas.Find(Id);

            if (despesa == null)
                return RedirectToAction(nameof(Index));

            return View(despesa);    
        }

        [HttpGet]
        public IActionResult Deletar(int Id)
        {
            var despesa = _tabela.Despesas.Find(Id);

            if(despesa == null)
                return RedirectToAction(nameof(Index));

            return View(despesa);
        }

        [HttpPost]
        public IActionResult Deletar(Despesa despesaDeletada)
        {
            var despesa = _tabela.Despesas.Find(despesaDeletada.Id);

            _tabela.Despesas.Remove(despesa);
            _tabela.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}