using UnityEngine;

namespace SortItems
{
    public class ChangeGameStateTo : MonoBehaviour
    {
        [SerializeField] private GameStateMachine _gameStateMachine;
        [SerializeField] private State _gameState;

        public GameStateMachine GameStateMachine => _gameStateMachine;

        public void ChangeState()
        {
            Debug.Log("zashlo v state");
            GameStateMachine.GameState = _gameState;
        }
    }
}
