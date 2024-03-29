using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Linq;
using AlchemistNPCRebornAgain.Extensions;

namespace AlchemistNPCRebornAgain.Projectiles
{
    public class Wasps : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(189);
            Projectile.netImportant = true;
            Projectile.netUpdate = true;

            Projectile.DamageType = DamageClass.Ranged;
            Projectile.aiStyle = 36;
            AIType = 189;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            // Cache and re-use this, significantly faster than the old way for large number of mods
            if (!_hasTestedModCache) TestCachedMods();

            // This should run sooooooo much faster >.>
            for (int index1 = 0; index1 < 8 + player.extraAccessorySlots; ++index1)
            {
                var armor = player.armor[index1].type;
                if (armor == _plagueHiveItem || armor == ItemID.HiveBackpack || armor == _beeEnchantmentItem)
                    Projectile.scale = 1.5f;
            }
        }

        private static void TestCachedMods()
        {
            _hasTestedModCache = true;
            if (ExternalModCache.findMod("CalamityMod", out var calamity) && ExternalModCache.GetOrCreateModItem(calamity, "PlagueHive", out var calamityItem))
                _plagueHiveItem = calamityItem.Type;
            if (ExternalModCache.findMod("FargowiltasSouls", out var fargoSouls) && ExternalModCache.GetOrCreateModItem(fargoSouls, "BeeEnchant", out var fargoItem))
                _beeEnchantmentItem = fargoItem.Type;
        }

        private static bool _hasTestedModCache = false;
        private static int _plagueHiveItem = -10000;
        private static int _beeEnchantmentItem = -10000;

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            Player player = Main.player[Projectile.owner];
            // Cache and re-use this, significantly faster than the old way for large number of mods
            if (!_hasTestedModCache) TestCachedMods();

            // This should run sooooooo much faster >.>
            for (int index1 = 0; index1 < 8 + player.extraAccessorySlots; ++index1)
            {
                var armor = player.armor[index1].type;
                if (armor == _plagueHiveItem || armor == ItemID.HiveBackpack || armor == _beeEnchantmentItem)
                    modifiers.FinalDamage /= 2;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
                Projectile.Kill();
            else
            {
                Projectile.ai[0] += 0.1f;
                if (!Projectile.velocity.X.Equals(oldVelocity.X))
                    Projectile.velocity.X = -oldVelocity.X;
                if (!Projectile.velocity.Y.Equals(oldVelocity.Y))
                    Projectile.velocity.Y = -oldVelocity.Y;
                Projectile.velocity *= 0.75f;
            }

            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.immune[Projectile.owner] = 1;
            target.AddBuff(70, 600);
            Projectile.penetrate = 1;
        }
    }
}
