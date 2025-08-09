using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

public class C_ProjectileRework : GlobalProjectile
{
    public override void SetDefaults(Projectile projectile)
    {
        if (projectile.type == ProjectileID.SapphireBolt)
        {
            projectile.penetrate = 2;
        }

        if (projectile.type == ProjectileID.RubyBolt || projectile.type == ProjectileID.DiamondBolt)
        {
            projectile.penetrate = 3;
        }

        if (projectile.type == ProjectileID.Starfury)
        {
            projectile.DamageType = DamageClass.Magic;
        }
    }
    public override void OnSpawn(Projectile projectile, IEntitySource source)
    {
        if (projectile.type == ProjectileID.Starfury)
        {
            projectile.damage = 30;
        }
    }
}