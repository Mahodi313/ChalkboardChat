using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChalkboardChat.Data.Models
{
    public class MessageModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; } = null!;
        public string Username { get; set; } = null!;
    }
}
