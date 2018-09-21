using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
namespace Datos
{
    public class AccesoDatos : Comun
    {
        

        public int _Ejecutar(string idStore, object parameters, int usuario, string audiencia)
        {
            try
            {
                _Verifica_Store_result Permiso = VerificaSp(idStore, usuario, audiencia);
                if (Permiso.Autorizado)
                    return SqlMapper.Execute(Connection, Permiso.SP, parameters, commandType: CommandType.StoredProcedure);
                else
                    throw new Exception("Usuario no autorizado para la consulta a este modulo");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public dynamic _Listar(string idStore, object parameters, int usuario, string audiencia)
        {
            try
            {
                _Verifica_Store_result Permiso = VerificaSp(idStore,usuario,audiencia);
                if (Permiso.Autorizado)
                    return SqlMapper.Query(Connection, Permiso.SP, parameters, commandType: CommandType.StoredProcedure);
                else
                    throw new Exception("Usuario no autorizado para la consulta a este modulo");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<T> _Listar<T>(string idStore, object parameters, int usuario, string audiencia)
        {
            try
            {
                _Verifica_Store_result Permiso = VerificaSp(idStore, usuario, audiencia);
                if (Permiso.Autorizado)
                    return SqlMapper.Query<T>(Connection, Permiso.SP, parameters, commandType: CommandType.StoredProcedure);
                else
                    throw new Exception("Usuario no autorizado para la consulta a este modulo");
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        
        protected _Verifica_Store_result VerificaSp(string idStore, int usuario, string audiencia)
        {
            try
            {
                return SqlMapper.QueryFirst<_Verifica_Store_result>(
                    Connection,
                    "Seguridad._Verifica_Store",
                    new { id = idStore, usuario = usuario, audiencia = audiencia },
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
    public class _Verifica_Store_result
    {
        public string SP { get; set; }
        public bool Autorizado { get; set; }
    }
}
