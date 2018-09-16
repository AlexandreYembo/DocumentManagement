using FluentMigrator;
using System;

namespace DocumentManagement.FluentMigrator.Migrations
{
    [Migration(2018091607250000)]
    public class _2018091607250000_CreateTableDocument : Migration
    {
        public override void Up()
        {
            Create.Table("DOCUMENT")
                .WithColumn("IDDOCUMENT").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("IDUSERAPP").AsString(100).NotNullable().ForeignKey("USERAPP", "IDUSERAPP")
                .WithColumn("FILENAME").AsString(100).Nullable()
                .WithColumn("FILESIZE").AsInt64().NotNullable()
                .WithColumn("FILEFORMAT").AsString(50).Nullable()
                .WithColumn("UPLOADDATE").AsDateTime().NotNullable().WithDefaultValue(DateTime.Now)
                .WithColumn("UPDATEDATE").AsDateTime().Nullable()
                .WithColumn("LASTACCESSDATE").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("DOCUMENT");
        }
    }
}