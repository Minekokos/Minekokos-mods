using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SparkPunk.Content.Items.Accessories
{
    public class JourneymanCloak : ModItem
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
            if (player.statMana > player.statManaMax2 * 0.8) //apprentice cloak effect
            {
                player.GetDamage(DamageClass.Magic) += 0.1f;
            }
            else if (player.statMana > player.statManaMax2 * 0.5)
            {
                player.GetDamage(DamageClass.Magic) += 0.05f;
            }
            else return; 
            //-------------------

            int MagnetRange = 400; //celestial magnet effect

            foreach (Item item in Main.item)
            {
                if (!item.active || item.type != ItemID.Star) continue;

                float distance = Vector2.Distance(item.Center, player.Center);

                if (distance < MagnetRange)
                {
                    Vector2 moveDirection = player.Center - item.Center;
                    moveDirection.Normalize();
                    moveDirection *= 1.5f;
                    item.velocity += moveDirection;
                }
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Content.Items.Accessories.ApprenticeCloak>())
            .AddIngredient(ItemID.CelestialMagnet)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
    }
}