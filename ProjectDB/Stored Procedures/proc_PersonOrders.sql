SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE 
	[dbo].[proc_PersonLastOrder]	

AS
BEGIN
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
 
select P.PersonId, P.NameFirst, P.NameLast, OP.OrderId, FORMAT(OP.OrderDateTime, 'dd/MM/yyyy hh:mm tt', 'en-US')
from Person P
OUTER APPLY (SELECT TOP 1 *
	FROM   [Order]
	WHERE  PersonId = P.PersonId
	ORDER  BY OrderDateTime desc) OP

RETURN @@ROWCOUNT 
END
