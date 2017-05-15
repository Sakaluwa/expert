using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Expert
{
    /// <summary>
    /// modify.xaml 的交互逻辑
    /// </summary>
    public partial class modify : Window
    {
        public modify()
        {
            InitializeComponent();
        }
        //清除性格类型中的推荐工作
        private void clear_typejob(object sender, RoutedEventArgs e)
        {
            textBoxr1.Clear();
            textBoxr2.Clear();
            textBoxr3.Clear();
            textBoxi1.Clear();
            textBoxi2.Clear();
            textBoxi3.Clear();
            textBoxa1.Clear();
            textBoxa2.Clear();
            textBoxa3.Clear();
            textBoxs1.Clear();
            textBoxs2.Clear();
            textBoxs3.Clear();
            textBoxe1.Clear();
            textBoxe2.Clear();
            textBoxe3.Clear();
            textBoxc1.Clear();
            textBoxc2.Clear();
            textBoxc3.Clear();

        }
        //清除特定性格类型的职业推荐
        private void clear_detailjob(object sender, RoutedEventArgs e)
        {
            textBoxjtype.Clear();
            textBoxj1.Clear();
            textBoxj2.Clear();
            textBoxj3.Clear();
            textBoxj4.Clear();
            textBoxj5.Clear();
            textBoxj6.Clear();
            textBoxj7.Clear();
            textBoxj8.Clear();
            textBoxj9.Clear();
            textBoxj10.Clear();
            
        }

        private void submit_type(object sender, RoutedEventArgs e)
        {
            //连接数据库：Server=服务器名称；DataBase=数据库名称；Uid=用户登录名；Pwd=登录密码
            string connString = "Server=SAKALUWA;DataBase=career;Uid=sa;Pwd=123456";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();//连接数据库
            if (textBoxr1.Text.ToString().Trim() != "")
            {
                string str = "update type set job1='"+textBoxr1.Text.ToString().Trim()+"' where type='R'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();//执行非查询SQL语句
            }
            if (textBoxr2.Text.ToString().Trim() != "")
            {
                string str = "update type set job2='" + textBoxr2.Text.ToString().Trim() + "' where type='R'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            if (textBoxr3.Text.ToString().Trim() != "")
            {
                string str = "update type set job3='" + textBoxr3.Text.ToString().Trim() + "' where type='R'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            if (textBoxi1.Text.ToString().Trim() != "")
            {
                string str = "update type set job1='" + textBoxi1.Text.ToString().Trim() + "' where type='I'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            if (textBoxi2.Text.ToString().Trim() != "")
            {
                string str = "update type set job2='" + textBoxi2.Text.ToString().Trim() + "' where type='I'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            if (textBoxi3.Text.ToString().Trim() != "")
            {
                string str = "update type set job3='" + textBoxi3.Text.ToString().Trim() + "' where type='I'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            if (textBoxa1.Text.ToString().Trim() != "")
            {
                string str = "update type set job1='" + textBoxa1.Text.ToString().Trim() + "' where type='A'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            if (textBoxa2.Text.ToString().Trim() != "")
            {
                string str = "update type set job2='" + textBoxa2.Text.ToString().Trim() + "' where type='A'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            if (textBoxa3.Text.ToString().Trim() != "")
            {
                string str = "update type set job3='" + textBoxa3.Text.ToString().Trim() + "' where type='A'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            if (textBoxs1.Text.ToString().Trim() != "")
            {
                string str = "update type set job1='" + textBoxs1.Text.ToString().Trim() + "' where type='S'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            if (textBoxs2.Text.ToString().Trim() != "")
            {
                string str = "update type set job2='" + textBoxs2.Text.ToString().Trim() + "' where type='S'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            if (textBoxs3.Text.ToString().Trim() != "")
            {
                string str = "update type set job3='" + textBoxs3.Text.ToString().Trim() + "' where type='S'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            if (textBoxe1.Text.ToString().Trim() != "")
            {
                string str = "update type set job1='" + textBoxe1.Text.ToString().Trim() + "' where type='E'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            if (textBoxe2.Text.ToString().Trim() != "")
            {
                string str = "update type set job2='" + textBoxe2.Text.ToString().Trim() + "' where type='E'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            if (textBoxe3.Text.ToString().Trim() != "")
            {
                string str = "update type set job3='" + textBoxe3.Text.ToString().Trim() + "' where type='E'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            if (textBoxc1.Text.ToString().Trim() != "")
            {
                string str = "update type set job1='" + textBoxc1.Text.ToString().Trim() + "' where type='C'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            if (textBoxc2.Text.ToString().Trim() != "")
            {
                string str = "update type set job2='" + textBoxc2.Text.ToString().Trim() + "' where type='C'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            if (textBoxc3.Text.ToString().Trim() != "")
            {
                string str = "update type set job3='" + textBoxc3.Text.ToString().Trim() + "' where type='C'";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }
            conn.Close();//关闭数据库
            MessageBox.Show("您的修改已成功提交!");

        }

        private void submit_job(object sender, RoutedEventArgs e)
        {
            string connString = "Server=SAKALUWA;DataBase=career;Uid=sa;Pwd=123456";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            //Trim去除首尾空格
            if (textBoxjtype.Text.ToString().Trim() != "")
            {
                string s = "select count(*) from type_job where type='" + textBoxjtype.Text.ToString().Trim()+"'";
                SqlCommand scmd = new SqlCommand(s, conn);
                //查询数据库中是否存在指定性格类型的职业推荐
                int result=int.Parse(scmd.ExecuteScalar().ToString());
                if (result == 0)//插入新的职业类型
                {
                    string insert = "insert into type_job (type,job1,job2,job3,job4,job5,job6,job7,job8,job9,job10) values ("
                        + "'"+textBoxjtype.Text.ToString().Trim()+"'," + "'" + textBoxj1.Text.ToString() + " '," + "'" + textBoxj2.Text.ToString().Trim() + " ',"
                        + "'" + textBoxj3.Text.ToString().Trim() + " '," + "'" + textBoxj4.Text.ToString().Trim() + " ',"
                        + "'" + textBoxj5.Text.ToString().Trim() + " '," + "'" + textBoxj6.Text.ToString().Trim() + " ',"
                        + "'" + textBoxj7.Text.ToString().Trim() + " '," + "'" + textBoxj8.Text.ToString().Trim() + " ',"
                        + "'" + textBoxj9.Text.ToString().Trim() + " '," + "'" + textBoxj10.Text.ToString().Trim() + " ')";
                    SqlCommand insertcmd = new SqlCommand(insert, conn);
                    insertcmd.ExecuteNonQuery();
                }
                else//更新职业类型
                {
                    string update = "update type_job set job1=" + "'" + textBoxj1.Text.ToString().Trim() + " ',job2=" + "'" + textBoxj2.Text.ToString().Trim() + " '"
                        + ",job3=" + "'" + textBoxj3.Text.ToString().Trim() + " '," + "job4=" + "'" + textBoxj4.Text.ToString().Trim() + " '"
                        + ",job5=" + "'" + textBoxj5.Text.ToString().Trim() + " '," + "job6=" + "'" + textBoxj6.Text.ToString().Trim() + " '"
                        + ",job7=" + "'" + textBoxj7.Text.ToString().Trim() + " '," + "job8=" + "'" + textBoxj8.Text.ToString().Trim() + " '"
                        + ",job9=" + "'" + textBoxj9.Text.ToString().Trim() + " '," + "job10=" + "'" + textBoxj10.Text.ToString().Trim()
                        + " ' where type='" + textBoxjtype.Text.ToString().Trim() + "'";
                    SqlCommand updatecmd = new SqlCommand(update, conn);
                    updatecmd.ExecuteNonQuery();
                   
                }
                MessageBox.Show("您对 " + textBoxjtype.Text.ToString().Trim() + " 类型的职业推荐已提交");
            }
            else
            {
                MessageBox.Show("请您输入职业性格类型（例：\"ACE\"）!");
            }

        }
    }
}
