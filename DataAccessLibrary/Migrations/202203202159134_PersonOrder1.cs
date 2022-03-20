namespace DataAccessLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonOrder1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        OrderDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        NameFirst = c.String(maxLength: 128),
                        NameLast = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "PersonId", "dbo.Person");
            DropIndex("dbo.Order", new[] { "PersonId" });
            DropTable("dbo.Person");
            DropTable("dbo.Order");
        }
    }
}
