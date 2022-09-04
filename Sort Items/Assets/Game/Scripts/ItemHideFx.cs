using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace SortItems
{
    public class ItemHideFx : MonoBehaviour
    {
        [SerializeField] private VFXPoolProvider _vfxPoolProvider;
        public UnityEvent OnHide;

        protected IEnumerator RemoveObj()
        {
            yield return new WaitForSeconds(0.7f);
            Destroy(this.gameObject); 
        }

        public void Hide()
        {
            OnHide.Invoke();
            VFXPoolItem poolItem = _vfxPoolProvider.VFXPool.GetFromPool();
            poolItem.transform.position = transform.position;
            poolItem.ParticleSystem.Play();
            StartCoroutine(RemoveObj());
        }
    }
}
