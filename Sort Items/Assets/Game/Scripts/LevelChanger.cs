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
        
        private void Start() 
        {
            var lastLevel = PlayerPrefs.GetInt("Level",0);
            Debug.Log(lastLevel+" last, "+levelNumber+" now");
            if (lastLevel != levelNumber)
                LoadLevel(lastLevel);
        }

        public void LoadLevel(int level)
        { 
            if (oldItems!=null)
            RemoveItems(oldItems);
            if (getters!=null)
            foreach(var g in getters)
                Destroy(g);
            Vector3 vector = new Vector3(0,0,0);  
            PlayerPrefs.SetInt("Level",level);  
            var newLevel = Instantiate(Resources.Load<GameObject>("Prefabs/Levels/Level"+(level)),vector,Quaternion.identity);
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
