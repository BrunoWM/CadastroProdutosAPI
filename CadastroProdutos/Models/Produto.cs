using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProdutos.Models
{
    public class Produto
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        public String Name { get; set; }

        [MaxLength(100)]
        public String Description { get; set; }
        public Produto(int id, string name, string description)
        {
           this.ID = id;
           this.Name = name;
           this.Description = description;
        }
        public Produto()
        {
        }
    }
}
