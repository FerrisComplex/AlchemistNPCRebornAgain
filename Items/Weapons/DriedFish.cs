using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using AlchemistNPCRebornAgain.Items.PaleDamageClass;
using AlchemistNPCRebornAgain;
using Terraria.WorldBuilding;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class DriedFish : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 28;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.crit = 10;
			Item.width = 52;
			Item.height = 52;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.value = 100000;
			Item.rare = 5;
            Item.knockBack = 4;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1.5f;
		}
		
		public override void OnHitNPC(Terraria.Player player, NPC target, NPC.HitInfo hit, int damage)
		{
			target.AddBuff(BuffID.Wet, 600);
			Vector2 vel1 = new Vector2(-1, -1);
			vel1 *= 12f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X+200, target.position.Y+200, vel1.X, vel1.Y, Mod.Find<ModProjectile>("DriedFishBubble").Type, damage/4, 0, Main.myPlayer);
			Vector2 vel2 = new Vector2(1, 1);
			vel2 *= 12f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X-200, target.position.Y-200, vel2.X, vel2.Y, Mod.Find<ModProjectile>("DriedFishBubble").Type, damage/4, 0, Main.myPlayer);
			Vector2 vel3 = new Vector2(1, -1);
			vel3 *= 12f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X-200, target.position.Y+200, vel3.X, vel3.Y, Mod.Find<ModProjectile>("DriedFishBubble").Type, damage/4, 0, Main.myPlayer);
			Vector2 vel4 = new Vector2(-1, 1);
			vel4 *= 12f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X+200, target.position.Y-200, vel4.X, vel4.Y, Mod.Find<ModProjectile>("DriedFishBubble").Type, damage/4, 0, Main.myPlayer);
			Vector2 vel5 = new Vector2(0, -1);
			vel5 *= 12f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X, target.position.Y+200, vel5.X, vel5.Y, Mod.Find<ModProjectile>("DriedFishBubble").Type, damage/4, 0, Main.myPlayer);
			Vector2 vel6 = new Vector2(0, 1);
			vel6 *= 12f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X, target.position.Y-200, vel6.X, vel6.Y, Mod.Find<ModProjectile>("DriedFishBubble").Type, damage/4, 0, Main.myPlayer);
			Vector2 vel7 = new Vector2(1, 0);
			vel7 *= 12f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X-200, target.position.Y, vel7.X, vel7.Y, Mod.Find<ModProjectile>("DriedFishBubble").Type, damage/4, 0, Main.myPlayer);
			Vector2 vel8 = new Vector2(-1, 0);
			vel8 *= 12f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X+200, target.position.Y, vel8.X, vel8.Y, Mod.Find<ModProjectile>("DriedFishBubble").Type ,damage/4, 0, Main.myPlayer);
		}
	}
}
