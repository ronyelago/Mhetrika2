namespace mhetrika.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cep = c.String(nullable: false, maxLength: 50, unicode: false),
                        Number = c.Int(nullable: false),
                        Street = c.String(nullable: false, maxLength: 50, unicode: false),
                        Neighbourhood = c.String(nullable: false, maxLength: 50, unicode: false),
                        City = c.String(nullable: false, maxLength: 50, unicode: false),
                        Uf = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(maxLength: 50, unicode: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 32, unicode: false),
                        PatientId = c.Int(nullable: false),
                        LaboratoryId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Laboratories", t => t.LaboratoryId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId)
                .Index(t => t.LaboratoryId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Laboratories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64, unicode: false),
                        Cnpj = c.String(nullable: false, maxLength: 32, unicode: false),
                        Email = c.String(nullable: false, maxLength: 32, unicode: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Gender = c.String(nullable: false, maxLength: 10, unicode: false),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Cpf = c.String(maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 32, unicode: false),
                        Phone = c.String(maxLength: 20, unicode: false),
                        AddressId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Medicaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64, unicode: false),
                        Status = c.String(nullable: false, maxLength: 32, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 128, unicode: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 8, unicode: false),
                        CardioExamId = c.Int(nullable: false),
                        QuizId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cardio", t => t.CardioExamId)
                .ForeignKey("dbo.Questions", t => t.QuizId)
                .Index(t => t.CardioExamId)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 8, unicode: false),
                        ExamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.ExamId)
                .Index(t => t.ExamId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Crm = c.String(nullable: false, maxLength: 20, unicode: false),
                        Uf = c.String(nullable: false, maxLength: 2, unicode: false),
                        Phone = c.String(maxLength: 20, unicode: false),
                        Specialty = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Cardio",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Pas = c.Int(nullable: false),
                        Ldl_c = c.Int(nullable: false),
                        Hdl_c = c.Int(nullable: false),
                        Ct = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Smokes = c.Boolean(nullable: false),
                        Statin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Fibrosis",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        AST = c.Double(nullable: false),
                        ALT = c.Double(nullable: false),
                        IMC = c.Double(nullable: false),
                        Platelets = c.Double(nullable: false),
                        Albumin = c.Double(nullable: false),
                        Diabetic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fibrosis", "Id", "dbo.Exams");
            DropForeignKey("dbo.Cardio", "Id", "dbo.Exams");
            DropForeignKey("dbo.Doctors", "Id", "dbo.Users");
            DropForeignKey("dbo.Results", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Responses", "QuizId", "dbo.Questions");
            DropForeignKey("dbo.Responses", "CardioExamId", "dbo.Cardio");
            DropForeignKey("dbo.Exams", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Exams", "LaboratoryId", "dbo.Laboratories");
            DropForeignKey("dbo.Laboratories", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Exams", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Fibrosis", new[] { "Id" });
            DropIndex("dbo.Cardio", new[] { "Id" });
            DropIndex("dbo.Doctors", new[] { "Id" });
            DropIndex("dbo.Results", new[] { "ExamId" });
            DropIndex("dbo.Responses", new[] { "QuizId" });
            DropIndex("dbo.Responses", new[] { "CardioExamId" });
            DropIndex("dbo.Patients", new[] { "AddressId" });
            DropIndex("dbo.Laboratories", new[] { "AddressId" });
            DropIndex("dbo.Exams", new[] { "DoctorId" });
            DropIndex("dbo.Exams", new[] { "LaboratoryId" });
            DropIndex("dbo.Exams", new[] { "PatientId" });
            DropTable("dbo.Fibrosis");
            DropTable("dbo.Cardio");
            DropTable("dbo.Doctors");
            DropTable("dbo.Results");
            DropTable("dbo.Responses");
            DropTable("dbo.Questions");
            DropTable("dbo.Medicaments");
            DropTable("dbo.Patients");
            DropTable("dbo.Laboratories");
            DropTable("dbo.Exams");
            DropTable("dbo.Users");
            DropTable("dbo.Addresses");
        }
    }
}
