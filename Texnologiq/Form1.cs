using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Texnologiq.Controller;
using Texnologiq.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Texnologiq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FruitController fruitController = new FruitController();
        FruitTypeController fruitTypeController = new FruitTypeController();

        private void LoadRecord(Fruit fruit)
        {
            txt1.BackColor = Color.White;
            txt1.Text = fruit.Id.ToString();
            txt2.Text = fruit.Name;
            txt3.Text = fruit.Description.ToString();
            cmb1.Text = fruit.Name;
        }
        private void ClearScreen()
        {
            txt1.BackColor = Color.White;
            txt1.Clear();
            txt2.Clear();
            txt3.Clear();
            cmb1.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<FruitType> allFruitTypes = fruitTypeController.GetAllFruitTypes();
            cmb1.DataSource = allFruitTypes;
            cmb1.DisplayMember = "Name";
            cmb1.ValueMember = "Id";

            btn5_Click(sender, e);
            
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt2.Text) || txt2.Text == "")
            {
                MessageBox.Show("Въведете данни!");
                txt2.Focus();
                return;
            }
            Fruit newFruit = new Fruit();
            newFruit.Description = txt3.Text;
            newFruit.Name = txt2.Text;
            //записва в таблицата Id на избрания елемент =>
            //Разлиства имената на породите, а записва съответното Id
            newFruit.FruitTypeId = (int)cmb1.SelectedValue;

            fruitController.Create(newFruit);
            MessageBox.Show("Записът е успешно добавен!");
            ClearScreen();
            //btn5_Click(sender, e);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            List<Fruit> allFruitType = fruitController.GetAll();
            listBox1.Items.Clear();
            foreach (var item in allFruitType)
            {
                listBox1.Items.Add($"{item.Id}. {item.Name} - Description: {item.Description} Type:{item.FruitTypeId}");
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txt1.Text) || !txt1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txt1.Text);
            }
            Fruit findedFruit = fruitController.Get(findId);
            if (findedFruit == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            LoadRecord(findedFruit);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txt1.Text) || !txt1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txt1.Text);
            }
            //Ако няма намерен запис търсим по Id и визуализираме на екрана
            if (string.IsNullOrEmpty(txt2.Text))
            {
                Fruit findedFruit = fruitController.Get(findId);
                if (findedFruit == null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                    txt1.BackColor = Color.Red;
                    txt1.Focus();
                    return;
                }
                LoadRecord(findedFruit);
            }
            else //Ако има намерен вече запис променяме по полетата
            {
                Fruit updatedFruit = new Fruit();
                updatedFruit.Name = txt2.Text;
                updatedFruit.Description = txt3.Text;
                updatedFruit.FruitTypeId = (int)cmb1.SelectedValue;

                fruitController.Update(findId, updatedFruit);
            }

            btn5_Click(sender, e);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txt1.Text) || !txt1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txt1.Text);
            }
            Fruit findedFruit = fruitController.Get(findId);
            if (findedFruit== null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            LoadRecord(findedFruit);

            DialogResult answer = MessageBox.Show("Наистина ли искате да изтриете запис No " +
            findId + " ?",
             "PROMPT", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                fruitController.Delete(findId);
            }

            //btn5_Click(sender, e);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
