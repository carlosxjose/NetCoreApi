using System;
using System.Collections.Generic;

namespace NetCoreAPI.Entities.Models
{
    public partial class inv_master_aud
    {
        public int key1 { get; set; }
        public DateTime fechah { get; set; }
        public string terminal { get; set; }
        public string operation { get; set; }
        public string usuario { get; set; }
        public int id_articulo { get; set; }
        public string tipo { get; set; }
        public string codigo { get; set; }
        public string nombre_f { get; set; }
        public string nombre_s { get; set; }
        public string referencia { get; set; }
        public decimal factorCompra { get; set; }
        public int? id_cod_control { get; set; }
        public decimal costo_pro { get; set; }
        public decimal costo_pro_old { get; set; }
        public decimal precio_m { get; set; }
        public decimal precio_m_old { get; set; }
        public decimal precio_e { get; set; }
        public decimal precio_e_old { get; set; }
        public decimal precio_r { get; set; }
        public decimal precio_r_old { get; set; }
        public bool itbis { get; set; }
        public bool sts_especial { get; set; }
        public bool sts_nodescto { get; set; }
        public bool sts_noinv { get; set; }
        public bool sts_nulo { get; set; }
    }
}
