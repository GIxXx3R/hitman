using System.Collections.Generic;
using Common;
namespace GameState
{
    public interface IGameService
    {
         void IncrementMaxLevel();
         GameStatesType GetCurrentState();
         void ChangeToPlayerState();
         int GetCurrentLevel();
         void ChangeToLobbyState();
         List<StarData> GetStarsForLevel(int level);
         void SetCurrentLevel(int level);
         void ChangeToEnemyState();
         void ChangeToGameOverState();
         void ChangeToLoadLevelState();
         void IncrementLevel();
         int GetNumberOfLevels();
    }
}