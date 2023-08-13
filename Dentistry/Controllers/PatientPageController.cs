using Dentistry.Models;
using Dentistry.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dentistry.Controllers
{
    public class PatientPageController : Controller
    {
        private readonly ModelDBContext _context;

        public PatientPageController(ModelDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public JsonResult GetReceptions(string receptionsID)
        {
            var receptionsIDToInt =
                receptionsID.ToCharArray().Where(_ => _ != ',').Select(_ => int.Parse(_.ToString())).ToList();
            List<Reception> patientsReceptions = new();
            foreach (var recID in receptionsIDToInt) 
            {
                patientsReceptions.Add(_context.Receptions.FirstOrDefault(_ =>  _.ID == recID));
            }
            return Json(patientsReceptions);
        }

        [HttpGet]
        public JsonResult GetType(int typeID)
        {
            return Json(_context.OperationTypes.FirstOrDefault(_ => _.ID == typeID).OperationTypeName);
        }
    }
}
