using System;
using DIO.Bank.Model;
using DIO.Bank.Enum;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>(); //Collection
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Conta minhaConta = new Conta(TipoConta.PessoaFisica,100.00,50.00,"Amauri");
            //Console.WriteLine(minhaConta.ToString());
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario) {
                    case "1":
                    ListarContas();
                    break;
                    case "2":
                    InserirConta();
                    break;
                    case "3":
                    //Transferir();
                    break;
                    case "4":
                    //Sacar();
                    break;
                    case "5":
                    //Depositar();
                    break;
                    case "C":
                    Console.Clear();
                    break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }


        }

       
        private static void InserirConta() {
            Console.WriteLine("Inserir nova conta:");
            int entradaTipoConta = 0;
            bool validaTipoConta = false;
            while (!validaTipoConta)
            {
                Console.WriteLine("Digite o tipo de conta: 1 para Física e 2 para Jurídica");
                string entradaTipoContaString = Console.ReadLine();
                if (entradaTipoContaString == "1") 
                {
                    entradaTipoConta = int.Parse(entradaTipoContaString);
                    validaTipoConta = true;
                } else if (entradaTipoContaString == "2") {
                    entradaTipoConta = int.Parse(entradaTipoContaString);
                    validaTipoConta = true;
                } else {
                    Console.WriteLine("Tipo de Conta Inválido, escolha 1 para Física e 2 para Jurídica");
                }
            }
            Console.WriteLine("Digite o nome da conta:");
            string entradaNomeConta = Console.ReadLine();
            Console.WriteLine("Digite o saldo inicial da conta:");
            double entradaSaldoConta = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o crédito inicial da conta:");
            double entradaCreditoConta = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta:(TipoConta) entradaTipoConta
                                        ,entradaSaldoConta
                                        ,entradaCreditoConta
                                        ,entradaNomeConta);

            listaContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            foreach (Conta conta in listaContas){
                Console.WriteLine(conta.ToString());
            }
        }

        private static string ObterOpcaoUsuario() {
            Console.WriteLine();
            Console.WriteLine("DIO Bank ao seu dispor!");
            Console.WriteLine("1 - Lista Contas");
            Console.WriteLine("2 - Inserir Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }


    }
}
