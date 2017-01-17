using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IEnumerableTs
{
    class Person
    {
        public Person(string name)
        {
            this.name = name;
        }
        public string name;
    }

    class PeopleEnum  /*:IEnumerator*/
    {
        public Person[] _people;

        int position = -1;
        public PeopleEnum(Person[] list)
        {
            _people = list;
        }

        public bool MoveNext()
        {
            position++;
            return position < _people.Length;
        }

        public void Reset()
        {
            position = -1;
        }

        /* object IEnumerator.Current
         {
             get
             {
                 return Current;
             }
         }*/
        public Person Current
        {
            get
            {
                try
                {
                    return _people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

    }

    class People : IEnumerable
    {
        private Person[] _people;
        public People(Person[] pArray)
        {
            _people = new Person[pArray.Length];
            for (int i = 0; i < pArray.Length;i++)
            {
                _people[i] = pArray[i];
            }
        }
        /*显示类型实现，只能通过接口对象进行调用，而无法通过继承类对象调用 */
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public PeopleEnum  GetEnumerator()
        {
            return new PeopleEnum (_people);
        }
    }

   
    class Program
    {
        static void Main(string[] args)
        {

            Person[] peopleArray = new Person[3]
        {
            new Person("张三"),
            new Person("李四"),
            new Person("王五"),
        };
            People people = new People(peopleArray) { };
            
            foreach (var va in people)
            {
                Console.WriteLine(va.name);
            }

            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "Tom");
            dic.Add(2, "Jerry");
            dic.Add(3, "Hyman");

            Dictionary<int, string>.Enumerator enumerator = dic.GetEnumerator();
            for (int i = 0; i < dic.Count;i++ )
            {
                enumerator.MoveNext();
                Console.WriteLine(enumerator.Current.Value);
            }

            List<string> list = new List<string> { "123", "456", "789" };
            List<string>.Enumerator enumerator2 = list.GetEnumerator();
            for (int j = 0; j < list.Count; j++)
            {
                enumerator2.MoveNext();
                Console.WriteLine(enumerator2.Current);
            }

        }
    }
}
