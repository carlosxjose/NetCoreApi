using System;
using System.Collections.Generic;

namespace NetCoreAPI.Entities.Models
{
    public partial class mps_usuarios
    {
        public int key1 { get; set; }
        public string identificacion { get; set; }
        public int nivel { get; set; }
        public string programa0 { get; set; }
        public bool consultar { get; set; }
        public bool imprimir { get; set; }
        public bool anadir { get; set; }
        public bool modificar { get; set; }
        public bool borrar { get; set; }
        public bool menuCRM { get; set; }
        public bool menuCBA { get; set; }
        public bool menuCXC { get; set; }
        public bool menuCXP { get; set; }
        public bool menuINV { get; set; }
        public bool menuPOS { get; set; }
        public bool menuNOM { get; set; }
        public bool menuCNT { get; set; }
        public bool menuCCA { get; set; }
        public bool menuATA { get; set; }
        public bool menuVET { get; set; }
        public bool menuAVS { get; set; }
        public bool menuCCB { get; set; }
        public bool menuENV { get; set; }
        public bool menuCIN { get; set; }
        public string notas { get; set; }
        public string supKey { get; set; }
        public bool supCaso01 { get; set; }
        public bool supCaso02 { get; set; }
        public bool supCaso03 { get; set; }
        public bool supCaso04 { get; set; }
        public bool supCaso05 { get; set; }
        public bool supCaso06 { get; set; }
        public bool supCaso07 { get; set; }
        public bool supCaso08 { get; set; }
        public bool supCaso09 { get; set; }
        public bool supCaso10 { get; set; }
        public bool supCaso11 { get; set; }
        public bool supCaso12 { get; set; }
        public bool supCaso13 { get; set; }
        public bool supCaso14 { get; set; }
        public bool? supCaso15 { get; set; }
        public int? id_vendedor { get; set; }
    }
}
