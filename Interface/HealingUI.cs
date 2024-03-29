﻿using ReLogic.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System;
using Terraria.ID;
using System.Linq;
using AlchemistNPCRebornAgain;
using ReLogic.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.Audio;
using System;
using Terraria.ID;
using System.Linq;
using AlchemistNPCRebornAgain.NPCs;
using ReLogic.Content;
using Terraria.Utilities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.UI;
using Terraria.GameInput;

namespace AlchemistNPCRebornAgain.Interface
{
		class HealingUI : UIState
	{
		public UIPanel HealingUIPanel;
		public static bool visible = false;
		
		public override void OnInitialize()
		{
			HealingUIPanel = new UIPanel();
			HealingUIPanel.SetPadding(0);
			HealingUIPanel.Left.Set(575f, 0f);
			HealingUIPanel.Top.Set(275f, 0f);
			HealingUIPanel.Width.Set(275f, 0f);
			HealingUIPanel.Height.Set(90f, 0f);
			HealingUIPanel.BackgroundColor = new Color(73, 94, 171);

			HealingUIPanel.OnLeftMouseDown += new UIElement.MouseEvent(DragStart);
			HealingUIPanel.OnLeftMouseUp += new UIElement.MouseEvent(DragEnd);
			
			Mod mod = AlchemistNPCRebornAgain.Instance;
			Asset<Texture2D> Yes = ModContent.Request<Texture2D>("AlchemistNPCRebornAgain/Interface/Yes");
			Asset<Texture2D> No = ModContent.Request<Texture2D>("AlchemistNPCRebornAgain/Interface/No");
			//Texture2D Yes = mod.GetTexture("Interface/Yes");
			//Texture2D No = mod.GetTexture("Interface/No");

			string UItext;
			if(Language.ActiveCulture == GameCulture.FromCultureName(GameCulture.CultureName.Chinese))
			{
				UItext = "你要付医疗费吗?";
			}
			else
			{
				UItext = "Would you pay the doctor's fee?";
			}
			
			UIText text = new UIText(UItext);
			text.Left.Set(10, 0f);
			text.Top.Set(10, 0f);
			text.Width.Set(60, 0f);
			text.Height.Set(22, 0f);
			HealingUIPanel.Append(text);

			UIImageButton playButton = new UIImageButton(Yes);
			playButton.Left.Set(40, 0f);
			playButton.Top.Set(45, 0f);
			playButton.Width.Set(40, 0f);
			playButton.Height.Set(28, 0f);
			playButton.OnLeftClick += new MouseEvent(PlayButtonClicked1);
			HealingUIPanel.Append(playButton);
			
			UIImageButton closeButton = new UIImageButton(No);
			closeButton.Left.Set(188, 0f);
			closeButton.Top.Set(45, 0f);
			closeButton.Width.Set(40, 0f);
			closeButton.Height.Set(28, 0f);
			closeButton.OnLeftClick += new MouseEvent(CloseButtonClicked);
			HealingUIPanel.Append(closeButton);
			base.Append(HealingUIPanel);
		}

		private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
		{
			int num5 = Main.player[Main.myPlayer].statLifeMax2 - Main.player[Main.myPlayer].statLife;
			int num13 = 0;
			int num14 = 0;
			int num15 = 0;
			int num16 = 0;
			int num17 = num5;
			if (num17 > 0)
			{
				num17 = (int)((double)num17 * 0.75);
				if (num17 < 1)
				{
					num17 = 1;
				}
			}
			if (num17 < 0)
			{
				num17 = 0;
			}
			num5 = num17;
			if (num17 >= 1000000)
			{
				num13 = num17 / 1000000;
				num17 -= num13 * 1000000;
			}
			if (num17 >= 10000)
			{
				num14 = num17 / 10000;
				num17 -= num14 * 10000;
			}
			if (num17 >= 100)
			{
				num15 = num17 / 100;
				num17 -= num15 * 100;
			}
			if (num17 >= 1)
			{
				num16 = num17;
			}
			if (num5 > 0)
			{
				if (Main.player[Main.myPlayer].BuyItem(num5, -1))
				{
					SoundEngine.PlaySound(SoundID.Item4);
					Main.player[Main.myPlayer].HealEffect(Main.player[Main.myPlayer].statLifeMax2 - Main.player[Main.myPlayer].statLife, true);
					Main.player[Main.myPlayer].statLife = Main.player[Main.myPlayer].statLifeMax2;
					if(Language.ActiveCulture == GameCulture.FromCultureName(GameCulture.CultureName.Chinese))
					{
						Main.NewText("[c/00FF00:护士]: 好了. 祝您今天愉快!", 0, 0, 0);
					}
					else
					{
						Main.NewText("[c/00FF00:Nurse]: Done. Have a good day!", 0, 0, 0);
					}
				}
				else
				{
					SoundEngine.PlaySound(SoundID.Item16);
					if(Language.ActiveCulture == GameCulture.FromCultureName(GameCulture.CultureName.Chinese))
					{
						Main.NewText("[c/00FF00:护士]: 你付不起医疗费!", 0, 0, 0);
					}
					else
					{
						Main.NewText("[c/00FF00:Nurse]: You cannot afford to pay the fee!", 0, 0, 0);
					}
				}
			}
			HealingUI.visible = false;
		}

		private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
		{
			SoundEngine.PlaySound(SoundID.MenuOpen);
			visible = false;
		}

		Vector2 offset;
		public bool dragging = false;
		private void DragStart(UIMouseEvent evt, UIElement listeningElement)
		{
			offset = new Vector2(evt.MousePosition.X - HealingUIPanel.Left.Pixels, evt.MousePosition.Y - HealingUIPanel.Top.Pixels);
			dragging = true;
		}

		private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
		{
			Vector2 end = evt.MousePosition;
			dragging = false;

			HealingUIPanel.Left.Set(end.X - offset.X, 0f);
			HealingUIPanel.Top.Set(end.Y - offset.Y, 0f);

			Recalculate();
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (HealingUIPanel.ContainsPoint(MousePosition))
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			if (dragging)
			{
				HealingUIPanel.Left.Set(MousePosition.X - offset.X, 0f);
				HealingUIPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
				Recalculate();
			}
		}
	}
}
