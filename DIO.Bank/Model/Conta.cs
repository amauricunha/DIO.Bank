using System;
using DIO.Bank.Enum;

namespace DIO.Bank.Model
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        //Método construtor: chamado no momento que é criado o objeto.
        public Conta (TipoConta tipoConta, double saldo, double credito, string nome){
            //this é para alterar a instância chamado, e não todas elas.
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
         }

         public bool Sacar (double valorSaque){
             if ((this.Saldo - valorSaque) < (this.Credito*-1))
             {
                 Console.WriteLine("Saldo insuficiente");
                 return false;
             }
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual de {0} é {1}",this.Nome, this.Saldo); //formatação composta
            return true;
         }

         public void Depositar (double valorDeposito) {
             this.Saldo += valorDeposito;
             Console.WriteLine("Depósito realizado com sucesso");
             Console.WriteLine("Saldo atual de {0} é {1}",this.Nome, this.Saldo);
         }

         public void Transferir (double valorTransferencia, Conta contaDestino) {
             if (this.Sacar(valorTransferencia)) //já tenho validação neste método, não é necessário retornar bool
             {
                 contaDestino.Depositar(valorTransferencia); //também já tenho retorno descritivo neste método.
             }
         }

        public override string ToString() //sobrescrevendo o método padrão ToString. Muito usado para logs.
        {
            string retorno = "";
            retorno += "Tipo Conta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Crédito: " + this.Credito;
            return retorno;
        }
    }
}