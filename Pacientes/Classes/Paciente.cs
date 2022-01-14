using System;
using System.Collections.Generic;
namespace Pacientes.Classes
{
    public class Paciente : EntidadeBase
    {
        private string Nome {get;set;}
        private string CPF {get;set;}
        private int Idade {get;set;}
        private string Telefone{get;set;}
        private Medico Medico {get;set;}

        private string Ano {get;set;}

        private Tipo_Paciente p {get; set;}

        private double Valor {get;set;}

        private bool Excluido {get; set;}

        public Paciente(int id, string Nome, string CPF, int Idade, string Telefone, Medico Medico,string Ano, Tipo_Paciente p,double Valor)
        {
            this.Id = id;
            this.Nome = Nome;
            this.CPF = CPF;
            this.Idade = Idade;
            this.Telefone = Telefone;
            this.Medico = Medico;
            this.Ano = Ano;
            this.p = p;
            this.Valor = Valor;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Id: "+this.Id+Environment.NewLine;
            retorno += "Nome: "+this.Nome+Environment.NewLine;
            retorno += "CPF: "+this.CPF+Environment.NewLine;
            retorno += "Idade: "+this.Idade+Environment.NewLine;
            retorno += "Medico: "+this.Medico+Environment.NewLine;
            retorno += "Data: "+this.Ano+Environment.NewLine;
            retorno += "Tipo de Paciente: "+this.p+Environment.NewLine;
            retorno += "Telefone: "+this.Telefone+Environment.NewLine;
            retorno += "Valor: "+this.Valor+Environment.NewLine;
            return retorno;
        }

        public string retornaData()
        {
            return this.Ano;
        }
        public string retornaNomeCPF()
        {
            return this.Nome+"/"+this.CPF;
        }
        public int retornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
        public bool retornaExcluido()
		{
			return this.Excluido;
		}

    }
}