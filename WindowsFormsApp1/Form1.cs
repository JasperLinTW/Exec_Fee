using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{/// <summary>
/// 根據客戶性別及年齡計算應付車資, 規則如下:
/// - <=3 零元
/// - >=70, 男, 2元
/// - >=60, 女, 3元
/// - 全票, 15元
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            int age;
            try
            {
                age = GetAge();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            bool gender;
            try
            {
                gender = GetGender();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            string[] result = Calculate(age , gender);

            FeeLable.Text = $"車資: {result[0]}元";
            reasonLable.Text = $"原因: {result[1]}";
        }

        private string[] Calculate(int age, bool gender)
        {
            int fee;
            string reason = string.Empty;
            if (age <= 3){fee = 0; reason = "年齡小於等於3歲"; }
            else if (age >= 70 && gender) { fee = 2; reason ="年齡大於七十歲男性"; }
            else if (age >= 60 && !gender ) { fee = 3; reason = "年齡大於六十歲女性"; }
            else { fee = 15; reason = "您屬於全票範圍"; }
            string feeResult = fee.ToString();
            string[] result = new string[] {feeResult, reason};
            return result;
            
        }

        private bool GetGender()
        {
            if (maleRadioButton.Checked) { return true; }
            else if(FemaleRadioButton.Checked) { return false; }
            else { throw new Exception("您未選取性別"); }
        }

        private int GetAge()
        {
            string input = ageTxtBox.Text;
            bool isInt = int.TryParse(input, out int age);
            return isInt ? age : throw new Exception("您輸入的年齡格式不正確");

        }
    }
}
