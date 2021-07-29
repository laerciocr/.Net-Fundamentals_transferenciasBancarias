using System;

namespace DIO.Bank {

    public class Conta {
       	private TipoConta _tipoConta;
		private double _saldo, _credito;
        private string _nome;

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome) {
			_tipoConta = tipoConta;
			_saldo = saldo;
			_credito = credito;
			_nome = nome;
		}

		public bool sacar(double valorSaque) {
            if (valorSaque > (_saldo + _credito)) {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            else {
                _saldo -= valorSaque;
                Console.WriteLine("Saldo atual da conta de {0} é {1}", _nome, _saldo);
                // https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting
                return true;
            }
		}

		public void depositar(double valorDeposito) {
			_saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", _nome, _saldo);
		}

		public void transferir(double valorTransferencia, Conta contaDestino) {
			if (this.sacar(valorTransferencia))
                contaDestino.depositar(valorTransferencia);
		}

        public override string ToString() {
            string retorno = "";
            retorno += "TipoConta " + _tipoConta + " | ";
            retorno += "Nome " + _nome + " | ";
            retorno += "Saldo " + _saldo + " | ";
            retorno += "Crédito " + _credito;
			return retorno;
		}

    }
}