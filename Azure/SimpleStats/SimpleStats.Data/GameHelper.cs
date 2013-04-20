using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleStats.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace SimpleStats.Data
{
    public static class GameHelper
    {
        public static void ProcessGame(GameData gameData)
        {
            foreach (Int64 playerId in gameData.PlayerData.Keys)
            {
                PlayerHelper.ProcessPlayerGame(playerId, gameData.PlayerData[playerId], gameData.GameId, gameData.GameDurationSeconds);
            }
        }      
    }
}
