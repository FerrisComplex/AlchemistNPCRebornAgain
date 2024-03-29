using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class EbonyIvory : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 100;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useAnimation = 6;
			Item.useTime = 6;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = 1000000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Bullet;
			Item.scale = 0.5f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = Mod.Find<ModProjectile>("DemonicBullet").Type;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-5, velocity.X, velocity.Y, type, damage/2, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, velocity.X, velocity.Y, type, damage/2, Item.knockBack, player.whoAmI);
			return false;
		}
		
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .66;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(8, 0);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "HateVial");
			recipe.AddIngredient(ItemID.DemonScythe);
			recipe.AddIngredient(ItemID.UnholyTrident);
			recipe.AddIngredient(ItemID.InfernoFork);
			recipe.AddIngredient(ItemID.VenusMagnum, 2);
			recipe.AddIngredient(null, "AlchemicalBundle");
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
