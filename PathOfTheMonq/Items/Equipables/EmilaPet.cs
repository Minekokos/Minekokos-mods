using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace PathOfTheMonq.Items.Equipables
{
    public class EmilaPet : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.UnluckyYarn);

            //Item.shoot <projectile.path>
            //Item.buffType <buff.path>
        }
    }
}