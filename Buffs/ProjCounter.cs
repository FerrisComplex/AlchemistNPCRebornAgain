using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Buffs
{
	public class ProjCounter : ModBuff
	{
		public static int counter = 0;
		
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			int timeValue = 600;
			if (NPC.downedSlimeKing)
			{
				timeValue = 575;
			}
			if (NPC.downedBoss1)
			{
				timeValue = 550;
			}
			if (NPC.downedBoss2)
			{
				timeValue = 525;
			}
			if (NPC.downedQueenBee)
			{
				timeValue = 500;
			}
			if (NPC.downedBoss3)
			{
				timeValue = 450;
			}
			if (Main.hardMode)
			{
				timeValue = 400;
			}
			if (NPC.downedMechBossAny)
			{
				timeValue = 350;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				timeValue = 325;
			}
			if (NPC.downedPlantBoss)
			{
				timeValue = 300;
			}
			if (NPC.downedGolemBoss)
			{
				timeValue = 275;
			}
			if (NPC.downedFishron)
			{
				timeValue = 250;
			}
			if (NPC.downedAncientCultist)
			{
				timeValue = 210;
			}
			if (NPC.downedMoonlord)
			{
				timeValue = 180;
			}
			player.AddBuff(Mod.Find<ModBuff>("ProjCounter").Type, 2);
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Globe199").Type] <= 0)
			{
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.position.X-15, player.position.Y-100, 0f, 0f, Mod.Find<ModProjectile>("Globe199").Type, 0, 0, player.whoAmI);
			}
			counter++;
			for (int i = 0; i < 1000; i++)
            {
                Projectile target = Main.projectile[i];

                float shootToX = target.position.X + target.width * 0.5f - player.Center.X;
                float shootToY = target.position.Y + target.height * 0.5f - player.Center.Y;
                float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                if (distance < 130f && !target.friendly && target.active && target.hostile)
                {
                    if (counter > timeValue)
                    {
						player.AddBuff(Mod.Find<ModBuff>("GuarantCrit").Type, 2);
						(player.GetModPlayer<AlchemistNPCRebornPlayer>()).GC = true;
						SoundEngine.PlaySound(SoundID.Item93, player.position);
                        Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), player.Center.X, player.Center.Y, 0f, 0f, Mod.Find<ModProjectile>("Counter").Type, 0, 6, Main.myPlayer, 0f, 0f);
                        counter = 0;
                    }
                }
			}
		}
	}
}
