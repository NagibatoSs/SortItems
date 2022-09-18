using UnityEngine;

namespace SortItems
{
    public class ChangeGameStateTo : MonoBehaviour
    {
        [SerializeField] private GameStateMachine _gameStateMachine;
        [SerializeField] private State _gameState;
        [SerializeField] private Animator _animator;

        public GameStateMachine GameStateMachine => _gameStateMachine;

        private void Start() 
        {
            //_animator=gameObject.GetComponent<Animator>();
        }

        public void ChangeStateTo()
        {
            _animator.SetTrigger("Close");
            GameStateMachine.GameState = _gameState;
        }
    }
}
