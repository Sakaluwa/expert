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
    /// start.xaml 的交互逻辑
    /// </summary>
    public partial class start : Window
    {
        private string[] type = { "传统型", "现实型", "研究型", "管理型", "社会型", "艺术型" };
        private result re = new result();
        public static string server = "SAKALUWA", database = "career", uid = "sa", pwd = "123456";

        public start()
        {
            InitializeComponent();
            
        }

        private void start_test(object sender, RoutedEventArgs e)
        {
          
            string connString = "Server="+server+";DataBase="+database+";Uid="+uid+";Pwd="+pwd;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            for (int i = 0; i < 60; i++)
            {
                string temp = "select details from test_table where id=" + (i+1).ToString();
                SqlCommand cmd = new SqlCommand(temp, conn);
                Object details = cmd.ExecuteScalar();
                string question = "问题 " + (i + 1).ToString() + "：" + details.ToString();
                test te = new test();
                te.test_item.Text = question;
                te.ShowDialog();

                if (te.yes_btn.IsChecked == true)
                {
                    string tempStr = "update test_table set yes=1 , no=0 where id=" + (i + 1).ToString();
                    SqlCommand ccmd = new SqlCommand(tempStr, conn);
                    int result = ccmd.ExecuteNonQuery();
                }

                if (te.no_btn.IsChecked == true)
                {
                    string tempStr = "update test_table set yes=0,no=1 where id=" + (i + 1).ToString();
                    SqlCommand ccmd = new SqlCommand(tempStr, conn);
                    int result = ccmd.ExecuteNonQuery();
                }

            }
            int tc, tr, ti, tee, ts, ta;
            string tcStr = "select count(*) from test_table where (type='C' and yes=1 and ( id=7 or id=19 or id=29 or id=39 or id=41 or id=51 or id=57))"
                +" or (type='C' and no=1 and ( id=5 or id=18 or id=40 ))";
            SqlCommand tccmd = new SqlCommand(tcStr,conn);
            tc = int.Parse(tccmd.ExecuteScalar().ToString());
            string trStr = "select count(*) from test_table where (type='R' and yes=1 and ( id=2 or id=13 or id=22 or id=36 or id=43))"
                + " or (type='R' and no=1 and ( id=14 or id=23 or id=44 or id=47 or id=48))";
            SqlCommand trcmd = new SqlCommand(trStr, conn);
            tr = int.Parse(trcmd.ExecuteScalar().ToString());
            string tiStr = "select count(*) from test_table where (type='I' and yes=1 and ( id=6 or id=8 or id=20 or id=30 or id=31 or id=42))"
                + " or (type='I' and no=1 and ( id=21 or id=55 or id=56 or id=58))";
            SqlCommand ticmd = new SqlCommand(tiStr, conn);
            ti = int.Parse(ticmd.ExecuteScalar().ToString());
            string teeStr = "select count(*) from test_table where (type='E' and yes=1 and ( id=11 or id=24 or id=28 or id=35 or id=38 or id=46 or id=60))"
                + " or (type='E' and no=1 and ( id=3 or id=16 or id=25 ))";
            SqlCommand teecmd = new SqlCommand(teeStr, conn);
            tee = int.Parse(teecmd.ExecuteScalar().ToString());
            string tsStr = "select count(*) from test_table where (type='S' and yes=1 and ( id=26 or id=37 or id=52 or id=59))"
                + " or (type='S' and no=1 and ( id=1 or id=12 or id=15 or id=27 or id=45 or id=53))";
            SqlCommand tscmd = new SqlCommand(tsStr, conn);
            ts = int.Parse(tscmd.ExecuteScalar().ToString());
            string taStr = "select count(*) from test_table where (type='A' and yes=1 and ( id=4 or id=9 or id=10 or id=17 or id=33 or id=34 or id=49 or id=50 or id=54))"
                + " or (type='A' and no=1 and id=32)";
            SqlCommand tacmd = new SqlCommand(taStr, conn);
            ta = int.Parse(tacmd.ExecuteScalar().ToString());
            
            int[] six = {tc*20,tr*20,ti*20,tee*20,ts*20,ta*20};
            
            re.DrawregularPolygon(6,200);//绘制10分制正六边形
            re.DrawIrregularPolygon(6, six);//绘制测试分六边形
            re.textBlockc.Text = type[0] + "C (" + tc.ToString() + " 分)";
            re.textBlockr.Text = type[1] + "R (" + tr.ToString() + " 分)";
            re.textBlocki.Text = type[2] + "I (" + ti.ToString() + " 分)";
            re.textBlocke.Text = type[3] + "E (" + tee.ToString() + " 分)";
            re.textBlocks.Text = type[4] + "S (" + ts.ToString() + " 分)";
            re.textBlocka.Text = type[5] + "A (" + ta.ToString() + " 分)";
            Dictionary<char, int> typeDic = new Dictionary<char, int> { {'C',tc },
            {'R',tr }, {'I',ti }, {'E',tee },{'S',ts },{'A',ta } };
            int[] sixx = {tc,tr,ti,tee,ts,ta };
            Array.Sort(sixx);//对职业性格测评分排序
            int isunique = 0,isuniquee=0,isuniqueee=0;//保证在遍历typeDic时，各指定项只被执行一次
            string detailtype = "";
            char a1=' ', a2=' ', a3=' ';
            foreach (var item in typeDic)
            {
                if (item.Value==sixx[5] && isunique==0)
                {
                    string job1qStr = "select job1 from type where type=" + "'" + item.Key.ToString() + "'";
                    string job2qStr = "select job2 from type where type=" + "'" + item.Key.ToString() + "'";
                    string job3qStr = "select job3 from type where type=" + "'" + item.Key.ToString() + "'";
                    SqlCommand job1cmd = new SqlCommand(job1qStr,conn);
                    SqlCommand job2cmd = new SqlCommand(job2qStr, conn);
                    SqlCommand job3cmd = new SqlCommand(job3qStr, conn);
                    Object job1 = job1cmd.ExecuteScalar();
                    Object job2 = job2cmd.ExecuteScalar();
                    Object job3 = job3cmd.ExecuteScalar();
                    show_job1( job1.ToString());
                    show_job2( job2.ToString());
                    show_job3( job3.ToString());
                    isunique++;
                    re.textBlocktype1.Text = get_type(item.Key)+'('+item.Key.ToString()+") :";
                    string type1dStr = "select detail from type where type=" + "'" + item.Key.ToString() + "'";
                    string type1d1Str = "select detail1 from type where type=" + "'" + item.Key.ToString() + "'";
                    string type1d2Str = "select detail2 from type where type=" + "'" + item.Key.ToString() + "'";
                    string type1d3Str = "select detail3 from type where type=" + "'" + item.Key.ToString() + "'";
     
                    SqlCommand dcmd = new SqlCommand(type1dStr, conn);
                    SqlCommand d1cmd = new SqlCommand(type1d1Str, conn);
                    SqlCommand d2cmd = new SqlCommand(type1d2Str, conn);
                    SqlCommand d3cmd = new SqlCommand(type1d3Str, conn);
                    Object d = dcmd.ExecuteScalar();
                    Object d1 = d1cmd.ExecuteScalar();
                    Object d2 = d2cmd.ExecuteScalar();
                    Object d3 = d3cmd.ExecuteScalar();
                    re.textBlockdetail1.Text = "  "+d.ToString().Trim() + "\n" +"  "+ d1.ToString().Trim() + "\n" + "  " +
                        d2.ToString().Trim() + "\n" + "  " + d3.ToString().Trim() + "\n";
                    a1 = item.Key;



                }
                else if (item.Value==sixx[4] && isuniquee == 0)
                {
                    string job1qStr = "select job1 from type where type=" + "'" + item.Key.ToString() + "'";
                    string job2qStr = "select job2 from type where type=" + "'" + item.Key.ToString() + "'";
                    string job3qStr = "select job3 from type where type=" + "'" + item.Key.ToString() + "'";
                    SqlCommand job1cmd = new SqlCommand(job1qStr, conn);
                    SqlCommand job2cmd = new SqlCommand(job2qStr, conn);
                    SqlCommand job3cmd = new SqlCommand(job3qStr, conn);
                    Object job1 = job1cmd.ExecuteScalar();
                    Object job2 = job2cmd.ExecuteScalar();
                    Object job3 = job3cmd.ExecuteScalar();
                    show_job4(job1.ToString());
                    show_job5(job2.ToString());
                    show_job6(job3.ToString());
                    re.textBlocktype2.Text = get_type(item.Key) + '(' + item.Key.ToString() + ") :";
                    string type1dStr = "select detail from type where type=" + "'" + item.Key.ToString() + "'";
                    string type1d1Str = "select detail1 from type where type=" + "'" + item.Key.ToString() + "'";
                    string type1d2Str = "select detail2 from type where type=" + "'" + item.Key.ToString() + "'";
                    string type1d3Str = "select detail3 from type where type=" + "'" + item.Key.ToString() + "'";

                    SqlCommand dcmd = new SqlCommand(type1dStr, conn);
                    SqlCommand d1cmd = new SqlCommand(type1d1Str, conn);
                    SqlCommand d2cmd = new SqlCommand(type1d2Str, conn);
                    SqlCommand d3cmd = new SqlCommand(type1d3Str, conn);
                    Object d = dcmd.ExecuteScalar();
                    Object d1 = d1cmd.ExecuteScalar();
                    Object d2 = d2cmd.ExecuteScalar();
                    Object d3 = d3cmd.ExecuteScalar();
                    isuniquee++;
                    re.textBlockdetail2.Text = "  " + d.ToString().Trim() + "\n" + "  " + d1.ToString().Trim() + "\n" + "  " +
                        d2.ToString().Trim() + "\n" + "  " + d3.ToString().Trim() + "\n";
                    a2= item.Key;
                }
                else if(item.Value == sixx[3] && isuniqueee==0)
                {
                    a3 = item.Key;
                    isuniqueee++;
                   
                }
            }
            //确定职业性格类型
            detailtype = a1.ToString() + a2.ToString() + a3.ToString();
            
            
           
            re.textBlocktype.Text = "     " + detailtype + " 型推荐职业 ";
            string detype1 = "select job1 from type_job where type=" + "\'"+detailtype+"\'";
            string detype2 = "select job2 from type_job where type=" + "\'" + detailtype + "\'";
            string detype3 = "select job3 from type_job where type=" + "\'" + detailtype + "\'";
            string detype4 = "select job4 from type_job where type=" + "\'" + detailtype + "\'";
            string detype5 = "select job5 from type_job where type=" + "\'" + detailtype + "\'";
            string detype6 = "select job6 from type_job where type=" + "\'" + detailtype + "\'";
            string detype7 = "select job7 from type_job where type=" + "\'" + detailtype + "\'";
            string detype8 = "select job8 from type_job where type=" + "\'" + detailtype + "\'";
            string detype9 = "select job9 from type_job where type=" + "\'" + detailtype + "\'";
            string detype10 = "select job10 from type_job where type=" + "\'" + detailtype + "\'";
            string detypecount = "select count(*) from type_job where type=" + "\'" + detailtype + "\'";

            SqlCommand detypecmd1 = new SqlCommand(detype1,conn);
            SqlCommand detypecmd2 = new SqlCommand(detype2, conn);
            SqlCommand detypecmd3 = new SqlCommand(detype3, conn);
            SqlCommand detypecmd4 = new SqlCommand(detype4, conn);
            SqlCommand detypecmd5 = new SqlCommand(detype5, conn);
            SqlCommand detypecmd6 = new SqlCommand(detype6, conn);
            SqlCommand detypecmd7 = new SqlCommand(detype7, conn);
            SqlCommand detypecmd8 = new SqlCommand(detype8, conn);
            SqlCommand detypecmd9 = new SqlCommand(detype9, conn);
            SqlCommand detypecmd10 = new SqlCommand(detype10, conn);
            SqlCommand detypecountcmd = new SqlCommand(detypecount,conn);
            int detypeNum = int.Parse(detypecountcmd.ExecuteScalar().ToString());
            string detailjob = "\n  ";//存储职业名称
            if (detypeNum != 0)
            {
                string detypeObj1 = detypecmd1.ExecuteScalar().ToString().Trim();
                string detypeObj2 = detypecmd2.ExecuteScalar().ToString().Trim();
                string detypeObj3 = detypecmd3.ExecuteScalar().ToString().Trim();
                string detypeObj4 = detypecmd4.ExecuteScalar().ToString().Trim();
                string detypeObj5 = detypecmd5.ExecuteScalar().ToString().Trim();
                string detypeObj6 = detypecmd6.ExecuteScalar().ToString().Trim();
                string detypeObj7 = detypecmd7.ExecuteScalar().ToString().Trim();
                string detypeObj8 = detypecmd8.ExecuteScalar().ToString().Trim();
                string detypeObj9 = detypecmd9.ExecuteScalar().ToString().Trim();
                string detypeObj10 = detypecmd10.ExecuteScalar().ToString().Trim();
               
                if (detypeObj1.Length > 1)
                {
                    detailjob += detypeObj1 + "、";
                }
                if (detypeObj2.Length > 1)
                {
                    detailjob += detypeObj2 + "、";
                }

                if (detypeObj3.Length > 1)
                {
                    detailjob += detypeObj3 + "、";
                }
                if (detypeObj4.Length > 1)
                {
                    detailjob += detypeObj4 + "、";
                }
                if (detypeObj5.Length > 1)
                {
                    detailjob += detypeObj5 + "、";
                }
                if (detypeObj6.Length > 1)
                {
                    detailjob += detypeObj6 + "、";
                }
                if (detypeObj7.Length > 1)
                {
                    detailjob += detypeObj7 + "、";
                }
                if (detypeObj8.Length > 1)
                {
                    detailjob += detypeObj8 + "、";
                }
                if (detypeObj9.Length > 1)
                {
                    detailjob += detypeObj9 + "、";
                }
                if (detypeObj10.Length > 1)
                {
                    detailjob += detypeObj10 + "、";
                }

            }
                   
            

            re.textBlockdetail.Text = detailjob;  //设置特定职业性格的职业推荐          
            conn.Close();
            re.ShowDialog();
        }

        private void start_modify(object sender, RoutedEventArgs e)
        {
            modify mo = new modify();
            mo.Show();
        }
        //返回性格类型
        private string get_type(char c)
        {
            string str="";
            if (c == 'R')
            {
                str = "常规型";
            }
            else if (c == 'I')
            {
                str = "研究型";
            }
            else if (c == 'A')
            {
                str = "艺术型";
            }
            else if (c == 'S')
            {
                str = "社会型";
            }
            else if (c == 'E')
            {
                str = "管理型";
            }
            else
            {
                str = "传统型";
            }
            return str;
        }
        //设置职业推荐一的图片源
        private void show_job1(String s)
        {
            if (s.Contains("诗人"))//s包含“诗人”
            {
                re.job1.Source = new BitmapImage(new Uri("poet.png", UriKind.RelativeOrAbsolute));//读取图片并设置
            }
            else if (s.Contains( "艺术家"))
            {
                re.job1.Source = new BitmapImage(new Uri("artist.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "生物学家"))
            {
                re.job1.Source = new BitmapImage(new Uri("biology.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "企业家"))
            {
                re.job1.Source = new BitmapImage(new Uri("boss.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "出纳"))
            {
                re.job1.Source = new BitmapImage(new Uri("chuna.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "土木工程师"))
            {
                re.job1.Source = new BitmapImage(new Uri("engineer.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "会计"))
            {
                re.job1.Source = new BitmapImage(new Uri("kuaiji.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "数学家"))
            {
                re.job1.Source = new BitmapImage(new Uri("math.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "秘书"))
            {
                re.job1.Source = new BitmapImage(new Uri("mishu.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "农民"))
            {
                re.job1.Source = new BitmapImage(new Uri("peasant.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "政治家"))
            {
                re.job1.Source = new BitmapImage(new Uri("politian.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "牧师"))
            {
                re.job1.Source = new BitmapImage(new Uri("priest.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "推销员"))
            {
                re.job1.Source = new BitmapImage(new Uri("saler.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "科研人员"))
            {
                re.job1.Source = new BitmapImage(new Uri("science.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "教师"))
            {
                re.job1.Source = new BitmapImage(new Uri("teacher.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "辅导人员"))
            {
                re.job1.Source = new BitmapImage(new Uri("teach.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "工人"))
            {
                re.job1.Source = new BitmapImage(new Uri("worker.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                re.job1.Source = new BitmapImage(new Uri("you.png", UriKind.RelativeOrAbsolute));
            }


        }
        private void show_job2(string s)
        {
            if (s.Contains( "诗人"))
            {
                re.job2.Source = new BitmapImage(new Uri("poet.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "艺术家"))
            {
                re.job2.Source = new BitmapImage(new Uri("artist.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "生物学家"))
            {
                re.job2.Source = new BitmapImage(new Uri("biology.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "企业家"))
            {
                re.job2.Source = new BitmapImage(new Uri("boss.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "出纳"))
            {
                re.job2.Source = new BitmapImage(new Uri("chuna.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "土木工程师"))
            {
                re.job2.Source = new BitmapImage(new Uri("engineer.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "会计"))
            {
                re.job2.Source = new BitmapImage(new Uri("kuaiji.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "数学家"))
            {
                re.job2.Source = new BitmapImage(new Uri("math.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "秘书"))
            {
                re.job2.Source = new BitmapImage(new Uri("mishu.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "农民"))
            {
                re.job2.Source = new BitmapImage(new Uri("peasant.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "政治家"))
            {
                re.job2.Source = new BitmapImage(new Uri("politian.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "牧师"))
            {
                re.job2.Source = new BitmapImage(new Uri("priest.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "推销员"))
            {
                re.job2.Source = new BitmapImage(new Uri("saler.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "科研人员"))
            {
                re.job2.Source = new BitmapImage(new Uri("science.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "教师"))
            {
                re.job2.Source = new BitmapImage(new Uri("teacher.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "辅导人员"))
            {
                re.job2.Source = new BitmapImage(new Uri("teach.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "工人"))
            {
                re.job2.Source = new BitmapImage(new Uri("worker.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                re.job2.Source = new BitmapImage(new Uri("you.png", UriKind.RelativeOrAbsolute));
            }


        }
        private void show_job3(string s)
        {
            if (s.Contains( "诗人"))
            {
                re.job3.Source = new BitmapImage(new Uri("poet.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "艺术家"))
            {
                re.job3.Source = new BitmapImage(new Uri("artist.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "生物学家"))
            {
                re.job3.Source = new BitmapImage(new Uri("biology.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "企业家"))
            {
                re.job3.Source = new BitmapImage(new Uri("boss.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "出纳"))
            {
                re.job3.Source = new BitmapImage(new Uri("chuna.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "土木工程师"))
            {
                re.job3.Source = new BitmapImage(new Uri("engineer.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "会计"))
            {
                re.job3.Source = new BitmapImage(new Uri("kuaiji.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "数学家"))
            {
                re.job3.Source = new BitmapImage(new Uri("math.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "秘书"))
            {
                re.job3.Source = new BitmapImage(new Uri("mishu.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "农民"))
            {
                re.job3.Source = new BitmapImage(new Uri("peasant.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "政治家"))
            {
                re.job3.Source = new BitmapImage(new Uri("politian.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "牧师"))
            {
                re.job3.Source = new BitmapImage(new Uri("priest.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "推销员"))
            {
                re.job3.Source = new BitmapImage(new Uri("saler.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "科研人员"))
            {
                re.job3.Source = new BitmapImage(new Uri("science.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "教师"))
            {
                re.job3.Source = new BitmapImage(new Uri("teacher.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "辅导人员"))
            {
                re.job3.Source = new BitmapImage(new Uri("teach.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "工人"))
            {
                re.job3.Source = new BitmapImage(new Uri("worker.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                re.job3.Source = new BitmapImage(new Uri("you.png", UriKind.RelativeOrAbsolute));
            }


        }

        private void database_info(object sender, RoutedEventArgs e)
        {
            server=textBoxserver.Text.ToString().Trim();
            database = textBoxdb.Text.ToString().Trim();
            uid = textBoxuser.Text.ToString().Trim();
            pwd = textBoxpwd.Text.ToString().Trim();
        }

        private void show_job4(string s)
        {
            if (s.Contains( "诗人"))
            {
                re.job4.Source = new BitmapImage(new Uri("poet.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "艺术家"))
            {
                re.job4.Source = new BitmapImage(new Uri("artist.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "生物学家"))
            {
                re.job4.Source = new BitmapImage(new Uri("biology.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "企业家"))
            {
                re.job4.Source = new BitmapImage(new Uri("boss.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "出纳"))
            {
                re.job4.Source = new BitmapImage(new Uri("chuna.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "土木工程师"))
            {
                re.job4.Source = new BitmapImage(new Uri("engineer.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "会计"))
            {
                re.job4.Source = new BitmapImage(new Uri("kuaiji.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "数学家"))
            {
                re.job4.Source = new BitmapImage(new Uri("math.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "秘书"))
            {
                re.job4.Source = new BitmapImage(new Uri("mishu.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "农民"))
            {
                re.job4.Source = new BitmapImage(new Uri("peasant.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "政治家"))
            {
                re.job4.Source = new BitmapImage(new Uri("politian.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "牧师"))
            {
                re.job4.Source = new BitmapImage(new Uri("priest.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "推销员"))
            {
                re.job4.Source = new BitmapImage(new Uri("saler.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "科研人员"))
            {
                re.job4.Source = new BitmapImage(new Uri("science.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "教师"))
            {
                re.job4.Source = new BitmapImage(new Uri("teacher.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "辅导人员"))
            {
                re.job4.Source = new BitmapImage(new Uri("teach.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "工人"))
            {
                re.job4.Source = new BitmapImage(new Uri("worker.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                re.job4.Source = new BitmapImage(new Uri("you.png", UriKind.RelativeOrAbsolute));
            }


        }
        private void show_job5(string s)
        {
            if (s.Contains( "诗人"))
            {
                re.job5.Source = new BitmapImage(new Uri("poet.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "艺术家"))
            {
                re.job5.Source = new BitmapImage(new Uri("artist.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "生物学家"))
            {
                re.job5.Source = new BitmapImage(new Uri("biology.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "企业家"))
            {
                re.job5.Source = new BitmapImage(new Uri("boss.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "出纳"))
            {
                re.job5.Source = new BitmapImage(new Uri("chuna.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "土木工程师"))
            {
                re.job5.Source = new BitmapImage(new Uri("engineer.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "会计"))
            {
                re.job5.Source = new BitmapImage(new Uri("kuaiji.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "数学家"))
            {
                re.job5.Source = new BitmapImage(new Uri("math.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "秘书"))
            {
                re.job5.Source = new BitmapImage(new Uri("mishu.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "农民"))
            {
                re.job5.Source = new BitmapImage(new Uri("peasant.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "政治家"))
            {
                re.job5.Source = new BitmapImage(new Uri("politian.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "牧师"))
            {
                re.job5.Source = new BitmapImage(new Uri("priest.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "推销员"))
            {
                re.job5.Source = new BitmapImage(new Uri("saler.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "科研人员"))
            {
                re.job5.Source = new BitmapImage(new Uri("science.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "教师"))
            {
                re.job5.Source = new BitmapImage(new Uri("teacher.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "辅导人员"))
            {
                re.job5.Source = new BitmapImage(new Uri("teach.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "工人"))
            {
                re.job5.Source = new BitmapImage(new Uri("worker.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                re.job5.Source = new BitmapImage(new Uri("you.png", UriKind.RelativeOrAbsolute));
            }


        }
        private void show_job6(string s)
        {
            if (s.Contains( "诗人"))
            {
                re.job6.Source = new BitmapImage(new Uri("poet.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "艺术家"))
            {
                re.job6.Source = new BitmapImage(new Uri("artist.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "生物学家"))
            {
                re.job6.Source = new BitmapImage(new Uri("biology.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "企业家"))
            {
                re.job6.Source = new BitmapImage(new Uri("boss.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "出纳"))
            {
                re.job6.Source = new BitmapImage(new Uri("chuna.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "土木工程师"))
            {
                re.job6.Source = new BitmapImage(new Uri("engineer.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "会计"))
            {
                re.job6.Source = new BitmapImage(new Uri("kuaiji.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "数学家"))
            {
                re.job6.Source = new BitmapImage(new Uri("math.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "秘书"))
            {
                re.job6.Source = new BitmapImage(new Uri("mishu.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "农民"))
            {
                re.job6.Source = new BitmapImage(new Uri("peasant.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "政治家"))
            {
                re.job6.Source = new BitmapImage(new Uri("politian.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "牧师"))
            {
                re.job6.Source = new BitmapImage(new Uri("priest.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "推销员"))
            {
                re.job6.Source = new BitmapImage(new Uri("saler.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "科研人员"))
            {
                re.job6.Source = new BitmapImage(new Uri("science.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "教师"))
            {
                re.job6.Source = new BitmapImage(new Uri("teacher.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "辅导人员"))
            {
                re.job6.Source = new BitmapImage(new Uri("teach.png", UriKind.RelativeOrAbsolute));
            }
            else if (s.Contains( "工人"))
            {
                re.job6.Source = new BitmapImage(new Uri("worker.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                re.job6.Source = new BitmapImage(new Uri("you.png", UriKind.RelativeOrAbsolute));
            }


        }


    }
}
