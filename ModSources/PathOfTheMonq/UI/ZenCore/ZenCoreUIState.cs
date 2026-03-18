using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace PathOfTheMonq.UI.ZenCore
{
    class ButtonUIState : UIState
    {   
        //making button ready to be drawn
        public ZenCoreUIElement button1;

        public override void OnInitialize()
        {
            button1 = new ZenCoreUIElement(); //example button + premade vanilla sprite
            Append(button1);

            UIPanel panel = new UIPanel(); //"procedural" box
            panel.Width.Set(100, 0);
            panel.Height.Set(30, 0);
            panel.HAlign = 0.5f; //behaves as float, not as pixels, so 1 = whole screen offset
            panel.VAlign = 0.43f;
            Append(panel);
        }
    }
}