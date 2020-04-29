using System;
using System.Collections.Generic;
using System.Text;

namespace DTOAgenda
{
   public  class AgendamentoDTO
    {
        public int ID_AGENDAMENTO { get; set; }
        public String NOME_AUDITORIO { get; set; }
        public int QTDE_AUDITORIO { get; set; }
        public DateTime DATA_AGENDAMENTO { get; set; }

    }
}
