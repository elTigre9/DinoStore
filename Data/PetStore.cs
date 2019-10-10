using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetDinos.Data
{
    public class PetStore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PSID { get; set; }
        public string PSName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Range(9999,99999)]
        public int Zip { get; set; }
    }
}
