using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetDinos.Data
{
    public class Dinosaur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }
        public string DName { get; set; }
        public string DType { get; set; }
        public DateTime DOB { get; set; }
        
        // foreign
        [Display(Name = "Store ID")]
        public int PSID { get; set; }
        [ForeignKey("PSID")]
        public PetStore PetStore { get; set; }
    }
}
