﻿using StudentsDiary.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentsDiary
{
    public partial class Main : Form
    {


        private FileHelper<List<Student>> _fileHelper =
            new FileHelper<List<Student>>(Program.FilePath);
        private List<Group> _groups;

        public bool IsMaximize
        {
            get
            {
                return Settings.Default.IsMaximize;
            }
            set
            {
                Settings.Default.IsMaximize = value;
            }
        }

        public Main()
        {
            InitializeComponent();
            _groups = GroupsHelper.GetGroups("Wszyscy");
            InitGroupsComboBox();
            RefreshDiary();
            SetColumnsHeader();
            HideColumns();


            if (IsMaximize)
            {
                WindowState = FormWindowState.Maximized;
            }

        }
        private void InitGroupsComboBox()
        {
            cmbGroups.DataSource = _groups;
            cmbGroups.DisplayMember = "Name";
            cmbGroups.ValueMember = "Id";
        }
        private void HideColumns()
        {
            dgvDiary.Columns[nameof(Student.GroupId)].Visible = false;
        }

        private void RefreshDiary()
        {
            var students = _fileHelper.DeserializeFromFile();

            var selectedGroupId = (cmbGroups.SelectedItem as Group).Id;
            if (selectedGroupId != 0)
            {
                students = students.Where(x => x.GroupId == selectedGroupId).ToList();
            }
            dgvDiary.DataSource = students;
        }
        private void SetColumnsHeader()
        {
            dgvDiary.Columns[nameof(Student.Id)].HeaderText = "Numer";
            dgvDiary.Columns[nameof(Student.FirstName)].HeaderText = "Imię";
            dgvDiary.Columns[nameof(Student.LastName)].HeaderText = "Nazwisko";
            dgvDiary.Columns[nameof(Student.Math)].HeaderText = "Matematyka";
            dgvDiary.Columns[nameof(Student.Technology)].HeaderText = "Technologia";
            dgvDiary.Columns[nameof(Student.Physics)].HeaderText = "Fizyka";
            dgvDiary.Columns[nameof(Student.PolishLang)].HeaderText = "Język polski";
            dgvDiary.Columns[nameof(Student.ForeignLang)].HeaderText = "Język obcy";
            dgvDiary.Columns[nameof(Student.Comments)].HeaderText = "Uwagi";
            dgvDiary.Columns[nameof(Student.AddClasses)].HeaderText = "Zajęcia dodatkowe";
            ;
        }


        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            var addEditStudent = new AddEditStudent();
            addEditStudent.FormClosing += AddEditStudent_FormClosing;
            addEditStudent.ShowDialog();

        }

        private void AddEditStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            RefreshDiary();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            if (dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybierz ucznia, którego dane będą zmieniane.");
                return;
            }

            var addEditStudent = new AddEditStudent(Convert.ToInt32(dgvDiary.SelectedRows[0].Cells[0].Value));
            addEditStudent.FormClosing += AddEditStudent_FormClosing;
            addEditStudent.ShowDialog();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybierz ucznia, którego dane będą usunięte.");
                return;
            }
            var selectedStudent = dgvDiary.SelectedRows[0];
            var confirmDelete = MessageBox.Show($"Czy na pewno chcesz usunąć ucznia {selectedStudent.Cells[1].Value.ToString() + " " + selectedStudent.Cells[2].Value.ToString().Trim()}?", "Usuwanie ucznia", MessageBoxButtons.OKCancel);

            if (confirmDelete == DialogResult.OK)
            {
                DeleteStudent(Convert.ToInt32(selectedStudent.Cells[0].Value));
                RefreshDiary();
            }

        }


        private void DeleteStudent(int id)
        {
            var students = _fileHelper.DeserializeFromFile();
            students.RemoveAll(x => x.Id == id);
            _fileHelper.SerializeToFile(students);
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            InitGroupsComboBox();
            RefreshDiary();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                IsMaximize = true;
            }
            else
            {
                IsMaximize = false;
            }
            Settings.Default.Save();
        }
    }
}
