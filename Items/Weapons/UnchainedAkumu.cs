using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using AlchemistNPCRebornAgain;
using Terraria.WorldBuilding;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class UnchainedAkumu : ModItem
	{

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.damage = 250;
			Item.width = 58;
			Item.height = 50;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 1;
			Item.value = 10000000;
			Item.rare = -12;
			Item.knockBack = 8;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = Mod.Find<ModProjectile>("Akumu").Type;
			Item.shootSpeed = 8f;
		}
		
		public override void HoldItem(Player player)
		{
			if (player.statLife > player.statLifeMax2*0.35f)
			{
				player.AddBuff(Mod.Find<ModBuff>("TrueAkumuAttack").Type, 2);
			}
			if (player.statLife < player.statLifeMax2*0.35f)
			{
				(player.GetModPlayer<AlchemistNPCRebornPlayer>()).Akumu = true;
				player.AddBuff(Mod.Find<ModBuff>("TrueAkumu").Type, 2);
			}
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.useTime = 30;
				Item.useAnimation = 30;
			}
			else
			{
				Item.useTime = 25;
				Item.useAnimation = 25;
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse != 2)
			{
			Item.noMelee = false;
			Projectile.NewProjectile(source, position, velocity, Mod.Find<ModProjectile>("AkumuThrow").Type, damage, Item.knockBack, player.whoAmI);
			}
			if (player.altFunctionUse == 2)
			{
				Item.noMelee = true;
				if (player.direction == 1)
				{
					Vector2 vel = new Vector2(0, 0);
					vel *= 0f;
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, vel.X, vel.Y, Mod.Find<ModProjectile>("Akumu").Type, damage, Item.knockBack, player.whoAmI);
				}
				if (player.direction == -1)
				{
					Vector2 vel = new Vector2(-1, 0);
					vel *= 0f;
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, vel.X, vel.Y, Mod.Find<ModProjectile>("AkumuMirror").Type, damage, Item.knockBack, player.whoAmI);
				}
			}
			return false;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "Akumu");
			recipe.AddIngredient(null, "ChromaticCrystal", 5);
			recipe.AddIngredient(null, "SunkroveraCrystal", 5);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 5);
			recipe.AddIngredient(null, "EmagledFragmentation", 150);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
