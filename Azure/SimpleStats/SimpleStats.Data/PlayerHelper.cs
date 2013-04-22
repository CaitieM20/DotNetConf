using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using SimpleStats.Storage;

namespace SimpleStats.Engine
{
    public class PlayerHelper
    {
        public static void ProcessPlayerGame(Int64 playerId, PlayerGameData gameData, Guid gameId, Int64 gameSeconds)
        {
            // Create the batch operation.
            TableBatchOperation batchOperation = new TableBatchOperation();

            //TODO: Get Player Row
            PlayerEntity player = PlayerEntity.GetPlayerEntity(playerId);
            batchOperation.InsertOrReplace(player);

            //Update Player Entity with Game Data
            player.TotalDeaths += gameData.Deaths;
            player.TotalKills += gameData.Kills;
            player.TotalPoints += gameData.Points;
            player.TotalWins += gameData.Win ? 1 : 0;
            player.TotalGames += 1;
            player.TotalSecondsPlayed += gameSeconds;

            //Create PlayerGame Row
            PlayerGameEntity playerGame = new PlayerGameEntity(playerId, gameId)
            {
                Points = gameData.Points,
                Win = gameData.Win,
                Kills = gameData.Kills,
                Deaths = gameData.Deaths,
                GameDuration = gameSeconds
            };
            batchOperation.Insert(playerGame);
        

            try
            {
                StorageManager.Instance.PlayersTable.ExecuteBatch(batchOperation);
            }
            catch (Exception ex)
            {
                //TODO: handle exception, check if its because an entity already existed.
                //This means we've already handled this data.  
            }
        }
    }
}
