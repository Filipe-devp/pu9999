using Camada.structure.DapperMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camada.InfraStructure.Repository.DTO.Usuarios
{
    public class UserDTO
    {
        [Col("ID")]
		public int ID { get; set; }
		[Col("NOME")]
		public string NOME { get; set; }
		[Col("SENHA")]
		public string SENHA { get; set; }
		[Col("TIPO_USUARIO")]// esse nome é referente ao banco(e precisa ser exatmente igual)
		public int TIPOUSUARIO { get; set; }// já este não .. é apenas uma var publica que uma pripriedade que faz referência a linha de cima
		[Col("ISATIVO")]
		public bool ISATIVO { get; set; }
		[Col("DATACRIADO")]
		public DateTime DATACRIADO { get; set; }
		[Col("DATAMOTIFICADO")]
		public DateTime DATAMOTIFICADO { get; set; }
	}
}
