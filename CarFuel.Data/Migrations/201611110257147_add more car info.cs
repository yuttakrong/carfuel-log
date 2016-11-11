namespace CarFuel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmorecarinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "PlateNo", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Cars", "Color", c => c.String(maxLength: 20));

            Sql("UPDATE dbo.cars SET Color='Black'");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Color");
            DropColumn("dbo.Cars", "PlateNo");
        }
    }
}
