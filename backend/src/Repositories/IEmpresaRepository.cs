using MyApp.Models;

namespace MyApp.Repositories
{
    public interface IEmpresaRepository
    {
        void Adicionar(Empresa empresa);
        void Salvar();
    }
}
