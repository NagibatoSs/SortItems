using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    [CreateAssetMenu(fileName="PlayerScriptableModel", menuName="Create PlayerScriptableModel", order=1)]
    public class PlayerScriptableModel : ScriptableModel<PlayerModel>
    {
        public bool AddCoin(int value)
        {
            if (Model.Coin + value < 0) 
                return false;
            Model.Coin +=value;
            return true;
        }

    }
}
