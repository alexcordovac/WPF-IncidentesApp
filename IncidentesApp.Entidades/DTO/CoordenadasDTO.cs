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
        public byte LatitudGrados { get; set; }
        public byte LatitudMinutos { get; set; }
        public byte LatitudSegundos { get; set; }
        public short LongitudGrados { get; set; }
        public byte LongitudMinutos { get; set; }
        public byte LongitudSegundos { get; set; }
        public short Altitud { get; set; }
    }
}
