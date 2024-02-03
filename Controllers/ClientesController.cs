using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroClientes.Context;
using CadastroClientes.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesContext _context;

        public ClientesController (ClientesContext context)
        {
            _context = context;
        }

        [HttpPost]

        public IActionResult Criar (Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();
            return Ok (cliente);
        }

        [HttpGet]

        public IActionResult Listar ( )
        {
            var cliente = _context.Clientes.ToList();
            return Ok (cliente);

        }

        [HttpDelete("{id}")]

        public IActionResult Delete ( int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
                return NotFound();
            
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return NoContent ();
        }

        [HttpPut("{id}")]

        public IActionResult UpDate (int id, Cliente cliente)
        {
            var clienteDB = _context.Clientes.Find(id);
            if (clienteDB == null)
                return NotFound();
            
            clienteDB.Nome = cliente.Nome;
            clienteDB.Telefone = cliente.Telefone;
            clienteDB.Status = cliente.Status;

            _context.Clientes.Update(clienteDB);
            _context.SaveChanges();

            return Ok (clienteDB);
        }

        
    }
}