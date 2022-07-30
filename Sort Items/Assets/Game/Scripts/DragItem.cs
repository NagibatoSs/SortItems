using UnityEngine;
using UnityEngine.EventSystems;

namespace SortItems
{
    public class DragItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private float upForce = 50f;
        [SerializeField] private ItemType _type;
        public ItemType Type { get => _type; }
        private Rigidbody _rigidbody;
        public bool IsDraggable {get; private set;}

        private void Start() 
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _rigidbody.isKinematic = true;
            _rigidbody.isKinematic = true;
            IsDraggable = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (IsDraggable==false) return;
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(Vector3.up*upForce);
            IsDraggable = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (IsDraggable==false) return;
            if (!eventData.pointerCurrentRaycast.isValid)
            {
                _rigidbody.isKinematic = false;
                IsDraggable = false;
                return;
            }
            var position = eventData.pointerCurrentRaycast.worldPosition;
            var delta = position - transform.position;
            delta.y = 0;
            transform.position+=delta;
        }
    }
}
