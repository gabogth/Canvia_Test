using PT_CANVIA.Core.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_CANVIA.Infraestructura.Repositorios.Base
{
    public class Repositorio : DbContext
    {
        public Repositorio():base("Server=SHAREPOINT2016\\SHAREPOINTRS, 8004;Database=TEST_CANVIA;Trusted_Connection=True;App=PT_CANVIA;")
        {
            
        }

        public string GetListaParemetros(object[] lsParametros)
        {
            string cParamteros = "";
            bool bInicio = true;
            foreach (SqlParameter oItem in lsParametros)
            {
                cParamteros += (!bInicio ? ", " : " ") + oItem.ParameterName +
                    (oItem.Direction == System.Data.ParameterDirection.Output ? " OUT" :
                        oItem.Direction == System.Data.ParameterDirection.InputOutput ? " OUTPUT" : "");
                bInicio = false;
            }
            return cParamteros;
        }
    }
}
