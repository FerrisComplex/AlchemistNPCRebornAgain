using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Equippable
{
	public class IlluminatiGift : ModItem
	{
	
		public override void SetDefaults()
		{
			Item.stack = 1;
			Item.width = 34;
			Item.height = 34;
			Item.value = 1000000;
			Item.rare = 11;
			Item.accessory = true;
			Item.defense = 4;
			Item.expert = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			(player.GetModPlayer<AlchemistNPCRebornPlayer>()).Illuminati = true;
			if (!hideVisual)
			{
				player.goldRing = true;
				for (int number = 0; number < 400; ++number)
				{
					if (Main.item[number].active && Main.item[number].noGrabDelay == 0)
					{
						int num1 = Player.defaultItemGrabRange*10;
						if (new Microsoft.Xna.Framework.Rectangle((int)player.position.X - num1, (int)player.position.Y - num1, player.width + num1 * 2, player.height + num1 * 2).Intersects(new Microsoft.Xna.Framework.Rectangle((int)Main.item[number].position.X, (int)Main.item[number].position.Y, Main.item[number].width, Main.item[number].height)))
						{
							Main.item[number].beingGrabbed = true;
							float num2 = 12f;
							Vector2 vector2 = new Vector2(Main.item[number].position.X + (float)(Main.item[number].width / 2), Main.item[number].position.Y + (float)(Main.item[number].height / 2));
							float num3 = player.Center.X - vector2.X;
							float num4 = player.Center.Y - vector2.Y;
							float num5 = (float)Math.Sqrt((double)num3 * (double)num3 + (double)num4 * (double)num4);
							float num6 = num2 / num5;
							float num7 = num3 * num6;
							float num8 = num4 * num6;
							int num9 = 5;
							Main.item[number].velocity.X = (Main.item[number].velocity.X * (float)(num9 - 1) + num7) / (float)num9;
							Main.item[number].velocity.Y = (Main.item[number].velocity.Y * (float)(num9 - 1) + num8) / (float)num9;
						}
					}
				}
			}
			player.discountAvailable = true;
			player.discountEquipped = true;
			if (player.statLife <= player.statLifeMax2/10 && !player.HasBuff(Mod.Find<ModBuff>("IlluminatiHeal").Type) && !player.HasBuff(Mod.Find<ModBuff>("IlluminatiCooldown").Type))
			{
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					player.AddBuff(Mod.Find<ModBuff>("IlluminatiHeal").Type, 3600);
					player.AddBuff(Mod.Find<ModBuff>("IlluminatiCooldown").Type, 7200);
				}
				if (ModLoader.GetMod("CalamityMod") == null)
				{
					player.AddBuff(Mod.Find<ModBuff>("IlluminatiHeal").Type, 3600);
					player.AddBuff(Mod.Find<ModBuff>("IlluminatiCooldown").Type, 7200);
				}
			}
		}
	}
}
