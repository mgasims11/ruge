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

    public static class ClickableControlBuilder
    {
        public static ClickableControl Create()
        {
            var control = new ClickableControl();
            control.ElementId = ControlHelper.GetNewControlID();
            control.IsVisible = true;
            control.Opacity = 100;
            control.Location = new XYPair(0, 0);
            control.Size = new XYPair();
            control.ZIndex = 50;
            control.IsEnabled = true;
            return control;
        }

        public static ClickableControl SetOpacity(this ClickableControl control, int opacity)
        {
            control.Opacity = opacity;
            return control;
        }

        public static ClickableControl SetBehavior(this ClickableControl control, Behaviors Behavior)
        {
            control.Behavior = Behavior;
            return control;
        }

        public static ClickableControl SetLocation(this ClickableControl clickableControl, XYPair location)
        {
            clickableControl.Location = location;
            return clickableControl;
        }

        public static ClickableControl SetIsVisible(this ClickableControl clickableControl, bool isVisible)
        {
            clickableControl.IsVisible = isVisible;
            return clickableControl;
        }

        public static ClickableControl SetSize(this ClickableControl clickableControl, XYPair size)
        {
            clickableControl.Size = size;
            return clickableControl;
        }

        public static ClickableControl SetZIndex(this ClickableControl control, int zIndex)
        {
            control.ZIndex = zIndex;
            return control;
        }
        public static ClickableControl SetIsEnabled(this ClickableControl control, bool IsEnabled)
        {
            control.IsEnabled = IsEnabled;
            return control;
        }

        public static ClickableControl SetX(this ClickableControl control, int x)
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

        public static ClickableControl SetY(this ClickableControl control, int y)
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

        public static ClickableControl SetWidth(this ClickableControl control, int x)
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

        public static ClickableControl SetHeight(this ClickableControl control, int y)
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

        public static ClickableControl SetImageUriTemplate(this ClickableControl control, string template, string token)
        {
            SetImageUriTemplate(control, template, token, "normal", "hover", "down", "disabled");
            return control;
        }

        public static ClickableControl SetImageUriTemplate(this ClickableControl control, string template, string token, string normal, string hover, string down, string disabled)
        {
            control.ImageUri = template.Replace(token,normal);
            control.ImageUriHover = template.Replace(token, hover);
            control.ImageUriDown = template.Replace(token, down);
            control.ImageUriDisabled = template.Replace(token, disabled);
            return control;
        }

        public static ClickableControl SetImageUri(this ClickableControl control, string uri)
        {
            control.ImageUri = uri;
            return control;
        }

        public static ClickableControl SetImageUriHover(this ClickableControl control, string uri)
        {
            control.ImageUriHover = uri;
            UpdateEmptyUris(control, uri);
            return control;
        }

        public static ClickableControl SetImageUriDown(this ClickableControl control, string uri)
        {
            control.ImageUriDown = uri;
            UpdateEmptyUris(control, uri);
            return control;
        }

        public static ClickableControl SetImageUriDisabled(this ClickableControl control, string uri)
        {
            control.ImageUriDisabled = uri;
            UpdateEmptyUris(control, uri);
            return control;
        }

        public static ClickableControl SetAllUris(this ClickableControl control, string uri)
        {
            control.ImageUri = uri;
            control.ImageUriHover = uri;
            control.ImageUriDown = uri;
            control.ImageUriDisabled = uri;

            return control;
        }

        private static ClickableControl UpdateEmptyUris(ClickableControl control, string uri)
        {
            if (control.ImageUriHover == null) control.ImageUriHover = uri;
            if (control.ImageUriDown == null) control.ImageUriDown = uri;
            if (control.ImageUriDisabled == null) control.ImageUriDisabled = uri;

            return control;
        }

        public static ClickableControl SetName(this ClickableControl control, string name)
        {
            control.Name = name;
            return control;
        }

        public static ClickableControl DetDelay(this ClickableControl control, int delayInMiliseconds)
        {
            control.Delay = delayInMiliseconds;
            return control;
        }
    }
}
