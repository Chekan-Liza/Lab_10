using Lab_5;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab_10
{
    class Student
    { private string name;
       
        public string Name
        {   get => name;
            set => name = value;
        }

        public Student(string name)
        {   this.name = name; 
        }

        public override string ToString()
        {   return base.ToString(); 
        }
    }
    class Program
    {
        private static void Deal(object a, NotifyCollectionChangedEventArgs e)// ----Произвольный метод на событие CollectionChange
        {   switch (e.Action)
            {   case NotifyCollectionChangedAction.Add: // ----Демонстрация с добавлением
                    {   Student newStudent = e.NewItems[0] as Student;
                        Console.WriteLine("Add object: " + newStudent.Name + ".");
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:// ----Демонстрация с удалением
                    {   Student oldStudent = e.OldItems[0] as Student;
                        Console.WriteLine("Del object: " + oldStudent.Name + ".");
                        break;
                    }
            }
        }
        static void Main(string[] args)
        {   Console.WriteLine("----1 задание----");
            ArrayList aList = new ArrayList();// ----Необобщенная коллекция
            Random rand = new Random();

            for (int i = 0; i < 5; i++)// ----Заполнение случайными числами
            {   aList.Add(rand.Next(100));
            }

            aList.Add("This string");// ----Добавление строки
            aList.Add("Student");

            aList.RemoveAt(6);// ----Удаление элемента с индексом 6

            Console.WriteLine("Size ArrayList: " + aList.Count);// ----Количество элементов

            foreach (var item in aList)// ----Вывод на консоль
            {   Console.WriteLine(item);
            }

            Console.WriteLine(aList.Contains("Student"));// ----Поиск значения

            Console.WriteLine("----2 задание----");

            Dictionary<int, string> DList = new Dictionary<int, string>();// ----Обобщенная коллекция

            DList.Add(1, "we");// ----Добавление пар: ключ-значение
            DList.Add(2, "scream");
            DList.Add(3,"we");
            DList.Add(4, "shout");
            DList.Add(5, "we are");
            DList.Add(6, "the");
            DList.Add(7, "fallen");
            DList.Add(8, "angels");

            foreach (KeyValuePair<int, string> keyValue in DList)// ----Вывод коллекции на консоль парами: ключ-значение
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }

            int n = 4;// ----Удаление n последовательных эл-ов (по ключу)

            for (int i = 1; i < n+1; i++)
            {
                DList.Remove(i);
            }

            DList[9] = "WHOA-WHOA";// ----Добавления эл-та другим методом

            Console.WriteLine("\n");

            HashSet<string> hSet = new HashSet<string>();// ----Вторая коллекция со значениями первой
            string[] arr = new string[DList.Count];

            for (int i = 0; i < arr.Length; i++)
            {
                foreach (KeyValuePair<int, string> keyValue in DList)
                {
                    arr[i] = DList[i+5];
                    hSet.Add(arr[i]);
                } 
            }

            foreach (var item in hSet)// ----Вывод второй коллекции на консоль
            {
                Console.Write(item+"\n");
            }

            Console.WriteLine(hSet.Contains("the"));// ----Поиск значения 

            Console.WriteLine("\n----3 задание----");// ----Задание 2 для пользовательского типа данных

            Receipt Receipt_1 = new Receipt("Грустинка", 1, "Лысенков", 320.50);
            Invoice Invoice_1 = new Invoice("Веселушечка", 5, 1400, "Хорошее настроение");
            Cheque Cheque_1 = new Cheque("Котики", 4, 540.00, "Вислоухий");

            LinkedList<Document> pList = new LinkedList<Document>();

            pList.AddLast(Receipt_1);
            pList.AddLast(Invoice_1);
            pList.AddLast(Cheque_1);

            foreach (var item in pList)
            {
                Console.WriteLine(item);
            }

            int n2 = 2;

            for (int i = 0; i < n2; i++)
            {
                pList.RemoveFirst();
            }


            HashSet<Document> pSet = new HashSet<Document>();
            Document[] pArr = new Document[pList.Count];

            pList.CopyTo(pArr, 0);

            for (int i = 0; i < pArr.Length; i++)
            {
                pSet.Add(pArr[i]);
            }

            foreach (var item in pSet)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(pSet.Contains(Receipt_1));

            Console.WriteLine("\n----4 задание----");

            ObservableCollection<Student> students = new ObservableCollection<Student>();// ----Наблюдаемая коллекция

            students.CollectionChanged += Deal;

            for (int i = 0; i < 4; i++)
            {
                students.Add(new Student(Convert.ToString(rand.Next(0, 255))));
            }
            students.Remove(new Student(Convert.ToString(rand.Next(0, 255))));
        }
    }
}
