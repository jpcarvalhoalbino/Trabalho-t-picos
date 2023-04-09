using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas.Model
{
    internal class ContaCorrente : Conta
    {
        public ContaCorrente(long numero, Cliente cliente, double saldo) : base(numero, cliente, saldo)
        {
        }

        protected override void Saque(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentOutOfRangeException("valor inválido");
            }
            else if (valor + 0.1 > Saldo)
            {
                throw new ArgumentOutOfRangeException("Valor maior que saldo");
            }
            else
            {
                Saldo -= (valor + 0.1);
                _saldoTotalGeral -= valor;
            }
            AtualizaMaiorSaldo();
        }

        public override void Deposito(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentOutOfRangeException("valor invalido");
            }
            else
            {
                Saldo += valor;
                _saldoTotalGeral += valor;
            }

            AtualizaMaiorSaldo();
        }

        protected override void AtualizaMaiorSaldo()
        {
            if (this.Saldo > _maiorSaldo)
            {
                _contaMaiorSaldo = this.Numero;
                _maiorSaldo = this.Saldo;
            }
        }

        protected override void Transferencia(double valor, Conta destino)
        {
            this.Saque(valor);
            destino.Deposito(valor);
        }
    }
}
