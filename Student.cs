using System;

namespace StudentsDiary
{
    public class Student : Person
    {
        public class Math
        {
            public const double PI = 3.14159;
        }
        private string _property;
        public string Property

        {
            get
            {
                if (_property == "1")

                    throw new Exception("Zła wartość.");
                return _property;
            }

            set
            {
                System.Windows.Forms.MessageBox.Show("Przypisywanie wartości - SET");
                _property = value;
            }
        }

        public Student()
        {
            _privateField = "1";
        }
        private readonly string _privateField;
        public string PublicField;

        public string Math { get; set; }
        public string Technology { get; set; }
        public string Physics { get; set; }
        public string PolishLang { get; set; }
        public string ForeignLang { get; set; }


        public override string GetInfo()
        {
            ProtectedField = "3";
            return $"{FirstName} {LastName} - Oceny z matematyki: {Math}.";
        }
    }

}
