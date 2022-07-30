using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SortItems
{
    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField] public GetterParameters[] _getters;
        public UnityEvent onFull;

        private void Start() 
        {
            if (_getters==null)
                Debug.LogError("Getters is null");
            foreach ( var getter in _getters)
            {
                getter.getter.SetCount(getter.targetCount);
                getter.getter.onCountChanged.AddListener(OnCountChanged);
            }
        }

        private void OnDestroy() 
        {
            foreach ( var getter in _getters)
            {
                getter.getter.onCountChanged.RemoveListener(OnCountChanged);
            }
        }

        private void OnCountChanged(Getter getter)
        {
            for (int i = 0; i<_getters.Length; i++)
            {
                ref var item = ref _getters[i];
                if (item.getter != getter) continue;
                item.count++;
            }
            bool isFull = true;
            foreach (var g in _getters)
            {
                if (g.count < g.targetCount)
                {
                    isFull = false;
                    break;
                }
            }

            if (isFull)
            {
                onFull.Invoke();
            }
        }
    }

    [System.Serializable]
    public struct  GetterParameters
    {
        public Getter getter;
        public int targetCount;
        [HideInInspector] public int count;
    }
}
