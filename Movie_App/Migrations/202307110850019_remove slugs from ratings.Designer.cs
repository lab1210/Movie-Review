﻿// <auto-generated />
namespace Movie_App.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed partial class removeslugsfromratings : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(removeslugsfromratings));
        
        string IMigrationMetadata.Id
        {
            get { return "202307110850019_remove slugs from ratings"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}