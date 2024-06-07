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
    public partial class AddForm : Form
    {

        public AddForm()
        {
            InitializeComponent();

            //Заполняем ComboBox-ы значениями.
            comboBoxGroup.DataSource = new List<string>() { "Одежда", "Обувь", "Аксессуары" };
            comboBoxType.DataSource = new List<string>() { "Мужская", "Женская" };
        }

        private void comboBoxGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            //Ограничеваем поля, включаем элементы управления
            //исходя из выбранного типа
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

        private void AddForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Добавляем в зависимости от выбранной группы
                switch (comboBoxGroup.SelectedValue.ToString())
                {
                    case "Одежда":
                        //Добавляем в список новый объект класса Clothes
                        Data.lProduct.Add(new Clothes(textBoxName.Text, comboBoxGroup.Text, comboBoxType.Text,
                            comboBoxKind.Text,textBoxColor.Text,textBoxMaterial.Text,
                            int.Parse(textBoxCount.Text),double.Parse(textBoxPrice.Text),
                            textBoxBrand.Text, textBoxCountry.Text
                            ));                                                                                 
                        break;
                    case "Обувь":
                        //Добавляем в список новый объект класса Shoes
                        Data.lProduct.Add(new Shoes(textBoxName.Text,comboBoxGroup.Text,comboBoxType.Text,
                            comboBoxKind.Text,textBoxColor.Text, textBoxMaterial.Text, int.Parse(textBoxCount.Text),
                            double.Parse(textBoxPrice.Text), textBoxBrand.Text, textBoxCountry.Text,
                            textBoxSoleMaterial.Text,int.Parse(textBoxSoleHeight.Text)
                            ));
                        break;
                    case "Аксессуары":
                        //Добавляем в список новый объект класса Accessories
                        Data.lProduct.Add(new Accessories(textBoxName.Text, comboBoxGroup.Text, comboBoxType.Text,
                            comboBoxKind.Text, textBoxColor.Text, textBoxMaterial.Text,
                            int.Parse(textBoxCount.Text), double.Parse(textBoxPrice.Text),
                            textBoxBrand.Text, textBoxCountry.Text
                            ));
                        break;
                    default:
                        break;
                }
            }
            catch { MessageBox.Show("Неправильно заполнены поля!"); }
            Close();
        }
    }
}
