using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCRebornAgain.Projectiles.Minions
{
    public class LittleWitchMonster : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(391);
            Projectile.minionSlots = 1;
            Main.projFrames[Projectile.type] = 11;
            Projectile.aiStyle = 26;
            AIType = 391;
        }

        //public override void CheckActive()
        //{
        //	Player player = Main.player[Projectile.owner];
        //	AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
        //	if (player.dead || !modPlayer.LaetitiaGift)
        //	{
        //		modPlayer.lwm = false;
        //		Projectile.Kill();
        //	}
        //	if (!player.HasBuff(mod.BuffType("LittleWitchMonster")))
        //	{
        //		modPlayer.lwm = false;
        //		Projectile.Kill();
        //	}
        //	if (!modPlayer.LaetitiaSet && !modPlayer.ParadiseLost)
        //	{
        //		modPlayer.lwm = false;
        //		Projectile.Kill();
        //	}
        //}

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            target.immune[Projectile.owner] = 5;
            Player player = Main.player[Projectile.owner];
            if (player.GetModPlayer<AlchemistNPCRebornPlayer>().ParadiseLost)
            {
                modifiers.FinalDamage *= 4;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.ShadowFlame, 600);
            target.AddBuff(BuffID.Ichor, 600);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.penetrate == 0)
            {
                Projectile.Kill();
            }

            return false;
        }
    }
}
