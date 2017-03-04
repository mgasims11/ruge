using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ruge.lib.model.controls
{
   using controls;
    using ruge.lib.model.controls.interfaces;
    public class TextInputControl : Control, IText, IResponsive
    {
        public bool IsEnabled { get; set; }
        public string ImageUriDisabled { get; set; }
        public string ImageUriDown { get; set; }
        public string ImageUriHover { get; set; }
        public string Text { get; set; }        
    }
}
