using InteractiveMenu.Buttons;

namespace InteractiveMenu.Runtime.Graph
{
    public interface IButtonNode
    {
        bool HasNeighbour(Side side);
        IButton GetNeighbour(Side side);
    }
}