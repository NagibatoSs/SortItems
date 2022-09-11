using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace SortItems
{
    public class DragItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private float upForce = 50f;
        [SerializeField] private ItemType _type;
        public UnityEvent OnHideRequest;
        public ItemType Type { get => _type; }
        private Rigidbody _rigidbody;
        public bool IsDraggable {get; private set;}
        [SerializeField] private ItemGetter outItem;

        private void Start() 
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _rigidbody.isKinematic = true;
            IsDraggable = true;
            outItem.isActive=true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (IsDraggable==false) return;
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(Vector3.up*upForce);
            IsDraggable = false;
            outItem.isActive=false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (IsDraggable==false) return;
            if (!eventData.pointerCurrentRaycast.isValid)
            {
                _rigidbody.isKinematic = false;
                IsDraggable = false;
                outItem.isActive=false;
                return;
            }
            var position = eventData.pointerCurrentRaycast.worldPosition;
            var delta = position - transform.position;
            delta.y = 0;
            transform.position+=delta;
        }
    }
}
