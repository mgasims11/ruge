using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ruge.lib.model.controls.interfaces
{
    public interface IResponsive
    {
        string ImageURIHover { get; set; }
        string ImageURIDown { get; set; }
        string ImageURIDisabled { get; set; }
    }
}
