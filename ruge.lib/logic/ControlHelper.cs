using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ruge.lib.logic
{
    public static class ControlHelper
    {
        public static string GetNewControlID()
        {
            return "C" + Guid.NewGuid().ToString().Replace("-", "");
        }

        public static string GetControlID(Guid guid)
        {
            return "C" + guid.ToString().Replace("-", "");
        }

    }
}
