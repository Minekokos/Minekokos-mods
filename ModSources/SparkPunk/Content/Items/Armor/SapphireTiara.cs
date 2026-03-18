using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace SparkPunk.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]

    public class SapphireTiara : ModItem
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
            Item.value = Item.sellPrice(silver: 80);
            Item.rare = ItemRarityID.Blue;
            Item.defense = 2;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.SapphireRobe;
		}
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            player.statDefense += 2;
            player.GetAttackSpeed(DamageClass.Magic) += 0.08f;
        }


        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Sapphire, 3)
            .AddRecipeGroup("SilverBars", 8)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}