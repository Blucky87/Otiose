using System;
using System.Collections.Generic;
using System.Text;

namespace Core.svelto.ui
{
    public interface ISveltoGamepadFocusable
    {
        bool shouldUseExplicitFocusableControl { get; set; }
        ISveltoGamepadFocusable gamepadUpElement { get; set; }
        ISveltoGamepadFocusable gamepadDownElement { get; set; }
        ISveltoGamepadFocusable gamepadLeftElement { get; set; }
        ISveltoGamepadFocusable gamepadRightElement { get; set; }


        /// <summary>
        /// enables shouldUseExplicitFocusableControl and sets the elements corresponding to each direction
        /// </summary>
        /// <param name="upEle">Up ele.</param>
        /// <param name="downEle">Down ele.</param>
        /// <param name="leftEle">Left ele.</param>
        /// <param name="rightEle">Right ele.</param>
        void enableExplicitFocusableControl(ISveltoGamepadFocusable upEle, ISveltoGamepadFocusable downEle, ISveltoGamepadFocusable leftEle, ISveltoGamepadFocusable rightEle);

        /// <summary>
        /// called only when the following conditions are met:
        /// - shouldUseExplicitFocusableControl is true
        /// - this Element is focused
        /// - a gamepad direction was pressed with a null gamepadDIRECTIONElement
        /// </summary>
        /// <param name="sveltoDirection">Direction.</param>
        void onUnhandledDirectionPressed(SveltoDirection sveltoDirection);

        /// <summary>
        /// called when gamepad focuses on the Element
        /// </summary>
        void onFocused();

        /// <summary>
        /// called when gamepad focus is removed from the Element
        /// </summary>
        void onUnfocused();

        /// <summary>
        /// called when the action button is pressed while the Element is focused
        /// </summary>
        void onActionButtonPressed();

        /// <summary>
        /// called when the action button is released while the Element is focused
        /// </summary>
        void onActionButtonReleased();
    }
}
