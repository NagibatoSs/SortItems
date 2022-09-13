using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    [CreateAssetMenu(fileName="PlayerScriptableModel", menuName="Create PlayerScriptableModel", order=1)]
    public class PlayerScriptableModel : ScriptableModel<PlayerModel>
    {
        public bool AddScore(int value)
        {
            if (Model.Score + value < 0) 
                return false;
            Model.Score +=value;
            return true;
        }

    }
}
