using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ClothingStore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void DisplayDataGrid()
        {
            dataGridView.Rows.Clear();
            dataGridView.ColumnCount = 12;
            dataGridView.Columns[0].HeaderText = "Название";
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[1].HeaderText = "Товарная группа";
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[2].HeaderText = "Тип";
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[3].HeaderText = "Семейство";
            dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[4].HeaderText = "Цвет";
            dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[5].HeaderText = "Материал";
            dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[6].HeaderText = "Количество";
            dataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[7].HeaderText = "Цена";
            dataGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[8].HeaderText = "Производитель";
            dataGridView.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[9].HeaderText = "Страна призводителя";
            dataGridView.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[10].HeaderText = "Материал подошвы";
            dataGridView.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[11].HeaderText = "Высота подошвы";
            dataGridView.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.AutoResizeColumns();
        }

        public void ShowAll()
        {
            DisplayDataGrid();
            for (int i = 0; i < Data.lProduct.Count; i++)
            {
                object[] a = Data.lProduct[i].Show();
                dataGridView.Rows.Add(a);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.ShowDialog();
            ShowAll();
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            ShowAll();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DisplayDataGrid();
            string k = textBoxSearch.Text.ToLower();
            Data.lProduct.ForEach(x =>
            {
                if (x.Kind.ToLower().Contains(k))
                {
                    object[] a = x.Show();
                    dataGridView.Rows.Add(a);
                }
            }
            );
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayDataGrid();
                List<Product> LA = new List<Product>();
                if (radioButtonName.Checked == true)
                {
                    //Сортировка по названию
                    LA = Data.lProduct.OrderBy(k => k.Name).ToList();
                    for (int i = 0; i < LA.Count; i++)
                    {
                        object[] a = LA[i].Show();
                        dataGridView.Rows.Add(a);
                    }
                }
                if (radioButtonPrice.Checked == true)
                {
                    //Сортировка по цене
                    LA = Data.lProduct.OrderBy(k => k.Price).ToList();
                    for (int i = 0; i < LA.Count; i++)
                    {
                        object[] a = LA[i].Show();
                        dataGridView.Rows.Add(a);
                    }
                }
                if (radioButtonGroup.Checked == true)
                {
                    //Сортировка по группе
                    LA = Data.lProduct.OrderBy(k => k.Group).ToList();
                    for (int i = 0; i < LA.Count; i++)
                    {
                        object[] a = LA[i].Show();
                        dataGridView.Rows.Add(a);
                    }
                }
            }
            catch { MessageBox.Show("Выберите параметр сортировки!"); }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var n = dataGridView.CurrentCell.Value.ToString();
                var a = Data.lProduct.Find(x => x.Name == n);
                Data.lProduct.Remove(a);
                ShowAll();
            }
            //В случае ошибки, оповещаем пользователя
            catch { MessageBox.Show("Выберите запись из списка!"); }
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            try
            {
                //Считываем имя у выделенной строки
                var n = dataGridView.CurrentCell.Value.ToString();
                Data.lProduct.ForEach(x =>
                { 
                    if (x.Name == n)
                    {
                        x.Count++;
                    }
                });
                DisplayDataGrid();
                ShowAll();
            }
            //В случае ошибки, оповещаем пользователя
            catch { MessageBox.Show("Выберите запись из списка!"); }
        }

        private void buttonSell_Click(object sender, EventArgs e)
        { 
            try
            {
                //Считываем имя у выделенной строки
                var n = dataGridView.CurrentCell.Value.ToString();
                Data.lProduct.ForEach(x =>
                {
                    if (x.Name == n)
                    {
                        if (x.Count > 0)
                        {
                            x.Count--;
                        }
                    }
                });
                DisplayDataGrid();
                ShowAll();
            }
            //В случае ошибки, оповещаем пользователя
            catch { MessageBox.Show("Выберите запись из списка!"); }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            try
            {
                //Считываем имя у выделенной строки
                var n = dataGridView.CurrentCell.Value.ToString();
                object[] a = Data.lProduct.Find(x => x.Name == n).Show();
                ChangeForm changeForm = new ChangeForm(a);
                changeForm.ShowDialog();
                ShowAll();
            }
            //В случае ошибки, оповещаем пользователя
            catch { MessageBox.Show("Выберите запись из списка!"); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("DB.data"))
            {
                var items = File.ReadAllLines("DB.data");
                

                foreach (var a in items)
                {
                    string[] item = a.Split(';');
                    switch (item[1].ToString())
                    {
                        case "Одежда":
                            Data.lProduct.Add(new Clothes(item[0], item[1], item[2], item[3], item[4], item[5], int.Parse(item[6]), double.Parse(item[7]), item[8], item[9]));
                            break;

                        case "Обувь":
                            Data.lProduct.Add(new Shoes(item[0], item[1], item[2], item[3], item[4], item[5], int.Parse(item[6]), double.Parse(item[7]), item[8], item[9], item[10], int.Parse(item[11])));
                            break;

                        case "Аксессуары":
                            Data.lProduct.Add(new Accessories(item[0], item[1], item[2], item[3], item[4], item[5], int.Parse(item[6]), double.Parse(item[7]), item[8], item[9]));
                            break;

                        default:
                            break;
                    }
                }
            }
            ShowAll();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText("DB.data", "");
            for (int i = 0; i < Data.lProduct.Count; i++)
            {
                object[] a = Data.lProduct[i].Show();
                if (a[1].ToString() == "Одежда")
                {
                    File.AppendAllText("DB.data", string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}\n", a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9]));
                }
                else if (a[1].ToString() == "Аксессуары")
                {
                    File.AppendAllText("DB.data", string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}\n", a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9]));
                }
                else if (a[1].ToString() == "Обувь")
                {
                    File.AppendAllText("DB.data", string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11}\n", a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11]));
                }
            }
        }
    }
}
