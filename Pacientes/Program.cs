using System;
using Pacientes;
using Pacientes.Classes;

namespace Series // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static PacienteHistorico dados = new PacienteHistorico();
        static void Main(string[] args)
        {
            
            string opcao = ObterOpcaoUsuario();

            while(opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":
                    Listar();
                    break;
                    case "2":
                    Inserir();
                    break;
                    case "3":
                    Atualizar();
                    break;
                    case "4":
                    Excluir();
                    break;
                    case "5":
                    Visualizar();
                    break;
                    case "C":
                    Console.Clear();
                    break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcao = ObterOpcaoUsuario();
            }
            
        }

        private static void Listar()
        {
            Console.WriteLine("Lista de Pacientes:");

            var lista = dados.Lista();
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum Paciente Cadastrado!");
                return;
            }
            foreach (var paciente in lista)
            {
                var excluido = paciente.retornaExcluido();
                Console.WriteLine("ID - {0}: {1} {2}", paciente.retornaId(), paciente.retornaNomeCPF(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void Inserir()
        {
            Console.WriteLine("Inserir novo Paciente: ");


            Console.Write("Nome do Paciente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("CPF: ");
            string entradacpf = Console.ReadLine();

            Console.Write("Idade: ");
            int entradaidade = int.Parse(Console.ReadLine());

            Console.Write("Telefone: ");
            string entradatelefone = Console.ReadLine();

            Console.WriteLine("Médicos: ");
            foreach (int i in Enum.GetValues(typeof(Medico)))
            {
                Console.WriteLine("{0}-{1}",i,Enum.GetName(typeof(Medico),i));
            }
            Console.Write("Digite o Médico de acordo com as opções acima: ");
            int entradaMedico = int.Parse(Console.ReadLine());
            
            Console.Write("Data: ");
            string entradadata = Console.ReadLine();

            foreach (int j in Enum.GetValues(typeof(Tipo_Paciente)))
            {
                Console.WriteLine("{0}-{1}",j,Enum.GetName(typeof(Tipo_Paciente),j));
            }
            Console.Write("Digite o tipo de paciente de acordo com as opções acima: ");
            int entradatipo = int.Parse(Console.ReadLine());

            Console.Write("Valor da consulta: ");
            double entradavalor = double.Parse(Console.ReadLine());
            
            Paciente novoPaciente = new Paciente(id: dados.ProximoId(),
            Nome: entradaNome,
            CPF: entradacpf,
            Idade: entradaidade,
            Telefone: entradatelefone,
            Medico: (Medico) entradaMedico,
            Ano: entradadata,
            p: (Tipo_Paciente)entradatipo,
            Valor: entradavalor);

            dados.Insere(novoPaciente);
        }

        private static void Atualizar()
        {
            Console.Write("Digite o ID que deseja atualizar:");
            int entradaid = int.Parse(Console.ReadLine());
            var lista = dados.Lista();
            bool existe = false;

            foreach (var paciente in lista)
            {
                if(paciente.Id == entradaid){
                 var pes = paciente;
                 Console.WriteLine(pes);
                 existe = true;
                }
            }

            if(existe){

            Console.Write("Digite o novo Nome do Paciente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Novo CPF: ");
            string entradacpf = Console.ReadLine();

            Console.Write("Digite a nova Idade: ");
            int entradaidade = int.Parse(Console.ReadLine());

            Console.Write("Digit o novo Telefone: ");
            string entradatelefone = Console.ReadLine();

            Console.WriteLine("Médicos: ");
            foreach (int i in Enum.GetValues(typeof(Medico)))
            {
                Console.WriteLine("{0}-{1}",i,Enum.GetName(typeof(Medico),i));
            }
            Console.Write("Digite o novo Médico de acordo com as opções acima: ");
            int entradaMedico = int.Parse(Console.ReadLine());
            
            Console.Write("Digite a nova Data: ");
            string entradadata = Console.ReadLine();

            foreach (int j in Enum.GetValues(typeof(Tipo_Paciente)))
            {
                Console.WriteLine("{0}-{1}",j,Enum.GetName(typeof(Tipo_Paciente),j));
            }
            Console.Write("Digite o novo tipo de paciente de acordo com as opções acima: ");
            int entradatipo = int.Parse(Console.ReadLine());

            Console.Write("Digite o novo Valor da consulta: ");
            double entradavalor = double.Parse(Console.ReadLine());
            
            Paciente pacienteatualizado = new Paciente(id: entradaid,
            Nome: entradaNome,
            CPF: entradacpf,
            Idade: entradaidade,
            Telefone: entradatelefone,
            Medico: (Medico) entradaMedico,
            Ano: entradadata,
            p: (Tipo_Paciente)entradatipo,
            Valor: entradavalor);
            dados.Atualiza(entradaid, pacienteatualizado);
            }
            else{
                Console.WriteLine("Não existe um Paciente com o id informado!");
            }

        }

        private static void Excluir()
        {
            Console.Write("Digite o id do Paciente: ");
			int indicePaciente = int.Parse(Console.ReadLine());

			dados.Exclui(indicePaciente);
        }

        private static void Visualizar()
        {
            Console.Write("Digite o id do Paciente: ");
			int indicePaciente = int.Parse(Console.ReadLine());
            var paciente = dados.RetornaPorId(indicePaciente);
            var excluido = paciente.retornaExcluido();
            
            if(excluido)
            {
                Console.WriteLine("Paciente foi excluído!");
            }
            else{
			    Console.WriteLine(paciente);
            }
        }

        private static string ObterOpcaoUsuario()
            {
                Console.WriteLine();
                Console.WriteLine("Sistema de Cadastro de Pacientes da NicoMeds");
                Console.WriteLine("Informe a opção desejada:");

                Console.WriteLine("1 - Listar Pacientes Registrados");
                Console.WriteLine("2 - Registrar novo Paciente");
                Console.WriteLine("3 - Atualizar dados do Paciente");
                Console.WriteLine("4 - Excluir dados do paciente");
                Console.WriteLine("5 - Visualizar dados do paciente");
                Console.WriteLine("C - Limpar Tela");
                Console.WriteLine("X - Sair");
                Console.WriteLine();

                string opcaoescolhida = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoescolhida;
            }
    }
}