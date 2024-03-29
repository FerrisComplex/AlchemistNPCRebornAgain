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
using ReLogic.Content;
using Terraria.Utilities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Linq;
using AlchemistNPCRebornAgain.NPCs;
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
    class ShopChangeUI : UIState
    {
        public UIPanel BrewerShopsPanel;
        public static bool visible = false;
        public static uint timeStart;

        public override void OnInitialize()
        {

            //Shop 21
            ModLoader.TryGetMod("CalamityMod", out Mod CalamityMod);
            //Shop 3
            ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod);
			
            BrewerShopsPanel = new UIPanel();
            BrewerShopsPanel.SetPadding(0);
            BrewerShopsPanel.Left.Set(575f, 0f);
            BrewerShopsPanel.Top.Set(275f, 0f);
            BrewerShopsPanel.Width.Set(385f, 0f);
            BrewerShopsPanel.Height.Set(190f, 0f);
            BrewerShopsPanel.BackgroundColor = new Color(73, 94, 171);

            BrewerShopsPanel.OnLeftMouseDown += new UIElement.MouseEvent(DragStart);
            BrewerShopsPanel.OnLeftMouseUp += new UIElement.MouseEvent(DragEnd);

            UIText text = new UIText("Vanilla");
            text.Left.Set(35, 0f);
            text.Top.Set(10, 0f);
            text.Width.Set(60, 0f);
            text.Height.Set(22, 0f);
            BrewerShopsPanel.Append(text);

            UIText text2 = new UIText("AlchemistNPC");
            text2.Left.Set(35, 0f);
            text2.Top.Set(40, 0f);
            text2.Width.Set(120, 0f);
            text2.Height.Set(22, 0f);
            BrewerShopsPanel.Append(text2);

            if (CalamityMod != null)
            {
                UIText text21 = new UIText("CalamityMod");
                text21.Left.Set(35, 0f);
                text21.Top.Set(70, 0f);
                text21.Width.Set(100, 0f);
                text21.Height.Set(22, 0f);
                BrewerShopsPanel.Append(text21);
            }

            if (ThoriumMod != null)
            {
                UIText text3 = new UIText("ThoriumMod");
                text3.Left.Set(35, 0f);
                text3.Top.Set(100, 0f);
                text3.Width.Set(70, 0f);
                text3.Height.Set(22, 0f);
                BrewerShopsPanel.Append(text3);
            }

            Asset<Texture2D> buttonPlayTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonPlay");
            UIImageButton playButton = new UIImageButton(buttonPlayTexture);
            playButton.Left.Set(10, 0f);
            playButton.Top.Set(10, 0f);
            playButton.Width.Set(22, 0f);
            playButton.Height.Set(22, 0f);
            playButton.OnLeftClick += new MouseEvent(PlayButtonClicked1);
            BrewerShopsPanel.Append(playButton);
			
            UIImageButton playButton2 = new UIImageButton(buttonPlayTexture);
            playButton2.Left.Set(10, 0f);
            playButton2.Top.Set(40, 0f);
            playButton2.Width.Set(22, 0f);
            playButton2.Height.Set(22, 0f);
            playButton2.OnLeftClick += new MouseEvent(PlayButtonClicked2);
            BrewerShopsPanel.Append(playButton2);
			
			
			
			if (CalamityMod != null)
            {
                UIImageButton playButton21 = new UIImageButton(buttonPlayTexture);
                playButton21.Left.Set(10, 0f);
                playButton21.Top.Set(70, 0f);
                playButton21.Width.Set(22, 0f);
                playButton21.Height.Set(22, 0f);
                playButton21.OnLeftClick += new MouseEvent(PlayButtonClicked21);
                BrewerShopsPanel.Append(playButton21);
			}
			
			if (ThoriumMod != null)
            {
                UIImageButton playButton3 = new UIImageButton(buttonPlayTexture);
                playButton3.Left.Set(10, 0f);
                playButton3.Top.Set(100, 0f);
                playButton3.Width.Set(22, 0f);
                playButton3.Height.Set(22, 0f);
                playButton3.OnLeftClick += new MouseEvent(PlayButtonClicked3);
                BrewerShopsPanel.Append(playButton3);
			}

            Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonDelete");
            UIImageButton closeButton = new UIImageButton(buttonDeleteTexture);
            closeButton.Left.Set(350, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnLeftClick += new MouseEvent(CloseButtonClicked);
            BrewerShopsPanel.Append(closeButton);
            base.Append(BrewerShopsPanel);
        }

        private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCRebornAgain.modConfiguration.ShopChangeDelay)
            {
                Brewer.Shop1 = true;
                Brewer.Shop2 = false;
                Brewer.Shop21 = false;
                Brewer.Shop3 = false;
                NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
                ShopChangeUI.visible = false;
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
                Brewer.Shop1 = false;
                Brewer.Shop2 = true;
                Brewer.Shop21 = false;
                Brewer.Shop3 = false;
                NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
                ShopChangeUI.visible = false;
                Main.playerInventory = true;
                Main.npcChatText = "";
                Main.SetNPCShopIndex(Main.MaxShopIDs - 1);
                Main.instance.shop[Main.npcShop].SetupShop(npc.type);
            }
        }

        private void PlayButtonClicked21(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCRebornAgain.modConfiguration.ShopChangeDelay)
            {
                Brewer.Shop1 = false;
                Brewer.Shop2 = false;
                Brewer.Shop21 = true;
                Brewer.Shop3 = false;
                NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
                ShopChangeUI.visible = false;
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
                Brewer.Shop1 = false;
                Brewer.Shop2 = false;
                Brewer.Shop21 = false;
                Brewer.Shop3 = true;
                NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
                ShopChangeUI.visible = false;
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
            offset = new Vector2(evt.MousePosition.X - BrewerShopsPanel.Left.Pixels, evt.MousePosition.Y - BrewerShopsPanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            BrewerShopsPanel.Left.Set(end.X - offset.X, 0f);
            BrewerShopsPanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (BrewerShopsPanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                BrewerShopsPanel.Left.Set(MousePosition.X - offset.X, 0f);
                BrewerShopsPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
    }
}
