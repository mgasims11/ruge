using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ruge.lib.model.controls.interfaces
{
    public interface IResponsive
    {
        string ImageUriHover { get; set; }
        string ImageUriDown { get; set; }
        string ImageUriDisabled { get; set; }
    }
}
