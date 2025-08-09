using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace SparkPunk.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]

    public class AmethystTiara : ModItem
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
            Item.value = Item.sellPrice(silver: 40);
            Item.rare = ItemRarityID.White;
            Item.defense = 2;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.AmethystRobe;
		}
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            player.statDefense += 1;
            player.manaRegenDelay /= 2;
        }


        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Amethyst, 3)
            .AddRecipeGroup("CopperBars", 8)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}