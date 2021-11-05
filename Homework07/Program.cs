using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Homework07
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = LoadPersons();

            DisplayPersons(persons);

            for (; ; )
            {
                if (Menu(persons) == false)
                {
                    break;
                }

                DisplayPersons(persons);
            }


            SavePersons(persons);

        }
        static bool Menu(List<Person> persons)
        {
            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("1. Добавить запись");
            Console.WriteLine("2. Редактировать запись");
            Console.WriteLine("3. Удалить запись");
            Console.WriteLine("4. Упорядочить записи");
            Console.WriteLine("5. Сгенерировать записи");
            Console.WriteLine("6. Загрузить записи по диапазону дат");
            Console.WriteLine("0. Выйти");
            var action = Console.ReadLine();
            if (action == "1")
            {
                AddPerson(persons);
            }
            else if (action == "2")
            {
                Console.WriteLine("Введите номер записи для редактирования:");
                var i = Convert.ToInt32(Console.ReadLine()) - 1;
                persons[i] = EditPerson(persons[i]);

            }
            else if (action == "3")
            {
                DeletePersons(persons);
            }
            else if (action == "4")
            {
                SortPersons(persons);
            }
            else if (action == "5")
            {
                GeneratePersons(persons);
            }
            else if (action == "6")
            {
                persons.Clear();
                persons.AddRange(LoadPersonsByDates());
            }
            else if (action == "0")
            {
                return false;
            }
            return true;

        }

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

        private static void SortPersons(List<Person> persons)
        {
            Console.WriteLine("По какому полю упорядочить?");
            Console.WriteLine("1 - имя");
            Console.WriteLine("2 - фамилия");
            Console.WriteLine("3 - возраст");
            Console.WriteLine("4 - пол");
            Console.WriteLine("5 - дата создания");

            var sortField = Console.ReadLine();
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

        static void DeletePersons(List<Person> persons)
        {
            Console.WriteLine("По какому полю удалить?");
            Console.WriteLine("0 - номер записи");
            Console.WriteLine("1 - имя");
            Console.WriteLine("2 - фамилия");
            Console.WriteLine("3 - возраст");
            Console.WriteLine("4 - пол");
            var fieldId = Console.ReadLine();
            switch (fieldId)
            {
                case "0":
                    Console.WriteLine("Введите номер записи для удаления:");
                    var i = Convert.ToInt32(Console.ReadLine()) - 1;
                    persons.RemoveAt(i);
                    break;
                case "1":
                    Console.WriteLine("Введите имя для удаления:");
                    var firstName = Console.ReadLine();
                    persons.RemoveAll(person => person.firstName == firstName);
                    break;
                case "2":
                    Console.WriteLine("Введите фамилию для удаления:");
                    var lastName = Console.ReadLine();
                    persons.RemoveAll(person => person.lastName == lastName);
                    break;
                case "3":
                    Console.WriteLine("Введите возраст для удаления:");
                    var age = Convert.ToInt32(Console.ReadLine());
                    persons.RemoveAll(person => person.age == age);
                    break;
                case "4":
                    Console.WriteLine("Введите пол для удаления (м/ж):");
                    var sex = Console.ReadLine() == "м" ? Sex.Male : Sex.Female;
                    persons.RemoveAll(person => person.sex == sex);
                    break;

            }
        }
        static void AddPerson(List<Person> persons)
        {
            var person3 = InputPerson();
            persons.Add(person3);

        }
        static Person EditPerson(Person person)
        {
            Console.WriteLine(person.firstName);
            Console.WriteLine("Введите новое имя или Enter для старого");
            var newFirstName = Console.ReadLine();
            var firstName = newFirstName == "" ? person.firstName : newFirstName;

            Console.WriteLine(person.lastName);
            Console.WriteLine("Введите новую фамилию или Enter для старой");
            var newLastName = Console.ReadLine();
            var lastName = newLastName == "" ? person.lastName : newLastName;

            Console.WriteLine(person.age);
            Console.WriteLine("Введите новый возраст или Enter для старого");
            var newAge = Console.ReadLine();
            var age = newAge == "" ? person.age : Convert.ToInt32(newAge);

            Console.WriteLine(person.sex);
            Console.WriteLine("Введите новый пол (м/ж) или Enter для старого");
            var newSex = Console.ReadLine();
            var sex = newSex == "" ? person.sex : newSex == "м" ? Sex.Male : Sex.Female;

            return new Person(firstName, lastName, age, sex);
        }
        static Person InputPerson()
        {
            Console.WriteLine("Введите имя:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию:");
            var lastName = Console.ReadLine();
            Console.WriteLine("Введите возраст:");
            var age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите пол (м/ж)");
            var sex = Console.ReadLine() == "м" ? Sex.Male : Sex.Female;
            return new Person(firstName, lastName, age, sex);
        }
        static void DisplayPersons(List<Person> persons)
        {
            Console.WriteLine($"{"№",2} {"Имя",10} {"Фамилия",20} {"Возраст",7} {"Пол",8} {"Время создания",20}");
            for (var i = 0; i < persons.Count; i++)
            {
                var person = persons[i];
                Console.WriteLine($"{i + 1,2} {person.firstName,10} {person.lastName,20} {person.age,7} {person.sex,8} {person.createdDate,20}");
            }

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
//Что нужно сделать
//Разработайте ежедневник, который может хранить множество записей. Каждая запись состоит из нескольких полей, количество которых
//должно быть не менее пяти.
//Поля могут быть произвольными, однако одним из них должна быть дата добавления записи.



//Для записей реализуйте следующие функции:

//создание,
//удаление,
//редактирование.


//Вы можете сделать создание записи двумя способами:

//Пользователь вводит информацию вручную с клавиатуры.
//Информация генерируется программой.


//Удалять запись можно как по номеру, так и по любому полю. Если несколько записей имеют одинаковые
//значения полей, следует удалить их все.



//Помимо этого, реализуйте следующие возможности:

//загрузка всех записей из файла,
//сохранение всех записей в файл,
//загрузка записей из файла по диапазону дат,
//упорядочивание записей по выбранному полю.


//Что оценивается
//Создан ежедневник, в котором могут храниться записи.
//Записи имеют как минимум пять полей.
//Одно из полей записи ― дата создания.
//Все записи сохраняются на диске.
//Все записи загружаются с диска.
//С диска загружаются записи в выбранном диапазоне дат.
//Записи можно создавать, редактировать и удалять.
//Записи сортируются по выбранному полю.