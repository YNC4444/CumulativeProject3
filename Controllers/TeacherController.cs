using CumulativeProject3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CumulativeProject3.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher/List
        public ActionResult List(string SearchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
            return View(Teachers);
        }

        // GET: Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.findTeacher(id);

            return View(SelectedTeacher);
        }

        // GET: /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.findTeacher(id);

            return View(NewTeacher);
        }

        //POST : /Teacher/Delete/{id}
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET : /Teacher/Add
        public ActionResult Add()
        {
            return View();
        }

        //POST : /Teacher/Create
        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLname, int TeacherId, string EmployeeNumber, DateTime HireDate, decimal Salary)
        {
            //identify the method is running
            //identify the inputs provided from the form

            Debug.WriteLine("I have accessed the Create Method");
            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(TeacherLname);
            Debug.WriteLine(TeacherId);
            Debug.WriteLine(EmployeeNumber);
            Debug.WriteLine(HireDate);
            Debug.WriteLine(Salary);

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.TeacherId = TeacherId;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.HireDate = HireDate;
            NewTeacher.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }

        /// <summary>
        /// Routes to a dynamically generated "Teacher Update" page. Gathers 
        /// information from the database.
        /// </summary>
        /// <param name="id">id of the Teacher</param>
        /// <returns> A dynamic "Update Teacher" webpage which provides the
        /// current information of the teacher and asks the user for new information
        /// as part of a form.</returns>
        /// <example> GET : Teacher/Update/{id}</example>
        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.findTeacher(id);

            return View(SelectedTeacher);
        }

        /// <summary>
        /// receives a POST request with information about an existing teacher
        /// in the system with new values. Conveys this information to the API
        /// & redirects to the "Teacher Show" page of our updated teacher.
        /// </summary>
        /// <param name="id">Teacher id</param>
        /// <param name="TeacherFname"></param>
        /// <param name="TeacherLname"></param>
        /// <param name="TeacherId"></param>
        /// <param name="EmployeeNumber"></param>
        /// <param name="HireDate"></param>
        /// <param name="Salary"></param>
        /// <example> 
        /// POST : /Teacher/Update/4 
        /// FORM DATA / POST DATA / REQUEST BODY
        /// {
        /// "TeacherFname":"John"
        /// "TeacherLname":"Doe"
        /// "TeacherId":"123"
        /// "EmployeeNumber":"321"
        /// "HireDate":"2024-4-12"
        /// "Salary":"3.14"
        /// }
        /// </example>
        /// <returns> A dynamic webpage which provides the current information of the teacher</returns>
        [HttpPost]
        public ActionResult Update(int id, string TeacherFname, string TeacherLname, int TeacherId, string EmployeeNumber, DateTime HireDate, decimal Salary)
        {
            Teacher TeacherInfo = new Teacher();
            TeacherInfo.TeacherFname = TeacherFname;
            TeacherInfo.TeacherLname = TeacherLname;
            TeacherInfo.TeacherId = TeacherId;
            TeacherInfo.EmployeeNumber = EmployeeNumber;
            TeacherInfo.HireDate = HireDate;
            TeacherInfo.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id, TeacherInfo);

            return RedirectToAction("Show/" + id);
        }
    }
}