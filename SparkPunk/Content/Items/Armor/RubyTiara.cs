using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
//using SparkPunk.Content.Mechanics.C_CraftingRework;

namespace SparkPunk.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]

    public class RubyTiara : ModItem
    {
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetStaticDefaults()
        {
            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;
            SetBonusText = this.GetLocalization("SetBonus");
            //set bonus text here
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Green;
            Item.defense = 3;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.RubyRobe;
		}
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            player.statDefense += 3;
            player.manaRegenDelay /= 2;
            player.GetAttackSpeed(DamageClass.Magic) += 0.1f;
        }


        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Ruby, 3)
            .AddRecipeGroup("GoldBars", 8)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}