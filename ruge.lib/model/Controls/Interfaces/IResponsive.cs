using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ruge.lib.model.controls.interfaces
{
    public interface IResponsive
    {
        bool IsEnabled { get; set; }
        string ImageUriHover { get; set; }
        string ImageUriDown { get; set; }
        string ImageUriDisabled { get; set; }
    }
}
