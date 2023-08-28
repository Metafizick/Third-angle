using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrid_angle.Database.RestAPI.DTO
{
    [Table("NewsCard")]
    public class NewsCard
    {
        [Key]
        public Guid IdNewsCard { get; set; }
        public string HeadlineNews { get; set; } // Заголовок новости
        public string ContentNews { get; set; } // содержание
        public string NewsText { get; set; } // тело 
        public int? PhotoNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
