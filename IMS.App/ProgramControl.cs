using IMS.Domain.Models;
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
    public partial class ProgramControl : UserControl
    {
        private Programs program;
        public ProgramControl(Programs program)
        {
            InitializeComponent();
            this.program = program;
            LoadProgram();
        }

        private void LoadProgram()
        {
            label1.Tag = program.Id;
            label1.Text = program.Name;
            label2.Text = program.Description ?? "{Needs Updating}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var _context = new AppDbContext())
            {
                var entity = _context.Programs.Find(label1.Tag);

                if (entity == null)
                {
                    return;
                }

                _context.Remove(entity);
                _context.SaveChanges();

                MessageBox.Show($"Program {label1.Text} deleted successfully.");
                this.Dispose();
            }
        }
    }
}
