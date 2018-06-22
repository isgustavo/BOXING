using UnityEngine;

namespace ODT.UI.Util
{
    public class UIPunchButtonBehaviour : UIButtonBehaviour
    {
        public static string VIRTUAL_PUNCH_BUTTON_VALUE = "Punch";

        public override string Input()
        {
            return VIRTUAL_PUNCH_BUTTON_VALUE;
        }
    }
}
