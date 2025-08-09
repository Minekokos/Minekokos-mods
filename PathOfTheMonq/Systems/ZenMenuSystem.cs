using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using PathOfTheMonq.UI;

namespace PathOfTheMonq.Systems
{
	public class ZenMenuSystem : ModSystem
	{
		private static UserInterface _interface;
		private static ZenMenuUI _menu;
        
        public static bool IsVisible => _interface?.CurrentState != null;


		public override void Load()
        {
            if (!Main.dedServ)
            {
                _interface = new UserInterface();
                _menu = new ZenMenuUI();
                _menu.Activate();
            }
        }

		public override void UpdateUI(GameTime gameTime)
		{
			_interface?.Update(gameTime);
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int inventoryIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
			if (inventoryIndex != -1)
			{
				layers.Insert(inventoryIndex, new LegacyGameInterfaceLayer(
					"ZenMenu: UI",
					() =>
					{
						if (_interface?.CurrentState != null)
							_interface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI
				));
			}
		}

		public static void Show()
		{
			_interface?.SetState(_menu);
		}

		public static void Hide()
		{
			_interface?.SetState(null);
		}
	}
}
