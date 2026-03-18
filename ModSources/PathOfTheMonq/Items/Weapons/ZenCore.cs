using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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
	}
}