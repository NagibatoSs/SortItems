using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SortItems
{
    public class ItemClickFx : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private VFXPoolProvider _vfxPoolProvider;
        public UnityEvent OnClick;
        public void OnPointerDown(PointerEventData eventData)
        {
            VFXPoolItem poolItem = _vfxPoolProvider.VFXPool.GetFromPool();
            poolItem.transform.position = transform.position;
            poolItem.ParticleSystem.Play();
            OnClick.Invoke();
        }
    }
}
