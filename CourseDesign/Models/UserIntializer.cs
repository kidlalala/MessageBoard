using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CourseDesign.Models
{
    public class UserIntializer : DropCreateDatabaseIfModelChanges<UserDbContext>
    {
        protected override void Seed(UserDbContext context)
        {
            base.Seed(context);
        }
    }
}