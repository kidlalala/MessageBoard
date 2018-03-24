using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CourseDesign.Models
{
    public class Message
    {
        [Key]
        public int MSG_ID { get; set; }

        [Display(Name = "留言主题")]
        [Required(ErrorMessage = "必填")]
        public string Topic { get; set; }

        [Display(Name = "留言内容")]
        [Required(ErrorMessage = "不可为空")]
        public string Content { get; set; }

        [Display(Name = "留言时间")]
        public DateTime MsgTime { get; set; }

        [Display(Name = "留言人ID")]
        public int ID { get; set; }

        [Display(Name = "留言人姓名")]
        public string Name { get; set; }

        public class UserDbContext : DbContext
        {
            public DbSet<Message> Messages { get; set; }
        }
    }
}