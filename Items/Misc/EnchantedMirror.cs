﻿using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.GameInput;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
 
namespace AlchemistNPCRebornAgain.Items.Misc
{
    public class EnchantedMirror : ModItem
    {

        
		public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MagicMirror);
            Item.maxStack = 1;
			Item.useAnimation = 15;
            Item.useTime = 15;
            Item.consumable = false;
            return;
        }
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			if (player.altFunctionUse == 0)
			{
			AlchemistNPCRebornAgain.ppx = player.position.X;
			AlchemistNPCRebornAgain.ppy = player.position.Y;
			player.GetModPlayer<TeleportSystem>().DoHomeTeleport();
			player.AddBuff(BuffID.ChaosState, 300);
			}
			if (player.altFunctionUse == 2)
			{
			HandleRecallTeleport(player);
			player.AddBuff(BuffID.ChaosState, 300);
			}
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			return (player.HasBuff(BuffID.ChaosState) == false);
		}
		
		private static void HandleRecallTeleport(Player player, bool syncData = false)
		{
			if (AlchemistNPCRebornAgain.ppx != 0f)
			{
			RunTeleport(player, new Vector2(AlchemistNPCRebornAgain.ppx, AlchemistNPCRebornAgain.ppy), syncData, false);
			}
			else return;
		}
		
		private static void RunTeleport(Player player, Vector2 pos, bool syncData = false, bool convertFromTiles = false)
		{
			bool postImmune = player.immune;
			int postImmunteTime = player.immuneTime;

			if (convertFromTiles)
				pos = new Vector2(pos.X * 16 + 8 - player.width / 2, pos.Y * 16 - player.height);

			LeaveDust(player);

			player.grappling[0] = -1;
			player.grapCount = 0;
			for (int index = 0; index < 1000; ++index)
			{
				if (Main.projectile[index].active && Main.projectile[index].owner == player.whoAmI && Main.projectile[index].aiStyle == 7)
					Main.projectile[index].Kill();
			}

			player.Teleport(pos, 2, 0);
			player.velocity = Vector2.Zero;
			player.immune = postImmune;
			player.immuneTime = postImmunteTime;

			LeaveDust(player);

			if (Main.netMode != 2)
				return;

			if (syncData)
			{
				RemoteClient.CheckSection(player.whoAmI, player.position, 1);
				NetMessage.SendData(65, -1, -1, null, 0, (float)player.whoAmI, pos.X, pos.Y, 3, 0, 0);
			}
		}

		private static void LeaveDust(Player player)
		{
			for (int index = 0; index < 70; ++index)
				Main.dust[Dust.NewDust(player.position, player.width, player.height, 15, player.velocity.X * 0.2f, player.velocity.Y * 0.2f, 150, Color.Cyan, 1.2f)].velocity *= 0.5f;
			Main.TeleportEffect(player.getRect(), 1);
			Main.TeleportEffect(player.getRect(), 3);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "Beacon");
			recipe.AddIngredient(ItemID.MagicMirror);
			recipe.AddIngredient(ItemID.RecallPotion, 30);
			recipe.AddIngredient(ItemID.WormholePotion, 30);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddTile(TileID.CrystalBall);
			recipe.Register();
		}

		
		
    }
}
