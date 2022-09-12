using UnityEngine;
using UnityEngine.Events;

namespace SortItems
{
    [CreateAssetMenu(fileName = "GameStateMachine", menuName = "Create GameStateMachine", order = 0)]

    public class GameStateMachine : ScriptableObject
    {
        [SerializeField] private State _gameState;

        public UnityEvent OnChangeState;

        public State GameState
        {
            get => _gameState;
            set  
            {
                if (_gameState == value) return;
                _gameState = value;
                OnChangeState.Invoke();
            }
        }
    }   
}
