using System;

namespace Lesson27
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Person() { }
        public Person(string Name, string Surname, int Age)
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException(nameof(Name), "Wrong type of Name.");
            else
                this.Name = Name;

            if (string.IsNullOrWhiteSpace(Surname))
                throw new ArgumentNullException(nameof(Surname), "Wrong type of Surname.");
            else
                this.Surname = Surname;

            if (Age <= 0)
                throw new ArgumentException(nameof(Age), "Wrong age.");
            else
                this.Age = Age;
        }
        //trash
        public static Person operator + (Person p1, Person p2)
        {
            return new Person { Name = "NewPerson", Surname = p1.Surname, Age = p1.Age + p2.Age };
        }
        public override string ToString()
        {
            return $"{this.Name} {this.Surname} - {this.Age}";
        }
        /// <summary>
        /// Правила для перевизначення методу Equals:
        ///     1) метод немає кидати exception
        ///     2) метод повинен бути найбільш оптимальним
        ///     3) типи повинні співпадати
        ///     4) при порівнюванні елементу самим з собою повинен вертати true
        /// Порівняння не по адресу а по значеннях.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                if (this.Name == person.Name && this.Surname == person.Surname && this.Age == person.Age)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        //використовуються для максимально швидкої перевірки на співпадіння.
        //Наприклад ми працюємо з списком людей, хочемо порівняти дві людини по їх віку, якщо вік співпадає, то виконується
        //перевірка по Equals, якщо ні, то одразу false;
        public override int GetHashCode()
        {
            return Age;
        }
        //неглибоке копіювання. Всі значемі типи які є в класі який ми хочемо скопіювати скопіюються
        //так, що при зміні значення в одному класі не буде мінятись значення в наступному.
        //але всі силочні значення які є в одному, передадуться і в другого, тобто якщо ми захочемо
        //змінити силочне значення в одному обєктів, воно поміняється і для другого.
        public Person Clone()
        {
            return MemberwiseClone() as Person;
        }
        //Глибоке копіювання, ми самі вибираємо елементи які хочемо скопіювати.
        public Person DeepClone()
        {
            return new Person { Age = this.Age, Name = this.Name, Surname = this.Surname };
        }
    }
}
