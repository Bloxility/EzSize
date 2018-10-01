using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;

//namespace EzSize
//{
public class EzSize
{
    private static List<float[]> percentages = new List<float[]>();
    private static List<float[]> positionPerc = new List<float[]>();
    private static List<Control> controls = new List<Control>();
    public static bool initialiseResizer(Form form)
    {
        try
        {
            if (form.Controls.Count != 0)
            {
                foreach (Control i in form.Controls)
                {
                    controls.Add(i);
                    percentages.Add(new float[] { (float)i.Width / i.Parent.Width, (float)i.Height / i.Parent.Height });
                    positionPerc.Add(new float[] { (float)i.Location.X / i.Parent.Width, (float)i.Location.Y / i.Parent.Height });
                }
                add();
            }
            else
            {
                throw new Exception();
            }
        }
        catch (Exception e)
        {
            return false;
        }
        return true;
    }
    private static void add()
    {
        foreach (Control i in controls.ToArray())
        {
            if (i.Controls.Count != 0)
            {
                loopAdd(i);
            }
        }
    }
    private static void loopAdd(Control cont)
    {
        foreach(Control i in cont.Controls)
        {
            controls.Add(i);
            percentages.Add(new float[] { (float)i.Width / i.Parent.Width, (float)i.Height / i.Parent.Height });
            positionPerc.Add(new float[] { (float)i.Location.X / i.Parent.Width, (float)i.Location.Y / i.Parent.Height });
            if (i.Controls.Count != 0)
            {
                loopAdd(i);
            }
        }
    }
    public static void resizeEvent(object sender, EventArgs e)
    {
        int count = 0;
        foreach(Control i in controls.ToArray())
        {
            i.Size = new Size(Convert.ToInt32(percentages[count][0] * i.Parent.Width), Convert.ToInt32(percentages[count][1] * i.Parent.Height));

            i.Location = new Point(Convert.ToInt32(positionPerc[count][0] * i.Parent.Width), Convert.ToInt32(positionPerc[count][1] * i.Parent.Width));

            count = count + 1;
        }
    }
    public static bool add(Control i)
    {
        try
        {
            controls.Add(i);
            percentages.Add(new float[] { (float)i.Width / i.Parent.Width, (float)i.Height / i.Parent.Height });
            positionPerc.Add(new float[] { (float)i.Location.X / i.Parent.Width, (float)i.Location.Y / i.Parent.Height });
            if (i.Controls.Count != 0)
            {
                loopAdd(i);
                return true;
            }
            return true;
        }
        catch(Exception e)
        {
            return false;
        }
    }
}
    
//}
