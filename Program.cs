using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace RegexTeste
{

    class RegexGlobo
    {
        public static void Main(string[] args)
        {
            WebRequest requisicao = HttpWebRequest.Create("https://g1.globo.com/");
            requisicao.Method = "GET";

            string fonte;
            using (StreamReader reader = new StreamReader(requisicao.GetResponse().GetResponseStream()))
            {
                fonte = reader.ReadToEnd();
            }    

            string palavraParaLocalizar = "corona";
            int numeroPalavra = ContagemPalavra(palavraParaLocalizar,fonte);

            if (numeroPalavra>0) {
                System.Console.WriteLine("O número de palavras '" + palavraParaLocalizar + "' encontrado no site g1 é: " + numeroPalavra);
            } else {
                System.Console.WriteLine("Não encontrado a palavra '" + palavraParaLocalizar + "' no site.");
            }
        }        

        private static int ContagemPalavra(string palavra, string texto)
        {
            var regex = new Regex(string.Format(@"\b{0}\b", palavra),RegexOptions.IgnoreCase);
            return regex.Matches(texto).Count;
        }
    }
}
