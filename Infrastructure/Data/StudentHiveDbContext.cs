// using Microsoft.EntityFrameworkCore;
// using StudentHiveApi.Infrastructure.Data.Configurations;

// namespace StudentHive.Domain.Entities;

// public partial class StudentHiveDbContext : DbContext
// {
//     public StudentHiveDbContext()
//     {
//     }

//     public StudentHiveDbContext(DbContextOptions<StudentHiveDbContext> options)
//         : base(options)
//     {
//     }

//     public virtual DbSet<Administrador> Administrador { get; set; }

//     public virtual DbSet<Event> Events { get; set; }

//     public virtual DbSet<HouseService> HouseServices { get; set; }

//     public virtual DbSet<Image> Images { get; set; }

//     public virtual DbSet<Location> Locations { get; set; }

//     public virtual DbSet<Notification> Notifications { get; set; }

//     public virtual DbSet<RentalHouseDetail> RentalHouseDetails { get; set; }

//     public virtual DbSet<RentalHouse> RentalHouses { get; set; }

//     public virtual DbSet<ReportType> ReportTypes { get; set; }

//     public virtual DbSet<Report> Reports { get; set; }

//     public virtual DbSet<Request> Requests { get; set; }

//     public virtual DbSet<ReservationConfirmed> ReservationsConfirmed { get; set; }

//     public virtual DbSet<Rol> Rols { get; set; }

//     public virtual DbSet<User> Users { get; set; }

//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.ApplyConfiguration(new AdministradorConfiguration());
//         modelBuilder.ApplyConfiguration(new EventConfiguration());
//         modelBuilder.ApplyConfiguration(new HouseServiceConfiguration());
//         modelBuilder.ApplyConfiguration(new ImageConfiguration());
//         modelBuilder.ApplyConfiguration(new LocationConfiguration());
//         modelBuilder.ApplyConfiguration(new NotificationConfiguration());
//         modelBuilder.ApplyConfiguration(new RentalHouseDetailConfiguration());
//         modelBuilder.ApplyConfiguration(new RentalHouseConfiguration());
//         modelBuilder.ApplyConfiguration(new ReportTypeConfiguration());
//         modelBuilder.ApplyConfiguration(new ReportConfiguration());
//         modelBuilder.ApplyConfiguration(new RequestConfiguration());
//         modelBuilder.ApplyConfiguration(new ReservationConfirmedConfiguration());
//         modelBuilder.ApplyConfiguration(new RolConfiguration());
//         modelBuilder.ApplyConfiguration(new UserConfiguration());
//         OnModelCreatingPartial(modelBuilder);
//     }

//     partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
// }
