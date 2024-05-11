using System.Windows.Forms;

namespace StudentsDiary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnTest.Text = "Konstruktor";
            btnTest.MouseLeave += BtnTest_MouseLeave;

        }

        private void BtnTest_MouseLeave(object sender, System.EventArgs e)
        {
            btnTest.Text = "OK";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTest_Click(object sender, System.EventArgs e)
        {
            btnTest.Text = "Przycisk";
        }

        private void EnterTest(object sender, System.EventArgs e)
        {
            btnTest.Text = "Enter";
        }

    }
}
