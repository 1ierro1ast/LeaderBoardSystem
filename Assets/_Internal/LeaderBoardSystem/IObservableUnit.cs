using UnityEngine;

namespace _Internal.LeaderBoardSystem
{
    public interface IObservableUnit
    {
        string Name { get; }
        Transform Transform { get; }
        bool IsDied { get; }
        
        Color MyLeaderBoardColor { get; }
    }
}