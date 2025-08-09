using Terraria.UI;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace PathOfTheMonq.UI
{
	public class ZenElementBar : UIState
	{
		public static readonly string[] ElementNames = { "Earth", "Water", "Air", "Fire" };

		public override void OnInitialize()
		{
			UIElement panel = new UIElement();
			panel.Width.Set(0f, 0f);
			panel.Height.Set(60f, 0f);
			panel.Top.Set(100f, 0f);
			panel.HAlign = 0.5f;

			float spacing = 10f;
			float iconSize = 40f;

			for (int i = 0; i < ElementNames.Length; i++)
			{
				var icon = new ZenElementIcon(ElementNames[i]);
				icon.Width.Set(iconSize, 0f);
				icon.Height.Set(iconSize, 0f);
				icon.Left.Set(i * (iconSize + spacing), 0f);
				panel.Append(icon);
			}

			Append(panel);
		}
	}
}