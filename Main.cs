using System.IO;
using System.Windows.Forms;

namespace StudentsDiary
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            var path = ($@"{Path.GetDirectoryName(Application.ExecutablePath)}\..\NowyPlik2.txt");

            //if (!File.Exists(path))
            //{
            //    File.Create(path);
            //}

            // File.Delete(path); // usuwanie pliku
            //File.WriteAllText(path, "Zostań Programistą .NET"); // dodanie tekstu z nadpisywaniem
            File.AppendAllText(path, "\nAkademia .NET"); // dodanie tekstu bez nadpisywania

            var text = File.ReadAllText(path);
            MessageBox.Show(text); // wyświetlenie komunikatu w okienku
            MessageBox.Show("Test", "Tytuł", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error); // wyświetlenie komunikatu z przyciskami w okienku
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {

        }
    }
}
