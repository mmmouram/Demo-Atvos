using MyApp.Models;
using MyApp.Repositories;
using MyApp.Utils;

namespace MyApp.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        
        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public CadastroEmpresaResponse CadastrarEmpresa(CadastroEmpresaRequest request)
        {
            if (string.IsNullOrEmpty(request.Cnpj))
                throw new ArgumentException("CNPJ é obrigatório.");

            // Validação do tamanho
            if (request.Cnpj.Length != 14)
                throw new ArgumentException("O CNPJ deve conter 14 caracteres.");

            // Validação de caracteres (somente letras e dígitos)
            foreach (var c in request.Cnpj)
            {
                if (!char.IsLetterOrDigit(c))
                    throw new ArgumentException("O CNPJ contém caracteres inválidos.");
            }

            // Regra para MEI: somente CNPJ numérico
            if (request.IsMei && request.Cnpj.Any(ch => !char.IsDigit(ch)))
                throw new ArgumentException("MEI aceita apenas CNPJ numérico.");

            // Validação do dígito verificador
            if (!CnpjValidator.ValidarCnpj(request.Cnpj))
                throw new ArgumentException("CNPJ inválido, falha na validação do dígito verificador.");

            // Criação da entidade
            var empresa = new Empresa
            {
                Cnpj = request.Cnpj,
                IsMei = request.IsMei
            };

            _empresaRepository.Adicionar(empresa);
            _empresaRepository.Salvar();

            return new CadastroEmpresaResponse
            {
                Id = empresa.Id,
                Cnpj = empresa.Cnpj,
                IsMei = empresa.IsMei
            };
        }
    }
}
