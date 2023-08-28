using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InventarioTiWS.Data.Models
{
    public partial class InventarioWebContext : DbContext
    {
        public InventarioWebContext()
        {
        }

        public InventarioWebContext(DbContextOptions<InventarioWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActUsuario> ActUsuarios { get; set; } = null!;
        public virtual DbSet<ConsultaRegistro> ConsultaRegistros { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<EstadosTabla> EstadosTablas { get; set; } = null!;
        public virtual DbSet<InformacionEspecifica> InformacionEspecificas { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<ItemTipo> ItemTipos { get; set; } = null!;
        public virtual DbSet<Localidad> Localidads { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Modelo> Modelos { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedors { get; set; } = null!;
        public virtual DbSet<Registro> Registros { get; set; } = null!;
        public virtual DbSet<RolModulo> RolModulos { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TipoRegistro> TipoRegistros { get; set; } = null!;
        public virtual DbSet<Ubicacion> Ubicacions { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Validacione> Validaciones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=10.1.0.7;Database=InventarioWeb;User Id=InventarioWebRW; Password=QKPZ76r9LWcjbFas;Trust Server Certificate=true; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AI");

            modelBuilder.Entity<ActUsuario>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ActUsuario");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ConsultaRegistro>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ConsultaRegistro");

                entity.Property(e => e.Casos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("casos");

                entity.Property(e => e.DetalleEquipo)
                    .HasMaxLength(76)
                    .IsUnicode(false);

                entity.Property(e => e.Equipo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tecnico)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tecnico");

                entity.Property(e => e.TipoRegistro)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipoRegistro");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadosTabla>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Tabla)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InformacionEspecifica>(entity =>
            {
                entity.ToTable("InformacionEspecifica");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InfoDescripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InfoFecha).HasColumnType("datetime");

                entity.Property(e => e.Informacion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreItem)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Obs)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Nombre)
                    .HasName("PK_Equipos");

                entity.ToTable("Item");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoItem)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[fnCodigoItem]([id]))", false);

                entity.Property(e => e.FechaAdquisicion).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Moneda)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.NoSerie)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Obs)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioCompra).HasColumnType("decimal(13, 2)");

                entity.Property(e => e.RegistroFecha).HasColumnType("datetime");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemTipo>(entity =>
            {
                entity.ToTable("ItemTipo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prefijos)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(upper(left([Descripcion],(3))))", false);
            });

            modelBuilder.Entity<Localidad>(entity =>
            {
                entity.ToTable("localidad");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MarcaNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ModeloNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.MarcaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Modelos_Marcas");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("proveedor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contacto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Obs).HasMaxLength(100);

                entity.Property(e => e.Tecnico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

               /* entity.HasOne(d => d.TecnicoNavigation)
                    .WithMany(p => p.Proveedors)
                    .HasForeignKey(d => d.Tecnico)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_proveedor_Usuarios");*/
            });

            modelBuilder.Entity<Registro>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("registro");

                entity.Property(e => e.Casos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Equipo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEntrega).HasColumnType("datetime");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Obs)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tecnico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoRegistro).HasColumnName("tipoRegistro");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RolModulo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RolModulo");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoRegistro>(entity =>
            {
                entity.ToTable("tipoRegistros");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.ToTable("ubicacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SALT");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Estado)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Usuarios_estados");

                entity.HasOne(d => d.RolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Rol)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Usuarios_Roles");
            });

            modelBuilder.Entity<Validacione>(entity =>
            {
                entity.ToTable("validaciones");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoItem).HasColumnName("tipoItem");

                entity.HasOne(d => d.TipoItemNavigation)
                    .WithMany(p => p.Validaciones)
                    .HasForeignKey(d => d.TipoItem)
                    .HasConstraintName("FK_validaciones_ItemTipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
