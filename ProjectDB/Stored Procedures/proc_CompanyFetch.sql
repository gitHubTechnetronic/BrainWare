﻿SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE 
	[dbo].[proc_CompanyFetch]	
	@Id          decimal(15, 0)
AS
BEGIN
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SELECT
	c.company_id as CompanyId,
	c.name as CompanyName
FROM Company c
WHERE
	c.company_id = @Id

RETURN @@ROWCOUNT 
END
GO
