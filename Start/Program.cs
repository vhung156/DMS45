using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Start
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
            try
            {
                Epoint.Program.Main();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                
            }
		}
	}
}
