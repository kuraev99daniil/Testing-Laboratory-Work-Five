using Laboratory_Work_One;
using System.Collections.Generic;

namespace Laboratory_Work_Five.Models
{
    // Симуляция базы данных
    public class Data
    {
        private static Data instance;

        private Data() { }

        public PersonalDepartment personalDepartmens;

        public static Data GetInstance()
        {
            if (instance == null)
            {
                instance = new Data()
                {
                    personalDepartmens = new PersonalDepartment()
                    {
                        Address = "9th Street West",
                        IsOpened = true,
                        WorkSchedule = "11:00-19:00",
                        ListVacancies = new List<Vacancy>(),
                        ListEmployees = new List<Employee>(),
                        ListResigningPerson = new List<ResigningPerson>()
                    }
                };
            }

            return instance;
        }
    }
}
