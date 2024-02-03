using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Context
{
    public class ClientesContext : DbContext
    {
        public ClientesContext (DbContextOptions<ClientesContext> options) : base (options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}