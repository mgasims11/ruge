using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ruge.lib.logic
{
    using ruge.lib.logic;
    using ruge.lib.model.controls;
    using ruge.lib.model.controls.interfaces;

    public static class TextControlMaker
    {
        public static TextControl Create()
        {
            var control = new TextControl();
            control.ElementId = ControlHelper.GetNewControlID();
            return control;
        }

        public static TextControl X(this TextControl control, int x)
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

        public static TextControl Y(this TextControl control, int y)
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

        public static TextControl Width(this TextControl control, int x)
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

        public static TextControl Height(this TextControl control, int y)
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

        public static TextControl ImageUri(this TextControl control, string uri)
        {
            control.ImageUri = uri;
            return control;
        }

        public static TextControl SetIsEnabled(this TextControl control, bool isEnabled)
        {
            control.IsEnabled = isEnabled;
            return control;
        }

        public static TextControl Text(this TextControl control, string text)
        {
            control.Text = text;
            return control;
        }
    }
}
