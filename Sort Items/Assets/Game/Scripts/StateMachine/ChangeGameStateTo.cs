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
            if (_animator!=null)
            _animator.SetTrigger("Close");
            GameStateMachine.GameState = _gameState;
        }
    }
}
