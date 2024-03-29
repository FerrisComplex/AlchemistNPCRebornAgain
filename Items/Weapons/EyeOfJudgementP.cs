using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class EyeOfJudgementP : ModItem
	{
		public static int counter = 15;
		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Summon;
			Item.damage = 120;
			Item.width = 34;
			Item.mana = 20;
			Item.height = 36;
			Item.noUseGraphic = true;
			Item.useStyle = 1;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.maxStack = 1;
			Item.value = 1000000;
			Item.holdStyle = 1;
			Item.rare = -12;
			Item.scale = 1f;
			Item.knockBack = 4;
			Item.shoot = Mod.Find<ModProjectile>("SharpBone").Type;
			Item.autoReuse = true;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			position = SPos;
			Vector2 vel1 = new Vector2(-1, -1);
			vel1 *= 2f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X+150, position.Y+150, vel1.X, vel1.Y, Mod.Find<ModProjectile>("SharpBone").Type, Item.damage, 0, Main.myPlayer);
			Vector2 vel2 = new Vector2(1, 1);
			vel2 *= 2f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X-150, position.Y-150, vel2.X, vel2.Y, Mod.Find<ModProjectile>("SharpBone").Type, Item.damage, 0, Main.myPlayer);
			Vector2 vel3 = new Vector2(1, -1);
			vel3 *= 2f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X-150, position.Y+150, vel3.X, vel3.Y, Mod.Find<ModProjectile>("SharpBone").Type, Item.damage, 0, Main.myPlayer);
			Vector2 vel4 = new Vector2(-1, 1);
			vel4 *= 2f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X+150, position.Y-150, vel4.X, vel4.Y, Mod.Find<ModProjectile>("SharpBone").Type, Item.damage, 0, Main.myPlayer);
			Vector2 vel5 = new Vector2(0, -1);
			vel5 *= 2f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+150, vel5.X, vel5.Y, Mod.Find<ModProjectile>("SharpBone").Type, Item.damage, 0, Main.myPlayer);
			Vector2 vel6 = new Vector2(0, 1);
			vel6 *= 2f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-150, vel6.X, vel6.Y, Mod.Find<ModProjectile>("SharpBone").Type, Item.damage, 0, Main.myPlayer);
			Vector2 vel7 = new Vector2(1, 0);
			vel7 *= 2f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X-150, position.Y, vel7.X, vel7.Y, Mod.Find<ModProjectile>("SharpBone").Type, Item.damage, 0, Main.myPlayer);
			Vector2 vel8 = new Vector2(-1, 0);
			vel8 *= 2f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X+150, position.Y, vel8.X, vel8.Y, Mod.Find<ModProjectile>("SharpBone").Type, Item.damage, 0, Main.myPlayer);
			return false;
		}
		
		public override void HoldItem(Player player)
		{
		player.AddBuff(Mod.Find<ModBuff>("Judgement").Type, 2);
		player.endurance -= 0.17f;
		if (counter == 20)
			{
				if (player.direction == 1)
				{
					for (int h = 0; h < 1; h++) {
					Vector2 vel = new Vector2(0, 0);
					vel *= 0f;
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.Center.X+20+Main.rand.Next(15), player.Center.Y-50-Main.rand.Next(30), vel.X, vel.Y, Mod.Find<ModProjectile>("SharpBone").Type, Item.damage*3, 0, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.Center.X+20+Main.rand.Next(15), player.Center.Y-40-Main.rand.Next(30), vel.X, vel.Y, Mod.Find<ModProjectile>("SharpBone").Type, Item.damage*3, 0, player.whoAmI);
					counter = 0;
					}
				}
				if (player.direction == -1)
				{
					for (int h = 0; h < 1; h++) {
					Vector2 vel = new Vector2(-1, 0);
					vel *= 0f;
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.Center.X-20-Main.rand.Next(15), player.Center.Y-50-Main.rand.Next(30), vel.X, vel.Y, Mod.Find<ModProjectile>("SharpBone").Type, Item.damage*3, 0, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.Center.X-20-Main.rand.Next(15), player.Center.Y-40-Main.rand.Next(30), vel.X, vel.Y, Mod.Find<ModProjectile>("SharpBone").Type, Item.damage*3, 0, player.whoAmI);
					counter = 0;
					}
				}
			}
		counter++;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, 0);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "EyeOfJudgement");
			recipe.AddIngredient(null, "ChromaticCrystal", 3);
			recipe.AddIngredient(null, "SunkroveraCrystal", 3);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 3);
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
