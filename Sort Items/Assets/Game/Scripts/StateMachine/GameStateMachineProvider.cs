using UnityEngine;
using UnityEngine.Events;

namespace SortItems
{
    public class GameStateMachineProvider : MonoBehaviour
    {
        [SerializeField] private GameStateMachine _gameStateMachine;
        public GameStateMachine GameStateMachine => _gameStateMachine;
        public UnityEvent OnChangeState;

        private void OnEnable() 
        {
            _gameStateMachine.OnChangeState.AddListener(OnChangeStateDelegate);
        }

        private void OnDisable() 
        {
            _gameStateMachine.OnChangeState.RemoveListener(OnChangeStateDelegate);
        }

        private void OnChangeStateDelegate()
        {
            OnChangeState.Invoke();
        }
    }
}
