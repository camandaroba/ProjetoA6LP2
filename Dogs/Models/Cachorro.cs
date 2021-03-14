using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dogs.Models
{
    public class Cachorro
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 2)]
        public string Nome { get; set; }
        
        public string Idade { get; set; }

        [StringLength(45, MinimumLength = 2)]
        public string Raca { get; set; }
        public bool Castracao { get; set; }

        public string Genero { get; set; }

        public bool Vacinacao { get; set; }

        [Range(1, 150)]
        public int Peso { get; set; }

    }
}
