﻿using ReLogic.Graphics;
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
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Interface
{
	class ShopChangeUIT : UIState
	{
		public UIPanel TinkererShopsPanel;
		public static bool visible = false;

		public override void OnInitialize()
		{
			TinkererShopsPanel = new UIPanel();
			TinkererShopsPanel.SetPadding(0);
			TinkererShopsPanel.Left.Set(575f, 0f);
			TinkererShopsPanel.Top.Set(275f, 0f);
			TinkererShopsPanel.Width.Set(200f, 0f);
			TinkererShopsPanel.Height.Set(105f, 0f);
			TinkererShopsPanel.BackgroundColor = new Color(73, 94, 171);

			TinkererShopsPanel.OnLeftMouseDown += new UIElement.MouseEvent(DragStart);
			TinkererShopsPanel.OnLeftMouseUp += new UIElement.MouseEvent(DragEnd);

			string TinkererShops1; 
			string TinkererShops2;
			string TinkererShops3;

			if(Language.ActiveCulture == GameCulture.FromCultureName(GameCulture.CultureName.Chinese))
				{
					TinkererShops1 = "移动/其他饰品";
					TinkererShops2 = "战斗";
					TinkererShops3 = "战斗";
				}
			else
				{
					TinkererShops1 = "Movement/Misc";
					TinkererShops2 = "Combat";
					TinkererShops3 = "Tokens";
				}
			
			UIText text = new UIText(TinkererShops1);
			text.Left.Set(35, 0f);
			text.Top.Set(10, 0f);
			text.Width.Set(90, 0f);
			text.Height.Set(22, 0f);
			TinkererShopsPanel.Append(text);
			
			UIText text2 = new UIText(TinkererShops2);
			text2.Left.Set(35, 0f);
			text2.Top.Set(40, 0f);
			text2.Width.Set(50, 0f);
			text2.Height.Set(22, 0f);
			TinkererShopsPanel.Append(text2);
			
			UIText text3 = new UIText(TinkererShops3);
			text3.Left.Set(35, 0f);
			text3.Top.Set(70, 0f);
			text3.Width.Set(50, 0f);
			text3.Height.Set(22, 0f);
			TinkererShopsPanel.Append(text3);
			
			Asset<Texture2D> buttonPlayTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonPlay");
			UIImageButton playButton = new UIImageButton(buttonPlayTexture);
			playButton.Left.Set(10, 0f);
			playButton.Top.Set(10, 0f);
			playButton.Width.Set(22, 0f);
			playButton.Height.Set(22, 0f);
			playButton.OnLeftClick += new MouseEvent(PlayButtonClicked1);
			TinkererShopsPanel.Append(playButton);
			UIImageButton playButton2 = new UIImageButton(buttonPlayTexture);
			playButton2.Left.Set(10, 0f);
			playButton2.Top.Set(40, 0f);
			playButton2.Width.Set(22, 0f);
			playButton2.Height.Set(22, 0f);
			playButton2.OnLeftClick += new MouseEvent(PlayButtonClicked2);
			TinkererShopsPanel.Append(playButton2);
			UIImageButton playButton3 = new UIImageButton(buttonPlayTexture);
			playButton3.Left.Set(10, 0f);
			playButton3.Top.Set(70, 0f);
			playButton3.Width.Set(22, 0f);
			playButton3.Height.Set(22, 0f);
			playButton3.OnLeftClick += new MouseEvent(PlayButtonClicked3);
			TinkererShopsPanel.Append(playButton3);

			Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonDelete");
			UIImageButton closeButton = new UIImageButton(buttonDeleteTexture);
			closeButton.Left.Set(170, 0f);
			closeButton.Top.Set(10, 0f);
			closeButton.Width.Set(22, 0f);
			closeButton.Height.Set(22, 0f);
			closeButton.OnLeftClick += new MouseEvent(CloseButtonClicked);
			TinkererShopsPanel.Append(closeButton);
			base.Append(TinkererShopsPanel);
		}

		private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
		{
			Tinkerer.Shop = 1;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIT.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.SetNPCShopIndex(Main.MaxShopIDs - 1);
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
		{
			Tinkerer.Shop = 2;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIT.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.SetNPCShopIndex(Main.MaxShopIDs - 1);
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
		}
		
		private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
		{
			Tinkerer.Shop = 3;
			NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
			ShopChangeUIT.visible = false;
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.SetNPCShopIndex(Main.MaxShopIDs - 1);
			Main.instance.shop[Main.npcShop].SetupShop(npc.type);
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
			offset = new Vector2(evt.MousePosition.X - TinkererShopsPanel.Left.Pixels, evt.MousePosition.Y - TinkererShopsPanel.Top.Pixels);
			dragging = true;
		}

		private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
		{
			Vector2 end = evt.MousePosition;
			dragging = false;

			TinkererShopsPanel.Left.Set(end.X - offset.X, 0f);
			TinkererShopsPanel.Top.Set(end.Y - offset.Y, 0f);

			Recalculate();
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (TinkererShopsPanel.ContainsPoint(MousePosition))
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			if (dragging)
			{
				TinkererShopsPanel.Left.Set(MousePosition.X - offset.X, 0f);
				TinkererShopsPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
				Recalculate();
			}
		}
	}
}
