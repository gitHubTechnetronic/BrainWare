
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE 
	[dbo].[proc_OrderProducts]	
	@Id          decimal(15, 0)
AS
BEGIN
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SELECT op.price as Price, op.order_id, op.product_id, op.quantity as Quantity, p.name as Name, p.price as ProductPrice
	,op.OrderProductId
FROM orderproduct op 
INNER JOIN product p on op.product_id=p.product_id

WHERE
	op.order_id in (select o.order_id FROM [order] o WHERE o.company_id = @Id)

RETURN @@ROWCOUNT 
END
GO