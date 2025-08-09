using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader.UI;

public class C_ArmorRework : GlobalItem
{
    public override void UpdateEquip(Item item, Player player) //update equip
    {
        if (item.type == ItemID.RubyRobe) //ruby robe
        {
            player.manaCost = 0.15f;
            player.statManaMax2 += 20;
        }

        if (item.type == ItemID.SapphireRobe) //sapphire robe
        {
            player.manaCost = 0.11f;
            player.statManaMax2 += 20;
        }

        if (item.type == ItemID.AmethystRobe) //amethyst robe
        {
            player.manaCost = 0.07f;
            player.statManaMax2 += 20;
        }
    }
    public override void SetDefaults(Item item) //set defaults
    {
        if (item.type == ItemID.RubyRobe) //ruby robe
        {
            item.defense = 3;
            item.rare = ItemRarityID.Green;
        }

        if (item.type == ItemID.SapphireRobe) //sapphire robe
        {
            item.defense = 2;
        }

        if (item.type == ItemID.AmethystRobe) //amethyst robe
        {
            item.defense = 1;
        }
    }

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) //tooltip rewrite
    {
        if (item.type == ItemID.RubyRobe) //ruby robe
        {
            tooltips.RemoveAll(t => t.Text.Contains("mana"));
            tooltips.Add(new TooltipLine(Mod, "Tooltip0", Language.GetTextValue("Increases maximum mana by 80\n" +
            "15% reduced mana cost")));
        }

        if (item.type == ItemID.SapphireRobe) //sapphire robe
        {
            tooltips.RemoveAll(t => t.Text.Contains("mana"));
            tooltips.Add(new TooltipLine(Mod, "Tooltip0", Language.GetTextValue("Increases maximum mana by 60\n" +
            "11% reduced mana cost")));
        }

        if (item.type == ItemID.AmethystRobe) //amethyst robe
        {
            tooltips.RemoveAll(t => t.Text.Contains("mana"));
            tooltips.Add(new TooltipLine(Mod, "Tooltip0", Language.GetTextValue("Increases maximum mana by 40\n" +
            "7% reduced mana cost")));
        }
    }
}