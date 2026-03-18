using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using SparkPunk.Content.Mechanics;

namespace SparkPunk.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)] //showing shield sprite
	public class StellarShield : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = Item.buyPrice(10);
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<GlobalPlayer>().StellarDash = true;
			player.GetModPlayer<GlobalPlayer>().DashAccessoryEquipped = true;
		}

		/*public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.EoCShield, 1)
			.AddIngredient(ItemID.ManaRegenerationBand, 1)
			.AddTile(TileID.TinkerersWorkbench)
			.Register();
		}*/
	}
}