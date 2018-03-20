create database ZingMP3;
go

use ZingMP3;
go

create table Playlist(
	id INT IDENTITY(1,1) primary key,
	name NVARCHAR(60),
	created_at datetime,
	updated_at datetime,
)

create table Song(
	id INT IDENTITY(1,1) primary key,
	name NVARCHAR(60),
	artist NVARCHAR(100),
	thumb TEXT,
	playlistID int not null,
	foreign key (playlistID) references Playlist(id),
	url TEXT,
	zid VARCHAR(50),
)