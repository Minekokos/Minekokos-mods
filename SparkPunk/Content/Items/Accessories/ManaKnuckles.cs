using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using SparkPunk.Content.Mechanics;

namespace SparkPunk.Content.Items.Accessories
{
    public class ManaKnuckles : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.buyPrice(10);
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<GlobalPlayer>().KnucklesRegen = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.FleshKnuckles, 1)
            .AddIngredient(ItemID.ManaRegenerationPotion, 3)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
    }
}