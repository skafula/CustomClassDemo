using System.Collections;
using System.Collections.Generic;
using static Program;

internal class Program
{
    private static void Main(string[] args)
    {
        People people = new People()
        {
            new Person() { Id = 101, Name = "Emily", Email = "emily@gmail.com", Type = PersonType.VIP },
            new Person() { Id = 102, Name = "Scott", Email = "scott@gmail.com", Type = PersonType.Regular },
            new Person() { Id = 103, Name = "Jack", Email = "jack@gmail.com", Type = PersonType.VIP }
        };

        //User interactive List making without full exception handling.
        //bool exit = false;

        //while (!exit) 
        //{
        //    Console.WriteLine("Name: ");
        //    string name = Console.ReadLine();
        //    Console.WriteLine("Id: ");
        //    int id = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Email: ");
        //    string email = Console.ReadLine();
        //    Console.WriteLine("Type (Regular/VIP): ");
        //    string personType = Console.ReadLine() == "VIP" ? "VIP" : "Regular";

        //    people.Add(new Person() { Id = id, Name = name, Email = email, Type = personType == "VIP" ? PersonType.VIP : PersonType.Regular});

        //    Console.WriteLine("Person added! Do you want to exit ('1' yes/'2' no): ");
        //    int wantExit = int.Parse(Console.ReadLine());
        //    if (wantExit == 1 ? true : false)
        //    {
        //        exit = true;
        //    }
        //}
        
        foreach (Person person in people)
        {
            Console.WriteLine(person.Id + " " + person.Name + " " + person.Email + " " + person.Type);
        }

        Console.WriteLine(people.Count + " person exists in the list.");

        ////Adding reference, so if the values of the object on the referenceVariable (emily) is same as an object in the list, it will
        ////return false. But as i add the exact object reference to the variable emily it returns true.
        //Person emily = people.First();
        //Console.WriteLine(people.Contains(emily));
        //emily = new Person() { Id = 101, Name = "Emily", Email = "emily@gmail.com", Type = PersonType.VIP };
        //Console.WriteLine(people.Contains(emily));
        //people.Add(emily);
        //Console.WriteLine(people.Contains(emily));

        //As implemented IEquatable<T> in Person the Contain method calls the custom logic of the implementation.
        Console.WriteLine("\n");
        bool iEquatableCheck = people.Contains(new Person() { Id = 103, Name = "Jack", Email = "jack@gmail.com", Type = PersonType.VIP });
        Console.WriteLine("Contains by object details and not by reference: " + iEquatableCheck);

        foreach (Person person in people)
        {
            Console.WriteLine(person.Id + " " + person.Name + " " + person.Email + " " + person.Type);
        }

        //people.Remove(emily);

        Person nameScott = people.Find(personName => personName.Name == "Scott");
        if (nameScott != null)
        {
            Console.WriteLine(nameScott.Id + " " + nameScott.Name);
        }

        Console.WriteLine("\nVIP people: ");
        List<Person> findAll = people.FindAll(person => person.Type == PersonType.VIP);
        findAll.ForEach(person => Console.WriteLine(person.Id + ", " + person.Name + ", " + person.Type));

        Console.WriteLine("\n2nd person in list by index: " + people[2].Name);

        Person person1 = people[0];
        Console.WriteLine("IndexOf the first person: " + people.IndexOf(person1));

        Console.WriteLine("\nChecking InsertOf logic: ");
        people.Insert(5, new Person() { Id = 105, Name = "Robert", Email = "robert@gmail.com", Type = PersonType.Regular });

        people.Insert(1, new Person() { Id = 105, Name = "Robert", Email = "robert@gmail.com", Type = PersonType.Regular });
        people.RemoveAt(3);
        Console.WriteLine("\nPeople after insert of + removed last person by index: ");
        foreach (Person person in people)
        {
            Console.WriteLine(person.Id + " " + person.Name + " " + person.Email + " " + person.Type);
        }
    }
    public class People : IList<Person>
    {
        private List<Person> people = new List<Person>();
        public int Count => people.Count;
        public bool IsReadOnly => false;

        public Person this[int index] 
        { 
            get => people[index]; 
            set => people[index] = value; 
        }

        public int IndexOf(Person item)
        {
            return people.IndexOf(item);
        }

        public void Insert(int index, Person item)
        {
            if (index < 0 || index >= people.Count)
            {
                Console.WriteLine("Invalid index");
            }
            else 
            {
                people.Insert(index, item);
            }
        }

        public void RemoveAt(int index)
        {
            people.RemoveAt(index);
        }

        public void Add(Person item)
        {
            people.Add(item);
        }

        public void Clear()
        {
            people.Clear();
        }

        public bool Contains(Person item)
        {
            return people.Contains(item);
        }

        public void CopyTo(Person[] array, int arrayIndex)
        {
            people.CopyTo(array, arrayIndex);
        }

        public Person Find(Predicate<Person> match)
        {
            return people?.Find(match);
        }

        public List<Person> FindAll(Predicate<Person> match)
        {
            return people?.FindAll(match);
        }

        public bool Remove(Person item)
        {
            return people.Remove(item);
        }

        public IEnumerator<Person> GetEnumerator()
        {
            for (int i = 0; i < people.Count; i++)
            {
                yield return people[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class Person : IEquatable<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public PersonType Type { get; set; }

        bool IEquatable<Person>.Equals(Person? other)
        {
            return this.Id == other.Id && this.Name == other.Name && this.Email == other.Email && this.Type == other.Type;
        }
    }

    public enum PersonType
    {
        Regular,
        VIP
    }

    //public class People : ICollection<Person>
    //{
    //    private List<Person> people = new List<Person>();
    //    public int Count => people.Count;
    //    public bool IsReadOnly => false;

    //    public void Add(Person item)
    //    {
    //        people.Add(item);
    //    }

    //    public void Clear()
    //    {
    //        people.Clear();
    //    }

    //    public bool Contains(Person item)
    //    {
    //        return people.Contains(item);    
    //    }

    //    public void CopyTo(Person[] array, int arrayIndex)
    //    {
    //        people.CopyTo(array, arrayIndex);
    //    }

    //    public Person Find(Predicate<Person> match)
    //    {
    //        return people?.Find(match);
    //    }

    //    public List<Person> FindAll(Predicate<Person> match)
    //    {
    //        return people?.FindAll(match);
    //    }

    //    public bool Remove(Person item)
    //    {
    //        return people.Remove(item);
    //    }

    //    public IEnumerator<Person> GetEnumerator()
    //    {
    //        for (int i = 0; i < people.Count; i++)
    //        {
    //            yield return people[i];
    //        }
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return this.GetEnumerator();
    //    }
    //}

    //public class People : IEnumerable
    //{
    //    private List<Person> people = new List<Person>();
    //    public IEnumerator GetEnumerator()
    //    {
    //        for (int i = 0; i < people.Count; i++)
    //        {
    //            yield return people[i];
    //        }
    //    }
    //    public void Add(Person person)
    //    {
    //        people.Add(person);
    //    }
    //}
}