using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PathOfTheMonq.Systems;

namespace PathOfTheMonq.Items.Weapons
{
	public class ZenCore : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.useAnimation = 10;
			Item.useTime = 10;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.rare = ItemRarityID.LightRed;
			Item.noMelee = true;
		}

		public override void HoldItem(Player player)
		{
			if (Main.mouseRight && Main.mouseRightRelease && !ZenMenuSystem.IsVisible)
			{
				ZenMenuSystem.Show();
			}
		}
		public override bool AltFunctionUse(Player player) => true;

		public override bool CanUseItem(Player player)
		{
 		   if (player.altFunctionUse == 2) // Right Click
 		   {
 		       if (ZenMenuSystem.IsVisible)
 		           ZenMenuSystem.Hide();
 		       else
 		           ZenMenuSystem.Show();

 		       return false; // zabráníme normálnímu použití
  		  }

  		  return base.CanUseItem(player);
		}

	}
}
