using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentCourseCRUDMVC.Data;
using StudentCourseCRUDMVC.Models;

namespace StudentCourseCRUDMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var students = session.Query<Student>().ToList();
                return View(students);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var txn = session.BeginTransaction())
                    {

                        //student.Course.Student = student;
                        session.Save(student);
                        txn.Commit();
                        return RedirectToAction("Index");

                    }
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            Session["CurrentStudentId"] = id;
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Query<Student>().SingleOrDefault(s => s.Id == id);
                return View(student);
            }

        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            var id = (int)Session["CurrentStudentId"];
            
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var existingStudent = session.Query<Student>().FirstOrDefault(s=>s.Id == id);
                    if (ModelState.IsValid)
                    {               
                        existingStudent.Name = student.Name;
                        existingStudent.Email = student.Email;
                        existingStudent.Age = student.Age;  

                        session.Update(existingStudent);
                        txn.Commit();
                        return RedirectToAction("Index");
                    }
                }
            }

            return View();
        }


        public ActionResult Delete(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Query<Student>().FirstOrDefault(s => s.Id == id);
                TempData["currentStudent"] = student;
                return View(student);
            }
        }

        [HttpPost, ActionName("delete")]
        public ActionResult DeleteUser(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var student = (Student)TempData["currentStudent"];
                    session.Delete(student);
                    txn.Commit();
                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult DeleteCourse(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var course = session.Query<Course>().FirstOrDefault(s => s.Id == id);
                TempData["currentCourse"] = course;
                return View(course);
            }
        }

        [HttpPost, ActionName("deletecourse")]
        public ActionResult DeleteCourses(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var course = (Course)TempData["currentCourse"];
                    session.Delete(course);
                    txn.Commit();
                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult CreateCourse(int id)
        {
            Session["CurrentStudentId"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var txn = session.BeginTransaction())
                    {
                        var id = (int)Session["CurrentStudentId"];
                        course.Student = session.Query<Student>().FirstOrDefault(s => s.Id == id);
                        session.Save(course);
                        txn.Commit();
                        return RedirectToAction("index");
                    }
                }
            }
            return View();
        }

        public ActionResult EditCourse(int id)
        {
            Session["CurrentCourseId"] = id;
            using(var session = NHibernateHelper.CreateSession())
            {
                var query = session.Query<Course>().FirstOrDefault(s=>s.Id == id);
                return View(query);
            }
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                using(var session = NHibernateHelper.CreateSession())
                {
                    using (var txn = session.BeginTransaction())
                    {
                        var id = (int)(Session["CurrentCourseId"]);
                        var existingCourse = session.Query<Course>().FirstOrDefault(c=>c.Id == id);
                        existingCourse.Name = course.Name;
                        existingCourse.Duration = course.Duration;  
                        session.Update(existingCourse);
                        txn.Commit();
                        return RedirectToAction("index");
                    }
                }
            }
            return View();
        }
    }
}