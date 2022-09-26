using System.Collections.Generic;
using LeaderBoardSystem.Example.Code;
using UnityEngine;

namespace LeaderBoardSystem.CodeBase
{
    public class LeaderBoard : MonoBehaviour
    {
        [SerializeField] private PositionPanel _positionPanel;
        private List<PositionPanel> _positionPanels = new List<PositionPanel>();
        private List<PositionPanel> _positionPanelsReverse = new List<PositionPanel>();
        private List<IObservableUnit> _diedUnits = new List<IObservableUnit>();
        private int _panelsListLength;


        public void Initialize(List<IObservableUnit> units)
        {
            for (int i = 0; i < units.Count; i++)
            {
                var panel = Instantiate(_positionPanel, transform);
                panel.Initialize();
                SetDataToPanel(panel, units[i], i+1);
                _positionPanels.Add(panel);
                _positionPanelsReverse.Add(panel);
            }
            _panelsListLength = _positionPanels.Count;
            _positionPanelsReverse.Reverse();
        }

        public void UpdatePlaces(List<IObservableUnit> units)
        {
            _diedUnits.Clear();
            int c = 0;
            for (int i = 0; i < units.Count; i++)
            {
                IObservableUnit unit = units[i];
                if(unit.IsDied)
                {
                    _diedUnits.Add(unit);
                    c++;
                    continue;
                }
                var panel = _positionPanels[i-c];
                SetDataToPanel(panel, units[i], i+1-c);
            }
            for (int i = 0; i < _diedUnits.Count; i++)
            {
                var panel = _positionPanelsReverse[i];
                
                SetDataToPanel(panel, _diedUnits[i], 0);
            }
        }

        private void SetDataToPanel(PositionPanel panel, IObservableUnit unit, int place)
        {
            var type = unit is Player ? UnitType.Player : UnitType.Enemy;
            panel.SetData(unit.Name, place, type, unit.IsDied, unit.MyLeaderBoardColor);
        }
    }
}