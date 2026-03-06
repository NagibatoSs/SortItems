using UnityEngine;
using UnityEngine.Events;

namespace SortItems
{
    public class GameStateMachineProvider : MonoBehaviour
    {
        [SerializeField] private GameStateMachine _gameStateMachine;
        [SerializeField] private string canvasName;
        public GameStateMachine GameStateMachine => _gameStateMachine;
        public UnityEvent OnChangeState;

        private void OnEnable() 
        {
            _gameStateMachine.OnChangeState.AddListener(OnChangeStateDelegate);
        }

        private void Start()
        {
            _gameStateMachine.GameState = State.Menu;
        }

        private void OnDisable() 
        {
            _gameStateMachine.OnChangeState.RemoveListener(OnChangeStateDelegate);
        }

        private void OnChangeStateDelegate()
        {
            if (canvasName==GameStateMachine.GameState.ToString())
            OnChangeState.Invoke();
        }
    }
}
