using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class C_CraftingRework : ModSystem
{
    //registering material groups
    public override void AddRecipeGroups()
    {
        RecipeGroup group1 = new RecipeGroup(() => "Shadow Scale or Tissue Sample", new int[] //evil boss drops
        {
            ItemID.ShadowScale,
            ItemID.TissueSample
        });
        RecipeGroup.RegisterGroup("EvilMaterials", group1);

        RecipeGroup group2 = new RecipeGroup(() => "Gold Bar or Platinum Bar", new int[] //gold + platinum
        {
            ItemID.GoldBar,
            ItemID.PlatinumBar
        });
        RecipeGroup.RegisterGroup("GoldBars", group2);

        RecipeGroup group3 = new RecipeGroup(() => "Silver Bar or Tungsten Bar", new int[] //silver + tungsten
        {
            ItemID.SilverBar,
            ItemID.TungstenBar
        });
        RecipeGroup.RegisterGroup("SilverBars", group3);

        RecipeGroup group4 = new RecipeGroup(() => "Copper Bar or Tin Bar", new int[] // copper + tin
        {
            ItemID.CopperBar,
            ItemID.TinBar
        });
        RecipeGroup.RegisterGroup("CopperBars", group4);

        RecipeGroup group5 = new RecipeGroup(() => "Any Evil Bar", new int[] // demonite + crimtane
        {
            ItemID.DemoniteBar,
            ItemID.CrimtaneBar
        });
        RecipeGroup.RegisterGroup("EvilBars", group5);
    }


    public override void AddRecipes() //creating recipes for existing items
    {
            Recipe recipe = Recipe.Create(ItemID.FlowerofFire);
            recipe.AddIngredient(ItemID.MeteoriteBar, 12);
            recipe.AddIngredient(ItemID.YellowMarigold, 1);
            recipe.AddIngredient(ItemID.WandofSparking, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        

            Recipe recipe1 = Recipe.Create(ItemID.WandofSparking);
            recipe1.AddRecipeGroup("Wood", 15);
            recipe1.AddIngredient(ItemID.Torch, 3);
            recipe1.AddTile(TileID.WorkBenches);
            recipe1.Register();
    }

    public override void PostAddRecipes()
    {
        foreach (var recipe in Main.recipe)
        {

            //adding materials
            if (recipe.createItem.type == ItemID.JungleShirt) //jungle shirt
            {
                recipe.AddRecipeGroup("EvilMaterials", 12);
            }
            if (recipe.createItem.type == ItemID.JungleHat) //jungle hat
            {
                recipe.AddRecipeGroup("EvilMaterials", 8);
            }
            if (recipe.createItem.type == ItemID.JunglePants) //jungle pants
            {
                recipe.AddRecipeGroup("EvilMaterials", 10);
            }

            //changing quantity of needed materials
            // ROBES
            if (recipe.createItem.type == ItemID.DiamondRobe) //diamond robe - making crafting cheaper
            {
                foreach (var ingredient in recipe.requiredItem)
                {
                    if (ingredient.type == ItemID.Diamond)
                    {
                        ingredient.stack = 6;
                    }
                }
            }
            if (recipe.createItem.type == ItemID.RubyRobe) //ruby robe
            {
                foreach (var ingredient in recipe.requiredItem)
                {
                    if (ingredient.type == ItemID.Ruby)
                    {
                        ingredient.stack = 6;
                    }
                }
            }
            if (recipe.createItem.type == ItemID.EmeraldRobe) //Emerald robe
            {
                foreach (var ingredient in recipe.requiredItem)
                {
                    if (ingredient.type == ItemID.Emerald)
                    {
                        ingredient.stack = 6;
                    }
                }
            }
            if (recipe.createItem.type == ItemID.SapphireRobe) //Saphire robe
            {
                foreach (var ingredient in recipe.requiredItem)
                {
                    if (ingredient.type == ItemID.Sapphire)
                    {
                        ingredient.stack = 6;
                    }
                }
            }
            if (recipe.createItem.type == ItemID.AmethystRobe) //Amethyst robe
            {
                foreach (var ingredient in recipe.requiredItem)
                {
                    if (ingredient.type == ItemID.Amethyst)
                    {
                        ingredient.stack = 5;
                    }
                }
            }
            if (recipe.createItem.type == ItemID.TopazRobe) //Topaz robe
            {
                foreach (var ingredient in recipe.requiredItem)
                {
                    if (ingredient.type == ItemID.Topaz)
                    {
                        ingredient.stack = 5;
                    }
                }
            }

            //STAVES - slewniyni a nahradzyni barów, 
            if (recipe.createItem.type == ItemID.DiamondStaff) //Diamond Staff
            {
                foreach (var ingredient in recipe.requiredItem)
                {
                    if (ingredient.type == ItemID.Diamond)
                    {
                        ingredient.stack = 5;
                    }
                }
                recipe.requiredItem.RemoveAll(item => item.type == ItemID.PlatinumBar);
                recipe.AddRecipeGroup("GoldBars", 8);
            }

            if (recipe.createItem.type == ItemID.RubyStaff) //Ruby Staff
            {
                foreach (var ingredient in recipe.requiredItem)
                {
                    if (ingredient.type == ItemID.Ruby)
                    {
                        ingredient.stack = 5;
                    }
                }
                recipe.requiredItem.RemoveAll(item => item.type == ItemID.GoldBar);
                recipe.AddRecipeGroup("GoldBars", 8);
            }

            if (recipe.createItem.type == ItemID.EmeraldStaff) //Emerald Staff
            {
                foreach (var ingredient in recipe.requiredItem)
                {
                    if (ingredient.type == ItemID.Emerald)
                    {
                        ingredient.stack = 5;
                    }
                }
                recipe.requiredItem.RemoveAll(item => item.type == ItemID.TungstenBar); //Sapphire Staff
                recipe.AddRecipeGroup("SilverBars", 8);
            }

            if (recipe.createItem.type == ItemID.SapphireStaff)
            {
                foreach (var ingredient in recipe.requiredItem)
                {
                    if (ingredient.type == ItemID.Sapphire)
                    {
                        ingredient.stack = 5;
                    }
                }
                recipe.requiredItem.RemoveAll(item => item.type == ItemID.SilverBar);
                recipe.AddRecipeGroup("SilverBars", 8);
            }

            if (recipe.createItem.type == ItemID.AmethystStaff) //Amethyst Staff
            {
                foreach (var ingredient in recipe.requiredItem)
                {
                    if (ingredient.type == ItemID.Amethyst)
                    {
                        ingredient.stack = 5;
                    }
                }
                recipe.requiredItem.RemoveAll(item => item.type == ItemID.CopperBar);
                recipe.AddRecipeGroup("CopperBars", 8);
            }

            if (recipe.createItem.type == ItemID.TopazStaff) //Topaz Staff
            {
                foreach (var ingredient in recipe.requiredItem)
                {
                    if (ingredient.type == ItemID.Topaz)
                    {
                        ingredient.stack = 5;
                    }
                }
                recipe.requiredItem.RemoveAll(item => item.type == ItemID.TinBar);
                recipe.AddRecipeGroup("CopperBars", 8);
            }
        }
    }
}