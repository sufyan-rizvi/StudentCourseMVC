using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using StudentCourseCRUDMVC.Models;

namespace StudentCourseCRUDMVC.Mappings
{
    public class CourseMap:ClassMap<Course>
    {
        public CourseMap()
        {
            Table("Courses");
            Id(a=>a.Id).GeneratedBy.Identity().Unique();
            Map(c => c.Name);
            Map(c => c.Duration);
            References(a => a.Student).Column("StudentId").Unique().Cascade.None().Nullable();

        }
    }
}