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
using AlchemistNPCRebornAgain.Items.PaleDamageClass;
using Terraria.WorldBuilding;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class ParadiseLost : PaleDamageItem
	{

		public override void SafeSetDefaults()
		{
			Item.damage = 666;
			Item.crit = 66;
			Item.width = 52;
			Item.height = 52;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.value = 10000000;
			Item.rare = 11;
            Item.knockBack = 8;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = Mod.Find<ModProjectile>("ParadiseLostProjectile").Type;
			Item.shootSpeed = 8f;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
			{
				return true;
			}
			if (player.altFunctionUse == 2)
			{
				Item.useTime = 40;
				Item.useAnimation = 40;
			}
			else
			{
				Item.useTime = 30;
				Item.useAnimation = 30;
			}
			return false;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse != 2)
			{
				Item.noMelee = false;
				Vector2 SPos = player.position;
				position = SPos;
				if (player.direction == 1)
				{
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X+10, position.Y, velocity.X, velocity.Y, Mod.Find<ModProjectile>("ParadiseLostProjectile").Type, damage, Item.knockBack, player.whoAmI);
				}
				if (player.direction == -1)
				{
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X-10, position.Y, velocity.X, velocity.Y, Mod.Find<ModProjectile>("ParadiseLostProjectile").Type, damage, Item.knockBack, player.whoAmI);
				}
			}
			if (player.altFunctionUse == 2)
			{
				Item.noMelee = true;
				if (player.direction == 1)
				{
					for (int h = 0; h < 1; h++) {
					Vector2 vel = new Vector2(0, 0);
					vel *= 0f;
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, vel.X, vel.Y, Mod.Find<ModProjectile>("ParadiseLost").Type, damage, Item.knockBack, player.whoAmI);
					}
				}
				if (player.direction == -1)
				{
					for (int h = 0; h < 1; h++) {
					Vector2 vel = new Vector2(-1, 0);
					vel *= 0f;
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, vel.X, vel.Y, Mod.Find<ModProjectile>("ParadiseLostMirror").Type, damage, Item.knockBack, player.whoAmI);
					}
				}
			}
			return false;
		}
		
		public override void OnHitNPC(Terraria.Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(Mod.Find<ModBuff>("Twilight").Type, 600);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "Twilight");
			recipe.AddIngredient(null, "ChromaticCrystal", 10);
			recipe.AddIngredient(null, "SunkroveraCrystal", 10);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 10);
			recipe.AddIngredient(null, "EmagledFragmentation", 250);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
