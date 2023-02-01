using Dapper;
using IncidentesApp.Entidades.DTO;
using IncidentesApp.Entidades.Solicitud;
using IncidentesApp.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.Repositorios.Repositorios
{
    public class CentroAtencionRepository : ICentroAtencionRepository
    {
        private readonly IDbConnection _context;
        public CentroAtencionRepository(IDbConnection conn)
        {
            this._context = conn;
        }

        public async Task<IEnumerable<CentroAtencionDTO>> ListaCentrosAtencion()
        {
            string sql = @"SELECT
	                        CA.CentroAtencionID, CA.Nombre, CO.*
                        FROM CentroAtencion CA
                        INNER JOIN Coordenadas CO
	                        ON CA.CoordenadasID = CO.CoordenadasID";

            IEnumerable<CentroAtencionDTO> result;

            result = await _context.QueryAsync<CentroAtencionDTO, CoordenadasDTO, CentroAtencionDTO>(sql, (ca, co) =>
            {
                ca.Coordenadas = co;

                return ca;
            }, splitOn: "CoordenadasID", commandType: System.Data.CommandType.Text);


            return result;
        }
    }
}
