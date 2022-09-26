using System.Collections.Generic;
using System.Linq;
using LeaderBoardSystem.Example.Code;
using UnityEngine;

namespace LeaderBoardSystem.CodeBase
{
    public class UnitsObserver : MonoBehaviour, IUnitsObserver
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