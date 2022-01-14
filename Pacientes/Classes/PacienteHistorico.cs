using System;
using System.Collections.Generic;
using Pacientes.Interfaces;
using Pacientes.Classes;
namespace Pacientes
{
    public class PacienteHistorico : IHistorico<Paciente>
    {
        private List<Paciente> listaPacientes = new List<Paciente>();
        public void Atualiza(int id,Paciente entidade)
        {
            listaPacientes[id] = entidade;
        }
        public void Exclui(int id)
        {
            listaPacientes[id].Excluir();
        }
        public void Insere(Paciente entidade)
        {
            listaPacientes.Add(entidade);
        }

        public List<Paciente> Lista()
        {
            return listaPacientes;
        }
        public int ProximoId()
        {
            return listaPacientes.Count;
        }

        public Paciente RetornaPorId(int id)
        {
            return listaPacientes[id];
        }
    }
}