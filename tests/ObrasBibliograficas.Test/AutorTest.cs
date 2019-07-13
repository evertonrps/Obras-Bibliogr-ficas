using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace ObrasBibliograficas.Test
{
    public class AutorTest
    {
        /*
            Quando se lista o nome de autores de livros, artigos e outras publicações é comum que se apresente o nome do autor ou dos autores da seguinte forma: sobrenome do autor em letras maiúsculas, 
            seguido de uma vírgula e da primeira parte do nome apenas com as iniciais maiúsculas.

            Por exemplo:

            SILVA, Joao
            COELHO, Paulo
            ARAUJO, Celso de
            Seu desafio é fazer um programa que leia um número inteiro correspondendo ao número de nomes que será fornecido, e, a seguir, leia estes nomes (que podem estar em qualquer tipo de letra) 
            e imprima a versão formatada no estilo exemplificado acima.

            As seguintes regras devem ser seguidas nesta formatação:

            o sobrenome será igual a última parte do nome e deve ser apresentado em letras maiúsculas;
            se houver apenas uma parte no nome, ela deve ser apresentada em letras maiúsculas (sem vírgula): se a entrada for “ Guimaraes” , a saída deve ser “ GUIMARAES”;
            se a última parte do nome for igual a "FILHO", "FILHA", "NETO", "NETA", "SOBRINHO", "SOBRINHA" ou "JUNIOR" e houver duas ou mais partes antes, a penúltima parte 
            fará parte do sobrenome. Assim: se a entrada for "Joao Silva Neto", a saída deve ser "SILVA NETO, Joao" ; se a entrada for "Joao Neto" , a saída deve ser "NETO, Joao";
            as partes do nome que não fazem parte do sobrenome devem ser impressas com a inicial maiúscula e com as demais letras minúsculas;
            "da", "de", "do", "das", "dos" não fazem parte do sobrenome e não iniciam por letra maiúscula.         
        */

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Autor_Nao_Deve_Possuir_Um_Nome_Invalido_Fail(string nome)
        {
            var autor = new Autor();
            Assert.False(autor.ValidarNome(nome));
        }

        [Theory]
        [InlineData("Paulo Coelho")]
        [InlineData("Jorge Amado")]
        [InlineData("Sócrates")]
        public void Autor_Nao_Deve_Possuir_Um_Nome_Valido_Success(string nome)
        {
            var autor = new Autor();
            Assert.True(autor.ValidarNome(nome));
        }

        [Theory]
        [InlineData("Paulo")]
        [InlineData("Jorge")]
        [InlineData("Sócrates")]
        [InlineData("Akira")]
        public void Autor_Deve_Possuir_Somente_Nome_Success(string nome)
        {
            var autor = new Autor();
            Assert.True(autor.ValidarNomeSimples(nome));
        }

        [Theory]
        [InlineData("Paulo Coelho")]
        [InlineData("Jorge Amado")]
        public void Autor_Deve_Possuir_Somente_Nome_Fail(string nome)
        {
            var autor = new Autor();
            Assert.False(autor.ValidarNomeSimples(nome));
        }


        [Fact]
        public void Autor_Deve_Recuperar_Sobrenome_Success()
        {
            var nome = "Paulo Coelho";
            var autor = new Autor();
            Assert.Equal("Coelho".ToUpper(), autor.RecuperarSobrenome(nome));
        }

        [Fact]
        public void Autor_Deve_Recuperar_Nome_Simples_Success()
        {
            var nome = "Paulo";
            var autor = new Autor();
            Assert.Equal("Paulo".ToUpper(), autor.RecuperarSobrenome(nome));
        }

        [Theory]
        [InlineData("Paulo Coelho")]
        [InlineData("Jorge Amado")]
        [InlineData("Sócrates")]
        public void Autor_Deve_Possuir_Nome_Com_Excecao_Fail(string nome)
        {
            var autor = new Autor();

            Assert.False(autor.ValidarNomeComExcecao(nome));
        }

        [Theory]
        [InlineData("Joao Silva Neto")]
        [InlineData("Joao Silva Neta")]
        [InlineData("Joao Silva Filho")]
        [InlineData("Joao Silva Filha")]
        [InlineData("Joao Silva Sobrinho")]
        [InlineData("Joao Silva Sobrinha")]
        [InlineData("Joao Silva Junior")]
        public void Autor_Deve_Possuir_Nome_Com_Excecao_Success(string nome)
        {
            var autor = new Autor();

            Assert.True(autor.ValidarNomeComExcecao(nome));
        }

        [Fact]
        public void Autor_Deve_Recuperar_Sobrenome_De_Nome_Com_Excecao_Success()
        {
            var nome = "Paulo da Silva Neto";
            var autor = new Autor();
            Assert.Equal("Silva Neto".ToUpper(), autor.RecuperarSobrenomeComExcecao(nome));
        }

        [Fact]
        public void Autor_Deve_Recuperar_Sobrenome_De_Nome_Com_Excecao_Simples_Success()
        {
            var nome = "Paulo Neto";
            var autor = new Autor();
            Assert.Equal("Neto".ToUpper(), autor.RecuperarSobrenomeComExcecao(nome));
        }

        [Theory]
        [InlineData("Joao Silva da Neto")]
        public void Autor_Deve_Remover_Complementos_De_Nome_Success(string nome)
        {
            var autor = new Autor();

            Assert.Equal("Joao Silva Neto", autor.RemoverComplementosDeNome(nome));
        }


        [Fact]
        public void Autor_Deve_Recuperar_Nome_Formatado_Success()
        {
            var autor = new Autor();

            Assert.Equal("PAULO", autor.FormatarNome("Paulo"));
            Assert.Equal("SILVA NETO, Paulo da", autor.FormatarNome("Paulo da Silva Neto"));
            Assert.Equal("ASSIS, Machado de", autor.FormatarNome("Machado de Assis"));
            Assert.Equal("ROSA, Guimaraes", autor.FormatarNome("Guimaraes Rosa"));
            Assert.Equal("AMADO, Jorge", autor.FormatarNome("Jorge Amado"));
            Assert.Equal("NETO, João", autor.FormatarNome("João Neto"));
        }
    }

    public class Autor
    {
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

            }

            nomeFormatado = AutorExtension.CustomToUppercase(nome.Replace(sobrenomeFormatado, "", StringComparison.OrdinalIgnoreCase));

            Nome = nomeFormatado;
            SobreNome = sobrenomeFormatado;

            return $"{sobrenomeFormatado}, {nomeFormatado}";
        }
    }
    public static class AutorExtension
    {
        public static string[] naoFazParteDoSobrenome = { "da", "de", "do", "das", "dos" };

        public static string CustomToUppercase(string value)
        {
            var palavras = value.Split(" ");

            List<string> upword = new List<string>();

            foreach (var item in palavras)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (!naoFazParteDoSobrenome.Contains(item.ToLower()))
                    {
                        string s = item;
                       upword.Add(char.ToUpper(s[0]) + s.Substring(1));
                    }
                    else
                    {
                        upword.Add(item);
                    }

                }
            }
            var result = String.Join(" ", upword.ToArray());
            return result;
        }
    }
}
