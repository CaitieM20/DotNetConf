CREATE TABLE [simple_stats].[dbo].[PlayerTable](

	[player_id] [bigint] NOT NULL,
	[player_name] [varchar](50) NOT NULL,
	[player_pic] [image] NULL,

	PRIMARY KEY (player_id)
)
GO 

CREATE TABLE [simple_stats].[dbo].[PlayerStats](
	[player_id] [bigint] NOT NULL,
	[total_games] [int],
	[total_wins] [int],
	[total_points] [int],
	[total_kills] [int],
	[total_deaths] [int],
	[total_timePlayed] [bigint],
	PRIMARY KEY (player_id),
	FOREIGN KEY (player_id) REFERENCES PlayerTable(player_id)
)
GO

Create Table [simple_stats].[dbo].[Games](
	[game_id] [bigint] NOT NULL,
	[game_duration] [int],
	PRIMARY KEY (game_id)
)
GO

CREATE TABLE [simple_stats].[dbo].[PlayerGames](
	[player_id] [bigint] NOT NULL ,
	[game_id] [bigint] NOT NULL,
	[win] [bit],
	[points_earned] [int],
	[kills] [int],
	[deaths] [int],
	PRIMARY KEY (player_id, game_id),
	FOREIGN KEY (player_id) REFERENCES PlayerTable(player_id),
	FOREIGN KEY (game_id) REFERENCES Games(game_id)
)
GO



