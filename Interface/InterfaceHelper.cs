using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.UI;
using AlchemistNPCRebornAgain.Interface;

namespace AlchemistNPCRebornAgain.Interface
{
	public static class InterfaceHelper
	{

		public static void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			for (int k = 0; k < layers.Count; k++)
			{
				if (layers[k].Name == "Vanilla: Resource Bars")
				{
					layers.Insert(k + 1, new LegacyGameInterfaceLayer("AlchemistNPC: Shield Bar", DrawShieldBar, InterfaceScaleType.UI));
				}
				if (layers[k].Name == "Vanilla: Resource Bars")
				{
					layers.Insert(k + 2, new LegacyGameInterfaceLayer("AlchemistNPC: Disaster Bar", DrawDisasterBar, InterfaceScaleType.UI));
				}
			}
		}

		private static bool DrawShieldBar()
		{
			int anchorX = Main.screenWidth / 2 - 175;
			Player player = Main.player[Main.myPlayer];
			if (player.ghost)
			{
				return true;
			}
			Mod mod = AlchemistNPCRebornAgain.Instance;
			AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
			if (modPlayer.ShieldBelt == false)
			{
				return true;
			}

			const int barSize = 128;
			const int padding = 4;
			const int chargeSize = barSize - 2 * padding;
			const int chargeHeight = 20;
			DynamicSpriteFont font = FontAssets.MouseText.Value;
			float Shield = Math.Min(modPlayer.Shield, 150);
			string chargeText = Shield + "/" + 150;
			string maxText = "Shield Charge: " + 150 + "/" + 150;
			Vector2 maxTextSize = font.MeasureString(maxText);
			Color textColor = new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor);
			Main.spriteBatch.DrawString(font, "Shield Charge:", new Vector2(anchorX + barSize / 2 - maxTextSize.X / 2f, 42f), textColor, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
			Main.spriteBatch.DrawString(font, chargeText, new Vector2(anchorX + barSize / 2 + maxTextSize.X / 2f, 42f), textColor, 0f, new Vector2(font.MeasureString(chargeText).X, 0f), 1f, SpriteEffects.None, 0f);

		

			float fill = Shield / 150;
			Main.spriteBatch.Draw(ModContent.Request<Texture2D>("AlchemistNPCRebornAgain/Interface/ShieldBar").Value, new Vector2(anchorX, 64f), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(ModContent.Request<Texture2D>("AlchemistNPCRebornAgain/Interface/ShieldCharge").Value, new Vector2(anchorX + padding, 64f + padding), new Rectangle(0, 0, (int)(fill * chargeSize), chargeHeight), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(ModContent.Request<Texture2D>("AlchemistNPCRebornAgain/Interface/ShieldBarShield").Value, new Vector2(anchorX + padding, 64f + padding), new Rectangle(0, 0, (int)(fill * chargeSize), chargeHeight), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

			return true;
		}
		
		private static bool DrawDisasterBar()
		{
			int anchorX = Main.screenWidth / 2 + 175;
			Player player = Main.player[Main.myPlayer];
			if (player.ghost)
			{
				return true;
			}
			Mod mod = AlchemistNPCRebornAgain.Instance;
			AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
			if (modPlayer.PH == false)
			{
				return true;
			}

			const int barSize = 128;
			const int padding = 4;
			const int chargeSize = barSize - 2 * padding;
			const int chargeHeight = 20;
			DynamicSpriteFont font = FontAssets.MouseText.Value;
			float Gauge = Math.Min(modPlayer.DisasterGauge, 500);
			string chargeText = Gauge + "/" + 500;
			string maxText = "Disaster Gauge: " + 500 + "/" + 500;
			Vector2 maxTextSize = font.MeasureString(maxText);
			Color textColor = new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor);
			Main.spriteBatch.DrawString(font, "Disaster Gauge:", new Vector2(anchorX + barSize / 2 - maxTextSize.X / 2f, 42f), textColor, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
			Main.spriteBatch.DrawString(font, chargeText, new Vector2(anchorX + barSize / 2 + maxTextSize.X / 2f, 42f), textColor, 0f, new Vector2(font.MeasureString(chargeText).X, 0f), 1f, SpriteEffects.None, 0f);

			float fill = Gauge / 500;
			Main.spriteBatch.Draw(ModContent.Request<Texture2D>("AlchemistNPCRebornAgain/Interface/DisasterBar").Value, new Vector2(anchorX, 64f), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(ModContent.Request<Texture2D>("AlchemistNPCRebornAgain/Interface/DisasterCharge").Value, new Vector2(anchorX + padding, 64f + padding), new Rectangle(0, 0, (int)(fill * chargeSize), chargeHeight), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

			return true;
		}

		public static Rectangle GetFullRectangle(UIElement element)
		{
			CalculatedStyle dim = element.GetDimensions();
			return GetFullRectangle((int)dim.X, (int)dim.Y, (int)dim.Width, (int)dim.Height);
		}

		public static Rectangle GetFullRectangle(int x, int y, int width, int height)
		{
			Vector2 vector = new Vector2(x, y);
			Vector2 position = new Vector2(width, height) + vector;
			vector = Vector2.Transform(vector, Main.UIScaleMatrix);
			position = Vector2.Transform(position, Main.UIScaleMatrix);
			Rectangle result = new Rectangle((int)vector.X, (int)vector.Y, (int)(position.X - vector.X), (int)(position.Y - vector.Y));
			int sWidth = Main.spriteBatch.GraphicsDevice.Viewport.Width;
			int sHeight = Main.spriteBatch.GraphicsDevice.Viewport.Height;
			result.X = Utils.Clamp<int>(result.X, 0, sWidth);
			result.Y = Utils.Clamp<int>(result.Y, 0, sHeight);
			result.Width = Utils.Clamp<int>(result.Width, 0, sWidth - result.X);
			result.Height = Utils.Clamp<int>(result.Height, 0, sHeight - result.Y);
			return result;
		}
	}
}
