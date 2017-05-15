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

namespace Expert
{
    /// <summary>
    /// result.xaml 的交互逻辑
    /// </summary>
    public partial class result : Window
    {
        public result()
        {
            InitializeComponent();
            DrawregularPolygon(6,200);
        }
        public void DrawregularPolygon(int numSides,int r)
        {
            GeometryGroup gg = new GeometryGroup();         
            gg.Children.Add(BuildregularPolygon(numSides,r));//添加图形
            gg.Freeze();                
            path1.Data = gg;
        }
        public void DrawIrregularPolygon(int numSides,int[] r)
        {
            GeometryGroup gg = new GeometryGroup();
            gg.Children.Add(BuildIrregularPolygon(numSides,r));
            gg.Freeze();
            path2.Data = gg;
        }
        public StreamGeometry BuildIrregularPolygon(int numSides, int[] r)
        {
            Point c = new Point(100, 250);
            StreamGeometry geometry = new StreamGeometry();
            using (StreamGeometryContext ctx = geometry.Open())
            {
                Point c1 = c;
                double step = 2 * Math.PI / Math.Max(numSides, 3);
                double a = step;
                for (int i = 0; i < numSides; i++, a += step)
                {
                    c1.X = c.X + r[i] * Math.Cos(a);
                    c1.Y = c.Y + r[i] * Math.Sin(a);
                    if (i == 0)
                    {
                        ctx.BeginFigure(c1, true, true);
                    }
                    else
                    {
                        ctx.LineTo(c1, true, false);
                    }

                }
                for (int i = 0; i < numSides; i++, a += step)
                {
                    c1.X = c.X + r[i] * Math.Cos(a);
                    c1.Y = c.Y + r[i] * Math.Sin(a);               
                    Point[] pp = { c, c1 };
                    ctx.PolyLineTo(pp, true, true);

                }
            }
            return geometry;
        }
        //在Canvas绘制多边形，numSides=边数，r=半径
        public StreamGeometry BuildregularPolygon(int numSides,int r)
        {
            Point c = new Point(100, 250);//中心点
            StreamGeometry geometry = new StreamGeometry();

            using (StreamGeometryContext ctx = geometry.Open())
            {
                Point c1 = c;
                double step = 2 * Math.PI / Math.Max(numSides, 3);
                double a = step;
                //循环绘制并连接点
                for (int i=0;i<numSides;i++,a+=step)
                {
                    c1.X = c.X + r*Math.Cos(a);
                    c1.Y = c.Y + r*Math.Sin(a);
                    if (i == 0)
                    {
                        ctx.BeginFigure(c1, true, true);//图像开始点
                        
                    }
                    else
                    {
                        ctx.LineTo(c1, true, false);//从上一个点连接至新的点
                    }
                    

                }
                for (int i = 0; i < numSides; i++, a += step)
                {
                    c1.X = c.X + r * Math.Cos(a);
                    c1.Y = c.Y + r * Math.Sin(a);
                    Point[] pp = { c, c1 };                   
                    ctx.PolyLineTo(pp, true, true);      //从中心点连接到该点          
                }
            }
            return geometry;
        }
        
        
    }
}
