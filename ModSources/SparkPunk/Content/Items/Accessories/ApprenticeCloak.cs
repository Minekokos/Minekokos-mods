using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SparkPunk.Content.Items.Accessories
{
    public class ApprenticeCloak : ModItem
    {
        //[AutoloadEquip(EquipType.Back)]
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
            //player.starCloakItem = Item;  ---unused on this item
            if (player.statMana > player.statManaMax2 * 0.8)
            {
                player.GetDamage(DamageClass.Magic) += 0.1f;
            }
            else if (player.statMana > player.statManaMax2 * 0.5)
            {
                player.GetDamage(DamageClass.Magic) += 0.05f;
            }
            else return;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 10)
            .AddIngredient(ItemID.FallenStar, 5)
            .AddRecipeGroup("EvilBars", 8)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}