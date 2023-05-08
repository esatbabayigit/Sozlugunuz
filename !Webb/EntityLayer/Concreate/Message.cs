using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace EntityLayer.Concreate
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        [StringLength(50)]
        public string MessageSenderMail { get; set; }
        [StringLength(50)]
        public string MessageReceiverMail { get; set; }
        [StringLength(100)]
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageDraftStatus { get; set; }
        public bool MessageStatus { get; set; }
        public bool MessageInboxIsRead { get; set; }
        public bool MessageDeleteStatus { get; set; }

    }
}