﻿using System;
using System.Collections.Generic;

namespace Homework07
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.firstName = "Иван";
            person.lastName = "Иванов";
            person.age = 30;
            person.sex = Sex.Male;
            person.createdDate = DateTime.Now;

            var person2 = new Person();
            person2.firstName = "Мария";
            person2.lastName = "Петрова";
            person2.age = 25;
            person2.sex = Sex.Female;
            person2.createdDate = DateTime.Now;

            var person3 = InputPerson();


            var persons = new List<Person>();
            persons.Add(person);
            persons.Add(person2);
            persons.Add(person3);

            DisplayPersons(persons);
            
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
            Sex sex;
            if (Console.ReadLine() == "м")
            {
                sex = Sex.Male;
            }
            else
            {
                sex = Sex.Female;
            }
            var person = new Person();
            person.firstName = firstName;
            person.lastName = lastName;
            person.age = age;
            person.sex = sex;
            person.createdDate = DateTime.Now;
            return person;
        }
        static void DisplayPersons(List<Person> persons)
        {
            Console.WriteLine($"{"Имя",10} {"Фамилия",20} {"Возраст",7} {"Пол",8} {"Время создания",20}");
            foreach (var person in persons)
            {
                Console.WriteLine($"{person.firstName,10} {person.lastName,20} {person.age,7} {person.sex,8} {person.createdDate,20}");
            }

        }
    }
    class Person
    {
        public string firstName;
        public string lastName;
        public int age;
        public Sex sex;
        public DateTime createdDate;
    }
    enum Sex
    {
        Male,
        Female
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


//Удалять запись можно как по номеру, так и по любому полю. Если несколько записей имеют одинаковые значения полей, следует удалить их все.



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