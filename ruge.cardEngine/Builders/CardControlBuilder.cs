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
            var cardControl = new CardControl();
            cardControl.ElementId = ControlHelper.GetNewControlID();
            cardControl.IsEnabled = true;
            cardControl.Opacity = 100;
            return cardControl;
        }

        public static CardControl SetX(this CardControl cardControl, double x)
        {
            if (cardControl.Location == null)
            {
                cardControl.Location = new XYPair();
                cardControl.Location.X = x;
                cardControl.Location.Y = 0;
            }
            else
            {
                cardControl.Location.X = x;
            }
            return cardControl;
        }

        public static CardControl SetBehavior(this CardControl cardControl, Behaviors behavior)
        {
            cardControl.Behavior = behavior;
            return cardControl;
        }

        public static CardControl SetLocation(this CardControl cardControl, XYPair location)
        {
            cardControl.Location = location;
            return cardControl;
        }

        public static CardControl SetIsVisible(this CardControl cardControl, bool isVisible)
        {
            cardControl.IsVisible = isVisible;
            return cardControl;
        }

        public static CardControl SetOpacity(this CardControl cardControl, int opacity)
        {
            cardControl.Opacity = opacity;
            return cardControl;
        }

        public static CardControl SetSize(this CardControl cardControl, XYPair size)
        {
            cardControl.Size = size;
            return cardControl;
        }

        public static CardControl SetY(this CardControl cardControl, double y)
        {
            if (cardControl.Location == null)
            {
                cardControl.Location = new XYPair();
                cardControl.Location.X = 0;
                cardControl.Location.Y = y;
            }
            else
            {
                cardControl.Location.Y = y;
            }
            return cardControl;
        }

        public static CardControl SetWidth(this CardControl cardControl, double x)
        {
            if (cardControl.Size == null)
            {
                cardControl.Size = new XYPair();
                cardControl.Size.X = x;
                cardControl.Size.Y = x;
            }
            else
            {
                cardControl.Size.X = x;
            }
            return cardControl;
        }

        public static CardControl SetHeight(this CardControl cardControl, double y)
        {
            if (cardControl.Size == null)
            {
                cardControl.Size = new XYPair();
                cardControl.Size.X = y;
                cardControl.Size.Y = y;
            }
            else
            {
                cardControl.Size.Y = y;
            }
            return cardControl;
        }

        public static CardControl SetImageUriTemplate(this CardControl cardControl, string template, string token)
        {
            SetImageUriTemplate(cardControl, template, token, "normal", "hover", "down", "disabled");
            return cardControl;
        }

        public static CardControl SetImageUriTemplate(this CardControl cardControl, string template, string token, string normal, string hover, string down, string disabled)
        {
            cardControl.ImageUri = template.Replace(token,normal);
            cardControl.ImageUriHover = template.Replace(token, hover);
            cardControl.ImageUriDown = template.Replace(token, down);
            cardControl.ImageUriDisabled = template.Replace(token, disabled);
            return cardControl;
        }

        public static CardControl SetImageUri(this CardControl cardControl, string uri)
        {
            cardControl.ImageUri = uri;
            UpdateEmptyUris(cardControl, uri);
            return cardControl;
        }

        public static CardControl SetIsEnabled(this CardControl cardControl, bool isEnabled)
        {
            cardControl.IsEnabled = isEnabled;
            return cardControl;
        }

        public static CardControl SetImageUriHover(this CardControl cardControl, string uri)
        {
            cardControl.ImageUriHover = uri;
            UpdateEmptyUris(cardControl, uri);
            return cardControl;
        }

        public static CardControl SetImageUriDown(this CardControl cardControl, string uri)
        {
            cardControl.ImageUriDown = uri;
            UpdateEmptyUris(cardControl, uri);
            return cardControl;
        }

        public static CardControl SetImageUriDisabled(this CardControl cardControl, string uri)
        {
            cardControl.ImageUriDisabled = uri;
            UpdateEmptyUris(cardControl, uri);
            return cardControl;
        }

        public static CardControl SetAllUris(this CardControl cardControl, string uri)
        {
            cardControl.ImageUri = uri;
            cardControl.ImageUriHover = uri;
            cardControl.ImageUriDown = uri;
            cardControl.ImageUriDisabled = uri;

            return cardControl;
        }

        private static CardControl UpdateEmptyUris(CardControl cardControl, string uri)
        {
            if (cardControl.ImageUriHover == null) cardControl.ImageUriHover = uri;
            if (cardControl.ImageUriDown == null) cardControl.ImageUriDown = uri;
            if (cardControl.ImageUriDisabled == null) cardControl.ImageUriDisabled = uri;

            return cardControl;
        }

        public static CardControl  SetDeck(this CardControl cardControl, Deck deck)
        {
            cardControl.Deck = deck;

            return cardControl;
        }

        public static CardControl SetIndex(this CardControl cardControl, int index)
        {
            cardControl.Index = index;

            return cardControl;
        }

        public static CardControl SetControlId(this CardControl cardControl, Guid cardId)
        {
            cardControl.ElementId = ControlHelper.GetControlID(cardId);

            return cardControl;
        }

        public static CardControl SetZIndex(this CardControl cardControl, int zOrder)
        {
            cardControl.ZIndex = zOrder;

            return cardControl;
        }

        public static CardControl SetName(this CardControl control, string name)
        {
            control.Name = name;
            return control;
        }
    }
}
