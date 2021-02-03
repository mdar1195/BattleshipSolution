using System.Text;

namespace BattleshipGrid
{
    public class Coordinate
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }

        public Coordinate()
        {
            Latitude = 0;
            Longitude = 0;
        }
        public Coordinate(int latitude, int longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public bool Equals(Coordinate obj)
        {
            return obj.Latitude == Latitude && obj.Longitude == Longitude;
        }
        public override string ToString()
        {
            return string.Format("(", Latitude, ",", Longitude, ")");
        }
    }
}
