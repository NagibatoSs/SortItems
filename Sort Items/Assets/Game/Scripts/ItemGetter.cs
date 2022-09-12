using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SortItems
{
    public class ItemGetter : MonoBehaviour
    {
        [SerializeField] public ItemType _type;
        private DragItem _item;
        [HideInInspector] public Material _material {get; set;}
        [HideInInspector] public Color _defaultColor {get;private set;}
        [SerializeField] public GetterParameters _getter;
        
        public int targetCount = 1;
        private int count = 0;
        [HideInInspector] public bool isActive = false;

        public UnityEvent<ItemGetter> onCountChanged;
        public UnityEvent onRemove;

        private void Start() 
        {
            _material = GetComponent<MeshRenderer>().material;
            _defaultColor = _material.color;
        }

        public void AddCountToGetter()
        {
            _getter.count++;
        }

        public void SetCount(int value)
        {
            targetCount = value;
            if (count >= targetCount)
                {
                    _material.color = Color.gray;
                    isActive = false;
                }
        }

        private void OnTriggerStay(Collider other) 
        {
            if (!isActive) return;
            var item = other.gameObject.GetComponent<DragItem>();
            if (item==null) return;
            if (item!=null)
                _item = item;
                return;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!isActive) return;
            var item = other.gameObject.GetComponent<DragItem>();
            if (item==null) return;
            Debug.Log("exit");
            if (_item == item)
            {
                Debug.Log("tryget exit");
                _material.color = _defaultColor;
                if (item.IsDraggable == false)
                    TryGetItem();
                _item=null;
            }
        }

        private void TryGetItem()
        {
            if (_item.Type==_type)
            {
                Debug.Log("remove");
                _item.OnHideRequest.Invoke();
                var item2 = this.gameObject.GetComponent<DragItem>();
                item2.OnHideRequest.Invoke();
                _item.gameObject.GetComponents<BoxCollider>()[0].enabled = false;
                item2.gameObject.GetComponents<BoxCollider>()[0].enabled = false;
                _item.gameObject.GetComponents<BoxCollider>()[1].enabled = false;
                item2.gameObject.GetComponents<BoxCollider>()[1].enabled = false;
                onRemove.Invoke();
                count++;
                onCountChanged.Invoke(this);
                if (count >= targetCount)
                {
                    _material.color = Color.gray;
                    isActive = false;
                }
            }
        } 
    }
}
