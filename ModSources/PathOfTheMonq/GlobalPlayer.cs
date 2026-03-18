using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace PathOfTheMonq
{
    public class GlobalPlayer : ModPlayer
    {
        // line to add to each custom class item => var linetochange = tooltips.FirstOrDefault(x => x.Name=="Damage" && x.Mod == "Terraria");

        public float ZenDamage = 0f;

        public override void ResetEffects()
        {
            ZenDamage = 0f;
        }
    }
}