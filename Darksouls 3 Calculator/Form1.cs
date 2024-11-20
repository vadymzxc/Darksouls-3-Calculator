using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace Darksouls_3_Calculator
{

    public partial class Form1 : Form
    {
        private List<Weapon> weapons;
        private readonly List<string> allowedCategories = new List<string>
        {
            "Мечі", "Двуручні мечі", "Списи", "Ізогнуті мечі", "Катани"
        };

        public Form1()
        {
            InitializeComponent();
            InitializeWeapons();
            PopulateCategories();

            // За замовчуванням вибираємо першу категорію
            comboBox1.SelectedIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }

       

        private void PopulateCategories()
        {
            // Заповнюємо випадаючий список категорій
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(allowedCategories.ToArray());
        }

        private void PopulateWeaponList()
        {
            // Отримуємо вибрану категорію з comboBox1
            string selectedCategory = comboBox1.SelectedItem.ToString();

            // Очищаємо список зброї
            listBox1.Items.Clear();

            // Фільтруємо зброю по категорії
            var filteredWeapons = weapons.Where(w => w.Category == selectedCategory).ToList();

            // Додаємо назви зброї в ListBox
            foreach (var weapon in filteredWeapons)
            {
                listBox1.Items.Add(weapon.Name);  // Додаємо тільки назви зброї
            }
        }



        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Отримуємо обрану зброю з ListBox
            var selectedWeapon = weapons.FirstOrDefault(w => w.Name == listBox1.SelectedItem?.ToString());

            if (selectedWeapon == null)
            {
                label7.Text = "Загальний урон: 0";
                return;
            }

            // Перевіряємо і конвертуємо введення атрибутів
            int strength = string.IsNullOrWhiteSpace(textBox1.Text) ? 0 : int.Parse(textBox1.Text);
            int dexterity = string.IsNullOrWhiteSpace(textBox2.Text) ? 0 : int.Parse(textBox2.Text);
            int intelligence = string.IsNullOrWhiteSpace(textBox3.Text) ? 0 : int.Parse(textBox3.Text);
            int faith = string.IsNullOrWhiteSpace(textBox4.Text) ? 0 : int.Parse(textBox4.Text);

            // Обчислення загального урону
            double totalDamage = selectedWeapon.BaseDamage +
                (strength * selectedWeapon.StrengthScaling) +
                (dexterity * selectedWeapon.DexterityScaling) +
                (intelligence * selectedWeapon.IntelligenceScaling) +
                (faith * selectedWeapon.FaithScaling);

            // Виведення результату
            label7.Text = $"Загальний урон: {totalDamage:F2}";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // При зміні категорії викликаємо метод для заповнення ListBox
            PopulateWeaponList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                // Получаем выбранное оружие
                var selectedWeapon = weapons.FirstOrDefault(w => w.Name == listBox1.SelectedItem?.ToString());

                if (selectedWeapon != null && !string.IsNullOrEmpty(selectedWeapon.ImagePath))
                {
                    try
                    {
                        // Устанавливаем изображение в PictureBox
                        pictureBox1.Image = System.Drawing.Image.FromFile(selectedWeapon.ImagePath);
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show($"Файл изображения не найден: {selectedWeapon.ImagePath}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pictureBox1.Image = null; // Убираем изображение, если файл не найден
                    }
                }
                else
                {
                    pictureBox1.Image = null; // Убираем изображение, если ничего не выбрано
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void InitializeWeapons()
        {
            // Список зброї визначається тут
            weapons = new List<Weapon>
            {

                //Мечі-----------------------------------------------------------------------------------

                new Weapon
                {
                    Category = "Мечі",
                    Name = "Довгий меч",
                    BaseDamage = 100,
                    StrengthScaling = 1.2,
                    DexterityScaling = 0.8,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/longsword-transformed.png"
                },                                           
                new Weapon
                {
                    Category = "Мечі",
                    Name = "Асторський меч",
                    BaseDamage = 129,
                    StrengthScaling = 0.5,
                    DexterityScaling = 0.25,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/astora_straight_sword.png"
                },
                new Weapon
                {
                    Category = "Мечі",
                    Name = "Ірітіллсьий меч",
                    BaseDamage = 124,
                    StrengthScaling = 0.5,
                    DexterityScaling = 0.5,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/IrithyllStraightSword.png"
                },
                new Weapon
                {
                    Category = "Мечі",
                    Name = "Канделябр клірика",
                    BaseDamage = 140,
                    StrengthScaling = 0.5,
                    DexterityScaling = 0.5,
                    IntelligenceScaling = 0,
                    FaithScaling = 0.75,
                    ImagePath = "images/cleric_s_candlestick_1.png"
                },               
                new Weapon
                {
                    Category = "Мечі",
                    Name = "Палаш",
                    BaseDamage = 117,
                    StrengthScaling = 0.99,
                    DexterityScaling = 0.65,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/broadsword_(1)-transformed.png"
                },
                new Weapon
                {
                    Category = "Мечі",
                    Name = "лицарський меч Лотріка",
                    BaseDamage = 103,
                    StrengthScaling = 0.75,
                    DexterityScaling = 0.75,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/lothric_knight_sword.png"
                },               
                new Weapon
                {
                    Category = "Мечі",
                    Name = "Меч тьми",
                    BaseDamage = 110,
                    StrengthScaling = 0.95,
                    DexterityScaling = 0.5,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/dark_sword_1.png"
                },
                new Weapon
                {
                    Category = "Мечі",
                    Name = "Меч Анрі",
                    BaseDamage = 117,
                    StrengthScaling = 0.74,
                    DexterityScaling = 0.3,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/anris_straight_sword.png"
                },
                new Weapon
                {
                    Category = "Мечі",
                    Name = "Моріонний меч",
                    BaseDamage = 131,
                    StrengthScaling = 0.74,
                    DexterityScaling = 0.74,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/morion_blade.png"
                },
                new Weapon
                {
                    Category = "Мечі",
                    Name = "Хоробре сердце",
                    BaseDamage = 120,
                    StrengthScaling = 0.72,
                    DexterityScaling = 0.68,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/valorheart_-_final.png"
                },

                //Двуручні мечі--------------------------------------------------------------------------

                new Weapon
                {
                    Category = "Двуручні мечі",
                    Name = "Клеймор",
                    BaseDamage = 150,
                    StrengthScaling = 1.4,
                    DexterityScaling = 1.0,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/claymore.png"
                },
                new Weapon
                {
                    Category = "Двуручні мечі",
                    Name = "Великий меч вогня",
                    BaseDamage = 128,
                    StrengthScaling = 0.75,
                    DexterityScaling = 0.67,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/firelink_greatsword.png"
                },
                new Weapon
                {
                    Category = "Двуручні мечі",
                    Name = "Фламеберг",
                    BaseDamage = 158,
                    StrengthScaling = 0.73,
                    DexterityScaling = 0.65,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/flameberge.png"
                },
                new Weapon
                {
                    Category = "Двуручні мечі",
                    Name = "Меч місячного сяйва",
                    BaseDamage = 200,
                    StrengthScaling = 0.24,
                    DexterityScaling = 0,
                    IntelligenceScaling = 0.99,
                    FaithScaling = 0,
                    ImagePath = "images/moonlight_greatsword.png"
                },
                new Weapon
                {
                    Category = "Двуручні мечі",
                    Name = "Великий меч Гаеля",
                    BaseDamage = 147,
                    StrengthScaling = 0.99,
                    DexterityScaling = 0.57,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/gael's_greatsword.png"
                },
                new Weapon
                {
                    Category = "Двуручні мечі",
                    Name = "Оніксовие лезо ",
                    BaseDamage = 80,
                    StrengthScaling = 0.35,
                    DexterityScaling = 0.39,
                    IntelligenceScaling = 0.49,
                    FaithScaling = 0.56,
                    ImagePath = "images/onyx_blade_-_final.png"
                },
                new Weapon
                {
                    Category = "Двуручні мечі",
                    Name = "Священний меч Вольніра",
                    BaseDamage = 151,
                    StrengthScaling = 0.73,
                    DexterityScaling = 0.71,
                    IntelligenceScaling = 0,
                    FaithScaling = 0.64,
                    ImagePath = "images/wolnirs_holy_sword.png"
                },
                new Weapon
                {
                    Category = "Двуручні мечі",
                    Name = "Великий меч принців-близнюків",
                    BaseDamage = 200,
                    StrengthScaling = 0.28,
                    DexterityScaling = 0.43,
                    IntelligenceScaling = 0,
                    FaithScaling = 0.2,
                    ImagePath = "images/twin_princess_greatsword1.png"
                },
                new Weapon
                {
                    Category = "Двуручні мечі",
                    Name = "Меч крові дракона",
                    BaseDamage = 224,
                    StrengthScaling = 0.35,
                    DexterityScaling = 0.39,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/drakeblood_greatsword.png"
                },
                new Weapon
                {
                    Category = "Двуручні мечі",
                    Name = "Правитель бурі",
                    BaseDamage = 143,
                    StrengthScaling = 0.33,
                    DexterityScaling = 0.36,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/storm_ruler.png"
                },
                new Weapon
                {
                    Category = "Двуручні мечі",
                    Name = "Меч правосуддя",
                    BaseDamage = 198,
                    StrengthScaling = 0.43,
                    DexterityScaling = 0.45,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/greatsword_of_judgement.png"
                },
                new Weapon
                {
                    Category = "Двуручні мечі",
                    Name = "Меч лицаря-вовка",
                    BaseDamage = 139,
                    StrengthScaling = 0.87,
                    DexterityScaling = 0.68,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/wolf_knights_greatsword.png"
                },

                //Списи-----------------------------------------------------------------------------------

                new Weapon
                {
                    Category = "Списи",
                    Name = "Чотиризубий плуг",
                    BaseDamage = 105,
                    StrengthScaling = 0.68,
                    DexterityScaling = 0.73,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/four-pronged_plow.png"
                },
                new Weapon
                {
                    Category = "Списи",
                    Name = "Спис Йоршка",
                    BaseDamage = 102,
                    StrengthScaling = 0.64,
                    DexterityScaling = 0.62,
                    IntelligenceScaling = 0,
                    FaithScaling = 0.59,
                    ImagePath = "images/yorshkas_spear.png"
                },
                new Weapon
                {
                    Category = "Списи",
                    Name = "Двузубец святого",
                    BaseDamage = 98,
                    StrengthScaling = 0.74,
                    DexterityScaling = 0.34,
                    IntelligenceScaling = 0,
                    FaithScaling = 0.87,
                    ImagePath = "images/saint_bident.png"
                },
                new Weapon
                {
                    Category = "Списи",
                    Name = "Спис-меч драконоборця",
                    BaseDamage = 157,
                    StrengthScaling = 0.54,
                    DexterityScaling = 0.89,
                    IntelligenceScaling = 0,
                    FaithScaling = 0.99,
                    ImagePath = "images/dragonslayer_swordspear.png"
                },
                new Weapon
                {
                    Category = "Списи",
                    Name = "Золотий ритуальний спис",
                    BaseDamage = 147,
                    StrengthScaling = 0.29,
                    DexterityScaling = 0.74,
                    IntelligenceScaling = 0,
                    FaithScaling = 1.24,
                    ImagePath = "images/golden_ritual_spear.png"
                },
                new Weapon
                {
                    Category = "Списи",
                    Name = "Іржавий спис мозляку",
                    BaseDamage = 104,
                    StrengthScaling = 0.73,
                    DexterityScaling = 0.69,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/rotten_ghru_spear.png"
                },
                new Weapon
                {
                    Category = "Списи",
                    Name = "Спис вбивці драконів",
                    BaseDamage = 183,
                    StrengthScaling = 0.7,
                    DexterityScaling = 0.96,
                    IntelligenceScaling = 0,
                    FaithScaling = 0.64,
                    ImagePath = "images/dragonslayer_spear.png"
                },
                new Weapon
                {
                    Category = "Списи",
                    Name = "Партизан",
                    BaseDamage = 108,
                    StrengthScaling = 0.68,
                    DexterityScaling = 0.73,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/partizan.png"
                },
                new Weapon
                {
                    Category = "Списи",
                    Name = "Полум'яний спис горгульї",
                    BaseDamage = 193,
                    StrengthScaling = 0.45,
                    DexterityScaling = 0.67,
                    IntelligenceScaling = 0.38,
                    FaithScaling = 0.32,
                    ImagePath = "images/gargoyle_flame_spear.png"
                },
                new Weapon
                {
                    Category = "Списи",
                    Name = "Військовий прапор Лотрика",
                    BaseDamage = 100,
                    StrengthScaling = 0.74,
                    DexterityScaling = 0.69,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/lothric_war_banner.png"
                },
                new Weapon
                {
                    Category = "Списи",
                    Name = "Кільчастий лицарський спис",
                    BaseDamage = 126,
                    StrengthScaling = 0.64,
                    DexterityScaling = 0.61,
                    IntelligenceScaling = 0.47,
                    FaithScaling = 0.49,
                    ImagePath = "images/ds3_ringedknightspear.png"
                },

                //Ізогнуті мечі------------------------------------------------------------------------------

                new Weapon
                {
                    Category = "Ізогнуті мечі",
                    Name = "Серп Місяця",
                    BaseDamage = 120,
                    StrengthScaling = 0,
                    DexterityScaling = 0.99,
                    IntelligenceScaling = 0.5,
                    FaithScaling = 0,
                    ImagePath = "images/crescent_moon_sword.png"
                },
                new Weapon
                {
                    Category = "Ізогнуті мечі",
                    Name = "Шрам демона",
                    BaseDamage = 99,
                    StrengthScaling = 0,
                    DexterityScaling = 0.39,
                    IntelligenceScaling = 0.7,
                    FaithScaling = 0.63,
                    ImagePath = "images/demon's_scar.png"
                },
                new Weapon
                {
                    Category = "Ізогнуті мечі",
                    Name = "Шабля послідовника",
                    BaseDamage = 112,
                    StrengthScaling = 0.7,
                    DexterityScaling = 0.6,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/follower_sabre_-_final.png"
                },
                new Weapon
                {
                    Category = "Ізогнуті мечі",
                    Name = "Викривлений меч мозгляка",
                    BaseDamage = 103,
                    StrengthScaling = 0.34,
                    DexterityScaling = 0.87,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/rotten_ghru_curved_sword.png"
                },
                new Weapon
                {
                    Category = "Ізогнуті мечі",
                    Name = "Картуський Шотель",
                    BaseDamage = 106,
                    StrengthScaling = 0.27,
                    DexterityScaling = 0.92,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/carthus_shotel.png"
                },
                new Weapon
                {
                    Category = "Ізогнуті мечі",
                    Name = "Кривий меч Картуса",
                    BaseDamage = 105,
                    StrengthScaling = 0.7,
                    DexterityScaling = 0.7,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/carthus_curved_sword.png"
                },
                new Weapon
                {
                    Category = "Ізогнуті мечі",
                    Name = "Вигнутий клинок бурі",
                    BaseDamage = 110,
                    StrengthScaling = 0.74,
                    DexterityScaling = 0.84,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/storm_curved_sword.png"
                },
                new Weapon
                {
                    Category = "Ізогнуті мечі",
                    Name = "Зачаровані мечі танцівниці",
                    BaseDamage = 203,
                    StrengthScaling = 0.6,
                    DexterityScaling = 0.6,
                    IntelligenceScaling = 0.6,
                    FaithScaling = 0.6,
                    ImagePath = "images/dancers_enchanted_swords.png"
                },
                new Weapon
                {
                    Category = "Ізогнуті мечі",
                    Name = "Шабля сторожа картин",
                    BaseDamage = 88,
                    StrengthScaling = 0.29,
                    DexterityScaling = 0.57,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/painting_guardians_curved_sword.png"
                },
                new Weapon
                {
                    Category = "Ізогнуті мечі",
                    Name = "Клинки зберігача",
                    BaseDamage = 93,
                    StrengthScaling = 0.68,
                    DexterityScaling = 0.54,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/warden_twinblades.png"
                },
                new Weapon
                {
                    Category = "Ізогнуті мечі",
                    Name = "Шотель",
                    BaseDamage = 104,
                    StrengthScaling = 0.4,
                    DexterityScaling = 0.9,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/shotel.png"
                },
                new Weapon
                {
                    Category = "Ізогнуті мечі",
                    Name = "Скимитари найманця",
                    BaseDamage = 99,
                    StrengthScaling = 0.3,
                    DexterityScaling = 0.79,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/sellsword_twinblades.png"
                },

                //Катани-------------------------------------------------------------------------

                new Weapon
                {
                    Category = "Катани",
                    Name = "Потертий клинок",
                    BaseDamage = 140,
                    StrengthScaling = 0.4,
                    DexterityScaling = 1.24,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/frayed_blade.png"
                },    
                new Weapon
                {
                    Category = "Катани",
                    Name = "Жага крові",
                    BaseDamage = 105,
                    StrengthScaling = 0.49,
                    DexterityScaling = 0.9,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/bloodlust.png"
                },
                new Weapon
                {
                    Category = "Катани",
                    Name = "Клинок Хаосу",
                    BaseDamage = 103,
                    StrengthScaling = 0.34,
                    DexterityScaling = 1.47,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/chaos_blade.png"
                },
                new Weapon
                {
                    Category = "Катани",
                    Name = "Чорний клинок",
                    BaseDamage = 122,
                    StrengthScaling = 0.27,
                    DexterityScaling = 0.99,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/black_blade.png"
                },
                new Weapon
                {
                    Category = "Катани",
                    Name = "Онікірі та Убадачі",
                    BaseDamage = 104,
                    StrengthScaling = 0.7,
                    DexterityScaling = 0.9,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/onikiri_and_ubadachi.png"
                },
                new Weapon
                {
                    Category = "Катани",
                    Name = "Пральний полюс",
                    BaseDamage = 121,
                    StrengthScaling = 0.63,
                    DexterityScaling = 0.59,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/washing_pole.png"
                },
                new Weapon
                {
                    Category = "Катани",
                    Name = "Учігатана",
                    BaseDamage = 115,
                    StrengthScaling = 0.4,
                    DexterityScaling = 0.57,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/uchigatana.png"
                },
                new Weapon
                {
                    Category = "Катани",
                    Name = "Темна Течія",
                    BaseDamage = 134,
                    StrengthScaling = 0.37,
                    DexterityScaling = 0.71,
                    IntelligenceScaling = 0,
                    FaithScaling = 0,
                    ImagePath = "images/darkdrift.png"
                },
            };
        }
    }

}
