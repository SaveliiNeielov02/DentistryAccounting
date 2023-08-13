using Dentistry.Models;
using Dentistry.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace Dentistry.Controllers
{
    public class PatientAdditionController : Controller
    {
        private readonly ModelDBContext _context;

        public PatientAdditionController(ModelDBContext context)
        {
            _context = context;
        }
        public ActionResult PatientAddition()
        {
            return View("~/Views/PatientAddition/PatientAddition.cshtml");
        }

        [HttpPost]
        public JsonResult AddPatient([FromBody] BodyRequest data)
        {
            if (_context.Patients.FirstOrDefault(_ => _.PhoneNumber == data.PhoneNumber && _.Name == data.Name) != default)
            {
               return Json(new { message = "Пользователь уже присутствует в базе данных, найдите его в каталоге!" });
            }
            OperationType? operationType = null;
            if (_context.OperationTypes.Select(_ => _.OperationTypeName).Contains(data.OperationTypeName))
            {
                operationType = _context.OperationTypes.FirstOrDefault(_ => _.OperationTypeName == data.OperationTypeName);
            }
            else
            {
                operationType = new OperationType() { ID = _context.OperationTypes.Count() + 1, OperationTypeName = data.OperationTypeName };
                _context.OperationTypes.Add(operationType);
            }

            var newReception = new Reception()
            {
                ID = _context.Receptions.Count() + 1,
                OperationTypeID = operationType.ID,
                ReceptionDate = data.ReceptionDate,
                OperationsTeeths = data.OperationsTooth,
                OperationNotices = data.OperationNotices,
                OperationType = operationType,
            };
            _context.Receptions.Add(newReception);
            _context.Patients.Add(
                new Patient()
                {
                    ID = _context.Patients.Count() + 1,
                    Name = data.Name,
                    Surname = data.Surname,
                    Patronymic = data.Patronymic,
                    PhoneNumber = data.PhoneNumber,
                    Reception = newReception,
                    ReceptionID = newReception.ID,
                }
                );
            _context.SaveChanges();
            return Json(new { message = "Данные успешно добавлены" });
        }
    }
}
