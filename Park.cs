using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking
{
    public partial class Park : Form
    {
        Functions Con;

        public Park()
        {
            InitializeComponent();
            Con = new Functions();
            GetCars();
            GetPlaces();
            ShowBooking();
        }

        private void GetCars()
        {
            string Query = "select * from CarsTbl";
            CarsCb.ValueMember = Con.GetData(Query).Columns["CNum"].ToString();
            CarsCb.DisplayMember = Con.GetData(Query).Columns["PNumber"].ToString();
            CarsCb.DataSource = Con.GetData(Query);
        }

        private void GetPlaces()
        {
            string PSt = "Free";
            string Query = "select * from PlaceTbl where PStatus = '{0}'";
            Query = string.Format(Query, PSt);
            PlaceCb.ValueMember = Con.GetData(Query).Columns["PlNum"].ToString();
            PlaceCb.DisplayMember = Con.GetData(Query).Columns["Pposition"].ToString();
            PlaceCb.DataSource = Con.GetData(Query);
        }

        private void ShowBooking()
        {
            string Query = "select * from ParkingTbl";
            ParkingDGV.DataSource = Con.GetData(Query);
        }

        private void UpdateStatus()
        {
            try
            {
                string PSt = "Booked";
                string Place = PlaceCb.SelectedValue.ToString();
                string Query = "update PlaceTbl set PStatus = '{0}' where PlNum = {1})";
                Query = string.Format(Query, PSt, Place);
                Con.SetData(Query);
                MessageBox.Show("Place Updated!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BookBtn_Click(object sender, EventArgs e)
        {
            if (CarsCb.SelectedIndex == -1 || PlaceCb.SelectedIndex == -1 || AmoutTb.Text == "" || DurationTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Car = CarsCb.SelectedValue.ToString();
                    string Duration = DurationTb.Text;
                    int Amount = Convert.ToInt32(AmoutTb.Text);
                    string Place = PlaceCb.SelectedValue.ToString();
                    string Query = "insert into ParkkingTbl values('{1}','{2}',{3},{4},'{5}')";
                    Query = string.Format(Query, Car, DateTime.Today.ToString(), Duration, Amount, Place);
                    Con.SetData(Query);
                    MessageBox.Show("Place Booked!!!");
                    ShowBooking();
                    UpdateStatus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void PictureCars_Click(object sender, EventArgs e)
        {
            Cars obj = new Cars();
            obj.Show();
            Hide();
        }

        private void PicturePlaces_Click(object sender, EventArgs e)
        {
            Places obj = new Places();
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
