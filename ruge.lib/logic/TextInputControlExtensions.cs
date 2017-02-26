using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ruge.lib.logic
{
    using ruge.lib.logic;
    using ruge.lib.model.controls;
    using ruge.lib.model.controls.interfaces;

    public static class TextInputControlMaker
    {
        public static TextInputControl Create()
        {
            var control = new TextInputControl();
            control.ElementId = ControlHelper.GetNewControlID();
            return control;
        }

        public static TextInputControl X(this TextInputControl control, int x)
        {
            if (control.Location == null)
            {
                control.Location = new model.XYPair();
                control.Location.X = x;
                control.Location.Y = 0;
            }
            else
            {
                control.Location.X = x;
            }
            return control;
        }

        public static TextInputControl Y(this TextInputControl control, int y)
        {
            if (control.Location == null)
            {
                control.Location = new model.XYPair();
                control.Location.X = 0;
                control.Location.Y = y;
            }
            else
            {
                control.Location.Y = y;
            }
            return control;
        }

        public static TextInputControl Width(this TextInputControl control, int x)
        {
            if (control.Size == null)
            {
                control.Size = new model.XYPair();
                control.Size.X = x;
                control.Size.Y = x;
            }
            else
            {
                control.Size.X = x;
            }
            return control;
        }

        public static TextInputControl Height(this TextInputControl control, int y)
        {
            if (control.Size == null)
            {
                control.Size = new model.XYPair();
                control.Size.X = y;
                control.Size.Y = y;
            }
            else
            {
                control.Size.Y = y;
            }
            return control;
        }

        public static TextInputControl ImageUri(this TextInputControl control, string uri)
        {
            control.ImageUri = uri;
            return control;
        }

        public static TextInputControl EnableState(this TextInputControl control, EnableStates enableState)
        {
            control.EnableState = enableState;
            return control;
        }

        public static TextInputControl Text(this TextInputControl control, string text)
        {
            control.Text = text;
            return control;
        }
    }
}
