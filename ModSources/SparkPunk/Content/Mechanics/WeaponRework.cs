using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Configuration;

public class C_WeaponRework : GlobalItem
{
    public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
    {
        if (item.type == ItemID.DemonScythe)
        {
            item.damage = 48;
        }

        if (item.type == ItemID.RubyStaff)
        {
            item.damage = 23;
        }

        if (item.type == ItemID.SapphireStaff)
        {
            item.damage = 19;
        }

        if (item.type == ItemID.AmethystStaff)
        {
            item.damage = 16;
        }

        if (item.type == ItemID.FlowerofFire)
        {
            item.damage = 32;
        }

        if (item.type == ItemID.CrimsonRod)
        {
            item.damage = 18;
        }

        if (item.type == ItemID.Starfury)
        {
            item.damage = 28;
        }
    }

    public override void SetDefaults(Item item)
    {
        if (item.type == ItemID.RubyStaff) //ruby staff
        {
            item.mana = 8;
            item.knockBack = 5.5f;
            item.useTime = 26;
            item.rare = ItemRarityID.Green;
        }

        if (item.type == ItemID.SapphireStaff) //sapphire staff --------------- needs to increase penetration
        {
            item.knockBack = 4.25f;
            item.useTime = 32;
        }

        if (item.type == ItemID.AmethystStaff) //amethyst staff
        {
            item.knockBack = 3.5f;
            item.useTime = 36;
        }

        if (item.type == ItemID.FlowerofFire) //flower of fire
        {
            item.rare = ItemRarityID.Green;
        }

        if (item.type == ItemID.Starfury)
        {
            item.mana = 8;
            item.DamageType = DamageClass.Magic;
            item.autoReuse = true;
        }
    }
    public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        if (item.type == ItemID.DiamondStaff || item.type == ItemID.RubyStaff) //changing velocity of Diamond/Ruby projectiles
        {
            velocity *= 3f;
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            return false;
        }
        if (item.type == ItemID.SapphireStaff) //changing velocity of Sapphire projectiles
        {
            velocity *= 2.5f;
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            return false;
        }
        if (item.type == ItemID.EmeraldStaff) //changing velocity of emerald projectiles
        {
            velocity *= 2.5f;
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            return false;
        }
        if (item.type == ItemID.AmethystStaff || item.type == ItemID.TopazStaff) //changing velocity of Amethyst/Topaz projectiles
        {
            velocity *= 2f;
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            return false;
        }
        return true;
    }
}