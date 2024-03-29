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

namespace AlchemistNPCRebornAgain.Interface
{
    class ShopChangeUIO : UIState
    {
        public UIPanel OperatorShopsPanel;
        public static bool visible = false;
        public static uint timeStart;

        public override void OnInitialize()
        {
            OperatorShopsPanel = new UIPanel();
            OperatorShopsPanel.SetPadding(0);
            OperatorShopsPanel.Left.Set(575f, 0f);
            OperatorShopsPanel.Top.Set(275f, 0f);
            OperatorShopsPanel.Width.Set(300f, 0f);
            OperatorShopsPanel.Height.Set(250f, 0f);
            OperatorShopsPanel.BackgroundColor = new Color(73, 94, 171);

            OperatorShopsPanel.OnLeftMouseDown += new UIElement.MouseEvent(DragStart);
            OperatorShopsPanel.OnLeftMouseUp += new UIElement.MouseEvent(DragEnd);

            UIText text = new UIText("Vanilla Materials/Boss Drops");
            text.Left.Set(35, 0f);
            text.Top.Set(10, 0f);
            text.Width.Set(90, 0f);
            text.Height.Set(22, 0f);
            OperatorShopsPanel.Append(text);

            UIText text1 = new UIText("Modded Materials/Boss Drops");
            text1.Left.Set(35, 0f);
            text1.Top.Set(40, 0f);
            text1.Width.Set(90, 0f);
            text1.Height.Set(22, 0f);
            OperatorShopsPanel.Append(text1);

            UIText text2 = new UIText("EGO Shop");
            text2.Left.Set(35, 0f);
            text2.Top.Set(70, 0f);
            text2.Width.Set(70, 0f);
            text2.Height.Set(22, 0f);
            OperatorShopsPanel.Append(text2);

            UIText text3 = new UIText("Vanilla Treasure Bags");
            text3.Left.Set(35, 0f);
            text3.Top.Set(100, 0f);
            text3.Width.Set(70, 0f);
            text3.Height.Set(22, 0f);
            OperatorShopsPanel.Append(text3);

            UIText text4 = new UIText("Modded Treasure Bags #1");
            text4.Left.Set(35, 0f);
            text4.Top.Set(130, 0f);
            text4.Width.Set(120, 0f);
            text4.Height.Set(22, 0f);
            OperatorShopsPanel.Append(text4);

            UIText text5 = new UIText("Modded Treasure Bags #2");
            text5.Left.Set(35, 0f);
            text5.Top.Set(160, 0f);
            text5.Width.Set(120, 0f);
            text5.Height.Set(22, 0f);
            OperatorShopsPanel.Append(text5);

            UIText text6 = new UIText("Modded Treasure Bags #3");
            text6.Left.Set(35, 0f);
            text6.Top.Set(190, 0f);
            text6.Width.Set(120, 0f);
            text6.Height.Set(22, 0f);
            OperatorShopsPanel.Append(text6);

            Asset<Texture2D> buttonPlayTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonPlay");
            UIImageButton playButton = new UIImageButton(buttonPlayTexture);
            playButton.Left.Set(10, 0f);
            playButton.Top.Set(10, 0f);
            playButton.Width.Set(22, 0f);
            playButton.Height.Set(22, 0f);
            playButton.OnLeftClick += new MouseEvent(PlayButtonClicked1);
            OperatorShopsPanel.Append(playButton);
            UIImageButton playButton1 = new UIImageButton(buttonPlayTexture);
            playButton1.Left.Set(10, 0f);
            playButton1.Top.Set(40, 0f);
            playButton1.Width.Set(22, 0f);
            playButton1.Height.Set(22, 0f);
            playButton1.OnLeftClick += new MouseEvent(PlayButtonClicked11);
            OperatorShopsPanel.Append(playButton1);
            UIImageButton playButton2 = new UIImageButton(buttonPlayTexture);
            playButton2.Left.Set(10, 0f);
            playButton2.Top.Set(70, 0f);
            playButton2.Width.Set(22, 0f);
            playButton2.Height.Set(22, 0f);
            playButton2.OnLeftClick += new MouseEvent(PlayButtonClicked9);
            OperatorShopsPanel.Append(playButton2);
            UIImageButton playButton3 = new UIImageButton(buttonPlayTexture);
            playButton3.Left.Set(10, 0f);
            playButton3.Top.Set(100, 0f);
            playButton3.Width.Set(22, 0f);
            playButton3.Height.Set(22, 0f);
            playButton3.OnLeftClick += new MouseEvent(PlayButtonClicked2);
            OperatorShopsPanel.Append(playButton3);
            UIImageButton playButton4 = new UIImageButton(buttonPlayTexture);
            playButton4.Left.Set(10, 0f);
            playButton4.Top.Set(130, 0f);
            playButton4.Width.Set(22, 0f);
            playButton4.Height.Set(22, 0f);
            playButton4.OnLeftClick += new MouseEvent(PlayButtonClicked3);
            OperatorShopsPanel.Append(playButton4);
            UIImageButton playButton5 = new UIImageButton(buttonPlayTexture);
            playButton5.Left.Set(10, 0f);
            playButton5.Top.Set(160, 0f);
            playButton5.Width.Set(22, 0f);
            playButton5.Height.Set(22, 0f);
            playButton5.OnLeftClick += new MouseEvent(PlayButtonClicked4);
            OperatorShopsPanel.Append(playButton5);
            UIImageButton playButton6 = new UIImageButton(buttonPlayTexture);
            playButton6.Left.Set(10, 0f);
            playButton6.Top.Set(190, 0f);
            playButton6.Width.Set(22, 0f);
            playButton6.Height.Set(22, 0f);
            playButton6.OnLeftClick += new MouseEvent(PlayButtonClicked5);
            OperatorShopsPanel.Append(playButton6);

            Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonDelete");
            UIImageButton closeButton = new UIImageButton(buttonDeleteTexture);
            closeButton.Left.Set(270, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnLeftClick += new MouseEvent(CloseButtonClicked);
            OperatorShopsPanel.Append(closeButton);
            base.Append(OperatorShopsPanel);
        }

        private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCRebornAgain.modConfiguration.ShopChangeDelay)
            {
                Operator.Shop1 = true;
                Operator.Shop2 = false;
                Operator.egoShop = false;
                Operator.Shop3 = false;
                Operator.Shop4 = false;
                Operator.Shop5 = false;
                Operator.Shop6 = false;
                NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
                ShopChangeUIO.visible = false;
                Main.playerInventory = true;
                Main.npcChatText = "";
                Main.SetNPCShopIndex(Main.MaxShopIDs - 1);
                Main.instance.shop[Main.npcShop].SetupShop(npc.type);
            }
        }

        private void PlayButtonClicked11(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCRebornAgain.modConfiguration.ShopChangeDelay)
            {
                Operator.Shop1 = false;
                Operator.Shop2 = true;
                Operator.egoShop = false;
                Operator.Shop3 = false;
                Operator.Shop4 = false;
                Operator.Shop5 = false;
                Operator.Shop6 = false;
                NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
                ShopChangeUIO.visible = false;
                Main.playerInventory = true;
                Main.npcChatText = "";
                Main.SetNPCShopIndex(Main.MaxShopIDs - 1);
                Main.instance.shop[Main.npcShop].SetupShop(npc.type);
            }
        }

        private void PlayButtonClicked9(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCRebornAgain.modConfiguration.ShopChangeDelay)
            {
                Operator.Shop1 = false;
                Operator.Shop2 = false;
                Operator.egoShop = true;
                Operator.Shop3 = false;
                Operator.Shop4 = false;
                Operator.Shop5 = false;
                Operator.Shop6 = false;
                NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
                ShopChangeUIO.visible = false;
                Main.playerInventory = true;
                Main.npcChatText = "";
                Main.SetNPCShopIndex(Main.MaxShopIDs - 1);
                Main.instance.shop[Main.npcShop].SetupShop(npc.type);
            }
        }

        private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCRebornAgain.modConfiguration.ShopChangeDelay)
            {
                Operator.Shop1 = false;
                Operator.Shop2 = false;
                Operator.egoShop = false;
                Operator.Shop3 = true;
                Operator.Shop4 = false;
                Operator.Shop5 = false;
                Operator.Shop6 = false;
                NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
                ShopChangeUIO.visible = false;
                Main.playerInventory = true;
                Main.npcChatText = "";
                Main.SetNPCShopIndex(Main.MaxShopIDs - 1);
                Main.instance.shop[Main.npcShop].SetupShop(npc.type);
            }
        }

        private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCRebornAgain.modConfiguration.ShopChangeDelay)
            {
                Operator.Shop1 = false;
                Operator.Shop2 = false;
                Operator.egoShop = false;
                Operator.Shop3 = false;
                Operator.Shop4 = true;
                Operator.Shop5 = false;
                Operator.Shop6 = false;
                NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
                ShopChangeUIO.visible = false;
                Main.playerInventory = true;
                Main.npcChatText = "";
                Main.SetNPCShopIndex(Main.MaxShopIDs - 1);
                Main.instance.shop[Main.npcShop].SetupShop(npc.type);
            }
        }

        private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCRebornAgain.modConfiguration.ShopChangeDelay)
            {
                Operator.Shop1 = false;
                Operator.Shop2 = false;
                Operator.egoShop = false;
                Operator.Shop3 = false;
                Operator.Shop4 = false;
                Operator.Shop5 = true;
                Operator.Shop6 = false;
                NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
                ShopChangeUIO.visible = false;
                Main.playerInventory = true;
                Main.npcChatText = "";
                Main.SetNPCShopIndex(Main.MaxShopIDs - 1);
                Main.instance.shop[Main.npcShop].SetupShop(npc.type);
            }
        }

        private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCRebornAgain.modConfiguration.ShopChangeDelay)
            {
                Operator.Shop1 = false;
                Operator.Shop2 = false;
                Operator.egoShop = false;
                Operator.Shop3 = false;
                Operator.Shop4 = false;
                Operator.Shop5 = false;
                Operator.Shop6 = true;
                NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
                ShopChangeUIO.visible = false;
                Main.playerInventory = true;
                Main.npcChatText = "";
                Main.SetNPCShopIndex(Main.MaxShopIDs - 1);
                Main.instance.shop[Main.npcShop].SetupShop(npc.type);
            }
        }

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCRebornAgain.modConfiguration.ShopChangeDelay)
            {
                SoundEngine.PlaySound(SoundID.MenuOpen);
                visible = false;
            }
        }

        Vector2 offset;
        public bool dragging = false;
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - OperatorShopsPanel.Left.Pixels, evt.MousePosition.Y - OperatorShopsPanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            OperatorShopsPanel.Left.Set(end.X - offset.X, 0f);
            OperatorShopsPanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (OperatorShopsPanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                OperatorShopsPanel.Left.Set(MousePosition.X - offset.X, 0f);
                OperatorShopsPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
    }
}
