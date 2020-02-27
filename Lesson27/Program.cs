using System;

namespace Lesson27
{
    class Program
    {
        static void Main(string[] args)
        {
            object MY_CUSTOM_OBJECT = new object();

            //Для значемих типів метод Equals виконує порівняння елементів(значень) записаних в змінних.
            int first_number = 10, second_number = 15;
            //false(10 !=== 15)
            Console.WriteLine(first_number.Equals(second_number).ToString());

            //Boxing - упаковка значемих типів в силочні (передача з стека в кучу).
            //виконується порівняння object(int) - тому порівнюються все ж таки як значемі, тобто їхні значення.
            var obj_first_number = (object)first_number;
            var obj_second_number = (object)second_number;
            Console.WriteLine(obj_first_number.Equals(obj_second_number).ToString());

            //Виконується порівнняня різних обєктів які розміщують в різних місцях
            var person1 = new Person("Roman", "Cholkan", 19);
            var person2 = new Person("Roman", "Cholkan", 19);
            Console.WriteLine(person1.Equals(person2).ToString());
            Console.WriteLine(person2.Equals(person1).ToString());

            //виконується швидка порівняння.
            Console.WriteLine(first_number.GetHashCode());
            Console.WriteLine(obj_first_number.GetHashCode());
            Console.WriteLine(new Point().GetHashCode());
            Console.WriteLine(person1.GetHashCode());

            Console.WriteLine(first_number.ToString());
            Console.WriteLine(new Point().ToString());
            Console.WriteLine(person1.ToString());

            Console.WriteLine(typeof(Person) == person1.GetType());

            //trash
            Console.WriteLine(person1 + person2);

            Console.WriteLine(first_number.GetType());
            Console.WriteLine(obj_first_number.GetType());
            Console.WriteLine(new Point().GetType());
            Console.WriteLine(person1.GetType());

            //порівнюємо обєкти по їх значеннях
            Console.WriteLine(Object.Equals(5, 5));
            //порівнюємо обєкти по їх силках
            Console.WriteLine(Object.ReferenceEquals(5, 5));
            Console.WriteLine(Object.ReferenceEquals(person1, person1));


            //в даному випадку person4 посилається на місце в памяті де знаходиться person3
            //тому всі зміни які ми виконаємо з person4 будуть втіленні й для person3, щоб 
            //цього уникнути потрібно використовувати клонування обєктів.
            var person3 = new Person();
            var person4 = person3;
            //клонування обєктів.
            person4 = person1.Clone();
            Console.WriteLine(person4);
            person3 = person1.DeepClone();
            Console.WriteLine(person3);

            Console.ReadLine();
        }
        public static void SwitchNumbers(ref int number1, ref int number2)
        {
            number1 = number2 + number1;
            number2 = number1 - number2;
            number1 = number1 - number2;
        }
    }
}
