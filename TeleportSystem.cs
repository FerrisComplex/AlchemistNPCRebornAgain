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

#nullable enable
namespace AlchemistNPCRebornAgain
{
  public class TeleportSystem : ModPlayer
  {
    public void DoHomeTeleport() 
    {
		for (int k = 0; k < 70; k++) {
			Dust.NewDust(Player.position, Player.width, Player.height, DustID.MagicMirror, Player.velocity.X * 0.5f, Player.velocity.Y * 0.5f, 150, default(Color), 1.5f);
		}
		Player.FindSpawn();
		int spawnX = Player.SpawnX, spawnY = Player.SpawnY;
		Player.RemoveSpawn();
		Player.RemoveAllGrapplingHooks();
		Player.Spawn(PlayerSpawnContext.RecallFromItem);
		if (spawnX != -1 && spawnY != -1) {
			Player.ChangeSpawn(spawnX, spawnY);
		}
		for (int l = 0; l < 70; l++) {
			Dust.NewDust(Player.position, Player.width, Player.height, DustID.MagicMirror, 0f, 0f, 150, default(Color), 1.5f);
		}
	}
  }
}