using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SparkPunk.Content.Items.Accessories
{
    public class MagicGlove : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.buyPrice(10);
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetAttackSpeed(DamageClass.Magic) += 0.15f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.FeralClaws, 1)
            .AddIngredient(ItemID.ManaCrystal, 1)
            .AddIngredient(ItemID.CrystalShard, 10) //might change that
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
    }
}