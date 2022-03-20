namespace DataAccessLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonOrder : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Order", newName: "Order_Company");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Order_Company", newName: "Order");
        }
    }
}
