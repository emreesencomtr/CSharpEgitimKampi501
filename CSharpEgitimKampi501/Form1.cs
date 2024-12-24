using CSharpEgitimKampi501.Dtos;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi501
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Server=LAPTOP-83L42UFV\\SQLEXPRESS; initial Catalog=EgitimKampi501Db; integrated Security= true");
        private async void btnList_Click(object sender, EventArgs e)
        {
            string query = "Select * from TblProduct_";

            var values = await connection.QueryAsync<ResultProductDto>(query);

            dataGridView1.DataSource = values;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "insert into TblProduct_(ProductName,ProductStock,ProductPrice,ProductCategory) values (@productName,@productStock,@productPrice,@productCategory)";
            var parameters = new DynamicParameters();
            parameters.Add("@productName",txtProductName.Text);
            parameters.Add("@productStock",txtProductStock.Text);
            parameters.Add("@productPrice", txtProductStock.Text);
            parameters.Add("@productCategory", txtProductCategory.Text);
            await connection.ExecuteAsync(query, parameters);
            MessageBox.Show("Yeni Kitap Ekleme İşlemi Başarılı","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);  

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "Delete From TblProduct_ Where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId",txtProductId.Text);
            await connection.ExecuteAsync(query,parameters);
            MessageBox.Show("Kitap Silme İşleme Başarılı","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {

            string query = "Update TblProduct_ Set ProductName=@productName, ProductPrice=@productPrice,ProductStock=@productStock,ProductCategory=@productCategory Where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productName", txtProductName.Text);
            parameters.Add("@productStock", txtProductStock.Text);
            parameters.Add("@productPrice", txtProductPrice.Text);
            parameters.Add("@productCategory", txtProductCategory.Text);
            parameters.Add("@productId", txtProductId.Text);
            await connection.ExecuteAsync(query , parameters);
            MessageBox.Show("Kitap Güncelleme İşlemi Başarılı Bir Şekilde Yapıldı","Güncelleme",MessageBoxButtons.OK,MessageBoxIcon.Hand);

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string query1 = "Select Count(*) From TblProduct_";
            var productTotalCount = await connection.QueryFirstOrDefaultAsync<int>(query1);
            lblTotalProductCount.Text = productTotalCount.ToString();

            string query2 = "Select ProductName From TblProduct_ Where ProductPrice=(Select Max(ProductPrice) From TblProduct_)";
            var maxPriceProductName= await connection.QueryFirstOrDefaultAsync<string>(query2);
            lblMaxPriceProductName.Text= maxPriceProductName.ToString();

            string query3 = "Select Count(Distinct(ProductCategory)) From TblProduct_";
            var distinctProductCount= await connection.QueryFirstOrDefaultAsync<int>(query3);
            lblDistinctCategoryCount.Text = distinctProductCount.ToString();


        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
