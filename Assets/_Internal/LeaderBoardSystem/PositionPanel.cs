using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Internal.LeaderBoardSystem
{
    public class PositionPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private TMP_Text _placeText;

        [SerializeField] private TMP_Text[] _allTexts;
        [SerializeField] private Image _background;
        [Space] 
        [SerializeField] private Sprite _playerBackground;
        [SerializeField] private Sprite _enemyBackground;
        [SerializeField] private Sprite _diedBackground;
        
        [SerializeField] private Color _defaultColor;

        private Dictionary<int, string> NumberEnds = new Dictionary<int, string>()
        {
            [0] = "",
            [1] = "st",
            [2] = "nd",
            [3] = "rd",
        };

        public void Initialize()
        {
            
        }

        public void SetData(string unitName, int place, UnitType type, bool isDied, Color color = default)
        {
            _text.text = unitName;
            _placeText.text = GetPlaceString(place);

            switch (type)
            {
                case UnitType.Player:
                    _background.sprite = _playerBackground;
                    foreach (var text in _allTexts)
                    {
                        text.color = _defaultColor;
                    }
                    PumpMe();
                    break;
                case UnitType.Enemy:
                    foreach (var text in _allTexts)
                    {
                        text.color = color;
                    }
                    _background.sprite = _enemyBackground;
                    break;
            }

            if (isDied)
            {
                foreach (var text in _allTexts)
                {
                    text.color = _defaultColor;
                }
                DeadPumpIn();
                _placeText.text = "<sprite=0>";
                _background.sprite = _diedBackground;
            } 
        }

        private string GetPlaceString(int place)
        {
            return place + (place < 4 ? NumberEnds[place] : "th");
        }

        private void DeadPumpIn()
        {
            _placeText.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1).OnComplete(DeadPumpOut);
        }

        private void DeadPumpOut()
        {
            _placeText.transform.DOScale(new Vector3(1f, 1f, 1f), 1);
        }

        private void PumpMe()
        {
            //_tween.Kill();
            transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1).OnComplete(PumpOut);
            transform.DOScale(new Vector3(1f, 1f, 1f), 1);
        }

        private void PumpOut()
        {
            //_tween = transform.DOScale(new Vector3(1f, 1f, 1f), 1);
        }
    }

    public enum UnitType
    {
        Enemy,
        Player
    }
}