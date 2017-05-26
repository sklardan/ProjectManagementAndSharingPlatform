namespace DPSP_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredProjectInformations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Projects", "Manager", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Projects", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Budget", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Budget", c => c.String());
            AlterColumn("dbo.Projects", "Content", c => c.String());
            AlterColumn("dbo.Projects", "Manager", c => c.String());
            AlterColumn("dbo.Projects", "Name", c => c.String());
        }
    }
}
