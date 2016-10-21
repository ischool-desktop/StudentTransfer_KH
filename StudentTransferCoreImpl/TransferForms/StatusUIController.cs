using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using System.Drawing;

namespace StudentTransferCoreImpl
{
    class StatusUIController
    {
        private List<PanelEx> Controls = new List<PanelEx>();

        public StatusUIController(PanelEx[] ctls)
        {
            Controls.AddRange(ctls);

            foreach (PanelEx each in Controls)
                SetStateOff(each);
        }

        private int _state = 0;
        public int Status
        {
            get { return _state; }
            set
            {
                _state = value;
                foreach (PanelEx each in Controls)
                    SetStateOff(each);

                for (int i = 0; i < value; i++)
                    SetStateOn(Controls[i]);
            }
        }

        private void SetStateOn(PanelEx panel)
        {
            panel.CanvasColor = System.Drawing.SystemColors.Control;
            panel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            panel.Size = new System.Drawing.Size(60, 30);
            panel.Style.Alignment = System.Drawing.StringAlignment.Center;
            panel.Style.BackColor1.Color = System.Drawing.Color.Red;
            panel.Style.BackColor2.Color = System.Drawing.Color.Brown;
            panel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            panel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            panel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            panel.Style.ForeColor.Color = System.Drawing.Color.White;
            panel.Style.GradientAngle = 90;
        }

        private void SetStateOff(PanelEx panel)
        {
            panel.CanvasColor = System.Drawing.SystemColors.Control;
            panel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            panel.Size = new System.Drawing.Size(60, 30);
            panel.Style.Alignment = System.Drawing.StringAlignment.Center;
            panel.Style.BackColor1.Color = System.Drawing.Color.Gainsboro;
            panel.Style.BackColor2.Color = System.Drawing.Color.LightGray;
            panel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            panel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            panel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            panel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            panel.Style.GradientAngle = 90;
        }
    }
}
