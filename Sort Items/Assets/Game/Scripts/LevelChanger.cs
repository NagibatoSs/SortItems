using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    public class LevelChanger : MonoBehaviour
    {
        [SerializeField] private int levelNumber;
        [SerializeField] private GameObject[] getters;
        [SerializeField] private ItemSpawner oldItems;
        
        public void LoadNextLevel()
        { 
            RemoveItems(oldItems);
            foreach(var g in getters)
                Destroy(g);
            Vector3 vector = new Vector3(0,0,0);
            var level = Instantiate(Resources.Load<GameObject>("Prefabs/Levels/Level"+(++levelNumber)),vector,Quaternion.identity);
        }
        
        public void RemoveItems(ItemSpawner oldItems)
        {
            foreach(var child in oldItems.GetComponentsInChildren<Transform>())
            {  
                Destroy(child.gameObject);
            }
        }
    }
}
