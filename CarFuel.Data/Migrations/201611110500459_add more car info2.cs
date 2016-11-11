namespace CarFuel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmorecarinfo2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Owner", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Owner");
        }
    }
}
