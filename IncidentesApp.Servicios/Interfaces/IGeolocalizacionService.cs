using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.Servicios.Interfaces
{
    public interface IGeolocalizacionService
    {
        double ConvertirACoordenadasDecimales(double degrees, double minutes, double seconds);
        double Distancia(double latitudOrigen, double longitudOrigen, double latitudDestino, double longitudDestino);
        string DireccionCardinal(double latitudOrigen, double longitudOrigen, double latitudDestino, double longitudDestino);
    }
}
