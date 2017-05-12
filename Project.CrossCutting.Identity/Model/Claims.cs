using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Infra.CrossCutting.Identity.Model
{
    [Table("Claims")]
    public class Claims
    {
        public Claims()
        {
            ClaimsId = Guid.NewGuid();
        }

        [Key]
        public Guid ClaimsId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(128)]
        public string Nome { get; set; }
    }
}