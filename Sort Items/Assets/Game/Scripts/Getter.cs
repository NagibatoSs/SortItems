using UnityEngine;
using UnityEngine.Events;

namespace SortItems
{
    public class Getter : MonoBehaviour
    {
        [SerializeField] public ItemType _type;
        private DragItem _item;
        [HideInInspector] public Material _material {get; set;}
        [HideInInspector] public Color _defaultColor {get;private set;}
        
        public int targetCount = 1;
        private int count = 0;
        private bool isActive = true;

        public UnityEvent<Getter> onCountChanged;

        private void Start() 
        {
            _material = GetComponent<MeshRenderer>().material;
            _defaultColor = _material.color;
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
            var item = other.attachedRigidbody.GetComponent<DragItem>();
            
            if (item!=null && item.IsDraggable==true)
            {
                _item = item;
                if (_item.Type == _type)
                {
                    _material.color = Color.green;
                }
                else 
                {
                    _material.color = Color.red;
                }
                return;
            }
            if (item.IsDraggable == false && _item==item)
            {
                TryGetItem();
                _item=null;
                _material.color = _defaultColor;
                return;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!isActive) return;
            var item = other.attachedRigidbody.GetComponent<DragItem>();
            if (_item == item)
            {
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
                _item.OnHideRequest.Invoke();
                //Destroy(_item.gameObject);
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
