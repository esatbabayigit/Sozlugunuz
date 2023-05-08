using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        [StringLength(50)]
        public string WriterName { get; set; }
        [StringLength(50)]
        public string WriterSurname { get; set; }
        [StringLength(500)]
        public string WriterImage { get; set; }
        [StringLength(200)]
        public string WriterMail { get; set; }
        [StringLength(200)]
        public string WriterPassword { get; set; }
        public bool WriterStatus { get; set; }
        [StringLength(100)] public string WriterAbout { get; set; }
        [StringLength(50)] public string WriterTitle { get; set; }
        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }

        [StringLength(30)]
        public string WriterAttention1 { get; set; }
        [StringLength(30)]
        public string WriterAttention2 { get; set; }
        [StringLength(30)]
        public string WriterAttention3 { get; set; }
        [StringLength(30)]
        public string WriterAttention4 { get; set; }
        
        public string WriterLongAbout { get; set; }
        public string WriterExperience{ get; set; }
        public string WriterPhoneNumber{ get; set; }
        //Skills
        public string WriterSkill1{ get; set; }
        public int WriterSkill11{ get; set; }

        public string WriterSkill2{ get; set; }
        public int WriterSkill22{ get; set; }

        public string WriterSkill3{ get; set; }
        public int WriterSkill33{ get; set; }

        public string WriterSkill4{ get; set; }
        public int WriterSkill44{ get; set; }

        public string WriterSkill5{ get; set; }
        public int WriterSkill55{ get; set; }

        public string WriterSkill6{ get; set; }
        public int WriterSkill66{ get; set; }

        //instagram,facebook,twiiter
        public string WriterInsatgram { get; set; }
        public string WriterTwitter { get; set; }
        public string WriterFacebook{ get; set; }

        public DateTime WriterDateTime { get; set; }

        
    }
}
