using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ruge.lib.model.controls
{
   using controls;
    using ruge.lib.model.controls.interfaces;
    public class ClickableControl : Control, IResponsive
    {
        public string ImageUriDisabled { get; set; }
        public string ImageUriDown { get; set; }
        public string ImageUriHover { get; set; }
    }
}
