using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.Security.Cryptography.X509Certificates;

namespace SparkPunk.Content.Mechanics
{
    public class GlobalPlayer : ModPlayer
    {
        public bool hasStarThorned; //bool for star necklace effect

        public bool KnucklesRegen; //mana knuckles effect activity

        public bool StellarDash = false;

        public const int DashLeft = 2; //using reserved numbers to prevent issues
        public const int DashRight = 3;

        const float RecoilSpeed = 5f;


        public int DashCooldown = 45;
        public int DashDuration = 25;

        public float DashVelocity = 10f;
        public int DashDir = -1;

        public bool DashAccessoryEquipped = false;
        public int DashDelay = 0;
        public int DashTimer = 0;

        public enum DashType
        {
            Stellar = 0,
            invalid = -1
        }

        public override void ResetEffects()
        {
            StellarDash = false;
            DashAccessoryEquipped = false;

            //checking for dash direction
            if (Player.controlRight && Player.releaseRight && Player.doubleTapCardinalTimer[2] < 15)
            {
                DashDir = DashRight;
            }
            else if (Player.controlLeft && Player.releaseLeft && Player.doubleTapCardinalTimer[3] < 15)
            {
                DashDir = DashLeft;
            }
            else
            {
                DashDir = -1;
            }

            //star thorned necklace
            hasStarThorned = false;

            //mana knuckles
            KnucklesRegen = false;
        }


        public override void PostUpdate() //mana knuckles
        {
            if (!KnucklesRegen)
                return;

            float clossestDistance = float.MaxValue;
            foreach (NPC npc in Main.npc)
            {
                if (npc.active && !npc.friendly && !npc.townNPC)
                {
                    float dist = Vector2.Distance(Player.Center, npc.Center);
                    if (dist < clossestDistance)
                        clossestDistance = dist;
                }
            }

            float regenBonus = Math.Clamp(300f - clossestDistance, 0f, 300f) * 30f; //dont forget to divide it instead of multiplying when finished
            Player.manaRegenBonus += (int)regenBonus;

            if (clossestDistance < 50)
                Main.NewText("regen works");
        }


        public override void PreUpdateMovement() // applying the dash
        {
            if (CanUseDash())
            {
                Vector2 newVelocity = Player.velocity;
                Player.statMana -= 20;

                switch (DashDir)
                {
                    case DashLeft when Player.velocity.X > -DashVelocity:
                    case DashRight when Player.velocity.X < DashVelocity:
                        {
                            float DashDirection = DashDir == DashRight ? 1 : -1;
                            newVelocity.X = DashDirection * DashVelocity;

                            //applying shield damage
                            foreach (NPC npc in Main.npc)
                            {
                                if (npc.active && !npc.friendly && npc.Hitbox.Intersects(Player.Hitbox))
                                {
                                    Main.NewText("tento if se spustil");
                                    float dmg = Player.GetDamage(DamageClass.Generic).ApplyTo(30);
                                    int dmgf = (int)Math.Round(dmg);
                                    float kb = 9f * (Player.kbGlove ? 2f : 1f);

                                    //apply damage
                                    npc.SimpleStrikeNPC(dmgf, DashDir, false, kb, DamageClass.Default, false, 0, false);

                                    //recoil
                                    Player.velocity.X = -DashDir * RecoilSpeed;

                                    //apply immunity
                                    Player.immune = true;
                                    Player.immuneTime = 20;
                                    Player.immuneNoBlink = true; // does not work; crying recommended
                                }
                            }

                            break;
                        }
                    default:
                        return;
                }

                DashDelay = DashCooldown;
                DashTimer = DashDuration;
                Player.velocity = newVelocity;
            }

            if (DashDelay > 0) //dash cooldown decrement
                DashDelay--;

            if (DashTimer > 0)
            {
                Player.eocDash = DashTimer;
                DashTimer--;
            }
        }


        private bool CanUseDash() //checking dash availability
        {
            return DashAccessoryEquipped
                && Player.dashType == 0
                && !Player.setSolar
                && DashDir != -1
                && DashDelay == 0
                && Player.statMana > 20
                && !Player.mount.Active;
        }
    }
}