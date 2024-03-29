using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;

namespace AlchemistNPCRebornAgain.Projectiles.Minions
{
    public class Turret : ModProjectile
    {
		public int counter = 0;
        public override void SetDefaults()
        {
            Projectile.width = 46;
            Projectile.height = 48;
            Projectile.timeLeft = Projectile.SentryLifeTime;
            Projectile.ignoreWater = true;
            Projectile.sentry = true;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
        }

        public override void SetStaticDefaults()
        {
			Main.projFrames[Projectile.type] = 2;
        }
		
        //public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		//{
		//	fallThrough = false;
		//	return true;
		//}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.width = 32;
			Projectile.velocity.Y = 0f;
			return false;
		}
		
        public override void AI()
        {
			Player player = Main.player[Projectile.owner];
			AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
			if (player.dead || !player.HasBuff(ModContent.BuffType<Buffs.Turret>()))
			{
				modPlayer.turret = false;
			}
			if (modPlayer.turret)
			{
				Projectile.timeLeft = 2;
			}
            if (Projectile.localAI[0] == 0f)
            {
                Projectile.localAI[1] = 1f;
                Projectile.localAI[0] = 1f;
                Projectile.ai[0] = 120f;
                SoundEngine.PlaySound(SoundID.Item11, Projectile.position);
            }
            Projectile.velocity.X = 0f;
            Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
            bool flag18 = false;
            float num506 = Projectile.Center.X;
            float num507 = Projectile.Center.Y;
            float num508 = 1000f;
            NPC ownerMinionAttackTargetNPC = Projectile.OwnerMinionAttackTargetNPC;
            if (ownerMinionAttackTargetNPC != null && ownerMinionAttackTargetNPC.CanBeChasedBy(this, false))
            {
                float num509 = ownerMinionAttackTargetNPC.position.X + ownerMinionAttackTargetNPC.width / 2;
                float num510 = ownerMinionAttackTargetNPC.position.Y + ownerMinionAttackTargetNPC.height / 2;
                float num511 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num509) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - num510);
                if (num511 < num508 && Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, ownerMinionAttackTargetNPC.position, ownerMinionAttackTargetNPC.width, ownerMinionAttackTargetNPC.height))
                {
                    num508 = num511;
                    num506 = num509;
                    num507 = num510;
                    flag18 = true;
                }
            }
            if (!flag18)
            {
                for (int num512 = 0; num512 < 200; num512++)
                {
                    if (Main.npc[num512].CanBeChasedBy(this, false))
                    {
                        float num513 = Main.npc[num512].position.X + Main.npc[num512].width / 2;
                        float num514 = Main.npc[num512].position.Y + Main.npc[num512].height / 2;
                        float num515 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num513) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - num514);
                        if (num515 < num508 && Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, Main.npc[num512].position, Main.npc[num512].width, Main.npc[num512].height))
                        {
                            num508 = num515;
                            num506 = num513;
                            num507 = num514;
                            flag18 = true;
                        }
                    }
                }
				Projectile.frame = 1;
            }
            if (flag18)
            {
				if (counter == 60)
				{
                    if (!Main.dedServ)
			        {
			        	SoundStyle soundStyle = new SoundStyle("AlchemistNPCRebornAgain/Sounds/Item/ThereYouAre", (SoundType) 0);
			        	SoundEngine.PlaySound(soundStyle, new Vector2?(((Entity) player).Center));
			        }
				}
				counter++;
				if (counter == 1200)
				{
					counter = 0;
				}
                float num516 = num506;
                float num517 = num507;
                num506 -= Projectile.Center.X;
                num507 -= Projectile.Center.Y;
				int num518 = 0;
                if (Projectile.frameCounter > 0)
                {
                    Projectile.frameCounter--;
                }
                if (Projectile.frameCounter <= 0)
                {
                    int num519 = Projectile.spriteDirection;
                    if (num506 < 0f)
                    {
                        Projectile.spriteDirection = -1;
                    }
                    else
                    {
                        Projectile.spriteDirection = 1;
                    }
                    if (num507 > 0f)
                    {
                        num518 = 0;
                    }
                    else if (Math.Abs(num507) > Math.Abs(num506) * 3f)
                    {
                        num518 = 4;
                    }
                    else if (Math.Abs(num507) > Math.Abs(num506) * 2f)
                    {
                        num518 = 3;
                    }
                    else if (Math.Abs(num506) > Math.Abs(num507) * 3f)
                    {
                        num518 = 0;
                    }
                    else if (Math.Abs(num506) > Math.Abs(num507) * 2f)
                    {
                        num518 = 1;
                    }
                    else
                    {
                        num518 = 2;
                    }
                    Projectile.frame = 1;
                    Projectile.frameCounter = 8;
					if (Projectile.ai[0] <= 0f)
					{
						Projectile.frameCounter = 4;
					}
                }
                if (Projectile.ai[0] <= 0f)
                {
                    Projectile.localAI[1] = 0f;
                    Projectile.ai[0] = 3f;
                    if (Main.myPlayer == Projectile.owner)
                    {
                        float num521 = 6f;
                        int num522 = 242;
                        Vector2 vector37 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
                        if (num518 == 0)
                        {
                            vector37.X += 24 * Projectile.spriteDirection;
                        }
                        else if (num518 == 1)
                        {
                            vector37.X += 24 * Projectile.spriteDirection;
                        }
                        else if (num518 == 2)
                        {
                            vector37.X += 24 * Projectile.spriteDirection;
                        }
                        else if (num518 == 3)
                        {
                            vector37.X += 14 * Projectile.spriteDirection;
                        }
                        else if (num518 == 4)
                        {
                            vector37.X += 2 * Projectile.spriteDirection;
                        }
                        if (Projectile.spriteDirection < 0)
                        {
                            vector37.X += 10f;
                        }
                        float num523 = num516 - vector37.X;
                        float num524 = num517 - vector37.Y;
                        float num525 = (float)Math.Sqrt(num523 * num523 + num524 * num524);
                        num525 = num521 / num525;
                        num523 *= num525;
                        num524 *= num525;
                        int num526 = Projectile.damage;
                        Projectile.NewProjectile(((Entity) this.Projectile).GetSource_FromThis((string) null), vector37.X, vector37.Y, num523, num524, num522, num526, Projectile.knockBack, Main.myPlayer, 0f, 0f);
                    }
                }
            }
            else if (Projectile.ai[0] <= 60f && (Projectile.frame == 1 || Projectile.frame == 3 || Projectile.frame == 5 || Projectile.frame == 7 || Projectile.frame == 9))
            {
                Projectile.frame = 0;
            }
            if (Projectile.ai[0] > 0f)
            {
                Projectile.ai[0] -= 1f;
                return;
            }
        }
    }
}
