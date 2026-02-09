using IMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.App
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadPrograms();
        }

        private void LoadPrograms()
        {
            using (var _context = new AppDbContext())
            {
                var programs = _context.Programs.ToList();

                foreach (var program in programs)
                {
                    var programControl = new ProgramControl(program);
                    flowLayoutPanel1.Controls.Add(programControl);
                }
            }
        }
    }
}
