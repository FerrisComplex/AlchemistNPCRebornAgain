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
using Terraria.GameContent.Events;

namespace AlchemistNPCRebornAgain.Items.Misc
{
	public class WorldControlUnit : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.rare = 5;
			Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 4;
			Item.UseSound = SoundID.Item4;
			Item.consumable = false;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool ConsumeItem(Player player)
		{
			return false;
		}
		
		public override bool? UseItem(Player player)
        {
			if (player.altFunctionUse == 2)
			{
				if (player.ZoneDesert)
				{
					if (Sandstorm.Happening)
					{
						Sandstorm.Happening = false;
						Sandstorm.TimeLeft = 0;
					}
					else
					{
						Sandstorm.Happening = true;
						Sandstorm.TimeLeft = 36000;
					}
				} else {
					if (Main.raining)
					{
						Main.rainTime = 0;
						Main.maxRaining = 0f;
						Main.raining = false;
					}
					else
					{
						Main.rainTime = 24000;
						Main.maxRaining = 1f;
						Main.raining = true;
					}
				}
				
			} 
			else 
			{
				if (Main.dayTime)
				{
					Main.dayTime = false;
					Main.time = 0.0;
					return true;
				}
				if (!Main.dayTime)
				{
					Main.dayTime = true;
					Main.time = 0.0;
					return true;
				}
			}
			return base.UseItem(player);
		}
	}
}
