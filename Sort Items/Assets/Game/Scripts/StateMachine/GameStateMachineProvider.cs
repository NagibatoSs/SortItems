using UnityEngine;
using UnityEngine.Events;

namespace SortItems
{
    public class GameStateMachineProvider : MonoBehaviour
    {
        [SerializeField] private GameStateMachine _gameStateMachine;
        [SerializeField] private Animator _animator;
        public GameStateMachine GameStateMachine => _gameStateMachine;
       // [SerializeField] List<Canvas>
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
            OnChangeState.Invoke();
        }

        public void OpenUI()
        {
            _animator.SetTrigger("Open");

        }

        public void CloseUI()
        {
            _animator.SetTrigger("Close");
        }

        public void MasterUI()
        {
            switch (GameStateMachine.GameState)
                {
                case State.Play:
                    break;
                case State.Menu:
                    break;
                case State.Win:
                    break;
                case State.Lose:
                    break;
                }
        }

        // public void OpenPlay()
        // {
        //     if (GameStateMachine.GameState==State.Win)

        // }
    }
}
