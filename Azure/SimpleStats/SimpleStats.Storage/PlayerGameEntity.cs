using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace SimpleStats.Storage
{
    public class PlayerGameEntity : TableEntity 
    {
        private static string RowKeyString = "game_{0}";

        public PlayerGameEntity(Int64 playerId, Guid gameId)
        {
            PartitionKey = StorageManager.GetPlayerTablePartitionKey(playerId);
            RowKey = String.Format(RowKeyString, gameId);
        }

        public Int64 Points { get; set; }
        public bool Win { get; set; }
        public Int32 Kills { get; set; }
        public Int32 Deaths { get; set; }
        public Int64 GameDuration { get; set; }  
    }
}
