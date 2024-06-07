using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothingStore
{
    public partial class ChangeForm : Form
    {
        public ChangeForm()
        {
            InitializeComponent();
            //Заполняем ComboBox-ы значениями.
            comboBoxGroup.DataSource = new List<string>() { "Одежда", "Обувь", "Аксессуары" };
            comboBoxType.DataSource = new List<string>() { "Мужская", "Женская" };

        }
        string nameOld;

        //Перегружанем конструктор, передаем значения строки DataGrid
        //для дальнейшего изменения
        public ChangeForm(object[] a)
        {
            InitializeComponent();
            comboBoxGroup.DataSource = new List<string>() { "Одежда", "Обувь", "Аксессуары" };
            comboBoxType.DataSource = new List<string>() { "Мужская", "Женская" };
            textBoxName.Text = a[0].ToString();
            comboBoxGroup.Text = a[1].ToString();
            comboBoxType.Text = a[2].ToString();
            comboBoxKind.Text = a[3].ToString();
            textBoxColor.Text = a[4].ToString();
            textBoxMaterial.Text = a[5].ToString();
            textBoxCount.Text = a[6].ToString();
            textBoxPrice.Text = a[7].ToString();
            textBoxBrand.Text = a[8].ToString();
            textBoxCountry.Text = a[9].ToString();
            if (a[1].ToString() == "Обувь")
            {
                textBoxSoleMaterial.Text = a[10].ToString();
                textBoxSoleHeight.Text = a[11].ToString();
            }
            nameOld = a[0].ToString();

            switch (a[1])
            {
                case "Одежда":
                    comboBoxKind.DataSource = new List<string>() { "Брюки и Шорты", "Юбки", "Платья", "Пиджаки и желеты", "Рубашки", "Блузы", "Футболки", "Кофты", "Верхняя одежда", "Нижнее белье" };
                    comboBoxKind.Text = a[3].ToString();
                    break;
                case "Обувь":
                    comboBoxKind.DataSource = new List<string>() { "Кроссовки", "Туфли", "Сапоги", "Кеды", "Ботинки" };
                    comboBoxKind.Text = a[3].ToString();
                    break;
                case "Аксессуары":
                    comboBoxKind.DataSource = new List<string>() { "Шапки", "Шарфы", "Сумки", "Перчатки", "Рюкзаки" };
                    comboBoxKind.Text = a[3].ToString();
                    break;
                default:
                    break;
            }
        }

        private void comboBoxGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (comboBoxGroup.SelectedValue.ToString())
            {
                case "Одежда":
                    comboBoxKind.DataSource = new List<string>() { "Брюки и Шорты", "Юбки", "Платья", "Пиджаки и желеты", "Рубашки", "Блузы", "Футболки", "Кофты", "Верхняя одежда", "Нижнее белье" };
                    textBoxSoleHeight.Enabled = false;
                    textBoxSoleMaterial.Enabled = false;
                    break;
                case "Обувь":
                    comboBoxKind.DataSource = new List<string>() { "Кроссовки", "Туфли", "Сапоги", "Кеды", "Ботинки" };
                    textBoxSoleHeight.Enabled = true;
                    textBoxSoleMaterial.Enabled = true;
                    break;
                case "Аксессуары":
                    comboBoxKind.DataSource = new List<string>() { "Шапки", "Шарфы", "Сумки", "Перчатки", "Рюкзаки" };
                    textBoxSoleHeight.Enabled = false;
                    textBoxSoleMaterial.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            try
            {
                var a = Data.lProduct.Find(x => x.Name == nameOld);         
                Data.lProduct.Remove(a);
                //Добавляем в зависимости от выбранной группы
                switch (comboBoxGroup.SelectedValue.ToString())
                {
                    case "Одежда":
                        //Добавляем в список новый объект класса Clothes
                        Data.lProduct.Add(new Clothes(
                            textBoxName.Text,
                            comboBoxGroup.Text,
                            comboBoxType.Text,
                            comboBoxKind.Text,
                            textBoxColor.Text,
                            textBoxMaterial.Text,
                            int.Parse(textBoxCount.Text),
                            double.Parse(textBoxPrice.Text),
                            textBoxBrand.Text,
                            textBoxCountry.Text
                            ));
                        break;
                    case "Обувь":
                        //Добавляем в список новый объект класса Shoes
                        Data.lProduct.Add(new Shoes(
                            textBoxName.Text,
                            comboBoxGroup.Text,
                            comboBoxType.Text,
                            comboBoxKind.Text,
                            textBoxColor.Text,
                            textBoxMaterial.Text,
                            int.Parse(textBoxCount.Text),
                            double.Parse(textBoxPrice.Text),
                            textBoxBrand.Text,
                            textBoxCountry.Text,
                            textBoxSoleMaterial.Text,
                            int.Parse(textBoxSoleHeight.Text)
                            ));
                        break;
                    case "Аксессуары":
                        //Добавляем в список новый объект класса Accessories
                        Data.lProduct.Add(new Accessories(
                            textBoxName.Text,
                            comboBoxGroup.Text,
                            comboBoxType.Text,
                            comboBoxKind.Text,
                            textBoxColor.Text,
                            textBoxMaterial.Text,
                            int.Parse(textBoxCount.Text),
                            double.Parse(textBoxPrice.Text),
                            textBoxBrand.Text,
                            textBoxCountry.Text
                           ));
                        break;
                    default:
                        break;
                }
                Close();
            }
            catch { MessageBox.Show("Неправильно заполнены поля!"); }
        }
     }
}
