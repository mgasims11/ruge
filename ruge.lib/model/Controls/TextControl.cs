using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ruge.lib.model.controls
{
    using controls;
    using ruge.lib.model.controls.interfaces;
    public class TextControl : Control, IText, IResponsive
    {
        public string ImageUriDisabled { get; set; }
        public string ImageUriDown { get; set; }
        public string ImageUriHover { get; set; }
        public bool IsEnabled { get; set; }
        public Behaviors Behavior { get; set; }
        public string Text { get; set; }
    }
}
