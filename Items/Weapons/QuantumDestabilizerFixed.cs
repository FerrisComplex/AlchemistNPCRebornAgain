using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class QuantumDestabilizerFixed : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 700;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.channel = true;
			Item.rare = 11;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 20;
			Item.UseSound = SoundID.Item13;
			Item.useStyle = 5;
			Item.shootSpeed = 14f;
			Item.useAnimation = 20;   
			Item.knockBack = 10;			
			Item.shoot = Mod.Find<ModProjectile>("QuantumDestabilizer").Type;
			Item.value = Item.sellPrice(1, 0, 0, 0);
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-14, 1);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "QuantumDestabilizer");
			recipe.AddIngredient(null, "SupremeEnergyCore");
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
