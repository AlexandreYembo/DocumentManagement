using FluentMigrator;

namespace DocumentManagement.FluentMigrator.Migrations
{
    [Migration(2018091607230000)]
    public class _2018091607230000_CreateTableUser : Migration
    {
        public override void Up()
        {
            Create.Table("USERAPP")
                .WithColumn("IDUSERAPP").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("DSLOGIN").AsString(100).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("USERAPP");
        }
    }
}