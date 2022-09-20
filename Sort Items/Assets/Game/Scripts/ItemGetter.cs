using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SortItems
{
    public class ItemGetter : MonoBehaviour
    {
        [SerializeField] public ItemType _type;
        [SerializeField] public string _itemId;
        private DragItem _item;
        [SerializeField] public GetterParameters _getter;

        [HideInInspector] public bool isActive = false;

        public UnityEvent onRemove;

        private void OnTriggerStay(Collider other) 
        {
            if (!isActive) return;
            var item = other.gameObject.GetComponent<DragItem>();
            if (item==null) return;
            if (item!=null)
                _item = item;
                return;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!isActive) return;
            var item = other.gameObject.GetComponent<DragItem>();
            if (item==null) return;
            Debug.Log("exit");
            if (_item == item)
            {
                Debug.Log("tryget exit");
                if (item.IsDraggable == false)
                    TryGetItem();
                _item=null;
            }
        }

        private void TryGetItem()
        {
            if (_item.Type==_type && _item._itemId==_itemId)
            {
                var item2 = this.gameObject.GetComponent<DragItem>();
                _item.gameObject.GetComponents<BoxCollider>()[0].enabled = false;
                item2.gameObject.GetComponents<BoxCollider>()[0].enabled = false;
                _item.gameObject.GetComponents<BoxCollider>()[1].enabled = false;
                item2.gameObject.GetComponents<BoxCollider>()[1].enabled = false;
                _item.OnHideRequest.Invoke();
                item2.OnHideRequest.Invoke();
                onRemove.Invoke();
            }
        } 
    }
}
