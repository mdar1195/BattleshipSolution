
namespace BattleshipGrid.Ships
{
    public interface IShip
    {
        public bool IsHit(Coordinate point);
        public bool DidSank(Coordinate point);
    }
}
