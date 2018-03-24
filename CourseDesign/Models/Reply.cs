using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CourseDesign.Models
{
    public class Reply
    {
        [Key]
        public int ReplyID { get; set; }

        [Display(Name = "回复内容")]
        [Required(ErrorMessage = "必填")]
        public string ReplyContent { get; set; }

        [Display(Name = "回复时间")]
        public DateTime ReplyTime { get; set; }

        [Display(Name = "回复人")]
        public string ReplyUserName { get; set; }

        [Display(Name = "留言ID")]
        public int MSG_ID { get; set; }


        public class UserDbContext : DbContext
        {
            public DbSet<Reply> Replies { get; set; }
        }
    }
}