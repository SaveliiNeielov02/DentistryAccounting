using Dentistry.Models;
using Dentistry.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dentistry.Controllers
{
    public class PatientsCatalogController : Controller
    {
        private readonly ModelDBContext _context;

        public PatientsCatalogController(ModelDBContext context)
        {
            _context = context;
        }

        public IActionResult PatientsCatalog()
        {
            return View("~/Views/PatientsCatalog/PatientsCatalog.cshtml", _context.Patients.ToList());
        }
        public IActionResult PatientPage(int ID)
        {
            return View("~/Views/PatientsCatalog/PatientPage.cshtml", 
                _context.Patients.Where(_ => _.PhoneNumber ==  (_context.Patients.FirstOrDefault(_ => _.ID == ID)).PhoneNumber).ToList());
        }

    }
}