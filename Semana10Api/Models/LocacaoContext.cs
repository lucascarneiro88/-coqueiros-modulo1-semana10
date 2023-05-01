
using Microsoft.EntityFrameworkCore;
using Semana10Api.Models;

namespace Locacao.Context
{
    public class LocacaoContext : DbContext
    {
        public LocacaoContext(DbContextOptions<LocacaoContext> options) : base(options) { }
        public DbSet<CarroModel> Carro { get; set; }
        public DbSet<MarcaModel> Marca { get; set; }

       
       
    }
}