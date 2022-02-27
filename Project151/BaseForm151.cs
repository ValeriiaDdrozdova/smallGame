using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Project151
{
    /// <summary>
    /// Base class for forms
    /// </summary>
    public class BaseForm151 : Form
    {
        public static System.Drawing.Font userFont;
        public string UserName;
        public int Speed;

        public void SetFont()
        {
            if (userFont != null)
            {
                foreach (var ctrl in this.Controls)
                {
                    if (ctrl.GetType().GetProperty("Font") != null)
                    {
                        ((Control)ctrl).Font = new System.Drawing.Font(userFont.FontFamily, ((Control)ctrl).Font.Size);
                    }
                }
            }
        }
    }
}
