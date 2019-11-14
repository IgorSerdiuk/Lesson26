namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComment_OrderDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "Comment");
        }
    }
}
