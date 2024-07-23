namespace StudentsDiary
{
    public class Teacher : Person
    {
        public string Position { get; set; }

        public override string GetInfo()
        {
            return $"{FirstName} {LastName} - Nauczyciel.";
        }
    }
}
