using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas.Model
{
    public class Agencia
    {
        public string None { get; set; }
        public int Numero { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public Banco Banco { get; set; }

        public Agencia(string none, int numero, Banco banco)
        {
            None = none;
            Numero = numero;
            Banco = banco;
        }
    }
}
