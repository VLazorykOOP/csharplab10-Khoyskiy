public class HorseEventArgs : EventArgs
{
    private string name;
    private int age;

    public string Name { get { return name; } }
    public int Age { get { return age; } }

    public HorseEventArgs(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}