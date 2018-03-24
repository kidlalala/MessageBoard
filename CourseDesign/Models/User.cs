using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CourseDesign.Models
{
    public class User
    {
        public int ID { get; set; }

        [Display(Name = "姓名")]
        [Required(ErrorMessage = "必填")]
        public string Name { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "必填")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "必须为6-50个字符")]
        public string Password { get; set; }

        [Display(Name = "个人介绍")]
        public string Introduction { get; set; }
    }

    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<CourseDesign.Models.Message> Messages { get; set; }

        public System.Data.Entity.DbSet<CourseDesign.Models.Reply> Replies { get; set; }
    }
}
