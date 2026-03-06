using Unity.VisualScripting;
using UnityEngine;

namespace SortItems
{
    public class ChangeGameStateTo : MonoBehaviour
    {
        [SerializeField] private GameStateMachine _gameStateMachine;
        [SerializeField] private State _gameState;
        [SerializeField] private Animator _animator;

        public GameStateMachine GameStateMachine => _gameStateMachine;

        public void ChangeStateTo()
        {
            if (_animator == null)
            {
                var canvas = GameObject.Find("PlayCanvas");
                _animator = canvas?.GetComponent<Animator>();
            }

            _animator.SetTrigger("Close");
            
            GameStateMachine.GameState = _gameState;
        }
    }
}
