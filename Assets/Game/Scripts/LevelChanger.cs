using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    public class LevelChanger : MonoBehaviour
    {
        private int level=0;
        [SerializeField] private GameObject[] getters;
        [SerializeField] private ItemSpawner oldItems;
        [SerializeField] private ItemSpawner newSpawnItems;
        private void Start() 
        {
            var defLevel = PlayerPrefs.GetInt("Level",0);
            if (level!=defLevel)
                LoadLevel(level);
        }
        public void LoadNextLevel()
        { 
            RemoveItems(newSpawnItems);
            RemoveItems(oldItems);
            foreach(var g in getters)
               Destroy(g);
               level++;
            LoadLevel(level);
            
        }
        
        public void RemoveItems(ItemSpawner oldItems)
        {
            foreach(var child in oldItems.GetComponentsInChildren<Transform>())
            {  
                Destroy(child.gameObject);
            }
        }
        public void LoadLevel(int level)
        {
            Vector3 vector = new Vector3(0,0,0);
                var getterYellow = Instantiate(Resources.Load<GameObject>("Prefabs/OneGetterLevel"),vector,Quaternion.identity);
                var sh = getterYellow.transform.gameObject.GetComponent<ScoreHandler>();
                sh._getters[0].targetCount=3;
        }
         
    }
}
