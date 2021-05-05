using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CollegeManagementSystem.lib
{
    public class CustomMenuColor : ProfessionalColorTable
    {
        public override Color MenuBorder
        {
            get { return Color.FromArgb(238, 226, 212); }
        }

        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(188, 143, 90); }
        }

        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(210, 180, 143); }
        }

        public override Color SeparatorDark
        {
            get { return Color.FromArgb(202, 167, 125); }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return Color.FromArgb(217, 191, 161); }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return Color.FromArgb(211, 183, 150); }
        }

        public override Color ImageMarginGradientMiddle
        {
            get { return Color.FromArgb(211, 183, 150); }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return Color.FromArgb(211, 183, 150); }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(211, 183, 150); }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(218, 193, 163); }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.FromArgb(200, 163, 120); }
        }

        public override Color MenuItemPressedGradientMiddle
        {
            get { return Color.FromArgb(235, 221, 205); }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.FromArgb(211, 183, 150); }
        }
    }
}