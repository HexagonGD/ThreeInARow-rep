using ThreeInARow.States;

namespace ThreeInARow.Tiles.States
{
    public interface ITileState : IState
    {
        void Blow();
        bool NeedStone();
        bool IsMovable { get; }
        int GetStoneID();
    }
}