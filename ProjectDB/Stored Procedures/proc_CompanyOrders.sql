
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE 
	[dbo].[proc_CompanyOrders]	
	@Id          decimal(15, 0)
AS
BEGIN
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SELECT  
	o.description as Description, o.order_id 

FROM [Order_Company] o 

WHERE
	o.company_id = @Id

RETURN @@ROWCOUNT 
END
GO