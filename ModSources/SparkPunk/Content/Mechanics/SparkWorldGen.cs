using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace SparkPunk.Content.Mechanics
{
    public class WorldGenRework : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight) // replacing flower of fire by demon scythe in shadow chests
        {
            int index = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
            if (index != -1)
            {
                tasks.Insert(index + 1, new PassLegacy("Replace Shadow Chest Loot", ReplaceShadowLoot));
            }
        }
        private void ReplaceShadowLoot(GenerationProgress progress, GameConfiguration config)
        {
            for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest == null) continue;

                Tile tile = Main.tile[chest.x, chest.y];

                if (tile.TileType == TileID.Containers && tile.TileFrameX == 4 * 36)
                {
                    for (int i = 0; i < chest.item.Length; i++)
                    {
                        if (chest.item[i].type == ItemID.FlowerofFire)
                        {
                            chest.item[i].SetDefaults(ItemID.DemonScythe);
                            chest.item[i].Prefix(-1);
                            break;
                        }
                    }
                }
            }
        }
    }
}