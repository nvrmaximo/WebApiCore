using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data; 
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApiCore.Context
{
    public class Conex
    {


        /****************FUNCTION TO RETURN STRING CONEXION************************************************************************/


        public static SqlConnection cnx()
        {
      
            SqlConnection cn = new SqlConnection( Startup.connectionstring );
            
            return cn;
        }

        /****************ENCAPSULE FUNCTION OF CONEXION TO DB************************************************************************/
        public SqlConnection con = cnx();


        /***********METOD FOR EXECUTE TO STORE PROCEDURE WITH VERV POST, PUT, DELETE ***************************************************/
        public void EjecutarSP(string nombreSP, List<SqlParameter> parametros = null)
        {
            try
            {
                con.Open();
                var comand = con.CreateCommand();
                comand.CommandText = nombreSP;
                comand.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null) comand.Parameters.AddRange(parametros.ToArray());
                comand.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                throw;
            }
        }


        /***********METODO PARA EJECUTAR PROCEDIMEINTOS DE VERVO GET**********************************************************************/

        public DataSet ConsultarSP(string nombreSP, List<SqlParameter> parametros = null)
        {
            DataSet dsDatos = new DataSet();
            try
            {
                con.Open();
                var comand = con.CreateCommand();
                comand.CommandText = nombreSP;
                comand.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null) comand.Parameters.AddRange(parametros.ToArray());
                var adapter = new SqlDataAdapter(comand);
                adapter.Fill(dsDatos);
                con.Close();
            }
            catch
            {
                throw;
            }
            return dsDatos;
        }



        //End Class
    }
}
