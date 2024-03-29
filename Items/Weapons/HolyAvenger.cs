using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.Utilities;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class HolyAvenger : ModItem
	{

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Muramasa);
			Item.damage = 14;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 78;
			Item.height = 78;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(platinum: 1);
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override bool CanUseItem(Player player)
		{
			if (!Main.hardMode)
			{
				Item.autoReuse = false;
			}
			Item.useTime = 15;
			Item.useAnimation = 15;
			if (NPC.downedSlimeKing)
			{
				Item.damage = 16;
			}
			if (NPC.downedBoss1)
			{
				Item.damage = 18;
			}
			if (NPC.downedBoss2)
			{
				Item.damage = 22;
			}
			if (NPC.downedQueenBee)
			{
				Item.damage = 26;
			}
			if (NPC.downedBoss3)
			{
				Item.damage = 30;
			}
			if (Main.hardMode)
			{
				Item.damage = 36;
				Item.useTime = 10;
				Item.useAnimation = 10;
				Item.autoReuse = true;
			}
			if (NPC.downedMechBossAny)
			{
				Item.damage = 44;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				Item.damage = 52;
			}
			if (NPC.downedPlantBoss)
			{
				Item.damage = 64;
			}
			if (NPC.downedGolemBoss)
			{
				Item.damage = 72;
			}
			if (NPC.downedFishron)
			{
				Item.damage = 81;
			}
			if (NPC.downedAncientCultist)
			{
				Item.damage = 90;
			}
			if (NPC.downedMoonlord)
			{
				Item.damage = 100;
			}
			return true;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, Mod.Find<ModDust>("JustitiaPale").Type);
			}
		}

		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 81;
		}
		
		public override void OnHitNPC(Terraria.Player player, NPC target, NPC.HitInfo hit, int damage)
		{
			target.buffImmune[Mod.Find<ModBuff>("CurseOfLight").Type] = false;
			target.AddBuff(Mod.Find<ModBuff>("CurseOfLight").Type, 300);
			if (Main.hardMode && !NPC.downedMechBossAny)
			{
				Vector2 vel1 = new Vector2(0, 0);
				vel1 *= 0f;
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X, target.position.Y, vel1.X, vel1.Y, Mod.Find<ModProjectile>("ExplosionAvenger").Type, damage/4, 0, Main.myPlayer);
			}
			if (Main.hardMode && NPC.downedMechBossAny && !NPC.downedGolemBoss)
			{
				Vector2 vel1 = new Vector2(0, 0);
				vel1 *= 0f;
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X, target.position.Y, vel1.X, vel1.Y, Mod.Find<ModProjectile>("ExplosionAvenger").Type, damage/3, 0, Main.myPlayer);
			}
			if (Main.hardMode && NPC.downedGolemBoss)
			{
				Vector2 vel1 = new Vector2(0, 0);
				vel1 *= 0f;
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X, target.position.Y, vel1.X, vel1.Y, Mod.Find<ModProjectile>("ExplosionAvenger").Type, damage/2, 0, Main.myPlayer);
			}
		}
	}
}
