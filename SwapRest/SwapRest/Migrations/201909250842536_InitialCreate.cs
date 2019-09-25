namespace SwapRest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50, unicode: false),
                        lastname = c.String(nullable: false, maxLength: 50, unicode: false),
                        email = c.String(nullable: false, maxLength: 50, unicode: false),
                        password = c.String(nullable: false, maxLength: 50, unicode: false),
                        birthday = c.DateTime(nullable: false, storeType: "date"),
                        mobilephone = c.String(nullable: false, maxLength: 50, unicode: false),
                        description = c.String(nullable: false, maxLength: 100, unicode: false),
                        active = c.Int(nullable: false),
                        gender = c.String(nullable: false, maxLength: 50, unicode: false),
                        country_id = c.Int(nullable: false),
                        token = c.String(maxLength: 50),
                        rol_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Rols", t => t.rol_id)
                .ForeignKey("dbo.Countries", t => t.country_id)
                .Index(t => t.country_id)
                .Index(t => t.rol_id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        student_id = c.Int(nullable: false),
                        teacher_id = c.Int(nullable: false),
                        latitude = c.Single(nullable: false),
                        lenght = c.Single(nullable: false),
                        day = c.DateTime(),
                        task_id = c.Int(nullable: false),
                        description = c.String(nullable: false, maxLength: 100, unicode: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Tasks", t => t.task_id)
                .ForeignKey("dbo.Users", t => t.student_id)
                .ForeignKey("dbo.Users", t => t.teacher_id)
                .Index(t => t.student_id)
                .Index(t => t.teacher_id)
                .Index(t => t.task_id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.User_wish",
                c => new
                    {
                        user_id = c.Int(nullable: false),
                        language_id = c.Int(nullable: false),
                        level_id = c.Int(nullable: false),
                        wish_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.user_id, t.language_id, t.level_id, t.wish_id })
                .ForeignKey("dbo.Languages", t => t.language_id)
                .ForeignKey("dbo.Levels", t => t.level_id)
                .ForeignKey("dbo.Wishes", t => t.wish_id)
                .ForeignKey("dbo.Users", t => t.user_id)
                .Index(t => t.user_id)
                .Index(t => t.language_id)
                .Index(t => t.level_id)
                .Index(t => t.wish_id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Wishes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "country_id", "dbo.Countries");
            DropForeignKey("dbo.User_wish", "user_id", "dbo.Users");
            DropForeignKey("dbo.User_wish", "wish_id", "dbo.Wishes");
            DropForeignKey("dbo.User_wish", "level_id", "dbo.Levels");
            DropForeignKey("dbo.User_wish", "language_id", "dbo.Languages");
            DropForeignKey("dbo.Users", "rol_id", "dbo.Rols");
            DropForeignKey("dbo.Lessons", "teacher_id", "dbo.Users");
            DropForeignKey("dbo.Lessons", "student_id", "dbo.Users");
            DropForeignKey("dbo.Lessons", "task_id", "dbo.Tasks");
            DropIndex("dbo.User_wish", new[] { "wish_id" });
            DropIndex("dbo.User_wish", new[] { "level_id" });
            DropIndex("dbo.User_wish", new[] { "language_id" });
            DropIndex("dbo.User_wish", new[] { "user_id" });
            DropIndex("dbo.Lessons", new[] { "task_id" });
            DropIndex("dbo.Lessons", new[] { "teacher_id" });
            DropIndex("dbo.Lessons", new[] { "student_id" });
            DropIndex("dbo.Users", new[] { "rol_id" });
            DropIndex("dbo.Users", new[] { "country_id" });
            DropTable("dbo.Wishes");
            DropTable("dbo.Levels");
            DropTable("dbo.Languages");
            DropTable("dbo.User_wish");
            DropTable("dbo.Rols");
            DropTable("dbo.Tasks");
            DropTable("dbo.Lessons");
            DropTable("dbo.Users");
            DropTable("dbo.Countries");
        }
    }
}
