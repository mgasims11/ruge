using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ruge.lib.logic
{
    using ruge.lib.logic;
    using ruge.lib.model.controls;
    using ruge.lib.model.controls.interfaces;

    public static class StaticImageControlMaker
    {
        public static StaticImageControl Create()
        {
            var control = new StaticImageControl();
            control.ControlId = ControlHelper.GetNewControlID();
            return control;
        }

        public static StaticImageControl X(this StaticImageControl control, int x)
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

        public static StaticImageControl Y(this StaticImageControl control, int y)
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

        public static StaticImageControl Width(this StaticImageControl control, int x)
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

        public static StaticImageControl Height(this StaticImageControl control, int y)
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

        public static StaticImageControl ImageUri(this StaticImageControl control, string uri)
        {
            control.ImageUri = uri;
            return control;
        }

        public static StaticImageControl ControlState(this StaticImageControl control, ControlState controlState)
        {
            control.ControlState = controlState;
            return control;
        }
    }
}
