using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Produto.Data;
using Produto.Models;

namespace Produto.Controllers
{
    public class EnderecoesController : Controller
    {
        private readonly ClienteContext _context;

        public EnderecoesController(ClienteContext context)
        {
            _context = context;
        }

        // GET: Enderecoes
        public async Task<IActionResult> Index()
        {
            var clienteContext = _context.Endereco.Include(e => e.Cliente);
            return View(await clienteContext.ToListAsync());
        }

        // GET: Enderecoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Endereco == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(m => m.ClienteForeignKey == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // GET: Enderecoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteForeignKey"] = new SelectList(_context.Cliente, "Cpf", "Cpf");
            return View();
        }

        // POST: Enderecoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cep,Cidade,Bairro,Logradouro,Numero,ClienteForeignKey")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(endereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteForeignKey"] = new SelectList(_context.Cliente, "Cpf", "Cpf", endereco.ClienteForeignKey);
            return View(endereco);
        }

        // GET: Enderecoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Endereco == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }
            ViewData["ClienteForeignKey"] = new SelectList(_context.Cliente, "Cpf", "Cpf", endereco.ClienteForeignKey);
            return View(endereco);
        }

        // POST: Enderecoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Cep,Cidade,Bairro,Logradouro,Numero,ClienteForeignKey")] Endereco endereco)
        {
            if (id != endereco.ClienteForeignKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(endereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoExists(endereco.ClienteForeignKey))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteForeignKey"] = new SelectList(_context.Cliente, "Cpf", "Cpf", endereco.ClienteForeignKey);
            return View(endereco);
        }

        // GET: Enderecoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Endereco == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(m => m.ClienteForeignKey == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // POST: Enderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Endereco == null)
            {
                return Problem("Entity set 'ClienteContext.Endereco'  is null.");
            }
            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco != null)
            {
                _context.Endereco.Remove(endereco);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoExists(string id)
        {
          return (_context.Endereco?.Any(e => e.ClienteForeignKey == id)).GetValueOrDefault();
        }
    }
}
