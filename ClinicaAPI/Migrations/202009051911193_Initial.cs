namespace ClinicaAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointment_area",
                c => new
                    {
                        id = c.Int(nullable: false),
                        name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.name, unique: true);
            
            CreateTable(
                "dbo.Appointment",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        p_id = c.Int(nullable: false),
                        a_date = c.DateTime(nullable: false),
                        area_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Appointment_area", t => t.area_id, cascadeDelete: true)
                .ForeignKey("dbo.Patient", t => t.p_id, cascadeDelete: true)
                .Index(t => t.p_id)
                .Index(t => t.area_id);
            
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        id = c.Int(nullable: false),
                        name = c.String(maxLength: 200),
                        lastname = c.String(maxLength: 200),
                        phone = c.Int(),
                        sex = c.String(maxLength: 1),
                        password = c.String(maxLength: 100),
                        admin = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointment", "p_id", "dbo.Patient");
            DropForeignKey("dbo.Appointment", "area_id", "dbo.Appointment_area");
            DropIndex("dbo.Appointment", new[] { "area_id" });
            DropIndex("dbo.Appointment", new[] { "p_id" });
            DropIndex("dbo.Appointment_area", new[] { "name" });
            DropTable("dbo.Patient");
            DropTable("dbo.Appointment");
            DropTable("dbo.Appointment_area");
        }
    }
}
