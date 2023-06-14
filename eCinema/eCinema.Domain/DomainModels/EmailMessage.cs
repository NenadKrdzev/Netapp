using eCinema.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCinema.Domain.DomainModels
{
    public class EmailMessage:BaseEntity
    {
        public string MailTo { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Boolean Status { get; set; }
    }
}
