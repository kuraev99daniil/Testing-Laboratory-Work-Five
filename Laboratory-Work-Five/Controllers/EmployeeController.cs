using Laboratory_Work_Five.Models;
using Laboratory_Work_One;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Laboratory_Work_Five.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Data data;

        public EmployeeController()
        {
            data = Data.GetInstance();
        }

        public IActionResult Index(int? position)
        {
            var model = new EmployeeModel()
            {
                allEmployees = data.personalDepartmens.ListEmployees
            };

            var employees = data.personalDepartmens.ListEmployees;

            if (position != null)
            {
                var employee = employees[(int)position];

                model.resultSearching = $"Найден: {employee.Surname} {employee.Name} {employee.MiddleName}";
            }
            else
            {
                model.resultSearching = "Пусто!";
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult PerformEmployeeAction(Employee enteredEmployee, string submitButton)
        {
            switch (submitButton)
            {
                case "Добавить":
                    {
                        data.personalDepartmens.AddEmployee(enteredEmployee);

                        break;
                    }
                case "Найти":
                    {
                        var employees = data.personalDepartmens.ListEmployees;

                        for (int i = 0; i < employees.Count; i++)
                        {
                            if (enteredEmployee.PassportSeries == employees[i].PassportSeries && enteredEmployee.PassportNumber == employees[i].PassportNumber)
                            {
                                return RedirectToAction("Index", "Employee", new { position = i });
                            }
                        }

                        break;
                    }
                case "Удалить":
                    {
                        var removedVacancy = data.personalDepartmens
                            .ListEmployees
                            .First(value => value.PassportSeries == enteredEmployee.PassportSeries && value.PassportNumber == enteredEmployee.PassportNumber);

                        data.personalDepartmens.RemoveEmployee(removedVacancy);

                        break;
                    }
            }

            return RedirectToAction("Index", "Employee");
        }
    }
}
