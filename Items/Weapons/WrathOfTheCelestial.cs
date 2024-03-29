using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class WrathOfTheCelestial : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.staff[Item.type] = true;
        }

		public override void SetDefaults()
		{
			Item.damage = 369;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 10;
			Item.rare = 11;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.UseSound = SoundID.Item20;
			Item.useStyle = 5;
			Item.shootSpeed = 12f;
			Item.useAnimation = 15;   
			Item.knockBack = 4;
			Item.value = Item.sellPrice(1, 0, 0, 0);
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("BlueFlame").Type;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			//float speedX = 12f;
			//float speedY = 12f;
			Vector2 perturbedSpeed1 = velocity.RotatedByRandom(MathHelper.ToRadians(5));
			Vector2 perturbedSpeed2 = velocity.RotatedByRandom(MathHelper.ToRadians(5));
			Vector2 perturbedSpeed3 = velocity.RotatedByRandom(MathHelper.ToRadians(10));
			Vector2 perturbedSpeed4 = velocity.RotatedByRandom(MathHelper.ToRadians(10));
			Vector2 perturbedSpeed5 = velocity.RotatedByRandom(MathHelper.ToRadians(15));
			Vector2 perturbedSpeed6 = velocity.RotatedByRandom(MathHelper.ToRadians(15));
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, velocity.X, velocity.Y, type, damage*4, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, perturbedSpeed1.X, perturbedSpeed1.Y, type, damage*4, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, type, damage*4, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, perturbedSpeed3.X, perturbedSpeed3.Y, type, damage*4, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, perturbedSpeed4.X, perturbedSpeed4.Y, type, damage*4, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, perturbedSpeed5.X, perturbedSpeed5.Y, type, damage*4, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, perturbedSpeed6.X, perturbedSpeed6.Y, type, damage*4, Item.knockBack, player.whoAmI);
			return false;
		}
	}
}
