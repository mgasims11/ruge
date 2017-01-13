﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ruge.lib.logic
{
    using ruge.lib.logic;
    using ruge.lib.model.controls;
    using ruge.lib.model.controls.interfaces;

    public static class ClickableControlExtensions
    {
        public static ClickableControl Create()
        {
            var control = new ClickableControl();
            control.ControlId = ControlHelper.GetNewControlID();
            return control;
        }

        public static ClickableControl X(this ClickableControl control, int x)
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

        public static ClickableControl Y(this ClickableControl control, int y)
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

        public static ClickableControl Width(this ClickableControl control, int x)
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

        public static ClickableControl Height(this ClickableControl control, int y)
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

        public static ClickableControl ImageUri(this ClickableControl control, string uri)
        {
            control.ImageUri = uri;
            UpdateEmptyUris(control,uri);
            return control;
        }

        public static ClickableControl ControlState(this ClickableControl control, ControlState controlState)
        {
            control.ControlState = controlState;
            return control;
        }

        public static ClickableControl ImageUriHover(this ClickableControl control, string uri)
        {
            control.ImageUriHover = uri;
            UpdateEmptyUris(control, uri);
            return control;
        }

        public static ClickableControl ImageUriDown(this ClickableControl control, string uri)
        {
            control.ImageUriDown = uri;
            UpdateEmptyUris(control, uri);
            return control;
        }

        public static ClickableControl ImageUriDisabled(this ClickableControl control, string uri)
        {
            control.ImageUriDisabled = uri;
            UpdateEmptyUris(control, uri);
            return control;
        }

        private static void UpdateEmptyUris(ClickableControl control, string uri)
        {
            if (control.ImageUriHover == null) control.ImageUriHover = uri;
            if (control.ImageUriDown == null) control.ImageUriDown = uri;
            if (control.ImageUriDisabled == null) control.ImageUriDisabled = uri;
        }
    }
}
