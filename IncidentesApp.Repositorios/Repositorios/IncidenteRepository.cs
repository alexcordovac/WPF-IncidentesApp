using Dapper;
using IncidentesApp.Entidades.DTO;
using IncidentesApp.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.Repositorios.Repositorios
{
    public class IncidenteRepository : IIncidenteRepository
    {
        private readonly IDbConnection _context;

        public IncidenteRepository(IDbConnection connection)
        {
            this._context = connection;
        }

        public async Task<int> Guardar(IncidenteDTO incidente)
        {
            var sql = @"INSERT INTO 
                        Incidente(Descripcion, Lugar, Latitud, Longitud, DistanciaKM, DireccionCardinal, TiempoEstimadoMinutos, HoraEstimadaLlegada, UsuarioID, TipoAsistenciaID, CentroAtencionID)
                        VALUES (@Descripcion, @Lugar, @Latitud, @Longitud, @DistanciaKM, @DireccionCardinal, @TiempoEstimadoMinutos, @HoraEstimadaLlegada, @UsuarioID, @TipoAsistenciaID, @CentroAtencionID)";

            var rows = await _context.ExecuteAsync(sql, new { incidente.Descripcion, incidente.Lugar, incidente.Latitud, incidente.Longitud, incidente.DistanciaKM, incidente.DireccionCardinal, incidente.TiempoEstimadoMinutos, incidente.HoraEstimadaLlegada, incidente.UsuarioID, incidente.TipoAsistencia.TipoAsistenciaID, incidente.CentroAtencion.CentroAtencionID });

            return rows;
        }
    }
}
