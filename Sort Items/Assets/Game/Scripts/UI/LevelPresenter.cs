using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

namespace SortItems
{
    public class LevelPresenter:MonoBehaviour
    {
        [SerializeField] protected Text _levelText;
        [SerializeField] LevelChanger _levelChanger;
        public Text LevelText => _levelText;

        private void OnEnable()
        {
            _levelChanger.OnLevelChanged += UpdateLevel;
        }
        private void OnDisable()
        {
            _levelChanger.OnLevelChanged -= UpdateLevel;
        }
        private void Start()
        {
            LevelText.text = _levelChanger.CurrentLevel.ToString();
        }

        public void UpdateLevel()
        {
            LevelText.text = _levelChanger.CurrentLevel.ToString();
        }

    }
}
