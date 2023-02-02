using IncidentesApp.Entidades.DTO;
using IncidentesApp.Repositorios.Interfaces;
using IncidentesApp.Repositorios.Repositorios;
using IncidentesApp.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.Servicios.Servicios
{
    public class IncidenteService : IIncidenteService
    {
        private readonly ICentroAtencionRepository _centroAtencionRepository;
        private readonly IIncidenteRepository _incidenteRepository;
        private readonly GeolocalizacionService _geolocalizacionService = new GeolocalizacionService();

        public IncidenteService(ICentroAtencionRepository centroAtencionRepository, IIncidenteRepository incidenteRepository)
        {
            _centroAtencionRepository = centroAtencionRepository;
            _incidenteRepository = incidenteRepository;
        }

        /// <summary>
        /// Ubica el centro de atención más cercano y su distancia
        /// </summary>
        /// <param name="incidente"></param>
        /// <returns></returns>
        public async Task<IncidenteDTO> CentroAtencionCercano(IncidenteDTO incidente)
        {
            var listaCentrosAtn = await this._centroAtencionRepository.ListaCentrosAtencion();

            //Mapear la distancia como el key de un diccionario y el valor del Centro de Atención
            var diaccionarioCentrosAtn = listaCentrosAtn.ToDictionary(t => this._geolocalizacionService.Distancia(_geolocalizacionService.ConvertirACoordenadasDecimales(t.Coordenadas.LatitudGrados, t.Coordenadas.LatitudMinutos, t.Coordenadas.LatitudSegundos), _geolocalizacionService.ConvertirACoordenadasDecimales(t.Coordenadas.LongitudGrados, t.Coordenadas.LongitudMinutos, t.Coordenadas.LongitudSegundos), incidente.Latitud, incidente.Longitud), v => v);

            //Buscar el registro en diccionario que tenga el key (distancia) menor
            var el = diaccionarioCentrosAtn.MinBy(t => t.Key);
            incidente.DistanciaKM = el.Key;
            incidente.CentroAtencion = el.Value;

            return incidente;

        }

        /// <summary>
        /// Calcula la dirección cardinal
        /// </summary>
        /// <param name="incidente"></param>
        /// <returns></returns>
        public async Task<IncidenteDTO> DireccionCardinal(IncidenteDTO incidente)
        {
            string direccion = _geolocalizacionService.DireccionCardinal(_geolocalizacionService.ConvertirACoordenadasDecimales(incidente.CentroAtencion.Coordenadas.LatitudGrados, incidente.CentroAtencion.Coordenadas.LatitudMinutos, incidente.CentroAtencion.Coordenadas.LatitudSegundos), _geolocalizacionService.ConvertirACoordenadasDecimales(incidente.CentroAtencion.Coordenadas.LongitudGrados, incidente.CentroAtencion.Coordenadas.LongitudMinutos, incidente.CentroAtencion.Coordenadas.LongitudSegundos), incidente.Latitud, incidente.Longitud);

            incidente.DireccionCardinal = direccion;

            return incidente;
        }

        /// <summary>
        /// Calcula el Tiempo Estimado de Recorrido
        /// </summary>
        /// <param name="incidente"></param>
        /// <returns>Incidente con tiempo estimado en minutos</returns>
        public async Task<IncidenteDTO> TiempoEstimado(IncidenteDTO incidente)
        {
            incidente.TiempoEstimadoMinutos = (incidente.DistanciaKM / 120) * 60;

            return incidente;
        }

        /// <summary>
        /// Calcula la Hora Estimada de llegada desde el centro de atención al incidente.
        /// </summary>
        /// <param name="incidente"></param>
        /// <returns>Incidente con HoraEstimada</returns>
        public async Task<IncidenteDTO> HoraEstimada(IncidenteDTO incidente)
        {
            incidente.HoraEstimadaLlegada = DateTime.Now.AddMinutes(incidente.TiempoEstimadoMinutos);

            return incidente;
        }


        /// <summary>
        /// Guardar la incidencia en base de datos
        /// </summary>
        /// <param name="incidente"></param>
        /// <returns></returns>
        public async Task<int> GuardarIncidente(IncidenteDTO incidente)
        {
            var rows = await this._incidenteRepository.Guardar(incidente);

            return rows;
        }


        /// <summary>
        /// Obtiene todos los incidentes relacionados a un centro de monitoreo
        /// </summary>
        /// <param name="centroAtencionID"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IncidenteDTO>> FiltrarIncidentesPorCentroAtencionID(int? centroAtencionID)
        {
            return await this._incidenteRepository.FiltrarPorIDCentroAtencion(centroAtencionID);
        }

    }
}
