using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SortItems
{
    public class PlayerScriptableModelProvider : MonoBehaviour
    {
        [SerializeField] protected PlayerScriptableModel _playerScrModel;
        public PlayerScriptableModel PlayerScriptableModel => _playerScrModel;

        public UnityEvent OnModelChange = new UnityEvent();

        protected void OnEnable() 
        {
            Debug.Log("enable psmProvider");
            PlayerScriptableModel.OnLoad.AddListener(OnLoadDelegate);
            PlayerScriptableModel.Model.OnChange.AddListener(OnModelChangeDelegate);
        }

        protected void OnDisable() 
        {
            PlayerScriptableModel.OnLoad.RemoveListener(OnLoadDelegate);
            PlayerScriptableModel.Model.OnChange.RemoveListener(OnModelChangeDelegate);
        }

        public void AddWinCoins()
        {
            PlayerScriptableModel.AddCoin(5);
            PlayerScriptableModel.Save();
        }

        public void IncreaseCoin(int value)
        {
            _playerScrModel.AddCoin(value);
        }

        public void DecreaseCoin(int value)
        {
            _playerScrModel.AddCoin(-value);
        }

        public void Load()
        {
            PlayerScriptableModel.Load();
            PlayerScriptableModel.Model.OnChange.AddListener(OnModelChangeDelegate);
        }

        public void Save()
        {
            PlayerScriptableModel.Save();
        }

        protected void OnModelChangeDelegate()
        {
            OnModelChange.Invoke();
        }

        public void OnLoadDelegate()
        {
            Debug.Log("onLoadDel");
            PlayerScriptableModel.Model.OnChange.AddListener(OnModelChangeDelegate);
        }
    }
}
