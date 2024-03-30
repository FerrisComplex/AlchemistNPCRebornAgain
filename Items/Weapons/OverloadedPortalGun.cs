using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using System.Linq;
using AlchemistNPCRebornAgain.Extensions;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class OverloadedPortalGun : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 125;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = 3000000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item114;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("PortalGunProj").Type;
			Item.shootSpeed = 16f;
			Item.useAmmo = Mod.FindItem("EnergyCapsule").Type;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "PortalGun");
			recipe.AddIngredient(null, "ChromaticCrystal", 3);
			recipe.AddIngredient(null, "SunkroveraCrystal", 3);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 3);
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
