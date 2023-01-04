using System;

namespace Camada.Domain.Models
{
    public class User
    {

		public int ID { get; set; }

		public string Nome { get; set; }// padrão c# == "case" 

		public string Senha { get; set; }

		public int TipoUsuario { get; set; }

		public bool IsAtivo { get; set; }

		public DateTime DataCriado { get; set; }

		public DateTime DataModificado { get; set; }


	}
}
