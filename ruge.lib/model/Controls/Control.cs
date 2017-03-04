using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ruge.lib.model.controls
{
    using controls;
    using ruge.lib.model.controls.interfaces;

    public abstract class Control : IElement
    {
        private int _opacity;
        private int _zOrder;
        private int _rotation;
                
        public string ElementId { get; set; }
        public string ImageUri { get; set; }
        public XYPair Location { get; set; }
        public XYPair Size { get; set; }
        public bool IsVisible { get; set; }

        public int Opacity
        {
            get
            {
                return _opacity;
            }
            set
            {
                if (value > 100 || value < 0) throw new OverflowException("Range for Opacity values is 0 through 100");
                _opacity = value;
            }
        }

        public int ZIndex
        {
            get
            {
                return _zOrder;
            }
            set
            {
                if (value > 100 || value< 0) throw new OverflowException("Range for ZIndex values is 0 through 100");
                _zOrder = value;
            }
        }


        public int Rotation 
        {
            get
            {
                return _rotation;
            }
            set
            {
                if (value > 360 || value< 0) throw new OverflowException("Range for Rotation values is 0 through 360");
                _rotation = value;
            }
        }

        public string Name { get; set; }
    }
}
