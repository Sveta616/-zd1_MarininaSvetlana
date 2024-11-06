using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Zadanie2
{
   
    public partial class Form1 : Form
    {

        private Shop shop;
        public Form1()
        {
            shop = new Shop();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button3.Visible = false;
        }
        //Shop
        //Добавление продукта и проверка на буквы
        private void AddProduct_Click(object sender, EventArgs e)
        {

            if (textBox1.Text=="")
            {
                MessageBox.Show("Введите название продукта");
                return;


            }
            string name = textBox1.Text;
            bool onlyLetters = true;
            foreach (var ch in name)
            {
                if (!char.IsLetter(ch))
                {
                    onlyLetters = false;
                    break; 
                }
            }

            if (!onlyLetters)
            {
                MessageBox.Show("Можно использовать только буквы без пробелов");
                return;


            }

            
            name = char.ToUpper(name[0]) + name.Substring(1).ToLower();

            double price = Convert.ToDouble(numericUpDown1.Value);
            int quantity = Convert.ToInt32(numericUpDown2.Value);
            shop.CreateProduct(name, price, quantity);
            shop.WriteAllProducts();
            UpdateList();
        }
        //добавление списка наименования продукта в checkedListBox1
        private void UpdateList()
        {
            checkedListBox1.Items.Clear();
            foreach (var product in shop.GetAllProducts())
            {
                checkedListBox1.Items.Add(product.Name);
            }
        }
        //Продажа продукта
        private void SellProduct_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            int quantity = Convert.ToInt32(numericUpDown2.Value);
            foreach (var item in checkedListBox1.CheckedItems)
            {
                string productName = item.ToString();
                shop.Sell(productName, quantity);
            }
        }
        //Удаление продукта по наименованию
        private void DeleteProduct_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox1.CheckedItems)
            {
                string productName = item.ToString();
                shop.Delete(productName);
            }
            UpdateList();
        }



        //Playlist
        Playlist playlist = new Playlist();
        Song song = new Song();

        //Обновляет данные о текущей песне
        private void UpdateSong()
        {
            song = playlist.CurrentSong();
            Author.Text = song.Author;
            SongName.Text = song.Title;
            FileName.Text = song.Filename;
        }
        //Вернуться на прошлый трек
        private void BackSong_Click_1(object sender, EventArgs e)
        {
            playlist.BackSong();
            song = playlist.CurrentSong();
            Author.Text = song.Author;
            SongName.Text = song.Title;
            FileName.Text = song.Filename;
        }
        //Перейти на следующий трек
        private void NextSong_Click_1(object sender, EventArgs e)
        {
            playlist.NextSong();
            song = playlist.CurrentSong();
            Author.Text = song.Author;
            SongName.Text = song.Title;
            FileName.Text = song.Filename;
        }
        //Добавить новую песню
        private void AddNewSong_Click_1(object sender, EventArgs e)
        {
            string author, name, filename;
            author = AuthorText.Text;
            name = Nametext.Text;
            filename = Path.Text;

            
            if (string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(filename))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            if (author.Length == 0 || !char.IsUpper(author[0]))
            {
                MessageBox.Show("Автор должен начинаться с заглавной буквы");
                return;
            }
            for (int i = 1; i < author.Length; i++)
            {
                if (!char.IsLower(author[i]))
                {
                    MessageBox.Show("Автор должен содержать только буквы, начиная с заглавной");
                    return;
                }
            }


            if (name.Length == 0 || !char.IsUpper(name[0]))
            {
                MessageBox.Show("Название песни должно начинаться с заглавной буквы");
                return;
            }
            for (int i = 1; i < name.Length; i++)
            {
                if (!char.IsLower(name[i]))
                {
                    MessageBox.Show("Название песни должно содержать только буквы, начиная с заглавной");
                    return;
                }
            }


            if (string.IsNullOrWhiteSpace(filename) || string.IsNullOrWhiteSpace(filename) || string.IsNullOrEmpty(filename))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            if (filename.Length == 0 || !char.IsUpper(filename[0]))
            {
                MessageBox.Show("Автор должен начинаться с заглавной буквы");
                return;
            }
            for (int i = 1; i < filename.Length; i++)
            {
                if (!char.IsLower(filename[i]))
                {
                    MessageBox.Show("Автор должен содержать только буквы, начиная с заглавной");
                    return;
                }
            }


            playlist.AddSong(author, name, filename);
            AuthorText.ResetText();
            Nametext.ResetText();
            Path.ResetText();
            Author.Text = author;
            SongName.Text = name;
            FileName.Text = filename;
            MessageBox.Show("Песня добавлена!");
        }

        //Удалить определенный индекс 
        private void DeleteIndex_Click_1(object sender, EventArgs e)
        {
            playlist.RemoveSong(Convert.ToInt32(DelIndex.Value));
            UpdateSong();
        }
        //Очистить лист
        private void PlaylistClear_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Продолжить?", "Подтверждение", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Плейлист удален");
                playlist.Clear();
                Author.Text = " ";
                SongName.Text = " ";
                FileName.Text = " ";

            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Операция отменена");
            }
        }
        //Перейти на определенный индекс
        private void GoIndex_Click_1(object sender, EventArgs e)
        {
            playlist.GoIndex(Convert.ToInt32(SongIndex.Value));
            UpdateSong();
        }
        //Перейти в начало плейлиста
        private void GoStart_Click_1(object sender, EventArgs e)
        {
            playlist.GoStart();
            UpdateSong();

        }
        //Удалить объект в плейлисте
        private void DeleteZnClick_1(object sender, EventArgs e)
        {
            string author, name, filename;
            author = AuthorDel.Text;
            name = NameDel.Text;
            filename = PathDel.Text;


            if (string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(filename))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            if (author.Length == 0 || !char.IsUpper(author[0]))
            {
                MessageBox.Show("Автор должен начинаться с заглавной буквы");
                return;
            }
            for (int i = 1; i < author.Length; i++)
            {
                if (!char.IsLower(author[i]))
                {
                    MessageBox.Show("Автор должен содержать только буквы, начиная с заглавной");
                    return;
                }
            }


            if (name.Length == 0 || !char.IsUpper(name[0]))
            {
                MessageBox.Show("Название песни должно начинаться с заглавной буквы");
                return;
            }
            for (int i = 1; i < name.Length; i++)
            {
                if (!char.IsLower(name[i]))
                {
                    MessageBox.Show("Название песни должно содержать только буквы, начиная с заглавной");
                    return;
                }
            }


            if (string.IsNullOrWhiteSpace(filename) || string.IsNullOrWhiteSpace(filename) || string.IsNullOrEmpty(filename))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            if (filename.Length == 0 || !char.IsUpper(filename[0]))
            {
                MessageBox.Show("Автор должен начинаться с заглавной буквы");
                return;
            }
            for (int i = 1; i < filename.Length; i++)
            {
                if (!char.IsLower(filename[i]))
                {
                    MessageBox.Show("Автор должен содержать только буквы, начиная с заглавной");
                    return;
                }
            }

            playlist.RemoveSong(song);
            UpdateSong();
        }
    }

}

       
    


