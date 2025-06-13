using MyApp.Models;

namespace MyApp.Services
{
    public interface IEmpresaService
    {
        CadastroEmpresaResponse CadastrarEmpresa(CadastroEmpresaRequest request);
    }
}
