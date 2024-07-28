namespace StudentsDiary
{

    public interface IPerson
    {
        string GetInfo();
    }
    public abstract class Person
    {
        protected string ProtectedField;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Comments { get; set; }

        public abstract string GetInfo();

    }
}
