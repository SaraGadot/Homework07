using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework07
{
    partial class Program
    {
        private static void GeneratePersons(List<Person> persons)
        {
            Console.WriteLine("Введите количество записей для генерации:");
            var count = Convert.ToInt32(Console.ReadLine());
            var maleFirstNames = new[]
            {
                    "Александр",
                    "Борис",
                    "Виктор",
                    "Геннадий",
                    "Дмитрий",
                    "Евгений",
                    "Захар",
                    "Игорь",
                    "Константин",
                    "Леонид",
                    "Марк",
                    "Никита",

                };
            var maleLastNames = new[]
            {
                    "Иванов",
                    "Петров",
                    "Сидоров",
                    "Петухов",
                    "Воронов",
                    "Сорокин",
                    "Воробьев",
                    "Курицин",
                    "Собакин",
                    "Орлов",
                    "Соколов",
                    "Ласточкин",

                };
            var famaleFirstNames = new[]
           {
                    "Анна",
                    "Варвара",
                    "Галина",
                    "Дарья",
                    "Елена",
                    "Зинаида",
                    "Екатерина",
                    "Лариса",
                    "Мария",
                    "Наталья",
                    "Ольга",
                    "Полина",
                };
            var famaleLastNames = new[]
            {
                    "Борисова",
                    "Краснова",
                    "Никитина",
                    "Павлова",
                    "Шарикова",
                    "Круглова",
                    "Караваева",
                    "Куприянова",
                    "Пастухова",
                    "Чашкина",
                };
            var random = new Random();
            for (var i = 0; i < count; i++)
            {
                var sex = random.Next(2) == 0 ? Sex.Male : Sex.Female;
                var firstNames = sex == Sex.Male ? maleFirstNames : famaleFirstNames;
                var lastNames = sex == Sex.Male ? maleLastNames : famaleLastNames;
                var firstName = firstNames[random.Next(firstNames.Length)];
                var lastName = lastNames[random.Next(lastNames.Length)];
                var age = random.Next(100);
                var person = new Person(firstName, lastName, age, sex);
                persons.Add(person);
            }
        }

        private static void SortPersons(List<Person> persons, string sortField)
        {
            switch (sortField)
            {
                case "1":
                    persons.Sort((person1, person2) => string.Compare(person1.firstName, person2.firstName));
                    break;
                case "2":
                    persons.Sort((person1, person2) => string.Compare(person1.lastName, person2.lastName));
                    break;
                case "3":
                    persons.Sort((person1, person2) => person1.age.CompareTo(person2.age));
                    break;
                case "4":
                    persons.Sort((person1, person2) => person1.sex.CompareTo(person2.sex));
                    break;
                case "5":
                    persons.Sort((person1, person2) => person1.createdDate.CompareTo(person2.createdDate));
                    break;
                case "6":
                    persons.Sort((person1, person2) =>
                    {
                        var cmp = person1.sex.CompareTo(person2.sex);
                        if (cmp == 0)
                        {
                            cmp = string.Compare(person1.lastName, person2.lastName);
                        }
                        if (cmp == 0)
                        {
                            cmp = string.Compare(person1.firstName, person2.firstName);
                        }
                        return cmp;
                    }
                    );
                    break;
            }
        }

        private static void AddPerson(List<Person> persons, Person person)
        {
            persons.Add(person);
        }

        private static void DeleteBySex(List<Person> persons, Sex sex)
        {
            persons.RemoveAll(person => person.sex == sex);
        }

        private static void DeleteByAge(List<Person> persons, int age)
        {
            persons.RemoveAll(person => person.age == age);
        }

        private static void DeleteByLastName(List<Person> persons, string lastName)
        {
            persons.RemoveAll(person => person.lastName == lastName);
        }

        private static void DeleteByFirstName(List<Person> persons, string firstName)
        {
            persons.RemoveAll(person => person.firstName == firstName);
        }

        private static void DeleteByIndex(List<Person> persons, int i)
        {
            persons.RemoveAt(i);
        }


        static void SavePersons(List<Person> persons)
        {
            var json = JsonConvert.SerializeObject(persons, Formatting.Indented);
            File.WriteAllText("persons.json", json);
        }
        static List<Person> LoadPersons()
        {
            if (!File.Exists("persons.json"))
                return new List<Person>();

            var json = File.ReadAllText("persons.json");
            return JsonConvert.DeserializeObject<List<Person>>(json);
        }
        static List<Person> LoadPersonsByDates()
        {
            if (!File.Exists("persons.json"))
                return new List<Person>();

            var json = File.ReadAllText("persons.json");
            var persons = JsonConvert.DeserializeObject<List<Person>>(json);
            Console.WriteLine("Введите дату начала:");
            var startDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите дату конца:");
            var finishDate = DateTime.Parse(Console.ReadLine());
            persons.RemoveAll(person => finishDate < person.createdDate || person.createdDate < startDate);
            return persons;
        }


    }
}
