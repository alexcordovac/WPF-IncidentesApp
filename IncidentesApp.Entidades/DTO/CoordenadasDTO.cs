using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.Entidades.DTO
{
    public class CoordenadasDTO
    {
        public int CoordenadasID { get; set; }
        public short LatitudGrados { get; set; }
        public short LatitudMinutos { get; set; }
        public short LatitudSegundos { get; set; }
        public short LongitudGrados { get; set; }
        public short LongitudMinutos { get; set; }
        public short LongitudSegundos { get; set; }
        public short Altitud { get; set; }
    }
}
