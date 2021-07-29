using System;
using System.Collections.Generic;

namespace DIO.Bank {

	class Program {

		static List<Conta> listaContas = new List<Conta>();

		static void Main(string[] args) {

			string opcaoUsuario = obterOpcaoUsuario();

			while (opcaoUsuario != "x") {
				switch (opcaoUsuario) {
					case "1":
						listarContas(); break;
					case "2":
						inserirConta(); break;
					case "3":
						transferir(); break;
					case "4":
						sacar(); break;
					case "5":
						depositar(); break;
                    case "c":
						Console.Clear(); break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = obterOpcaoUsuario();
			}
			
			Console.WriteLine("Obrigado por utilizar nossos serviços.\n");
		}

		private static void depositar() {
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].depositar(valorDeposito);
		}

		private static void sacar() {
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].sacar(valorSaque);
		}

		private static void transferir() {
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].transferir(valorTransferencia, listaContas[indiceContaDestino]);
		}

		private static void inserirConta() {
			Console.WriteLine("Inserir nova conta");
			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Cliente: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double entradaCredito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta((TipoConta)entradaTipoConta, entradaSaldo,
										entradaCredito, entradaNome);

			listaContas.Add(novaConta);
		}

		private static void listarContas() {
			Console.WriteLine("Listar contas");

			if (listaContas.Count == 0) {
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < listaContas.Count; i++) {
				Conta conta = listaContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}
		}

		private static string obterOpcaoUsuario() {
			Console.WriteLine();
			Console.WriteLine("DIO Bank a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1 - Listar contas");
			Console.WriteLine("2 - Inserir nova conta");
			Console.WriteLine("3 - Transferir");
			Console.WriteLine("4 - Sacar");
			Console.WriteLine("5 - Depositar");
            Console.WriteLine("c - Limpar Tela");
			Console.WriteLine("x - Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
