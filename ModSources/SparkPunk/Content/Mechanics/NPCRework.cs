using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using Terraria.DataStructures;
using SparkPunk.Content.Items.Accessories;
using SparkPunk.Content.Mechanics;

public class NPCsRework : GlobalNPC
{
    public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
    {
        //blocks demon scythe from being dropped by demons
        if (npc.type == NPCID.Demon || npc.type == NPCID.VoodooDemon)
        {
            npcLoot.RemoveWhere(rule =>
            {
                if (rule is CommonDrop drop)
                {
                    return drop.itemId == ItemID.DemonScythe;
                }
                return false;
            });
        }

        //modifies mana drop chance for Star Thorned Necklace
        if (DontDropMana)
        {
            npcLoot.RemoveWhere(rule =>
            {
                if (rule is CommonDrop drop)
                {
                    return drop.itemId == ItemID.Star;
                }
                return false;
            });
        }
    }

    private bool DontDropMana = false;
    public override bool InstancePerEntity => true;
    public override void ResetEffects(NPC npc)
    {
        DontDropMana = false;
    }

    public override void OnHitByItem(NPC npc, Player player, Item item, NPC.HitInfo hit, int damageDone) //detecting hit
    {
        TryDropManaStar(npc, player);
        DontDropMana = true;
    }
    public override void OnHitByProjectile(NPC npc, Projectile projectile, NPC.HitInfo hit, int damageDone)
    {
        if (projectile.owner != -1 && Main.player[projectile.owner] is Player player)
        {
            TryDropManaStar(npc, player);
            DontDropMana = true;
        }
    }

    private void TryDropManaStar(NPC npc, Player player)
    {
        if (player.GetModPlayer<GlobalPlayer>().hasStarThorned && Main.rand.NextFloat() < 0.05f) //drop chance
        {
            Vector2 spawnPos = npc.Center;
            int index = Item.NewItem(npc.GetSource_Loot(), spawnPos, Vector2.Zero, ItemID.Star, 1);
            if (Main.netMode == NetmodeID.MultiplayerClient && index >= 0)
            {
                NetMessage.SendData(MessageID.SyncItem, number: index);
            }
        }
    }
}