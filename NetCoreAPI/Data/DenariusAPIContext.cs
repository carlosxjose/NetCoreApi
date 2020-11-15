using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NetCoreAPI.Entities.Models;

namespace NetCoreAPI.Data
{
    public partial class DenariusAPIContext : DbContext
    {
        public static string GetConnectionString()
        {
            if (!string.IsNullOrEmpty(ConnectionString))
                return ConnectionString;

            return Startup.ConnectionString;
        }

        public static string ConnectionString
        {
            get;
            set;
        }
        public DenariusAPIContext()
        {
        }

        public DenariusAPIContext(DbContextOptions<DenariusAPIContext> options)
            : base(options)
        {
        }

        public DenariusAPIContext(string connectionString) : base(GetOptions(connectionString))
        {
            ConnectionString = connectionString;
        }
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public virtual DbSet<inv_grp0> inv_grp0 { get; set; }
        public virtual DbSet<inv_grp1> inv_grp1 { get; set; }
        public virtual DbSet<inv_master> inv_master { get; set; }
        public virtual DbSet<inv_master_aud> inv_master_aud { get; set; }
        public virtual DbSet<mps_usuarios> mps_usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<inv_grp0>(entity =>
            {
                entity.HasKey(e => e.key1)
                    .HasName("PK_Inv_Grpo");

                entity.Property(e => e.cod_ant)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.idCnt0).HasDefaultValueSql("((-1))");

                entity.Property(e => e.nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<inv_grp1>(entity =>
            {
                entity.HasKey(e => e.key1);

                entity.Property(e => e.cod_ant)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.id_grp0Navigation)
                    .WithMany(p => p.inv_grp1)
                    .HasForeignKey(d => d.id_grp0)
                    .HasConstraintName("FK_inv_grp1_inv_grp0");
            });

            modelBuilder.Entity<inv_master>(entity =>
            {
                entity.HasKey(e => e.key1)
                    .HasName("PK_Inv_Mast");

                entity.HasIndex(e => e.codigo)
                    .HasDatabaseName("IX_inv_master")
                    .IsUnique();

                entity.HasIndex(e => e.id_cod_control)
                .HasDatabaseName("IX_inv_master_1");

                entity.HasIndex(e => new { e.key1, e.tipo, e.codigo, e.nombre_f, e.referencia, e.precio_r, e.sts_nulo })
                    .HasDatabaseName("IX_inv_master_2");

                entity.HasIndex(e => new { e.tipo, e.codigo, e.nombre_f, e.referencia, e.precio_r, e.sts_pos, e.sts_nulo })
                    .HasDatabaseName("IX_inv_master_3");

                entity.HasIndex(e => new { e.key1, e.codigo, e.nombre_f, e.referencia, e.costo_pro, e.precio_e, e.precio_r, e.tipo, e.sts_nulo })
                    .HasDatabaseName("IX_inv_master_5");

                entity.HasIndex(e => new { e.tipo, e.codigo, e.nombre_f, e.nombre_s, e.referencia, e.id_marca, e.id_suplidor, e.id_ubica_a, e.id_ubica_g, e.id_grp1 })
                    .HasDatabaseName("IX_inv_master_7");

                entity.HasIndex(e => new { e.codigo, e.nombre_f, e.referencia, e.id_marca, e.id_unidad, e.id_ubica_a, e.id_ubica_g, e.precio_r, e.porcReg, e.id_itbis, e.id_grp1 })
                    .HasDatabaseName("IX_inv_master_6");

                entity.HasIndex(e => new { e.key1, e.tipo, e.codigo, e.nombre_f, e.nombre_s, e.referencia, e.id_marca, e.id_suplidor, e.id_ubica_a, e.id_ubica_g, e.id_grp1 })
                    .HasDatabaseName("IX_inv_master_4");

                entity.HasIndex(e => new { e.tipo, e.codigo, e.nombre_f, e.referencia, e.id_grp1, e.id_marca, e.id_suplidor, e.id_ubica_a, e.id_ubica_g, e.costo_pro, e.precio_m, e.precio_e, e.precio_r, e.porcMin, e.porcEsp, e.porcReg, e.id_cod_control, e.itbis, e.id_itbis, e.sts_especial, e.sts_nodescto, e.sts_soloinsumo, e.sts_consignacion, e.sts_noinv, e.sts_nulo })
                    .HasDatabaseName("IX_inv_master_8");

                entity.Property(e => e.ancho).HasColumnType("numeric(10, 4)");

                entity.Property(e => e.cantidad_uc).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.cantidad_uv).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.codigo)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.comision).HasColumnType("numeric(10, 4)");

                entity.Property(e => e.costo_fob).HasColumnType("money");

                entity.Property(e => e.costo_pro).HasColumnType("money");

                entity.Property(e => e.costo_uc).HasColumnType("money");

                entity.Property(e => e.descripcion).HasMaxLength(500);

                entity.Property(e => e.descto_auto).HasColumnType("money");

                entity.Property(e => e.existencia_max).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.existencia_min).HasColumnType("numeric(10, 4)");

                entity.Property(e => e.factorCompra)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.factor_control).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.factor_formula).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.fecha_r)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fecha_uc).HasColumnType("datetime");

                entity.Property(e => e.fecha_uv).HasColumnType("datetime");

                entity.Property(e => e.freq_garantia).HasDefaultValueSql("((1))");

                entity.Property(e => e.grueso).HasColumnType("numeric(10, 4)");

                entity.Property(e => e.id_cod_control_tmp)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.id_suplidor).HasDefaultValueSql("((-1))");

                entity.Property(e => e.largo).HasColumnType("numeric(10, 4)");

                entity.Property(e => e.no_fraccionar).HasDefaultValueSql("((0))");

                entity.Property(e => e.nombre_f)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.nombre_s)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.porcEsp).HasColumnType("money");

                entity.Property(e => e.porcMin).HasColumnType("money");

                entity.Property(e => e.porcReg).HasColumnType("money");

                entity.Property(e => e.precio_e).HasColumnType("money");

                entity.Property(e => e.precio_m).HasColumnType("money");

                entity.Property(e => e.precio_r).HasColumnType("money");

                entity.Property(e => e.referencia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.req_serial).HasDefaultValueSql("((0))");

                entity.Property(e => e.sts_garantia).HasDefaultValueSql("((0))");

                entity.Property(e => e.sts_liquidacion_aut)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.sts_perecedero).HasDefaultValueSql("((0))");

                entity.Property(e => e.sts_pos)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.tiempo_garantia).HasDefaultValueSql("((1))");

                entity.Property(e => e.tipo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.id_cod_controlNavigation)
                    .WithMany(p => p.Inverseid_cod_controlNavigation)
                    .HasForeignKey(d => d.id_cod_control)
                    .HasConstraintName("FK_inv_master_id_cod_control");

                entity.HasOne(d => d.id_grp1Navigation)
                    .WithMany(p => p.inv_master)
                    .HasForeignKey(d => d.id_grp1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_inv_master_inv_grp1");
            });

            modelBuilder.Entity<inv_master_aud>(entity =>
            {
                entity.HasKey(e => e.key1);

                entity.HasIndex(e => e.fechah);

                entity.Property(e => e.codigo)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.costo_pro).HasColumnType("money");

                entity.Property(e => e.costo_pro_old).HasColumnType("money");

                entity.Property(e => e.factorCompra).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.fechah)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.nombre_f)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.nombre_s)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.operation)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.precio_e).HasColumnType("money");

                entity.Property(e => e.precio_e_old).HasColumnType("money");

                entity.Property(e => e.precio_m).HasColumnType("money");

                entity.Property(e => e.precio_m_old).HasColumnType("money");

                entity.Property(e => e.precio_r).HasColumnType("money");

                entity.Property(e => e.precio_r_old).HasColumnType("money");

                entity.Property(e => e.referencia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.terminal)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("(host_name())");

                entity.Property(e => e.tipo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.usuario)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())");
            });

            modelBuilder.Entity<mps_usuarios>(entity =>
            {
                entity.HasKey(e => e.key1)
                    .HasName("PK_usuarios");

                //entity.HasIndex(e => e.identificacion)
                //    .HasName("IX_mps_usuarios")
                //    .IsUnique();

                entity.Property(e => e.identificacion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.nivel).HasDefaultValueSql("('00')");

                entity.Property(e => e.notas).HasColumnType("text");

                entity.Property(e => e.programa0)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.supKey)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
