using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Declaration
{
    public class Declaration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "FullName")]
        public string Motive { get; set; }

        [DisplayFormat(DataFormatString ="{dd MM yyyy}")]
        [Display(Name = "DateCreation")]
        public DateTime DateCreated { get; set; }

        [ForeignKey("Id")]
        public int IdResponsible { get; set; }
    }
}
