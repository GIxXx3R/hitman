using Common;
using Enemy;
using GameState.Interface;
using GameState.Signals;
using InputSystem;
using PathSystem;
using Player;
using UnityEngine;
using Zenject;

namespace GameState
{
    public class GameService : IGameService,IInitializable
    {
        IGameStates currentGameState = new GamePlayerState();
        IGameStates previousGameState = new GameEnemyState();
        readonly SignalBus signalBus;

        public GameService(SignalBus signalBus)
        {
            this.signalBus = signalBus;
           
        }
        public GameStatesType GetCurrentState()
        {
            return currentGameState.GetStatesType();
        }
        public void ChangeState()
        {
            IGameStates tempState = previousGameState;
            if (GetCurrentState() == GameStatesType.PLAYERSTATE)
            {
                previousGameState.OnStateExit();
                previousGameState = currentGameState;
                currentGameState = tempState;
                currentGameState.OnStateEneter();
                Debug.Log(currentGameState);
            }
        }

        public void Initialize()
        {
            signalBus.TryFire(new GameStartSignal());
        }
    }
}