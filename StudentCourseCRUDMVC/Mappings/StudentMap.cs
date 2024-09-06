using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using StudentCourseCRUDMVC.Models;

namespace StudentCourseCRUDMVC.Mappings
{
    public class StudentMap:ClassMap<Student>
    {
        public StudentMap()
        {
            Table("Students");
            Id(s => s.Id).GeneratedBy.Identity().Unique();
            Map(s=>s.Name);
            Map(s=>s.Email);    
            Map(s=>s.Age);
            HasOne(u => u.Course).Cascade.All().PropertyRef(c => c.Student);
        }
    }
}