using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controle_Financeiro.ContextDb;
using Controle_Financeiro.Models;
using Microsoft.AspNetCore.Mvc;


namespace Controle_Financeiro.Controllers
{
    public class ReceitaController : Controller
    {
        private readonly BancoDbContext _tabela;
        public ReceitaController(BancoDbContext context)
        {
            _tabela = context;
        }

        public IActionResult Index()
        {
            var receitas = _tabela.Receitas.ToList();
            
            return View(receitas);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }
        // aprender a mandar mensagem de erro quando o valor for negativo
        [HttpPost]
        public IActionResult Criar(Receita receita)
        {
            if(ModelState.IsValid)
            {   
                if(receita.Valor > 0)
                {
                    _tabela.Receitas.Add(receita);
                    _tabela.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(receita);
        }
        
        [HttpGet]
        public IActionResult Editar(int Id)
        {   
            var receita = _tabela.Receitas.Find(Id);

            if (receita == null)
                return NotFound();
            
            return View(receita);
        }
         
        [HttpPost]
        public IActionResult Editar(Receita receitaAtualizada)
        {
            if (receitaAtualizada.Valor > 0)
            {
                var receita = _tabela.Receitas.Find(receitaAtualizada.Id);
                receita.Valor -= receitaAtualizada.Valor;
                
                if(receita.Valor > 0)
                {
                    // aprender a mandar mensagem de erro quando o valor for negativo
                    _tabela.Receitas.Update(receita);
                    _tabela.SaveChanges();
                    return RedirectToAction(nameof(Index));
                    
                }
            }
            // fazer se todo o valor for retirado, deletar o item.
            
            return RedirectToAction(nameof(Editar));
        }

        [HttpGet]
        public IActionResult Detalhes(int Id)
        {
            var receita = _tabela.Receitas.Find(Id);

            if (receita == null)
                return RedirectToAction(nameof(Index));

            return View(receita);
        }

        [HttpGet]
        public IActionResult Deletar(Receita receitaDeletar, int Id)
        {
            var receita = _tabela.Receitas.Find(Id);

            if(receita == null)
                return RedirectToAction(nameof(Index));

            return View(receita);
        }
        
        [HttpPost]
        public IActionResult Deletar (int Id)
        {
            var receita = _tabela.Receitas.Find(Id);

            if (receita == null)
                return RedirectToAction(nameof(Index));

            _tabela.Receitas.Remove(receita);
            _tabela.SaveChanges();   

            return RedirectToAction(nameof(Index));  
        }
    }
}