SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE 
	[dbo].[proc_PersonOrdersByDate]	
	@OrderDate          date
AS
BEGIN
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

declare @max date = DateAdd(DAY, 1, @OrderDate) 

select * from Person
where PersonID in (
	SELECT o.PersonId
	FROM [Order] o 

	WHERE
		o.OrderDateTime >= @OrderDate and o.OrderDateTime < @max
)

RETURN @@ROWCOUNT 
END
