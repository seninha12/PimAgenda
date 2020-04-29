using System;
using System.Collections.Generic;
using System.Text;

namespace DTOAgenda
{
     public class UsuarioDTO
    {
        public int ID_USUARIO { get; set; }
        public string REGISTRO_FUNCIONARIO { get; set; }
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public int TELEFONE { get; set; }
        public string SENHA { get; set; }
    }
}
