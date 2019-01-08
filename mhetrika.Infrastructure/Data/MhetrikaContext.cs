using mhetrika.core.Entities;
using mhetrika.Infrastructure.Data.Mappings;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace mhetrika.Infrastructure.Data
{
    public class MhetrikaContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Laboratory> Laboratories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Response> Responses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new PatientMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new DoctorMap());
            modelBuilder.Configurations.Add(new ExamMap());
            modelBuilder.Configurations.Add(new LaboratoryMap());
            modelBuilder.Configurations.Add(new CardioMap());
            modelBuilder.Configurations.Add(new FibrosisMap());
            modelBuilder.Configurations.Add(new MedicamentMap());
            modelBuilder.Configurations.Add(new QuizMap());
            modelBuilder.Configurations.Add(new ResponseMap());
            modelBuilder.Configurations.Add(new ResultMap());

            //Remove a pluralização automática das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Remove a exclusão em cascata de tabelas relacionadas (um para muitos)
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //Remove a exclusão em cascata de tableas relacionadas (muitos para muitos)
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Diz ao EF que todos nomes de campos que forem Id serão PK
            modelBuilder.Properties().
                Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //Diz ao EF que todos os campos tipo string serão varchar com tamanho máximo de 1000
            modelBuilder.Properties<string>().
                Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().
                Configure(p => p.HasMaxLength(500));
        }
    }
}
