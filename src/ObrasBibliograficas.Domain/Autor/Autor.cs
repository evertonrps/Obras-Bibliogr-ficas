using ObrasBibliograficas.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObrasBibliograficas.Domain
{
    public class Autor : Entity<Autor>
    {
        protected Autor(){ }

        public Autor(string nome)
        {
            FormatarNome(nome);
        }

        public readonly string[] names = { "FILHO", "FILHA", "NETO", "NETA", "SOBRINHO", "SOBRINHA", "JUNIOR" };

        public readonly string[] naoFazParteDoSobrenome = { "da", "de", "do", "das", "dos" };

        public string Nome { get; private set; }
        public string SobreNome { get; private set; }

        public bool ValidarNome(string nome)
        {
            return !string.IsNullOrEmpty(nome);
        }

        public bool ValidarNomeSimples(string nome)
        {
            return nome.Split(" ").Length == 1;
        }

        public string RecuperarSobrenome(string nome)
        {
            return nome.Split().Last().ToUpper();
        }

        public bool ValidarNomeComExcecao(string nome)
        {
            var sobrenome = RecuperarSobrenome(nome);
            return names.Contains(sobrenome);
        }

        public string RecuperarSobrenomeComExcecao(string nome)
        {
            var partes = RemoverComplementosDeNome(nome).Split();

            var sobreNome = string.Empty;

            if (partes.Count() > 2)
            {
                return sobreNome = $"{ partes[partes.Length - 2]} { partes[partes.Length - 1]}".ToUpper();
            }
            else
            {
                return partes.Last().ToUpper();
            }
        }

        public string RemoverComplementosDeNome(string nome)
        {
            string[] itens = nome.Split();

            itens = itens.Where(x => !naoFazParteDoSobrenome.Contains(x)).ToArray();

            return string.Join(" ", itens);
        }

        public string FormatarNome(string nome)
        {
            string nomeFormatado = string.Empty;
            string sobrenomeFormatado = string.Empty;

            if (ValidarNome(nome))
            {
                if (ValidarNomeSimples(nome))
                {
                    sobrenomeFormatado = RecuperarSobrenome(nome);
                    return sobrenomeFormatado;
                }
                else
                {
                    if (ValidarNomeComExcecao(nome))
                    {
                        sobrenomeFormatado = RecuperarSobrenomeComExcecao(nome);
                    }
                    else
                    {
                        sobrenomeFormatado = RecuperarSobrenome(nome);
                    }
                }
            }
            else
            {
                throw new Exception("Nome Inválido!");
            }

            nomeFormatado = AutorExtension.CustomToUppercase(nome.Replace(sobrenomeFormatado, "", StringComparison.OrdinalIgnoreCase));

            Nome = nomeFormatado;
            SobreNome = sobrenomeFormatado;

            return $"{sobrenomeFormatado}, {nomeFormatado}";
        }
    }
}
