namespace StudentsDiary
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
    }
    public class Student
    {
        public Student()
        {
            Address = new Address();
        }

        public string Math { get; set; }
        public string Technology { get; set; }
        public string Physics { get; set; }
        public string PolishLang { get; set; }
        public string ForeignLang { get; set; }

        public Address Address { get; set; }
        public int Id { get; internal set; }
    }

}
