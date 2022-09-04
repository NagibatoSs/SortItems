using UnityEngine;

namespace SortItems
{
    public class CharacterAnimationPlayer : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _trigName;

        private void Start() 
        {
            _animator.SetTrigger(_trigName);
        }

        public void PlayFail()
        {
            _animator.SetTrigger("Fail");
        }

        public void PlayWin()
        {
            _animator.SetTrigger("Win");
        }

    }
}
