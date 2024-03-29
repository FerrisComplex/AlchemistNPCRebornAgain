using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPCRebornAgain.Projectiles
{
    public class Lightning : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(580);
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.aiStyle = 88;
            AIType = 580;
        }

        public override bool CanHitPlayer(Player target)
        {
            return false;
        }

        public override bool? CanHitNPC(NPC target)
        {
            if (target.friendly)
            {
                return false;
            }

            return true;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.immune[Projectile.owner] = 1;
        }
    }
}
