using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    public class ScriptableModelLoader : MonoBehaviour
    {
        [SerializeField] protected List<ScriptableObject> _scriptableModelsList;

        public List<ScriptableObject> ScriptableModelsList => _scriptableModelsList;

        private void Start() 
        {
            ScriptableModelsList.ForEach(scriptableModel =>
            {
                (scriptableModel as IStorable)?.Load();
            });
        }

        private void OnDisable() 
        {
             ScriptableModelsList.ForEach(scriptableModel =>
            {
                (scriptableModel as IStorable)?.Save();
            });
        }
    }
}
