using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class TerrarianW : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LaserRifle);
			Item.damage = 25;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.UseSound = SoundID.Item31;
				Item.mana = 0;
				Item.useAnimation = 12;
				Item.useTime = 4;
				Item.reuseDelay = 14;
				Item.shoot = 10;
				Item.useAmmo = AmmoID.Bullet;
				Item.DamageType = DamageClass.Ranged;
				Item.damage = 18;
				if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
				{
					Item.damage = 36;
				}
			}
			else
			{
				Item.UseSound = SoundID.Item12;
				Item.mana = 5;
				Item.useAnimation = 18;
				Item.useTime = 6;
				Item.reuseDelay = 20;
				Item.shoot = 88;
				Item.useAmmo = 0;
				
				Item.DamageType = DamageClass.Magic;
				Item.damage = 25;
				if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
				{
					Item.damage = 100;
				}
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
			{
				if (player.altFunctionUse == 2)
				{
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, velocity.X, velocity.Y, type, damage*2, Item.knockBack, player.whoAmI);
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, velocity.X, velocity.Y, type, damage*2, Item.knockBack, player.whoAmI);
				}
				else
				{
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-6, velocity.X, velocity.Y, type, damage*2, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+6, velocity.X, velocity.Y, type, damage*2, Item.knockBack, player.whoAmI);
				}
			}
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == false)
			{
				if (player.altFunctionUse == 2)
				{
				Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, velocity.X, velocity.Y, type, damage, Item.knockBack, player.whoAmI);
				}
				else
				{
				}
			}
			return true;
		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .33f;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, 0);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Starfury);
			recipe.AddIngredient(ItemID.ClockworkAssaultRifle);
			recipe.AddIngredient(ItemID.CrystalShard, 30);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
