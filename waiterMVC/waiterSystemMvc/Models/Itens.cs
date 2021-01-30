namespace waiterSystemMvc.Banco_de_Dados
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Itens
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idPedido { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idMenu { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal valor { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bebida { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual Pedido Pedido { get; set; }
    }
}
