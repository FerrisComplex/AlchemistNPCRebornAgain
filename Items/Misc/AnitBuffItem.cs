using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCRebornAgain;
using Terraria.Audio;

namespace AlchemistNPCRebornAgain.Items.Misc
{
	public class AntiBuffItem : ModItem
	{
		public override void SetStaticDefaults()
		{

			Language.GetOrRegister(Mod.GetLocalizationKey("AntiBuffmodeactive"), () => "AntiBuff mode is on.");
			Language.GetOrRegister(Mod.GetLocalizationKey("AntiBuffmodeisdisabled"), () => "AntiBuff mode is off.");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.rare = 5;
			Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 4;
			//Item.UseSound = SoundID.Item4;
		}
		
		public override bool? UseItem(Player player)
        {
			SoundStyle UnHardButSound = new SoundStyle("AlchemistNPCRebornAgain/Sounds/Item/AntiBuffChanged");
			SoundEngine.PlaySound(UnHardButSound);
			if (!AlchemistNPCRebornWorld.foundAntiBuffMode)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue(Mod.GetLocalizationKey("AntiBuffmodeactive")), 255, 255, 255);
				}
				AlchemistNPCRebornWorld.foundAntiBuffMode = true;
				return true;
			}
			if (AlchemistNPCRebornWorld.foundAntiBuffMode)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue(Mod.GetLocalizationKey("AntiBuffmodeisdisabled")), 255, 255, 255);
				}
				AlchemistNPCRebornWorld.foundAntiBuffMode = false;
				return true;
			}
			return base.UseItem(player);
		}
		
		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
	}
}
