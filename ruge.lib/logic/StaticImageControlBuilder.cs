using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ruge.lib.model;

namespace ruge.lib.logic
{
    using ruge.lib.logic;
    using ruge.lib.model.controls;
    using ruge.lib.model.controls.interfaces;

    public static class StaticImageControlBuilder
    {
        public static StaticImageControl Create()
        {
            var control = new StaticImageControl();
            control.ElementId = ControlHelper.GetNewControlID();
            control.IsVisible = true;
            control.Opacity = 100;
            control.Location = new XYPair(0, 0);
            control.Size = new XYPair();
            control.ZIndex = 50;
            return control;
        }

        public static StaticImageControl SetOpacity(this StaticImageControl control, int opacity)
        {
            control.Opacity = opacity;
            return control;
        }
        public static StaticImageControl SetLocation(this StaticImageControl staticImageControl, XYPair location)
        {
            staticImageControl.Location = location;
            return staticImageControl;
        }

        public static StaticImageControl SetIsVisible(this StaticImageControl staticImageControl, bool isVisible)
        {
            staticImageControl.IsVisible = isVisible;
            return staticImageControl;
        }

        public static StaticImageControl SetSize(this StaticImageControl staticImageControl, XYPair size)
        {
            staticImageControl.Size = size;
            return staticImageControl;
        }

        public static StaticImageControl SetZIndex(this StaticImageControl control, int zIndex)
        {
            control.ZIndex = zIndex;
            return control;
        }

        public static StaticImageControl SetX(this StaticImageControl control, int x)
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

        public static StaticImageControl SetY(this StaticImageControl control, int y)
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

        public static StaticImageControl SetWidth(this StaticImageControl control, int x)
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

        public static StaticImageControl SetHeight(this StaticImageControl control, int y)
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

        public static StaticImageControl SetImageUriTemplate(this StaticImageControl control, string template, string token)
        {
            SetImageUriTemplate(control, template, token, "normal", "hover", "down", "disabled");
            return control;
        }

        public static StaticImageControl SetImageUriTemplate(this StaticImageControl control, string template, string token, string normal, string hover, string down, string disabled)
        {
            control.ImageUri = template.Replace(token, normal);
            return control;
        }

        public static StaticImageControl SetImageUri(this StaticImageControl control, string uri)
        {
            control.ImageUri = uri;
            return control;
        }

        public static StaticImageControl SetName(this StaticImageControl control, string name)
        {
            control.Name = name;
            return control;
        }
    }
}
