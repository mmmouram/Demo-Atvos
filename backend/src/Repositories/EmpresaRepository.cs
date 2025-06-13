using MyApp.Models;

namespace MyApp.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly AppDbContext _context;
        
        public EmpresaRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
