using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    public class LevelChanger : MonoBehaviour
    {
        [SerializeField] private int currentLevelNumber;
        public int CurrentLevel => currentLevelNumber;
        private GameObject currentLevel;
        public Action OnLevelChanged;
        public Action OnGameFinished;

        public void LoadNext()
        {
            currentLevelNumber++;
            LoadLevel(currentLevelNumber);
        }

        public void LoadLevel(int level)
        {
            if (currentLevel != null)
            {
                Destroy(currentLevel);
            }

            Vector3 vector = new Vector3(0,0,0);  
            PlayerPrefs.SetInt("Level",level);

            GameObject prefab = Resources.Load<GameObject>("Prefabs/Levels/Level" + (level));
            if (prefab != null)
            {
                currentLevelNumber = level;
                currentLevel = Instantiate(prefab, vector, Quaternion.identity);
                Debug.Log("Load level " + prefab.name);
            }  
            else
            {
                OnGameFinished?.Invoke();
            }
            OnLevelChanged?.Invoke();
        }

        public void RestartLevel()
        {
            if (currentLevel != null)
            {
                Destroy(currentLevel);
            }

            Vector3 vector = new Vector3(0,0,0);
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Levels/Level"  + currentLevelNumber);
            if (prefab != null)
            {
                currentLevel= Instantiate(prefab, vector, Quaternion.identity);
                Debug.Log("Load level " + prefab.name);
            }
        }
        
    }
}
