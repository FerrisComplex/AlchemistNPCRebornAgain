using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class Nyx : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.SniperRifle);
			Item.damage = 750;
			Item.autoReuse = true;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item36;
			Item.shoot = ModContent.ProjectileType<Projectiles.Nyx>();
			Item.DamageType = DamageClass.Ranged; // What type of damage does this item affect?
			Item.knockBack = 0f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.noMelee = true; // So the item's animation doesn't do damage.
			Item.rare = ItemRarityID.Yellow; // The color that the item's name will be in-game.
			Item.shootSpeed = 10f; // The speed of the projectile (measured in pixels per frame.)

			Item.value = Item.buyPrice(gold: 66); // The value of the weapon in copper coins
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
				Item.damage = 425;
			}
			else
			{
				Item.useTime = 60;
				Item.useAnimation = 60;
				Item.damage = 750;
			}
			return base.CanUseItem(player);
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(Item.type);
			recipe.AddIngredient(ItemID.SniperRifle);
			recipe.AddIngredient(ItemID.Ectoplasm, 50);
			recipe.AddIngredient(ItemID.ShroomiteBar, 8);
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 10);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
