using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.PropertyGridInternal;

namespace Dinner
{
    public partial class Form1 : Form
    {

        List<string> listFlowers;
        Dictionary<string, List<string>> bouquetsList;
        public Form1()
        {
            InitializeComponent();

            listFlowers = new List<string>() 
            {
                "Лилии", "Гладиолусы", "Гипсофила", "Орхидеи", "Эустомы", "Хризантемы", "Кустовые розы", "Гортензии",
                            "Пионы", "Нарциссы", "Герберы"
            };

            bouquetsList = new Dictionary<string, List<string>>()
            {
                {
                    "1 сентября", new List<string>()
                        {
                            "Лилии", "Гладиолусы", "Гипсофила"
                        }
                },
                {
                    "Первое свидание", new List<string>()
                    {
                        "Орхидеи"
                    }
                },
                {
                    "Деловая встреча", new List<string>()
                    {
                        "Эустомы", "Хризантемы", "Кустовые розы"
                    }
                },
                {
                    "Букет невесты", new List<string>()
                    {
                        "Хризантемы", "Гортензии"
                    }
                },
                {
                    "Для женщин старшего возраста", new List<string>()
                    {
                        "Пионы", "Нарциссы", "Герберы"
                    }
                }
            };

            listFlowers.Sort();

            foreach(var item in bouquetsList)
            {
                item.Value.Sort();
            }

            for (int i = 0; i < listFlowers.Count; i++)
            {
                checkedListBox_flowers.Items.Add(listFlowers[i]);
            }

            foreach(var item in bouquetsList)
            {
                listBoxD_flowers.Items.Add(item.Key);
            }
        }

        private void button_showBouquets_Click(object sender, EventArgs e)
        {
            listBox_bouquets.Items.Clear();
            
            List<string> tempDish = new List<string>();           

            foreach (var element in bouquetsList)
            {
                bool flag = true;
                foreach(var item in checkedListBox_flowers.CheckedItems)
                {
                    if (element.Value.IndexOf(item.ToString()) == -1)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    tempDish.Add(element.Key);
                }
                
            }

            tempDish.Sort();

            foreach (var item in tempDish)
            {
                listBox_bouquets.Items.Add(item);
            }
        }

        private void listBoxD_dish_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewD_bouquets.Items.Clear();
            foreach (var item in bouquetsList)
            {
                if(listBoxD_flowers.SelectedItem == item.Key)
                {
                    foreach(var element in bouquetsList[item.Key])
                    {                        
                        listViewD_bouquets.Items.Add(element);
                    }
                }
            }
            
        }
    }
}

