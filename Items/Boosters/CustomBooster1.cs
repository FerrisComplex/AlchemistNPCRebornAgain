using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Boosters
{
	class CustomBooster1 : ModItem
	{

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool? UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().CustomBooster1 == 0)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().CustomBooster1 = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCRebornPlayer>().CustomBooster1 == 1)
			{
				player.GetModPlayer<AlchemistNPCRebornPlayer>().CustomBooster1 = 0;
				return true;
			}
			return base.UseItem(player);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(Item.type);
			recipe.AddIngredient(ModContent.ItemType<BrokenBooster1>(), 1);
			recipe.AddIngredient(ItemID.ShinePotion, 30);
			recipe.AddIngredient(ItemID.NightOwlPotion, 30);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
