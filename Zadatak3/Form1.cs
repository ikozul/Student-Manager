using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadatak3
{
    public partial class Form1 : Form
    {
        PPPK_DZ3Entities db = new PPPK_DZ3Entities();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrikaziStudente();
        }

        private void PrikaziStudente()
        {
            var studenti = (from s in db.Students select s).ToList();
            lbStudenti.DataSource = studenti;

            lbStudenti.DisplayMember = "Ime";
            lbStudenti.ValueMember = "IDStudent";
            lbStudenti.SelectedIndex = 0;
        }

        private void PrikaziDetaljeStudenta()
        {
            Student s = (Student)lbStudenti.SelectedItem;
            txtIme.Text = s.Ime;
            txtPrezime.Text = s.Prezime;
            txtJmbg.Text = s.JMBG;
            txtEmail.Text = s.Email;           
        }

        private void lbStudenti_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrikaziDetaljeStudenta();
        }

        private void btnBrisi_Click(object sender, EventArgs e)
        {
            Student s = (Student)lbStudenti.SelectedItem;
            db.Students.Remove(s);
            db.SaveChanges();
            PrikaziStudente();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.Email = txtEmail.Text;
            s.Ime = txtIme.Text;
            s.Prezime = txtPrezime.Text;
            s.JMBG = txtJmbg.Text;
            db.Students.Add(s);
            db.SaveChanges();
            PrikaziStudente();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student s = (Student)lbStudenti.SelectedItem;
            s.Email = txtEmail.Text;
            s.Ime = txtIme.Text;
            s.Prezime = txtPrezime.Text;
            s.JMBG = txtJmbg.Text;
            db.SaveChanges();
            PrikaziStudente();
        }

    }
}
