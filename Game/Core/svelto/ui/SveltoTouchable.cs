using System;
using System.Collections.Generic;
using System.Text;

namespace Core.svelto.ui
{
    public enum SveltoTouchable
    {
        Enabled,

        /// <summary>
        /// No touch input events will be received by the element or any children.
        /// </summary>
        Disabled,

        /// <summary>
        /// No touch input events will be received by the element, but children will still receive events. Note that events on the
        /// children will still bubble to the parent.
        /// </summary>
        ChildrenOnly
    }
}
