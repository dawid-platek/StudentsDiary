using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace StudentsDiary
{
    public partial class Main : Form
    {
        private string _filePath =
            Path.Combine(Environment.CurrentDirectory, "students.txt");
        public Main()
        {
            InitializeComponent();

        }

        public void SerializeToFile(List<Student> students)

        {
            var serializer = new XmlSerializer(typeof(List<Student>));
            using (var streamWriter = new StreamWriter(_filePath))
            {
                serializer.Serialize(streamWriter, students);
                streamWriter.Close();
            }

        }

        public List<Student> DeserializeFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Student>();

            var serializer = new XmlSerializer(typeof(List<Student>));
            using (var streamReader = new StreamReader(_filePath))
            {
                var students = (List<Student>)serializer.Deserialize(streamReader);
                streamReader.Close();
                return students;
            }
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            var serializer = new XmlSerializer(typeof(List<Student>));
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {

        }
    }
}
