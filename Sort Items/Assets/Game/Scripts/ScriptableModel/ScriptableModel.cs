using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

namespace SortItems
{
    [System.Serializable]
    public class ScriptableModel<TModel> : ScriptableObject where TModel:Model, new()
    {
        [SerializeField] protected TModel _model;

        public TModel Model
        {
            get => _model;
            set 
            {
                _model = value;
            }
        }

        public bool Load()
        {
            if (File.Exists(GetStoragePath(name)) == false)
            {
                Debug.Log("File " + GetStoragePath(name) + " not exist");
                return false;
            }

            TModel model = new TModel();
            var text = File.ReadAllText(GetStoragePath(name));
            JsonUtility.FromJsonOverwrite(text,model);
            Model = model;
            return true;
        }

        public bool Save()
        {
            try
            {
                var text = JsonUtility.ToJson(Model);
                File.WriteAllText(GetStoragePath(name),text);
            }
            catch (Exception e)
            {
                Debug.Log(e);
                return false;
            }
            return true;
        }

        protected static string GetStoragePath(string name)
        {
            return Application.persistentDataPath + Path.DirectorySeparatorChar + name + ".json";
        }

    }
}
