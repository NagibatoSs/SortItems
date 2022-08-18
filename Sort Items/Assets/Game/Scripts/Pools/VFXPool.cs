using UnityEngine;
using System.Collections.Generic;

namespace SortItems
{
    [CreateAssetMenu(fileName="VFXPool", menuName="Game/VFXPool", order=1)]
    public class VFXPool : ScriptableObject 
    {
        [SerializeField] private int _size = 5;
        [SerializeField] private GameObject _vfxPrefab;

        private List<VFXPoolItem> _items;
        private Queue<VFXPoolItem> _queue;

        private bool _poolIsInit =false;

        public void InitializePool()
        {
            if (_poolIsInit)
                return;
            _items = new List<VFXPoolItem>(_size);
            _queue = new Queue<VFXPoolItem>();
            for (int i=0;i<_size;i++)
                CreateItem();
            _poolIsInit=true;
        }

        public void ResetPool()
        {
            _items.ForEach(item => 
            {
                if (item!=null && item.gameObject!=null)
                    Destroy(item);
            });
            _items?.Clear();
            _queue?.Clear();
            _poolIsInit=false;
        }

        public VFXPoolItem GetFromPool()
        {
            if (_queue.Count==0)
                ExpandPool();
            VFXPoolItem poolItem = _queue.Dequeue();
            poolItem.OnGetFromPool();
            return poolItem;
        }

        public void ReturnToPool(VFXPoolItem item)
        {
            _queue.Enqueue(item);
        }

        protected void ExpandPool()
        {
            for (int i=0;i<_size;i++)
                CreateItem();
        }

        protected VFXPoolItem CreateItem()
        {
            GameObject itemInstance = Instantiate(_vfxPrefab);
            itemInstance.SetActive(false);

            VFXPoolItem poolItem = itemInstance.GetComponent<VFXPoolItem>();
            poolItem.Pool = this;
            _items.Add(poolItem);
            _queue.Enqueue(poolItem);
            return poolItem;
        }
    }
}
