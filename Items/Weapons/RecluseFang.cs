using AlchemistNPCRebornAgain.Extensions;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class RecluseFang : ModItem
	{

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Bananarang);
			Item.damage = 48;
			
			Item.DamageType = DamageClass.Throwing;
			Item.maxStack = 1;
			Item.rare = 2;
			Item.value = 3333;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.shootSpeed = 16f;
			Item.shoot = Mod.Find<ModProjectile>("RecluseFang").Type;
		}
		
		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.SpiderFang, 12);
            recipe.AddIngredient(Mod.FindItem("SpiderFangarang").Type, 3);
			recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
	}
}
