using System.Collections.Generic;
using System.Linq;
using _Internal.LeaderBoardSystem.Demo;
using UnityEngine;

namespace _Internal.LeaderBoardSystem
{
    public class UnitsObserver : MonoBehaviour
    {
        [SerializeField] private List<TestPlayer> _testPlayers;
        [SerializeField] private LeaderBoard _leaderBoard;
        private List<IObservableUnit> _observableUnits;

        private void Awake()
        {
            _observableUnits = new List<IObservableUnit>();
            foreach (var testPlayer in _testPlayers)
            {
                _observableUnits.Add(testPlayer);
            }
            _leaderBoard.Initialize(_observableUnits);
        }

        private void Update()
        {
            if (_observableUnits.Count == 0) return;
            var sorted = _observableUnits
                .OrderBy(u => u.Transform.position.x)
                .Reverse()
                .ToList();
            _leaderBoard.UpdatePlaces(sorted);
        }
    }
}