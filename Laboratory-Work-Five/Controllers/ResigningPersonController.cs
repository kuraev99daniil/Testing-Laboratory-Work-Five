using Laboratory_Work_Five.Models;
using Laboratory_Work_One;
using Microsoft.AspNetCore.Mvc;

namespace Laboratory_Work_Five.Controllers
{
    public class ResigningPersonController : Controller
    {
        private readonly Data data;

        public ResigningPersonController()
        {
            data = Data.GetInstance();

            if (data.personalDepartmens.ListResigningPerson.Count == 0)
            {
                data.personalDepartmens.ListResigningPerson.Add(
                    new ResigningPerson()
                    {
                        Surname = "Смирнов",
                        Name = "Алексей",
                        MiddleName = "Олегович",
                        PassportSeries = 1234,
                        PassportNumber = 123456,
                        Reason = "На пенсию",
                        WorkExperience = 5,
                        IsOptional = true
                    }
                );

                data.personalDepartmens.ListResigningPerson.Add(
                    new ResigningPerson()
                    {
                        Surname = "Соловьев",
                        Name = "Иван",
                        MiddleName = "Дмитриевич",
                        PassportSeries = 5678,
                        PassportNumber = 123456,
                        Reason = "Смена места работы",
                        WorkExperience = 9,
                        IsOptional = true
                    }
                );
            }
        }

        public IActionResult Index(int? position)
        {
            var model = new ResigningPersonModel()
            {
                allResigningPersons = data.personalDepartmens.ListResigningPerson
            };

            var resigningPersons = data.personalDepartmens.ListResigningPerson;

            if (position != null)
            {
                var employee = resigningPersons[(int)position];

                model.resultSearching = $"Найден: {employee.Surname} {employee.Name} {employee.MiddleName}";
            }
            else
            {
                model.resultSearching = "Пусто!";
            }

            return View(model);
        }

        public IActionResult Find(string passportSeries, string passportNumber)
        {
            var resigningPersons = data.personalDepartmens.ListResigningPerson;

            for (int i = 0; i < resigningPersons.Count; i++)
            {
                if (int.Parse(passportSeries) == resigningPersons[i].PassportSeries && int.Parse(passportNumber) == resigningPersons[i].PassportNumber)
                {
                    return RedirectToAction("Index", "ResigningPerson", new { position = i });
                }
            }

            return RedirectToAction("Index", "ResigningPerson");
        }
    }
}
