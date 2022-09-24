using UnityEngine;
using UnityEngine.Events;

namespace SortItems
{
    public class GameStateMachineProvider : MonoBehaviour
    {
        [SerializeField] private GameStateMachine _gameStateMachine;
        [SerializeField] private Animator _animator;
        [SerializeField] private string canvasName;
        public GameStateMachine GameStateMachine => _gameStateMachine;
        public UnityEvent OnChangeState;

        private void OnEnable() 
        {
            try
            {
                _animator=gameObject.GetComponent<Animator>();
            }
            catch {};
            _gameStateMachine.OnChangeState.AddListener(OnChangeStateDelegate);
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
