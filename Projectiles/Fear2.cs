using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using AlchemistNPCRebornAgain.Items.Weapons;

namespace AlchemistNPCRebornAgain.Projectiles
{
    public class Fear2 : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.width = 256;
            Projectile.height = 256;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 1;
            Projectile.tileCollide = false;
            Projectile.usesLocalNPCImmunity = true;
        }


        public override void AI()
        {
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                if (target.active && !target.friendly && !target.townNPC && !target.boss)
                {
                    if (target.Hitbox.Intersects(Projectile.Hitbox))
                    {
                        SoulFear(target);
                    }
                }
            }
        }

        public void SoulFear(NPC target)
        {
            target.buffImmune[ModContent.BuffType<Buffs.CurseOfLight>()] = false;
            target.AddBuff(ModContent.BuffType<Buffs.CurseOfLight>(), 600);
            target.buffImmune[BuffID.Ichor] = false;
            target.AddBuff(BuffID.Ichor, 600);
            target.buffImmune[BuffID.CursedInferno] = false;
            target.AddBuff(BuffID.CursedInferno, 600);
            target.buffImmune[BuffID.ShadowFlame] = false;
            target.AddBuff(BuffID.ShadowFlame, 600);
        }
    }
}
