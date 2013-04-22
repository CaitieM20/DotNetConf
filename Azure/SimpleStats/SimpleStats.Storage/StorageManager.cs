using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage.Table;

namespace SimpleStats.Storage
{
    public class StorageManager
    {

        private static readonly string StorageAccountString = "UseDevStorage=true";
        private static StorageManager _storageManager = null;     
        public static StorageManager Instance
        {
            get
            {
                if (null == _storageManager)
                {
                   _storageManager = new StorageManager();
                }
                return _storageManager; 
            }
        }

        public CloudStorageAccount StorageAccount;
        public CloudTableClient TableClient;
        public CloudTable PlayersTable;

        private StorageManager()
        {
            // Retrieve the storage account from the connection string.
            StorageAccount = CloudStorageAccount.Parse(StorageAccountString);

            // Create the table client.
            TableClient = StorageAccount.CreateCloudTableClient();

            // Create the table if it doesn't exist.
            PlayersTable = TableClient.GetTableReference("Players");
        }
        
        public static string GetPlayerTablePartitionKey(Int64 playerId)
        {
            return String.Format("{0:x16}");
        }

    }
}
