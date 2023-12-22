using System;
using System.Windows.Forms;

namespace Parking
{
    public partial class Cars : Form
    {
        Functions Con;

        public Cars()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCars();
        }

        private void ShowCars()
        {
            string Query = "select * from CarsTbl";
            CarsDGV.DataSource = Con.GetData(Query);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (PNumberTb.Text == "" || DriverTb.Text == "" || CarType.Text == "" || ColorTb.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string PNumber = PNumberTb.Text;
                    string Driver = DriverTb.Text;
                    string Gen = GenderCb.SelectedItem.ToString();
                    string CType = CarType.Text;
                    string Color = ColorTb.Text;
                    string Query = "insert into CarsTbl values('{0}','{1},'{2}','{3}','{4}')";
                    Query = string.Format(Query, PNumber, Driver, Gen, CType, Color);
                    Con.SetData(Query);
                    MessageBox.Show("Car Added!!!");
                    ShowCars();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        int Key = 0;
        private void CarsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PNumberTb.Text = CarsDGV.SelectedRows[0].Cells[1].Value.ToString();
            DriverTb.Text = CarsDGV.SelectedRows[0].Cells[2].Value.ToString();
            GenderCb.SelectedItem = CarsDGV.SelectedRows[0].Cells[3].Value.ToString();
            CarType.Text = CarsDGV.SelectedRows[0].Cells[4].Value.ToString();
            ColorTb.Text = CarsDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (PNumberTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CarsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (PNumberTb.Text == "" || DriverTb.Text == "" || CarType.Text == "" || ColorTb.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string PNumber = PNumberTb.Text;
                    string Driver = DriverTb.Text;
                    string Gen = GenderCb.SelectedItem.ToString();
                    string CType = CarType.Text;
                    string Color = ColorTb.Text;
                    string Query = "update CarsTbl set PNumber = '{0}', Driver = '{1}, Gender = '{2}', CarType'{3}', Color = '{4}' where CNum = {5}";
                    Query = string.Format(Query, PNumber, Driver, Gen, CType, Color, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Car Updated!!!");
                    ShowCars();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Car!!");
            }
            else
            {
                try
                {
                    string PNumber = PNumberTb.Text;
                    string Driver = DriverTb.Text;
                    string Gen = GenderCb.SelectedItem.ToString();
                    string CType = CarType.Text;
                    string Color = ColorTb.Text;
                    string Query = "delete from CarsTbl where CNum = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Car Deleted!!!");
                    ShowCars();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void PicturePlacesS_Click(object sender, EventArgs e)
        {
            Places obj = new Places();
            obj.Show();
            Hide();
        }

        private void PictureParkingS_Click(object sender, EventArgs e)
        {
            Park obj = new Park();
            obj.Show();
            Hide();
        }

        private void PictureLoginS_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            Hide();
        }
    }
}
