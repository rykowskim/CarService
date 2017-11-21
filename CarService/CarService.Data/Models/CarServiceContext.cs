namespace CarService.Data.Models
{
    using System.Data.Entity;

    public partial class CarServiceContext : DbContext
    {
        public CarServiceContext()
            : base("name=CarServiceContext")
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Cost> Cost { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<OrderType> OrderType { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserXRole> UserXRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasMany(e => e.Customer)
                .WithRequired(e => e.Address)
                .HasForeignKey(e => e.Address_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.Address)
                .HasForeignKey(e => e.Address_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Car)
                .HasForeignKey(e => e.Car_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cost>()
                .Property(e => e.Cost1)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Car)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.Customer_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.Customer_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.Employee_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Cost)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.Order_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderStatus>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<OrderStatus>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.OrderStatus)
                .HasForeignKey(e => e.OrderStatus_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderType>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.OrderType)
                .HasForeignKey(e => e.OrderType_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.Position)
                .HasForeignKey(e => e.Position_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserXRole)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.Role_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserXRole)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
