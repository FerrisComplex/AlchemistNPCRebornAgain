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
	public class QoHWeapon : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 99;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 10;
			Item.rare = 11;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 6;
			Item.UseSound = SoundID.Item13;
			Item.useStyle = 5;
			Item.shootSpeed = 12f;
			Item.useAnimation = 6;   
			Item.knockBack = 4;
			Item.value = Item.sellPrice(1, 0, 0, 0);
			Item.autoReuse = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
			{
				Item.damage = 125;
				Item.useTime = 5;
				Item.useAnimation = 5;
			}
			else
			{
				Item.damage = 99;
				Item.useTime = 6;
				Item.useAnimation = 6;
			}
			switch (Main.rand.Next(4))
			{
				case 0:
				Item.shoot = Mod.Find<ModProjectile>("QoH1").Type;
				break;

				case 1:
				Item.shoot = Mod.Find<ModProjectile>("QoH2").Type;
				break;
				
				case 2:
				Item.shoot = Mod.Find<ModProjectile>("QoH3").Type;
				break;
				
				case 3:
				Item.shoot = Mod.Find<ModProjectile>("QoH4").Type;
				break;
			}
		return true;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{

			Vector2 perturbedSpeed = new Vector2(Item.shootSpeed, Item.shootSpeed).RotatedByRandom(MathHelper.ToRadians(5));
			float speedX = perturbedSpeed.X;
			float speedY = perturbedSpeed.Y;
			return true;
		}
		
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddIngredient(ItemID.RainbowRod);
			recipe.AddIngredient(ItemID.StarWrath);
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddIngredient(ItemID.FragmentNebula, 25);
			recipe.AddIngredient(null, "ChromaticCrystal", 5);
			recipe.AddIngredient(null, "SunkroveraCrystal", 5);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 5);
			recipe.AddIngredient(null, "HateVial");
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
