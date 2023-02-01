using Geolocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.Servicios.Servicios
{
    public class GeolocalizacionService
    {
        public GeolocalizacionService()
        {
            
        }

        public double ConvertirACoordenadasDecimales(double degrees, double minutes, double seconds)
        {
            return degrees + (minutes / 60) + (seconds / 3600);
        }

        public double Distancia(double latitudOrigen, double longitudOrigen, double latitudDestino, double longitudDestino)
        {
            return GeoCalculator.GetDistance(latitudOrigen, longitudOrigen, latitudDestino, longitudDestino, 2, DistanceUnit.Kilometers);
        }

        public string DireccionCardinal(double latitudOrigen, double longitudOrigen, double latitudDestino, double longitudDestino)
        {
            return GeoCalculator.GetDirection(latitudOrigen, longitudOrigen, latitudDestino, longitudDestino);
        }

    }
}
