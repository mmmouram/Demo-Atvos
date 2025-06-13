using System;

namespace MyApp.Utils
{
    public static class CnpjValidator
    {
        public static bool ValidarCnpj(string cnpj)
        {
            // O CNPJ deve conter 14 caracteres
            if (string.IsNullOrWhiteSpace(cnpj) || cnpj.Length != 14)
                return false;

            // Converter cada caractere para um valor inteiro.
            // Se for dígito, utiliza seu valor; se for letra, utiliza o valor ASCII subtraído de 48 (A=17, B=18, etc.).
            int[] valores = new int[14];
            for (int i = 0; i < 14; i++)
            {
                char c = cnpj[i];
                if (char.IsDigit(c))
                {
                    valores[i] = c - '0';
                }
                else if (char.IsLetter(c))
                {
                    valores[i] = (int)c - 48;
                }
                else
                {
                    // Caracter inválido encontrado
                    return false;
                }
            }

            // Cálculo do primeiro dígito verificador utilizando os 12 primeiros caracteres
            int soma = 0;
            for (int i = 0; i < 12; i++)
            {
                int peso = 2 + (i % 8); // pesos de 2 a 9
                soma += valores[i] * peso;
            }
            int mod = soma % 11;
            int dv1 = (mod < 2) ? 0 : 11 - mod;
            if (dv1 != valores[12])
                return false;

            // Cálculo do segundo dígito verificador utilizando os 13 primeiros caracteres (incluindo o primeiro DV)
            soma = 0;
            for (int i = 0; i < 13; i++)
            {
                int peso = 2 + (i % 8);
                soma += valores[i] * peso;
            }
            mod = soma % 11;
            int dv2 = (mod < 2) ? 0 : 11 - mod;
            if (dv2 != valores[13])
                return false;

            return true;
        }
    }
}
