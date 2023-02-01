using Dapper;
using IncidentesApp.Entidades.DTO;
using IncidentesApp.Entidades.Solicitud;
using IncidentesApp.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.Repositorios.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _context;

        public UsuarioRepository(IDbConnection cnn)
        {
            this._context = cnn;
        }

        public async Task<UsuarioDTO> ObtenerUsuario(string usuario)
        {
            string sql = @"SELECT 
                                U.UsuarioID, U.Usuario,  CONVERT(NVARCHAR(512), U.Contraseña,2) Contraseña, 
                                U.RolID, R.NombreRol
                            FROM Usuario U
                            INNER JOIN Rol R
	                            ON U.RolID = R.RolID
                            WHERE Usuario = @Usuario";

            IEnumerable<UsuarioDTO> result;

            result = await _context.QueryAsync<UsuarioDTO, RolDTO, UsuarioDTO>(sql, (u, r) =>
            {
                u.Rol = r;

                return u;
            }, splitOn: "RolID", commandType: System.Data.CommandType.Text, param: new { usuario });


            return result.FirstOrDefault();
        }
    }
}
