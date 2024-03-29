using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCRebornAgain.Projectiles
{
	public class NyctosythiaBulletGhost : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;        //The recording mode
		}
		
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bullet);
			Projectile.timeLeft = 300;
			AIType = ProjectileID.Bullet;
			Projectile.tileCollide = false;
		}
		
		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			modifiers.FinalDamage /= 2;
		}
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			SoundEngine.PlaySound(SoundID.NPCDeath52, Projectile.position);
			Vector2 vel = new Vector2(0, -1);
			float rand = Main.rand.NextFloat() * 6.283f;
			vel = vel.RotatedBy(rand);
			vel *= 12f;
			Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null),Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<NyctosyphiaBeam>(), Projectile.damage/6, 0, Main.myPlayer);
			Vector2 vel2 = new Vector2(0, -1);
			vel2 = vel.RotatedBy(rand);
			vel2 *= 12f;
			Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null),Projectile.Center.X, Projectile.Center.Y, vel2.X, vel2.Y, ModContent.ProjectileType<NyctosyphiaBeam>(), Projectile.damage/6, 0, Main.myPlayer);
			Vector2 vel3 = new Vector2(0, -1);
			vel3 = vel.RotatedBy(rand);
			vel3 *= 12f;
			Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null),Projectile.Center.X, Projectile.Center.Y, vel3.X, vel3.Y, ModContent.ProjectileType<NyctosyphiaBeam>(), Projectile.damage/6, 0, Main.myPlayer);
		}
	}
}
