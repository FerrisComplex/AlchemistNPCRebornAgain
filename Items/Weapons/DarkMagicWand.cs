using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class DarkMagicWand : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 150;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Magic;
			Item.channel = true;                            //Channel so that you can held the weapon [Important]
			Item.mana = 10;
			Item.rare = 11;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 20;
			Item.UseSound = SoundID.Item13;
			Item.useStyle = 5;
			Item.shootSpeed = 14f;
			Item.useAnimation = 20;   
			Item.knockBack = 1;			
			Item.shoot = Mod.Find<ModProjectile>("MagicWandC").Type;
			Item.value = Item.sellPrice(1, 0, 0, 0);
		}
		
		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			Item.damage = 150;
			Item.mana = 10;
			player.GetModPlayer<AlchemistNPCRebornPlayer>().chargetime++;
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().chargetime >= 390)
			{
				Item.damage = 250;
				Item.mana = 30;
				player.moveSpeed *= 0.50f;
			}
			else if (player.GetModPlayer<AlchemistNPCRebornPlayer>().chargetime >= 210)
			{
				Item.damage = 200;
				Item.mana = 20;
				player.moveSpeed *= 0.8f;
			}
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "MagicWand");
			recipe.AddIngredient(null, "ChromaticCrystal", 3);
			recipe.AddIngredient(null, "SunkroveraCrystal", 3);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 3);
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
