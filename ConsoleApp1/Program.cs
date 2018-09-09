using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Person
    {
        private string name;
        private int age;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public static bool operator <(Person p1, Person p2) => p1.Age < p2.Age;
        public static bool operator >(Person p1, Person p2) => p1.Age > p2.Age;
        public static bool operator <=(Person p1, Person p2) => p1.Age <= p2.Age;

        public static bool operator >= (Person p1, Person p2) => p1.Age >= p2.Age;
        public static bool operator ==(Person p1, Person p2) => p1.Age == p2.Age;
        public static bool operator !=(Person p1, Person p2) => p1.Age != p2.Age;
    }
    public class People:DictionaryBase/*集合*/,ICloneable//克隆
    {
        public object Clone() 
        {
            People clonePeople = new People();
            Person currentPerson, clonePerson;
            foreach(DictionaryEntry p in Dictionary)
            {
                currentPerson = p.Value as Person;
                clonePerson = new Person();
                clonePerson.Name = currentPerson.Name;
                clonePerson.Age = currentPerson.Age;
                clonePeople.Add(clonePerson);//深度复刻
            }
            return clonePeople;
        }
        public void Add(Person newPerson)=>Dictionary.Add(newPerson.Name, newPerson);
        public void Remove(string name) => Dictionary.Remove(name);
        public Person this[string name]
        {
            get { return (Person)Dictionary[name]; }
            set { Dictionary[name] = value; }
        }
        public Person[] GetOldest()
        {
            Person oldestPerson=null;
            Person currentPerson;
            People oldestPeople = new People();
            foreach(DictionaryEntry p in Dictionary)
            {
                currentPerson = p.Value as Person;
                if (oldestPerson == null)
                {
                    oldestPerson = currentPerson;
                }
                else
                {
                    if (currentPerson > oldestPerson)
                    {
                        oldestPerson = currentPerson;
                    }
                }
            }
            foreach(DictionaryEntry p in Dictionary)
            {
                currentPerson = p.Value as Person;
                if (oldestPerson == currentPerson)
                    oldestPeople.Add(currentPerson);
            }
            Person[] oldestpeopleArray = new Person[oldestPeople.Count];
            int copyIndex = 0;
            foreach(DictionaryEntry p in oldestPeople)
            {
                oldestpeopleArray[copyIndex] = p.Value as Person;
                copyIndex++;
            }
            return oldestpeopleArray;
        }
        public IEnumerable Ages
        {
            get
            {
                foreach (object person in Dictionary.Values)
                    yield return (person as Person).Age;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
