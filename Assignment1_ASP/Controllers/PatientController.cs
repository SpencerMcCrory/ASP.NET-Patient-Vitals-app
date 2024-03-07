using Assignment1_ASP.Migrations;
using Assignment1_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment1_ASP.Controllers
{
    public class PatientController : Controller
    {
        

        private PatientContext context { get; set; }
        public PatientController(PatientContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var patientReadings = context.Patients.Include(m => m.Position).OrderBy(
            m => m.PatientId).ToList();
            return View(patientReadings);
        }




        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Positions = context.Positions.OrderBy(g => g.Name).ToList();
            return View("Edit", new Patient());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Positions = context.Positions.OrderBy(g => g.Name).ToList();

            var patient = context.Patients.Find(id);
            return View(patient);
        }

        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                if (patient.PatientId == 0)
                {
                    context.Patients.Add(patient);
                }
                else
                {
                    context.Patients.Update(patient);    
                }

                context.SaveChanges();
                return RedirectToAction("Index", "Patient");


            }
            else
            {
                ViewBag.Action = (patient.PatientId == 0) ? "Add" : "Edit";
                ViewBag.Positions = context.Positions.OrderBy(g => g.Name).ToList();
                return View(patient);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var patient = context.Patients.Find(id);
            return View(patient);
        }

        [HttpPost]
        public IActionResult Delete(Patient patient)
        {
            context.Patients.Remove(patient);
            context.SaveChanges();
            return RedirectToAction("Index","Patient");
        }

    }
}
