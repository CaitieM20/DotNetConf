using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace SimpleStats.Storage
{
    public class PlayerEntity : TableEntity
    {
        private static string RowKeyString = "Players";

        public PlayerEntity(Int64 playerId)
        {
            PartitionKey = StorageManager.GetPlayerTablePartitionKey(playerId);
            RowKey = RowKeyString;
        }

        public PlayerEntity() { }

        public string Name { get; set; }
        public string Picture { get; set; }

        public Int64 TotalPoints { get; set; }
        public Int32 TotalGames { get; set; }
        public Int32 TotalWins { get; set; }
        public Int32 TotalKills { get; set; }
        public Int32 TotalDeaths { get; set; }
        public Int64 TotalSecondsPlayed { get; set; }


        public static PlayerEntity GetPlayerEntity(Int64 playerId)
        {
            var playerQuery = new TableQuery<PlayerEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, StorageManager.GetPlayerTablePartitionKey(playerId)));
        
            IEnumerable<PlayerEntity> results =StorageManager.Instance.PlayersTable.ExecuteQuery(playerQuery);
            PlayerEntity entity = results.FirstOrDefault();

            if (null == entity)
                entity = new PlayerEntity(playerId);

            return entity;
        }
    }
}
