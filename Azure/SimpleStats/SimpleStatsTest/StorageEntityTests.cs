using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;
using SimpleStats.Data;
using SimpleStats.Storage;

namespace SimpleStatsTest
{
    [TestClass]
    public class StorageEntityTests
    {
        [TestMethod]
        public void CreateAndReadPlayerEntity()
        {
          Random rand = new Random();
          Int64 playerId = rand.Next();
          PlayerEntity player = new PlayerEntity(playerId);

          TableOperation insertOperation = TableOperation.Insert(player);
          StorageManager.Instance.PlayersTable.Execute(insertOperation);

          Assert.IsNotNull(PlayerEntity.GetPlayerEntity(playerId));

        }
    }
}
