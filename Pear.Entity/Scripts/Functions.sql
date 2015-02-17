/****** Object:  UserDefinedFunction [dbo].[fnGetStoresByDistance]    Script Date: 2/17/2015 12:03:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER FUNCTION [dbo].[fnGetStoresByDistance] 
(
	@latitude real,
	@longitude real,
	@maxDistance real
)
RETURNS TABLE 
AS
RETURN 
(
	select *
	from Store
	where geography::STGeomFromText('POINT(' + convert(varchar(50), @latitude) + ' ' + convert(varchar(50), @longitude) + ')', 4326).STDistance(geography::STGeomFromText('POINT(' + convert(varchar(50), Latitude) + ' ' + convert(varchar(50), Longitude) + ')', 4326)) <= @maxDistance
)
