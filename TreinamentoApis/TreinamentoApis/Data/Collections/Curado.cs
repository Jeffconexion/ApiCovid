using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreinamentoApis.Data.Collections
{
    public class Curado
    {
        public int QtPessoas { get; set; }
        public string Cidade { get; set; }

        public Curado(int qtPessoas, string cidade)
        {
            QtPessoas = qtPessoas;
            Cidade = cidade;
        }
    }
}
