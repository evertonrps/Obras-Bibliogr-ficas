using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObrasBibliograficas.Domain.Utils
{
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
