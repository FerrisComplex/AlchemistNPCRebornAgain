using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using Terraria.GameContent;
using AlchemistNPCRebornAgain;

namespace AlchemistNPCRebornAgain.Projectiles
{
    public class DeadlyLaser : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(100);
            Projectile.width = 6;
            Projectile.tileCollide = false;
            Projectile.aiStyle = 1;
            Projectile.timeLeft = 600;
            AIType = 100;
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (target.friendly)
                modifiers.SetMaxDamage(5);
        }
    }
}
