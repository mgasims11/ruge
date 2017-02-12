using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardEngine.Model;
using ruge.lib.model;

namespace ruge.cardEngine.logic
{
    using ruge.lib.logic;
    using ruge.lib.model.controls;
    using ruge.lib.model.controls.interfaces;

    public static class CardControlMaker
    {
        public static CardControl Create()
        {
            var control = new CardControl();
            control.ControlId = ControlHelper.GetNewControlID();
            return control;
        }

        public static CardControl X(this CardControl control, int x)
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

        public static CardControl Y(this CardControl control, int y)
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

        public static CardControl Width(this CardControl control, int x)
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

        public static CardControl Height(this CardControl control, int y)
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

        public static CardControl UseImageUriTemplate(this CardControl control, string template, string token)
        {
            UseImageUriTemplate(control, template, token, "normal", "hover", "down", "disabled");
            return control;
        }

        public static CardControl UseImageUriTemplate(this CardControl control, string template, string token, string normal, string hover, string down, string disabled)
        {
            control.ImageUri = template.Replace(token,normal);
            control.ImageUriHover = template.Replace(token, hover);
            control.ImageUriDown = template.Replace(token, down);
            control.ImageUriDisabled = template.Replace(token, disabled);
            return control;
        }

        public static CardControl ImageUri(this CardControl control, string uri)
        {
            control.ImageUri = uri;
            UpdateEmptyUris(control,uri);
            return control;
        }

        public static CardControl ControlState(this CardControl control, ControlState controlState)
        {
            control.ControlState = controlState;
            return control;
        }

        public static CardControl ImageUriHover(this CardControl control, string uri)
        {
            control.ImageUriHover = uri;
            UpdateEmptyUris(control, uri);
            return control;
        }

        public static CardControl ImageUriDown(this CardControl control, string uri)
        {
            control.ImageUriDown = uri;
            UpdateEmptyUris(control, uri);
            return control;
        }

        public static CardControl ImageUriDisabled(this CardControl control, string uri)
        {
            control.ImageUriDisabled = uri;
            UpdateEmptyUris(control, uri);
            return control;
        }

        public static CardControl AllUris(this CardControl control, string uri)
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

        public static CardControl DeckId(this CardControl control, Guid deckId)
        {
            control.DeckId = deckId;

            return control;
        }

        public static CardControl Index(this CardControl control, int index)
        {
            control.Index = index;

            return control;
        }

        public static CardControl IsVisible(this CardControl control, Boolean isVisible)
        {
            control.IsVisible = isVisible;

            return control;
        }

        public static CardControl ControlId(this CardControl control, Guid cardId)
        {
            control.ControlId = ControlHelper.GetControlID(cardId);

            return control;
        }
    }
}
