using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace PathOfTheMonq.Items.Weapons
{
    public class StellarSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.DamageType = DamageClass.Melee;
            Item.damage = 25;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 10;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.rare = ItemRarityID.Cyan;
        }
    }
}