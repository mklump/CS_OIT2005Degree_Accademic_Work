set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[ngCreateAlbum]
  @AlbumName varchar(50)=null,
  @AlbumDesc varchar(2500)=null,
  @ParentAlbumID int=0,
  @Date datetime /* Parameter Added */
AS

INSERT INTO Album (AlbumName, AlbumDesc, ParentAlbumID, AlbumCreateDate)
	VALUES (@AlbumName, @AlbumDesc, @ParentAlbumID,
	/* getdate() Insertion Changed*/ @Date)



