using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace orcamento_pessoal_api.Models.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string Login { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string HashSenha { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Salt { get; set; } = null!;

        public DateTime Created { get; set; } = DateTime.Now;
    }
}