using ThreeInARow.States;
using ThreeInARow.Tiles;

namespace ThreeInARow.Boards.States
{
    public interface IBoardState : IState
    {
        bool TileClick(Tile tile);
        void NextStep();
    }
}