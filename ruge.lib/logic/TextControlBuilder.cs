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

    public static class TextControlBuilder
    {
          public static TextControl Create()
        {
            var control = new TextControl();
            control.ElementId = ControlHelper.GetNewControlID();
            control.IsVisible = true;
            control.Opacity = 100;
            control.Location = new XYPair(0, 0);
            control.Size = new XYPair();
            control.ZIndex = 50;
            control.IsEnabled = true;
            return control;
        }

        public static TextControl SetFontSize(this TextControl control, double fontSize)
        {
            control.FontSize = fontSize;
            return control;
        }

        public static TextControl SetMaxLength(this TextControl control, int maxLength)
        {
            control.MaxLength = maxLength;
            return control;
        }

        public static TextControl SetText(this TextControl control, string text)
        {
            control.Text = text;
            return control;
        }
        public static TextControl SetOpacity(this TextControl control, int opacity)
        {
            control.Opacity = opacity;
            return control;
        }

        public static TextControl SetBehavior(this TextControl control, Behaviors Behavior)
        {
            control.Behavior = Behavior;
            return control;
        }

        public static TextControl SetLocation(this TextControl clickableControl, XYPair location)
        {
            clickableControl.Location = location;
            return clickableControl;
        }

        public static TextControl SetIsVisible(this TextControl clickableControl, bool isVisible)
        {
            clickableControl.IsVisible = isVisible;
            return clickableControl;
        }

        public static TextControl SetSize(this TextControl clickableControl, XYPair size)
        {
            clickableControl.Size = size;
            return clickableControl;
        }

        public static TextControl SetZIndex(this TextControl control, int zIndex)
        {
            control.ZIndex = zIndex;
            return control;
        }
        public static TextControl SetIsEnabled(this TextControl control, bool IsEnabled)
        {
            control.IsEnabled = IsEnabled;
            return control;
        }

        public static TextControl SetX(this TextControl control, int x)
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

        public static TextControl SetY(this TextControl control, int y)
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

        public static TextControl SetWidth(this TextControl control, int x)
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

        public static TextControl SetHeight(this TextControl control, int y)
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

        public static TextControl SetImageUriTemplate(this TextControl control, string template, string token)
        {
            SetImageUriTemplate(control, template, token, "normal", "hover", "down", "disabled");
            return control;
        }

        public static TextControl SetImageUriTemplate(this TextControl control, string template, string token, string normal, string hover, string down, string disabled)
        {
            control.ImageUri = template.Replace(token,normal);
            control.ImageUriHover = template.Replace(token, hover);
            control.ImageUriDown = template.Replace(token, down);
            control.ImageUriDisabled = template.Replace(token, disabled);
            return control;
        }

        public static TextControl SetImageUri(this TextControl control, string uri)
        {
            control.ImageUri = uri;
            return control;
        }

        public static TextControl SetImageUriHover(this TextControl control, string uri)
        {
            control.ImageUriHover = uri;
            UpdateEmptyUris(control, uri);
            return control;
        }

        public static TextControl SetImageUriDown(this TextControl control, string uri)
        {
            control.ImageUriDown = uri;
            UpdateEmptyUris(control, uri);
            return control;
        }

        public static TextControl SetImageUriDisabled(this TextControl control, string uri)
        {
            control.ImageUriDisabled = uri;
            UpdateEmptyUris(control, uri);
            return control;
        }

        public static TextControl SetAllUris(this TextControl control, string uri)
        {
            control.ImageUri = uri;
            control.ImageUriHover = uri;
            control.ImageUriDown = uri;
            control.ImageUriDisabled = uri;

            return control;
        }

        private static TextControl UpdateEmptyUris(TextControl control, string uri)
        {
            if (control.ImageUriHover == null) control.ImageUriHover = uri;
            if (control.ImageUriDown == null) control.ImageUriDown = uri;
            if (control.ImageUriDisabled == null) control.ImageUriDisabled = uri;

            return control;
        }

        public static TextControl SetName(this TextControl control, string name)
        {
            control.Name = name;
            return control;
        }

        public static TextControl SetDelay(this TextControl control, int delayInMiliseconds)
        {
            control.Delay = delayInMiliseconds;
            return control;
        }


    }
}
