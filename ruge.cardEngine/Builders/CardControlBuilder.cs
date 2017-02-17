using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardEngine.Model;
using ruge.lib.model;

namespace ruge.cardEngine.Builders
{
    using ruge.lib.logic;
    using ruge.lib.model.controls;
    using ruge.lib.model.controls.interfaces;

    public static class CardControlBuilder
    {
        public static CardControl Create()
        {
            var control = new CardControl();
            control.ControlId = ControlHelper.GetNewControlID();
            control.ControlState = ControlState.Enabled;
            control.IsVisible = true;
            return control;
        }

        public static CardControl SetX(this CardControl control, double x)
        {
            if (control.Location == null)
            {
                control.Location = new XYPair();
                control.Location.X = x;
                control.Location.Y = 0;
            }
            else
            {
                control.Location.X = x;
            }
            return control;
        }

        public static CardControl SetLocation(this CardControl control, XYPair location)
        {
            control.Location = location;
            return control;
        }

        public static CardControl SetSize(this CardControl control, XYPair size)
        {
            control.Size = size;
            return control;
        }

        public static CardControl SetY(this CardControl control, double y)
        {
            if (control.Location == null)
            {
                control.Location = new XYPair();
                control.Location.X = 0;
                control.Location.Y = y;
            }
            else
            {
                control.Location.Y = y;
            }
            return control;
        }

        public static CardControl SetWidth(this CardControl control, double x)
        {
            if (control.Size == null)
            {
                control.Size = new XYPair();
                control.Size.X = x;
                control.Size.Y = x;
            }
            else
            {
                control.Size.X = x;
            }
            return control;
        }

        public static CardControl SetHeight(this CardControl control, double y)
        {
            if (control.Size == null)
            {
                control.Size = new XYPair();
                control.Size.X = y;
                control.Size.Y = y;
            }
            else
            {
                control.Size.Y = y;
            }
            return control;
        }

        public static CardControl SetImageUriTemplate(this CardControl control, string template, string token)
        {
            SetImageUriTemplate(control, template, token, "normal", "hover", "down", "disabled");
            return control;
        }

        public static CardControl SetImageUriTemplate(this CardControl control, string template, string token, string normal, string hover, string down, string disabled)
        {
            control.ImageUri = template.Replace(token,normal);
            control.ImageUriHover = template.Replace(token, hover);
            control.ImageUriDown = template.Replace(token, down);
            control.ImageUriDisabled = template.Replace(token, disabled);
            return control;
        }

        public static CardControl SetImageUri(this CardControl control, string uri)
        {
            control.ImageUri = uri;
            UpdateEmptyUris(control,uri);
            return control;
        }

        public static CardControl SetControlState(this CardControl control, ControlState controlState)
        {
            control.ControlState = controlState;
            return control;
        }

        public static CardControl SetImageUriHover(this CardControl control, string uri)
        {
            control.ImageUriHover = uri;
            UpdateEmptyUris(control, uri);
            return control;
        }

        public static CardControl SetImageUriDown(this CardControl control, string uri)
        {
            control.ImageUriDown = uri;
            UpdateEmptyUris(control, uri);
            return control;
        }

        public static CardControl SetImageUriDisabled(this CardControl control, string uri)
        {
            control.ImageUriDisabled = uri;
            UpdateEmptyUris(control, uri);
            return control;
        }

        public static CardControl SetAllUris(this CardControl control, string uri)
        {
            control.ImageUri = uri;
            control.ImageUriHover = uri;
            control.ImageUriDown = uri;
            control.ImageUriDisabled = uri;

            return control;
        }

        private static CardControl UpdateEmptyUris(CardControl control, string uri)
        {
            if (control.ImageUriHover == null) control.ImageUriHover = uri;
            if (control.ImageUriDown == null) control.ImageUriDown = uri;
            if (control.ImageUriDisabled == null) control.ImageUriDisabled = uri;

            return control;
        }

        public static CardControl  SetDeckId(this CardControl control, Guid deckId)
        {
            control.DeckId = deckId;

            return control;
        }

        public static CardControl SetIndex(this CardControl control, int index)
        {
            control.Index = index;

            return control;
        }

        public static CardControl SetIsVisible(this CardControl control, bool isVisible)
        {
            control.IsVisible = isVisible;

            return control;
        }

        public static CardControl SetControlId(this CardControl control, Guid cardId)
        {
            control.ControlId = ControlHelper.GetControlID(cardId);

            return control;
        }
    }
}
