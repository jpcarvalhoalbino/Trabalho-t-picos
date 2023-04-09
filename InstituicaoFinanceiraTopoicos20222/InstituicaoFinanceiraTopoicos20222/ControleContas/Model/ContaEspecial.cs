using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas.Model
{
    internal class ContaEspecial : Conta
    {
        public ContaEspecial(long numero, Cliente cliente, double saldo) : base(numero, cliente, saldo)
        {
        }

        private double _limite = 1000;

        protected override void Saque(double valor)
        {
            if(Saldo < (valor + _limite))
            {
                throw new ArgumentException("O saldo não pode ficar negativo");
            }

            Saldo -= valor;
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
