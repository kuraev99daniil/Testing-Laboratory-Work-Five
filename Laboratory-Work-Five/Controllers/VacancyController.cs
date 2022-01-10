using Laboratory_Work_Five.Models;
using Laboratory_Work_One;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Laboratory_Work_Five.Controllers
{
    public class VacancyController : Controller
    {
        private readonly Data data;

        public VacancyController()
        {
            data = Data.GetInstance();
        }

        public IActionResult Index()
        {
            return View(new VacancyModel()
            {
                allDescription = data.personalDepartmens.GetDescriptionVacancy()
            });
        }

        [HttpPost]
        public IActionResult PerformVacancyAction(Vacancy enteredVacancy, string submitButton)
        {
            switch (submitButton)
            {
                case "Добавить":
                    {
                        data.personalDepartmens.AddVacancy(enteredVacancy);

                        break;
                    }
                case "Удалить":
                    {
                        var removedVacancy = data.personalDepartmens
                            .ListVacancies
                            .First(value => value.Title == enteredVacancy.Title);

                        data.personalDepartmens.RemoveVacancy(removedVacancy);

                        break;
                    }
            }

            return RedirectToAction("Index", "Vacancy");
        }
    }
}
