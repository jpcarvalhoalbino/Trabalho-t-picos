using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas.Model
{
    abstract class Conta
    {
        public static long _contaMaiorSaldo;
        public static double _maiorSaldo;
        public static double _saldoTotalGeral=0;
        public long Numero { get; private set; }
        public double Saldo { get; protected set; }

        public Cliente Cliente { get; set; }
        public Agencia Agencia { get; set; }

        public Conta(long numero, Cliente cliente, double saldo)
        {
            Numero = numero;
            Cliente = cliente;
            if (saldo < 10)
                throw new ArgumentOutOfRangeException("O saldo deve ser maior ou igual a R$10,00");
            Saldo = saldo;
        }

        public override string ToString()
        {
            return $"Conta: {this.Numero}; Cliente: {this.Cliente.Nome}; Saldo: {this.Saldo}";
        }

        // o método Depositar modifica o saldo
        public abstract void Deposito(double valor);

        // o método Sacar modifica o saldo, sendo que neste caso o saldo nunca deve ficar negativo

        protected abstract void Saque(double valor);

        protected abstract void Transferencia(double valor, Conta destino);

        protected abstract void AtualizaMaiorSaldo();
      
    }
}
