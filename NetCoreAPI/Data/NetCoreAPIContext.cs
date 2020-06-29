using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetCoreAPI.Entities.Models
{
    public partial class NetCoreAPIContext : DbContext
    {
        public NetCoreAPIContext()
        {
        }

        public NetCoreAPIContext(DbContextOptions<NetCoreAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<InvGrp1> InvGrp1 { get; set; }
        public virtual DbSet<InvMaster> InvMaster { get; set; }
        public virtual DbSet<InvMasterAud> InvMasterAud { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.; Database=NetCoreAPI;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvGrp1>(entity =>
            {
                entity.HasKey(e => e.Key1);

                entity.ToTable("inv_grp1");

                entity.Property(e => e.Key1).HasColumnName("key1");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<InvMaster>(entity =>
            {
                entity.HasKey(e => e.Key1);

                entity.ToTable("inv_master");

                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_inv_master")
                    .IsUnique();

                entity.Property(e => e.Key1).HasColumnName("key1");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("codigo")
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CostoPro)
                    .HasColumnName("costo_pro")
                    .HasColumnType("money");

                entity.Property(e => e.CostoUc)
                    .HasColumnName("costo_uc")
                    .HasColumnType("money");

                entity.Property(e => e.FechaR)
                    .HasColumnName("fecha_r")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCodControl).HasColumnName("id_cod_control");

                entity.Property(e => e.IdGrp1).HasColumnName("id_grp1");

                entity.Property(e => e.NombreF)
                    .IsRequired()
                    .HasColumnName("nombre_f")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioE)
                    .HasColumnName("precio_e")
                    .HasColumnType("money");

                entity.Property(e => e.PrecioM)
                    .HasColumnName("precio_m")
                    .HasColumnType("money");

                entity.Property(e => e.PrecioR)
                    .HasColumnName("precio_r")
                    .HasColumnType("money");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasColumnName("referencia")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StsNulo).HasColumnName("sts_nulo");

                entity.Property(e => e.StsPos).HasColumnName("sts_pos");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdCodControlNavigation)
                    .WithMany(p => p.InverseIdCodControlNavigation)
                    .HasForeignKey(d => d.IdCodControl)
                    .HasConstraintName("FK_inv_master_inv_master");

                entity.HasOne(d => d.IdGrp1Navigation)
                    .WithMany(p => p.InvMaster)
                    .HasForeignKey(d => d.IdGrp1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_inv_master_inv_grp1");
            });

            modelBuilder.Entity<InvMasterAud>(entity =>
            {
                entity.HasKey(e => e.Key1);

                entity.ToTable("inv_master_aud");

                entity.Property(e => e.Key1).HasColumnName("key1");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("codigo")
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CostoPro)
                    .HasColumnName("costo_pro")
                    .HasColumnType("money");

                entity.Property(e => e.CostoProOld)
                    .HasColumnName("costo_pro_old")
                    .HasColumnType("money");

                entity.Property(e => e.FactorCompra)
                    .HasColumnName("factorCompra")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Fechah)
                    .HasColumnName("fechah")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdArticulo).HasColumnName("id_articulo");

                entity.Property(e => e.IdCodControl).HasColumnName("id_cod_control");

                entity.Property(e => e.NombreF)
                    .IsRequired()
                    .HasColumnName("nombre_f")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Operation)
                    .IsRequired()
                    .HasColumnName("operation")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PrecioE)
                    .HasColumnName("precio_e")
                    .HasColumnType("money");

                entity.Property(e => e.PrecioEOld)
                    .HasColumnName("precio_e_old")
                    .HasColumnType("money");

                entity.Property(e => e.PrecioM)
                    .HasColumnName("precio_m")
                    .HasColumnType("money");

                entity.Property(e => e.PrecioMOld)
                    .HasColumnName("precio_m_old")
                    .HasColumnType("money");

                entity.Property(e => e.PrecioR)
                    .HasColumnName("precio_r")
                    .HasColumnType("money");

                entity.Property(e => e.PrecioROld)
                    .HasColumnName("precio_r_old")
                    .HasColumnType("money");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasColumnName("referencia")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StsNulo).HasColumnName("sts_nulo");

                entity.Property(e => e.Terminal)
                    .IsRequired()
                    .HasColumnName("terminal")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("(host_name())");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
