using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIO.bank.Enum;

namespace DIO.bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");

            Console.ReadLine();
        }

        private static void Depositar()
        {
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            Console.Write("Digite o número da conta: ");
            if (!int.TryParse(Console.ReadLine(), out int indiceConta))
            {
                do
                {
                    Console.Write("Valor Inválido! \n Tente novamente:");

                } while (!int.TryParse(Console.ReadLine(), out indiceConta));

            }

            Console.Write("Digite o valor a ser depositado: ");
            if (!double.TryParse(Console.ReadLine(), out double valorDeposito))
            {
                do
                {
                    Console.Write("Valor Inválido! \n Tente novamente:");

                } while (!double.TryParse(Console.ReadLine(), out valorDeposito));

            }

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            Console.Write("Digite o número da conta: ");
            if (!int.TryParse(Console.ReadLine(), out int indiceConta))
            {
                do
                {
                    Console.Write("Valor Inválido! \n Tente novamente:");

                } while (!int.TryParse(Console.ReadLine(), out indiceConta));

            }

            Console.Write("Digite o valor a ser sacado: ");
            if (!double.TryParse(Console.ReadLine(), out double valorSaque))
            {
                do
                {
                    Console.Write("Valor Inválido! \n Tente novamente:");

                } while (!double.TryParse(Console.ReadLine(), out valorSaque));

            }

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Transferir()
        {
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            Console.Write("Digite o número da conta de origem: "); 
            if (!int.TryParse(Console.ReadLine(), out int indiceContaOrigem))
            {
                do
                {
                    Console.Write("Valor Inválido! \n Tente novamente:");

                } while (!int.TryParse(Console.ReadLine(), out indiceContaOrigem));

            }

            Console.Write("Digite o número da conta de destino: ");
            if (!int.TryParse(Console.ReadLine(), out int indiceContaDestino))
            {
                do
                {
                    Console.Write("Valor Inválido! \n Tente novamente:");

                } while (!int.TryParse(Console.ReadLine(), out indiceContaDestino));
            }

            Console.Write("Digite o valor a ser transferido: ");
            if (!double.TryParse(Console.ReadLine(), out double valorTransferencia))
            {
                do
                {
                    Console.Write("Valor Inválido! \n Tente novamente:");

                } while (!double.TryParse(Console.ReadLine(), out valorTransferencia));
            }

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void InserirConta()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Inserir nova conta");
            Console.WriteLine("-----------------------------------------------------------------");

            Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            if (!int.TryParse(Console.ReadLine(), out int entradaTipoConta))
            {
                do
                {
                    Console.Write("Valor Inválido! \n Tente novamente:");

                } while (!int.TryParse(Console.ReadLine(), out entradaTipoConta));

            }

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            if (!double.TryParse(Console.ReadLine(), out double entradaSaldo))
            {
                do
                {
                    Console.Write("Valor Inválido! \n Tente novamente:");

                } while (!double.TryParse(Console.ReadLine(), out entradaSaldo));

            }

            Console.Write("Digite o crédito: ");    
            if (!double.TryParse(Console.ReadLine(), out double entradaCredito))
            {
                do
                {
                    Console.Write("Valor Inválido! \n Tente novamente:");

                } while (!double.TryParse(Console.ReadLine(), out entradaCredito));

            }

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("-----------------------------------------------------------------");

            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}