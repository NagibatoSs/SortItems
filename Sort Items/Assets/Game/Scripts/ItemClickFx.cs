using UnityEngine;
using UnityEngine.EventSystems;

namespace SortItems
{
    public class ItemClickFx : MonoBehaviour, IPointerDownHandler
    {
        //[SerializeField] private GameObject _circleClickFxPrefab;
        [SerializeField] private VFXPoolProvider _vfxPoolProvider;

        public void OnPointerDown(PointerEventData eventData)
        {
            //Instantiate(_circleClickFxPrefab, transform.position, Quaternion.identity, null);
            VFXPoolItem poolItem = _vfxPoolProvider.VFXPool.GetFromPool();
            poolItem.transform.position = transform.position;
            poolItem.ParticleSystem.Play();

        }
    }
}