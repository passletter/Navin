class Person {
    public string Name;
    public int Age;
}

class Program {
    public void UpdatePerson(ref Person p) {
        p.Name = "Updated Name";
        p.Age += 1;
        Console.WriteLine("Updated Details: " + p.Name + ", Age: " + p.Age);
    }

    static void MainLarge() {
        Person p = new Person { Name = "Sudhir Sharma", Age = 28 };
        Console.WriteLine("Before Update: " + p.Name + ", Age: " + p.Age);

        Program program = new Program();
        program.UpdatePerson(ref p);

        Console.WriteLine("After Update: " + p.Name + ", Age: " + p.Age);
    }
}