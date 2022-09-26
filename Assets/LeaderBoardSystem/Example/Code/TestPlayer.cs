using LeaderBoardSystem.CodeBase;
using UnityEngine;

namespace LeaderBoardSystem.Example.Code
{
    public class TestPlayer : MonoBehaviour, IObservableUnit
    {
        [SerializeField] private bool _isDied;
        [SerializeField] private Color _myLeaderBoardColor;
        private Transform _transform;
        public string Name => name;
        public Transform Transform => _transform;
        public bool IsDied => _isDied;
        public Color MyLeaderBoardColor => _myLeaderBoardColor;

        private void Awake()
        {
            _transform = transform;
        }
        
    }
}