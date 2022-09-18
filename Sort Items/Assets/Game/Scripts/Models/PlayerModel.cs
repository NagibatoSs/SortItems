using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    [System.Serializable]
    public class PlayerModel : Model
    {
        [SerializeField] protected string _playerName;
        [SerializeField] protected int _coin;

        public string PlayerName 
        {
            get => _playerName;
            set => SetData(ref _playerName,value);
        }
        
        public int Coin
        {
            get => _coin;
            set
            {
                if (value<0) return;
                SetData(ref _coin,value);
            }

        }

    }
}
