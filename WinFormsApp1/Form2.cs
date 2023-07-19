using Microsoft.EntityFrameworkCore;
using WinFormsApp1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using WinFormsApp1;

namespace AssigmentPRN211
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            DGV_Load(0,"");
        }

        public void getCategoriesCombox1()
        {
            var context = new Prn211Context();
            context.Categories.Load<Category>();
            List<Category> categories = context.Categories.Local.ToList();
            Category category = new Category();
            category.Id = 0;
            category.Name = "All Category";
            categories.Add(category);
            categories.Sort((c1, c2) => c1.Id.CompareTo(c2.Id));
            cb_CategoryName.DataSource = categories;
            cb_CategoryName.DisplayMember = "Name";
            cb_CategoryName.ValueMember = "Id";
            cb_CategoryName.SelectedIndex = 0;
        }
        public void getCategoriesCombox2()
        {
            var context = new Prn211Context();
            context.Categories.Load<Category>();
            List<Category> categories = context.Categories.Local.ToList();
            Category category = new Category();
            categories.Add(category);
            categories.Sort((c1, c2) => c1.Id.CompareTo(c2.Id));
            cb_category.DataSource = categories;
            cb_category.DisplayMember = "Name";
            cb_category.ValueMember = "Id";
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            getCategoriesCombox1();
            getCategoriesCombox2();
        }
        public void DGV_Load(int category, string bookname)
        {
            var context = new Prn211Context();
            var query = from b in context.Books
                        join c in context.Categories on b.Cateid equals c.Id
                        select new
                        {
                            BookId = b.Id,
                            BookName = b.Name,
                            CategoryId = c.Id,
                            CategoryName = c.Name,
                            Price = b.Priceperunit,
                            Stock = b.Unit
                        };
            if (category != 0)
            {
                query = query.Where(x => x.CategoryId.Equals(category));
            }
            if(bookname != null)
            {
                query = query.Where(x => x.BookName.Contains(bookname));
            }
            var order = query.ToList();
            dataGridView1.DataSource = order;
            dataGridView1.Columns["BookId"].Visible = false;
            dataGridView1.Columns["CategoryId"].Visible = false;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            int category = Convert.ToInt32(cb_CategoryName.SelectedValue);
            string name = cb_SearchByName.Text;
            DGV_Load(category, name);
        }

        private void cb_CategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                cb_BookId.Text = dataGridView1.Rows[e.RowIndex].Cells["BookId"].FormattedValue.ToString();
                cb_bookName.Text = dataGridView1.Rows[e.RowIndex].Cells["BookName"].FormattedValue.ToString();
                cb_category.Text = dataGridView1.Rows[e.RowIndex].Cells["CategoryName"].FormattedValue.ToString();
                cb_price.Text = dataGridView1.Rows[e.RowIndex].Cells["Price"].FormattedValue.ToString();
                cb_stock.Text = dataGridView1.Rows[e.RowIndex].Cells["Stock"].FormattedValue.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string bname = cb_bookName.Text;
            int category = Convert.ToInt32(cb_category.SelectedValue);
            double price = Convert.ToDouble(cb_price.Text);
            int stock = Convert.ToInt32(cb_stock.Text);
            Book b = new Book();
            b.Name = bname;
            b.Cateid = category;
            b.Priceperunit = price;
            b.Unit = stock;
            var context = new Prn211Context();
            context.Books.Add(b);
            if (context.SaveChanges() > 0)
                MessageBox.Show("New Book added successfully!");
            DGV_Load(0, "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int bid = Convert.ToInt32(cb_BookId.Text);
            string bname = cb_bookName.Text;
            int category = Convert.ToInt32(cb_category.SelectedValue);
            double price = Convert.ToDouble(cb_price.Text);
            int stock = Convert.ToInt32(cb_stock.Text);
            Book b = new Book();
            b.Id = bid;
            b.Name = bname;
            b.Cateid = category;
            b.Priceperunit = price;
            b.Unit = stock;
            var context = new Prn211Context();
            if(bid == b.Id)
            {
                context.Books.Update(b);
            }
            if (context.SaveChanges() > 0)
                MessageBox.Show("Book updated successfully!");
            DGV_Load(0, "");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int bid = Convert.ToInt32(cb_BookId.Text);
            Book b = new Book();
            b.Id = bid;
            var context = new Prn211Context();
            if (bid == b.Id)
            {
                context.Books.Remove(b);
            }
            if (context.SaveChanges() > 0)
                MessageBox.Show("Book delete successfully!");
            DGV_Load(0, "");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cb_BookId.Text = String.Empty;
            cb_bookName.Text = String.Empty;
            cb_category.Text = String.Empty;
            cb_price.Text = String.Empty;
            cb_stock.Text = String.Empty;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 newpage = new Form3();
            newpage.Closed += (s, args) => this.Close();
            newpage.Show();
        }
    }
}
