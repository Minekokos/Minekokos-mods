using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework; //needs sprite--------------

namespace PathOfTheMonq.Items.Weapons
{
    public class StellarKunai : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.DamageType = DamageClass.Melee;
            Item.damage = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.staff[staff] = true; //potential error - animation of throwing weapon
            Item.useAnimation = 10;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.rare = ItemRarityID.Cyan;
        }

        public override void MofifyTooltips(List<TooltipLine> tooltips)
        {
            var LineToChange = tooltips.FirstOrDefault(x => x.Name=="Damage" && x.Mod == "Terraria");
            if (LineToChange != null)
            {
                string[] split = LineToChange.Text.Split(" "); //potential error - wrong apostrophes
                LineToChange.Text = split.First()+" zen " + split.Last();
            }
        }

        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            damage += player.GetModPlayer<GlobalPlayer>().ZenDamage;
        }
    }
}