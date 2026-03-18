using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SparkPunk.Content.Items.Accessories
{
    public class StellarEmblem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.buyPrice(10);
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) //increases dmg and applies mana flower effect
        {
            player.GetDamage(DamageClass.Magic) += 0.15f;

            if (player.statMana < 20 /*player.statManaMax2 * 0.1f*/)
            {
                player.QuickMana();
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.AvengerEmblem, 1)
            .AddIngredient(ItemID.ManaFlower, 1)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
    }
}