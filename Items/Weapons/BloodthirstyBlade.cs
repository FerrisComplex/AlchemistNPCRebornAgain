using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCRebornAgain;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class BloodthirstyBlade : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.crit = 50;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.value = 100000;
			Item.rare = 4;
            Item.knockBack = 8;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1.5f;
		}

		public override void UpdateInventory(Player player)
		{
			Item.damage = 10 + ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).BBP/100);
			if (Item.damage >= 36)
			{
				Item.shoot = Mod.Find<ModProjectile>("SB").Type;
				Item.shootSpeed = 12f;
			}
			if (!Main.hardMode)
			{
				if (Item.damage > 36)
				{
					Item.damage = 36;
				}
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
				Item.useTime = 15;
				Item.useAnimation = 15;
				if (Item.damage > 99)
				{
					Item.damage = 99;
				}
			}
			if (NPC.downedMoonlord)
			{
				Item.useTime = 10;
				Item.useAnimation = 10;
			}
		}
		
		public override void HoldItem(Player player)
		{
			Item.damage = 10 + ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).BBP/100);
			if (Item.damage >= 36)
			{
				Item.shoot = Mod.Find<ModProjectile>("SB").Type;
				Item.shootSpeed = 12f;
			}
			if (!Main.hardMode)
			{
				if (Item.damage > 36)
				{
					Item.damage = 36;
				}
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
				Item.useTime = 15;
				Item.useAnimation = 15;
				if (Item.damage > 99)
				{
					Item.damage = 99;
				}
			}
			if (NPC.downedMoonlord)
			{
				Item.useTime = 10;
				Item.useAnimation = 10;
			}
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Item.damage = 10 + ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).BBP/100);
			if (Item.damage >= 64)
			{
				Vector2 perturbedSpeed = new Vector2(Item.shootSpeed, Item.shootSpeed).RotatedByRandom(MathHelper.ToRadians(10));
				Vector2 perturbedSpeed2 = new Vector2(Item.shootSpeed, Item.shootSpeed).RotatedByRandom(MathHelper.ToRadians(10));
				float speedX = perturbedSpeed.X;
				float speedY = perturbedSpeed.Y;
				float speedX2 = perturbedSpeed2.X;
				float speedY2 = perturbedSpeed2.Y;
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+4, speedX, speedY, Mod.Find<ModProjectile>("SB").Type, damage/2, Item.knockBack, player.whoAmI);
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-4, speedX2, speedY2, Mod.Find<ModProjectile>("SB").Type, damage/2, Item.knockBack, player.whoAmI);
			}
			if (Item.damage > 99)
			{
				Vector2 perturbedSpeed3 = new Vector2(Item.shootSpeed, Item.shootSpeed).RotatedByRandom(MathHelper.ToRadians(15));
				Vector2 perturbedSpeed4 = new Vector2(Item.shootSpeed, Item.shootSpeed).RotatedByRandom(MathHelper.ToRadians(15));
				float speedX3 = perturbedSpeed3.X;
				float speedY3 = perturbedSpeed3.Y;
				float speedX4 = perturbedSpeed4.X;
				float speedY4 = perturbedSpeed4.Y;
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+5, speedX3, speedY3, Mod.Find<ModProjectile>("SB").Type, damage/2, Item.knockBack, player.whoAmI);
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-5, speedX4, speedY4, Mod.Find<ModProjectile>("SB").Type, damage/2, Item.knockBack, player.whoAmI);
			}
			damage /= 2;
			return true;
		}
		
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			Player player = Main.player[Main.myPlayer];
			string text1;
			if(Language.ActiveCulture == GameCulture.FromCultureName(GameCulture.CultureName.Chinese))
			{
				text1 = "渴血指数为" + (player.GetModPlayer<AlchemistNPCRebornPlayer>()).BBP;
			}
			else
			{
				text1 = "Bloodthirsty Blade points are " + (player.GetModPlayer<AlchemistNPCRebornPlayer>()).BBP;
			}
			TooltipLine line = new TooltipLine(Mod, "text1", text1);
			tooltips.Insert(1,line);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BloodButcherer);
			recipe.AddIngredient(ItemID.Vertebrae, 15);
			recipe.AddIngredient(ItemID.TissueSample, 10);
			recipe.AddIngredient(ItemID.Deathweed, 5);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LightsBane);
			recipe.AddIngredient(ItemID.RottenChunk, 15);
			recipe.AddIngredient(ItemID.ShadowScale, 10);
			recipe.AddIngredient(ItemID.Deathweed, 5);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
		}
	}
}
