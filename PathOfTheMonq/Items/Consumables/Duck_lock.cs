using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace PathOfTheMonq.Items.Consumables
{
    public class Duck_lock : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ItemRarityID.Cyan;
            Item.sellPrice(silver = 1);
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.anyNPCs(ModContent.NPCType<Doosh_HAn_body>);
        }


        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Duck)
            .AddIngredient(ItemID.Lock)
            .AddTile(TileID.DemonAltars)
            .Register();
        } 
    }
}