using UnityEngine;

namespace LeaderBoardSystem.CodeBase
{
    public interface IObservableUnit
    {
        string Name { get; }
        Transform Transform { get; }
        bool IsDied { get; }
        
        Color MyLeaderBoardColor { get; }
    }
}