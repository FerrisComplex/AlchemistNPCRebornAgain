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
using Terraria.WorldBuilding;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class MordenkainenSword : ModItem
	{

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.damage = 56;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 30;
			Item.useAnimation = 39;
			Item.useStyle = 1;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.value = 10000000;
			Item.rare = 11;
            Item.knockBack = 8;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = Mod.Find<ModProjectile>("MordenkainenSword").Type;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			position = SPos;
			return true;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Excalibur);
			recipe.AddIngredient(ItemID.MagnetSphere);
			recipe.AddIngredient(ItemID.Ectoplasm, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
