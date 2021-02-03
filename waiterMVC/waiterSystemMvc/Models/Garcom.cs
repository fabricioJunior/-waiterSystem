namespace waiterSystemMvc.Banco_de_Dados
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Garcom")]
    public partial class Garcom : ICloneable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Garcom()
        {
            Pedidos = new HashSet<Pedido>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        [StringLength(12)]
        public string cpf { get; set; }
        [StringLength(70)]
        public string login { get; set; }
        [StringLength(15)]
        public string senha { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
