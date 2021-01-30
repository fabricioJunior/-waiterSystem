namespace waiterSystemMvc.Banco_de_Dados
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pedido")]
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            Itens = new HashSet<Itens>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int clienteId { get; set; }

        public int garcomId { get; set; }

        public int fechado { get; set; }

        public int pago { get; set; }

        [Column(TypeName = "numeric")]
        public decimal valor { get; set; }

        public virtual Clientes Clientes { get; set; }

        public virtual Garcom Garcom { get; set; }

       [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
         public virtual ICollection<Itens> Itens { get; set; }
    }
}
