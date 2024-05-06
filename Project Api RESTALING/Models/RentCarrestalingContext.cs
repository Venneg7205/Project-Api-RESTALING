using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project_Api_RESTALING.Models;

public partial class RentCarrestalingContext : DbContext
{
    public RentCarrestalingContext()
    {
    }

    public RentCarrestalingContext(DbContextOptions<RentCarrestalingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdditionalService> AdditionalServices { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarMarking> CarMarkings { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<АвтомобилиВПрокате> АвтомобилиВПрокатеs { get; set; }

    public virtual DbSet<Автопарк> Автопаркs { get; set; }

    public virtual DbSet<ОтделКадров> ОтделКадровs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=RentCARRESTALING;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_CI_AS");

        modelBuilder.Entity<AdditionalService>(entity =>
        {
            entity.HasKey(e => e.IdУслуги).HasName("PK__Дополнит__C62AED9B60458848");

            entity.ToTable("Additional services");

            entity.Property(e => e.IdУслуги)
                .ValueGeneratedNever()
                .HasColumnName("ID_Услуги");
            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Описание)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Цена).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.IdАвтомобиля).HasName("PK__Автомоби__F14F5D3F27E321B1");

            entity.Property(e => e.IdАвтомобиля)
                .ValueGeneratedNever()
                .HasColumnName("ID_Автомобиля");
            entity.Property(e => e.IdМарки).HasColumnName("ID_Марки");
            entity.Property(e => e.IdМеханика).HasColumnName("ID_Механика");
            entity.Property(e => e.ГосНомер)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ДатаПоследнегоТо)
                .HasColumnType("date")
                .HasColumnName("ДатаПоследнегоТО");
            entity.Property(e => e.НомерДвигателя)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.НомерКузова)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Особенности)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ОтметкаОвозврате).HasColumnName("ОтметкаОВозврате");
            entity.Property(e => e.Цена).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ЦенаПроката).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<CarMarking>(entity =>
        {
            entity.HasKey(e => e.IdМарки).HasName("PK__МаркиАвт__E6BA2233EF42CDA5");

            entity.ToTable("Car Markings");

            entity.Property(e => e.IdМарки)
                .ValueGeneratedNever()
                .HasColumnName("ID_Марки");
            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Описание)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ТехническиеХарактеристики)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdКлиента).HasName("PK__Клиенты__F7300111893AAB90");

            entity.ToTable("Client");

            entity.Property(e => e.IdКлиента)
                .ValueGeneratedNever()
                .HasColumnName("ID_Клиента");
            entity.Property(e => e.Адрес)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Активность)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ВодительскоеУдостоверение)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Водительское удостоверение");
            entity.Property(e => e.ДатаРождения).HasColumnType("date");
            entity.Property(e => e.ПаспортныеДанные)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Пол)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Телефон)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdСотрудника).HasName("PK__Сотрудни__F4052FE38CF4D008");

            entity.ToTable("Employee");

            entity.Property(e => e.IdСотрудника)
                .ValueGeneratedNever()
                .HasColumnName("ID_Сотрудника");
            entity.Property(e => e.IdДолжности).HasColumnName("ID_Должности");
            entity.Property(e => e.Адрес)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ПаспортныеДанные)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Паспортные_данные");
            entity.Property(e => e.Пол)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Телефон)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdЗаказа).HasName("PK_Заказы");

            entity.Property(e => e.IdЗаказа)
                .ValueGeneratedNever()
                .HasColumnName("id_заказа");
            entity.Property(e => e.IdАвтомобиля).HasColumnName("id_автомобиля");
            entity.Property(e => e.IdКлиента).HasColumnName("id_клиента");
            entity.Property(e => e.ДатаЗаказа).HasColumnType("date");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.IdДолжности).HasName("PK__Должност__9A158B4788006856");

            entity.Property(e => e.IdДолжности)
                .ValueGeneratedNever()
                .HasColumnName("ID_Должности");
            entity.Property(e => e.Зарплата).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Обязанности)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Требования)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Rental");

            entity.Property(e => e.IdАвтомобиля).HasColumnName("ID_Автомобиля");
            entity.Property(e => e.IdКлиента).HasColumnName("ID_Клиента");
            entity.Property(e => e.IdСотрудника).HasColumnName("ID_Сотрудника");
            entity.Property(e => e.IdУслуги1).HasColumnName("ID_Услуги1");
            entity.Property(e => e.IdУслуги2).HasColumnName("ID_Услуги2");
            entity.Property(e => e.IdУслуги3).HasColumnName("ID_Услуги3");
            entity.Property(e => e.ДатаВозврата).HasColumnType("date");
            entity.Property(e => e.ДатаПроката).HasColumnType("date");
            entity.Property(e => e.ЦенаПроката).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07A0D8F448");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105347156F737").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<АвтомобилиВПрокате>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Автомобили в прокате");

            entity.Property(e => e.ГосНомер)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ДатаПроката).HasColumnType("date");
            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.СотрудникиФио)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("СотрудникиФИО");
            entity.Property(e => e.ТехническиеХарактеристики)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Услуги1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Услуги2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Услуги3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<Автопарк>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Автопарк");

            entity.Property(e => e.ГосНомер)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ОтделКадров>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Отдел кадров");

            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
