using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using AlchemistNPCRebornAgain;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;


namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class Akumu : ModItem
	{

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Melee;
			Item.damage = 150;
			Item.width = 58;
			Item.height = 50;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.value = 10000000;
			Item.rare = -12;
			Item.knockBack = 8;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<Projectiles.Akumu>();
			Item.shootSpeed = 8f;
		}
		
		public override void HoldItem(Player player)
		{
			if (player.statLife < player.statLifeMax2/4)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().Akumu = true;
				player.AddBuff(ModContent.BuffType<Buffs.Akumu>(), 2);
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
				Item.useTime = 40;
				Item.useAnimation = 40;
			}
			else
			{
				Item.useTime = 30;
				Item.useAnimation = 30;
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			if (player.statLife < player.statLifeMax2/4)
			{
			damage /= 2;
			}
			if (player.altFunctionUse != 2)
			{
			Item.noMelee = false;
			Vector2 vel = new Vector2(0, 0);
			vel *= 0f;
			//Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), position.X, position.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.AkumuThrow>(), damage, knockBack , player.whoAmI);
			}
			if (player.altFunctionUse == 2)
			{
				Item.noMelee = true;
				if (player.direction == 1)
				{
					Vector2 vel = new Vector2(0, 0);
					vel *= 0f;
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), position.X, position.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.Akumu>(), damage, knockBack, player.whoAmI);
				}
				if (player.direction == -1)
				{
					Vector2 vel = new Vector2(-1, 0);
					vel *= 0f;
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null), position.X, position.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.AkumuMirror>(), damage, knockBack, player.whoAmI);
				}
			}
			return false;
		}
	}
}
