using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization;

namespace SimpleStats.Engine
{
    [DataContract]
    public class GameData
    {
        [DataMember]
        public Guid GameId { get; set; }

        [DataMember]
        public Int32 GameDurationSeconds { get; set; }

        [DataMember]
        public Dictionary<Int64, PlayerGameData> PlayerData { get; set; }
    }

    [DataContract]
    public class PlayerGameData
    {
        [DataMember]
        public bool Win { get; set; }

        [DataMember]
        public Int32 Points { get; set; }

        [DataMember]
        public Int32 Kills { get; set; }

        [DataMember]
        public Int32 Deaths { get; set; }
    }
}
