namespace StudentsDiary
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Comments { get; set; }

        public virtual string GetInfo()
        {
            return string.Empty;
        }
    }
}
