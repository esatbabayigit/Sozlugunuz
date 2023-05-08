using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Contact 
    {
        [Key]
        public int ContactID { get; set; }
        [StringLength(50)]
        public string ContactName { get; set; }
        [StringLength(50)]
        public string ContactMail { get; set; }
        [StringLength(50)]
        public string ContactSubject { get; set; }
        [StringLength(1000)]
        public string ContactMessage { get; set; }
        public bool ContactIsRead { get; set; }

        public DateTime ContactDate { get; set; }
        public bool ContactStatus { get; set; }
        public bool ContactStatusEnd { get; set; }


        
    }
}
