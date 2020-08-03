using System;
using System.Collections.Generic;

namespace NetCoreAPI.Entities.Models
{
    public partial class inv_master
    {
        public inv_master()
        {
            Inverseid_cod_controlNavigation = new HashSet<inv_master>();
        }

        public int key1 { get; set; }
        public string tipo { get; set; }
        public string codigo { get; set; }
        public string nombre_f { get; set; }
        public string nombre_s { get; set; }
        public string referencia { get; set; }
        public string descripcion { get; set; }
        public int id_grp1 { get; set; }
        public int id_marca { get; set; }
        public int? id_promocion { get; set; }
        public int id_suplidor { get; set; }
        public int id_unidad { get; set; }
        public int id_unidad_f { get; set; }
        public decimal factor_formula { get; set; }
        public decimal factorCompra { get; set; }
        public decimal ancho { get; set; }
        public decimal grueso { get; set; }
        public decimal largo { get; set; }
        public bool bloq_ancho { get; set; }
        public bool bloq_grueso { get; set; }
        public bool bloq_largo { get; set; }
        public int id_ubica_a { get; set; }
        public int id_ubica_g { get; set; }
        public decimal comision { get; set; }
        public decimal costo_pro { get; set; }
        public decimal? costo_uc { get; set; }
        public decimal? costo_fob { get; set; }
        public decimal precio_m { get; set; }
        public decimal precio_e { get; set; }
        public decimal precio_r { get; set; }
        public DateTime? fecha_r { get; set; }
        public DateTime? fecha_uc { get; set; }
        public DateTime? fecha_uv { get; set; }
        public decimal? cantidad_uc { get; set; }
        public decimal? cantidad_uv { get; set; }
        public decimal porcMin { get; set; }
        public decimal porcEsp { get; set; }
        public decimal porcReg { get; set; }
        public decimal existencia_max { get; set; }
        public decimal existencia_min { get; set; }
        public string id_cod_control_tmp { get; set; }
        public int? id_cod_control { get; set; }
        public decimal factor_control { get; set; }
        public decimal descto_auto { get; set; }
        public bool itbis { get; set; }
        public int? id_itbis { get; set; }
        public int? id_area { get; set; }
        public bool sts_especial { get; set; }
        public bool sts_promocion { get; set; }
        public bool sts_nodescto { get; set; }
        public bool sts_soloinsumo { get; set; }
        public bool sts_consignacion { get; set; }
        public bool sts_noinv { get; set; }
        public bool? sts_perecedero { get; set; }
        public int dias_vencimiento { get; set; }
        public bool? sts_garantia { get; set; }
        public short? freq_garantia { get; set; }
        public int? tiempo_garantia { get; set; }
        public bool? req_serial { get; set; }
        public bool? no_fraccionar { get; set; }
        public bool sts_bloqueado { get; set; }
        public bool? sts_label_electronico { get; set; }
        public bool? sts_liquidacion_aut { get; set; }
        public bool? sts_pos { get; set; }
        public bool sts_nulo { get; set; }

        public virtual inv_master id_cod_controlNavigation { get; set; }
        public virtual inv_grp1 id_grp1Navigation { get; set; }
        public virtual ICollection<inv_master> Inverseid_cod_controlNavigation { get; set; }
    }
}
