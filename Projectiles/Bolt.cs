using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCRebornAgain.Projectiles
{
    public class Bolt : ModProjectile
    {
        public float rot = 0f;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;               //The width of Projectile hitbox
            Projectile.height = 20;              //The height of Projectile hitbox
            Projectile.aiStyle = 1;             //The ai style of the Projectile, please reference the source code of Terraria
            Projectile.friendly = true;         //Can the Projectile deal damage to enemies?
            Projectile.hostile = false;         //Can the Projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Magic;           //Is the Projectile shoot by a ranged weapon?
            Projectile.penetrate = -1;           //How many monsters the Projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 300;          //The live time for the Projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 255;             //The transparency of the Projectile, 255 for completely transparent. (aiStyle 1 quickly fades the Projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your Projectile is invisible.
            Projectile.light = 0.5f;            //How much light emit around the Projectile
            Projectile.ignoreWater = true;          //Does the Projectile's speed be influenced by water?
            Projectile.tileCollide = true;          //Can the Projectile collide with tiles?
            Projectile.extraUpdates = 1;            //Set to above 0 if you want the Projectile to update multiple time in a frame
            AIType = ProjectileID.Bullet;           //Act exactly like default Bullet
            Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Main.instance.LoadProjectile(Projectile.type);
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

            // Redraw the projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            return true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            Projectile.velocity.X = 0f;
            Projectile.velocity.Y = 0f;
            rot = Projectile.rotation;
            return false;
        }

        //public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI) {
        //	// If attached to an NPC, draw behind tiles (and the npc) if that NPC is behind tiles, otherwise just behind the NPC.
        //	if (Projectile.ai[0] == 1f) // or if(isStickingToTarget) since we made that helper method.
        //	{
        //		int npcIndex = (int)Projectile.ai[1];
        //		if (npcIndex >= 0 && npcIndex < 200 && Main.npc[npcIndex].active) {
        //			if (Main.npc[npcIndex].behindTiles) {
        //				drawCacheProjsBehindNPCsAndTiles.Add(index);
        //			}
        //			else {
        //				drawCacheProjsBehindNPCs.Add(index);
        //			}
        //
        //			return;
        //		}
        //	}
        //	// Since we aren't attached, add to this list
        //	drawCacheProjsBehindProjectiles.Add(index);
        //}

        //public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
        //	// For going through platforms and such, javelins use a tad smaller size
        //	width = height = 10; // notice we set the width to the height, the height to 10. so both are 10
        //	return true;
        //}

        public override void AI()
        {
            if (Projectile.velocity.X != 0f && Projectile.velocity.Y != 0f)
            {
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            }
            else
            {
                Projectile.rotation = rot;
            }

            UpdateAlpha();
            // Run either the Sticky AI or Normal AI
            // Separating into different methods helps keeps your AI clean
            if (IsStickingToTarget) StickyAI();
            else NormalAI();
        }

        public override void Kill(int timeLeft)
        {
            Player player = Main.player[Projectile.owner];
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item89, Projectile.position);
            for (int index1 = 0; index1 < 15; ++index1)
            {
                int index2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 29, 0.0f, 0.0f, 100, new Color(), 2.5f);
                Main.dust[index2].noGravity = true;
                Main.dust[index2].velocity *= 7f;
                int index3 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 29, 0.0f, 0.0f, 100, new Color(), 1.5f);
                Main.dust[index3].velocity *= 3f;
                Main.dust[index3].noGravity = true;
            }
            int damage = initialDamage != 0 ? initialDamage : Projectile.damage;
            Projectile.NewProjectile((Projectile).GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0f, 0f, ModContent.ProjectileType<ExplosionDummyL>(), damage * 2, Projectile.knockBack, player.whoAmI);
        }

        public bool IsStickingToTarget
        {
            get => Projectile.ai[0] == 1f;
            set => Projectile.ai[0] = value ? 1f : 0f;
        }

        // Index of the current target
        public int TargetWhoAmI
        {
            get => (int)Projectile.ai[1];
            set => Projectile.ai[1] = value;
        }

        private const int MAX_STICKY_JAVELINS = 100; // This is the max. amount of javelins being able to attach
        private readonly Point[] _stickingJavelins = new Point[MAX_STICKY_JAVELINS]; // The point array holding for sticking javelins
        private int initialDamage;

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            IsStickingToTarget = true; // we are sticking to a target
            TargetWhoAmI = target.whoAmI; // Set the target whoAmI
            Projectile.velocity =
                (target.Center - Projectile.Center) *
                0.75f; // Change velocity based on delta center of targets (difference between entity centers)
            Projectile.netUpdate = true; // netUpdate this javelin

            initialDamage = damageDone;
            Projectile.damage = 0; // Makes sure the sticking javelins do not deal damage anymore
        }

        // Change this number if you want to alter how the alpha changes
        private const int ALPHA_REDUCTION = 25;

        private void UpdateAlpha()
        {
            // Slowly remove alpha as it is present
            if (Projectile.alpha > 0)
            {
                Projectile.alpha -= ALPHA_REDUCTION;
            }

            // If alpha gets lower than 0, set it to 0
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }
        }

        private void NormalAI()
        {
            TargetWhoAmI++;
        }

        private void StickyAI()
        {
            // These 2 could probably be moved to the ModifyNPCHit hook, but in vanilla they are present in the AI
            Projectile.ignoreWater = true; // Make sure the Projectile ignores water
            Projectile.tileCollide = false; // Make sure the Projectile doesn't collide with tiles anymore
            Projectile.localAI[0] += 1f;

            // Every 30 ticks, the javelin will perform a hit effect
            int projTargetIndex = (int)TargetWhoAmI;
            if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage)
            { // If the target is active and can take damage
              // Set the Projectile's position relative to the target's center
                Projectile.Center = Main.npc[projTargetIndex].Center - Projectile.velocity * 2f;
                Projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
            }
        }
    }
}
