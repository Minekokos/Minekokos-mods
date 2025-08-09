using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using SparkPunk.Content.Mechanics;

namespace SparkPunk.Content.Items.Accessories
{
    public class StarThornedNecklace : ModItem
    {
        public bool StarThornedNecklaceEquipped = false;
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
            player.GetModPlayer<GlobalPlayer>().hasStarThorned = true;
            //Main.NewText("Necklace active");
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.SharkToothNecklace, 1)
            .AddIngredient(ItemID.NaturesGift, 1)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
    }
}