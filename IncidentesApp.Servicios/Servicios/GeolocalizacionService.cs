using Geolocation;
using IncidentesApp.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.Servicios.Servicios
{
    public class GeolocalizacionService : IGeolocalizacionService
    {
        public GeolocalizacionService()
        {
            
        }

        /// <summary>
        /// Convierte de grados, minutos, segundos a grados decimales
        /// </summary>
        /// <param name="degrees"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public double ConvertirACoordenadasDecimales(double degrees, double minutes, double seconds)
        {
            return degrees + (minutes / 60) + (seconds / 3600);
        }


        /// <summary>
        /// Distancia entre dos coordenadas
        /// </summary>
        /// <param name="latitudOrigen"></param>
        /// <param name="longitudOrigen"></param>
        /// <param name="latitudDestino"></param>
        /// <param name="longitudDestino"></param>
        /// <returns></returns>
        public double Distancia(double latitudOrigen, double longitudOrigen, double latitudDestino, double longitudDestino)
        {
            return GeoCalculator.GetDistance(latitudOrigen, longitudOrigen, latitudDestino, longitudDestino, 2, DistanceUnit.Kilometers);
        }

        /// <summary>
        /// Dirección cardinal entre dos coordenadas
        /// <param name="latitudOrigen"></param>
        /// <param name="longitudOrigen"></param>
        /// <param name="latitudDestino"></param>
        /// <param name="longitudDestino"></param>
        /// <returns></returns>
        public string DireccionCardinal(double latitudOrigen, double longitudOrigen, double latitudDestino, double longitudDestino)
        {
            return GeoCalculator.GetDirection(latitudOrigen, longitudOrigen, latitudDestino, longitudDestino);
        }

    }
}
