using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SortItems
{
    public class CoinPresenter : PlayerScriptableModelProvider
    {
        [SerializeField] protected TMP_Text _coinText;

        public TMP_Text CoinText => _coinText;

        protected new void OnEnable() 
        {
            base.OnEnable();
            PlayerScriptableModel.OnLoad.AddListener(UpdateCoin);
        }

        protected new void OnDisable() 
        {
            base.OnDisable();
            PlayerScriptableModel.OnLoad.RemoveListener(UpdateCoin);
        }

        public void UpdateCoin()
        {
            CoinText.text = PlayerScriptableModel.Model.Coin.ToString();
        }
    }
}
