using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;
using Terraria;

namespace PathOfTheMonq.UI
{
	public class ZenMenuUI : UIState
	{
		public override void OnInitialize()
		{
			UIText text = new UIText("Element Picker (Test)");
			text.Left.Set(400f, 0f);
			text.Top.Set(200f, 0f);
			Append(text);
		}
	}
}
