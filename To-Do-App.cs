using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_Liste_in_Windows_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Label_input_Click(object sender, EventArgs e)
        {

        }

        


        private void TO_DO_erstellen_Click(object sender, EventArgs e)
        {

            // 1. Text aus der TextBox holen
            string eingabeText = textBox1.Text;

            // 2. Prüfen ob Text eingegeben wurde
            if (eingabeText.Length > 0)
            {
                // 3. Neues ToDo erstellen
                ToDo neueseToDo = new ToDo();
                neueseToDo.Text = eingabeText;

                // 4. ToDo zur ListBox hinzufügen
                listBox1.Items.Add(neueseToDo);

                // 5. TextBox leeren für nächste Eingabe
                textBox1.Clear();
            }
        }

    }
}
