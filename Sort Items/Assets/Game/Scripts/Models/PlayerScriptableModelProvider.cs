using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    public class PlayerScriptableModelProvider : MonoBehaviour
    {
        [SerializeField] protected PlayerScriptableModel _playerScrModel;
        public PlayerScriptableModel PlayerScriptableModel => _playerScrModel;

        public void IncreaseScore(int value)
        {
            _playerScrModel.AddScore(value);
        }

        public void DecreaseScore(int value)
        {
            _playerScrModel.AddScore(-value);
        }

        public void Load()
        {
            PlayerScriptableModel.Load();
        }

        public void Save()
        {
            PlayerScriptableModel.Save();
        }
    }
}
