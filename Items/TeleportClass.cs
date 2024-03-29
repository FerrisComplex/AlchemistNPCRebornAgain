using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items
{
    public class TeleportClass : GlobalItem
    {

        public static void HandleTeleport(int teleportType = 0, bool forceHandle = false, int whoAmI = 0)
        {
            bool syncData = forceHandle || Main.netMode == 0;
            if (syncData)
            {
                TeleportPlayer(teleportType, forceHandle, whoAmI);
            }
            else
            {
                SyncTeleport(teleportType);
            }
        }

        private static void SyncTeleport(int teleportType = 0)
        {
            var netMessage = AlchemistNPCRebornAgain.Instance.GetPacket();
            netMessage.Write((byte)AlchemistNPCRebornAgain.AlchemistNPCRebornMessageType.TeleportPlayer);
            netMessage.Write(teleportType);
            netMessage.Send();
        }

        private static void TeleportPlayer(int teleportType = 0, bool syncData = false, int whoAmI = 0)
        {
            Player player;
            if (!syncData)
            {
                player = Main.LocalPlayer;
            }
            else
            {
                player = Main.player[whoAmI];
            }
            switch (teleportType)
            {
                case 0:
                    HandleDungeonTeleport(player, syncData);
                    break;
                case 1:
                    HandleOceanTeleport(player, syncData);
                    break;
                case 2:
                    HandleOceanTeleportLeft(player, syncData);
                    break;
                case 3:
                    HandleBeachTeleportRight(player, syncData);
                    break;
                case 4:
                    HandleBeachTeleportLeft(player, syncData);
                    break;
                case 5:
                    HandleHellTeleport(player, syncData);
                    break;
                case 6:
                    HandleHellTeleportLeft(player, syncData);
                    break;
                case 7:
                    HandleTempleTeleport(player, syncData);
                    break;
                case 8:
                    HandleBeaconTeleport(player, syncData);
                    break;
                case 9:
                    HandleJungleTeleport(player, syncData);
                    break;
                case 10:
                    HandleJungleTeleportLeft(player, syncData);
                    break;
                default:
                    break;
            }
        }

        private static void HandleDungeonTeleport(Player player, bool syncData = false)
        {
            RunTeleport(player, new Vector2(Main.dungeonX, Main.dungeonY), syncData, true);
        }

        private static void HandleOceanTeleport(Player player, bool syncData = false)
        {
            Vector2 prePos = player.position;
            Vector2 pos = prePos;
            for (int x = 0; x < Main.tile.Width; ++x)
            {
                for (int y = 0; y < Main.tile.Height; ++y)
                {
                    if (Main.tile[x, y] == null) continue;
                    if (Main.tile[x, y].TileType != 81) continue;
                    pos = new Vector2((x + 1) * 16, (y - 16) * 16);
                    break;
                }
            }
            if (pos != prePos)
            {
                RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
            }
            else return;
        }

        private static void HandleBeaconTeleport(Player player, bool syncData = false)
		{
            Mod mod = ModLoader.GetMod("AlchemistNPCRebornAgain");
			Vector2 prePos = player.position;
			Vector2 pos = prePos;
			for (int x = 0; x < Main.tile.Width; ++x)
			{
				for (int y = 0; y < Main.tile.Height; ++y)
				{
					if (Main.tile[x, y] == null) continue;
					if (Main.tile[x, y].TileType != mod.Find<ModTile>("Beacon").Type) continue;
					pos = new Vector2((x-1) * 16, (y-2) * 16);
					break;
				}
			}
			if (pos != prePos)
			{
				RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
			}
			else return;
		}

        private static void HandleOceanTeleportLeft(Player player, bool syncData = false)
        {
            Vector2 prePos = player.position;
            Vector2 pos = prePos;
            for (int x = 8400; x > 0; --x)
            {
                for (int y = 0; y < Main.tile.Height; ++y)
                {
                    if (Main.tile[x, y] == null) continue;
                    if (Main.tile[x, y].TileType != 81) continue;
                    pos = new Vector2((x - 1) * 16, (y - 16) * 16);
                    break;
                }
            }
            if (pos != prePos)
            {
                RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
            }
            else return;
        }

        private static void HandleHellTeleport(Player player, bool syncData = false)
        {
            Vector2 prePos = player.position;
            Vector2 pos = prePos;
            for (int x = 0; x < Main.tile.Width; ++x)
            {
                for (int y = 0; y < Main.tile.Height; ++y)
                {
                    if (Main.tile[x, y] == null) continue;
                    if (Main.tile[x, y].TileType != 75) continue;
                    pos = new Vector2((x - 3) * 16, (y + 2) * 16);
                    break;
                }
            }
            if (pos != prePos)
            {
                RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
            }
            else return;
        }

        private static void HandleHellTeleportLeft(Player player, bool syncData = false)
        {
            Vector2 prePos = player.position;
            Vector2 pos = prePos;
            for (int x = 8400; x > 0; --x)
            {
                for (int y = 0; y < Main.tile.Height; ++y)
                {
                    if (Main.tile[x, y] == null) continue;
                    if (Main.tile[x, y].TileType != 75) continue;
                    pos = new Vector2((x + 3) * 16, (y + 2) * 16);
                    break;
                }
            }
            if (pos != prePos)
            {
                RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
            }
            else return;
        }

        private static void HandleBeachTeleportRight(Player player, bool syncData = false)
        {
            Vector2 prePos = player.position;
            Vector2 pos = prePos;
            int x = Main.maxTilesX - 32;
            for (int y = 0; y < Main.maxTilesY; y += 16)
            {
                if (Main.tile[x, y] == null) continue;
                if (Main.tile[x, y].LiquidAmount != 255) continue;
                if (Main.tile[x, y].LiquidAmount == 255)
                {
                    do
                    {
                        x -= 16;
                    } while (Main.tile[x, y].LiquidAmount == 255);
                }
                if (Main.tile[x, y] != null && Main.tile[x, y].LiquidAmount == 0 && Main.tile[x, y].HasTile)
                {
                    do
                    {
                        y -= 16;
                    } while (Main.tile[x, y] != null && Main.tile[x, y].LiquidAmount == 0 && Main.tile[x, y].HasTile);
                }
                pos = new Vector2((x) * 16, (y - 2) * 16);
                break;
            }
            if (pos != prePos)
            {
                RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
            }
            else return;
        }

        private static void HandleBeachTeleportLeft(Player player, bool syncData = false)
        {
            Vector2 prePos = player.position;
            Vector2 pos = prePos;
            int x = 16;
            for (int y = 0; y < Main.maxTilesY; y += 16)
            {
                if (Main.tile[x, y] == null) continue;
                if (Main.tile[x, y].LiquidAmount != 255) continue;
                if (Main.tile[x, y].LiquidAmount == 255)
                {
                    do
                    {
                        x += 16;
                    } while (Main.tile[x, y].LiquidAmount == 255);
                }
                if (Main.tile[x, y] != null && Main.tile[x, y].LiquidAmount == 0 && Main.tile[x, y].HasTile)
                {
                    do
                    {
                        y -= 16;
                    } while (Main.tile[x, y] != null && Main.tile[x, y].LiquidAmount == 0 && Main.tile[x, y].HasTile);
                }
                pos = new Vector2((x) * 16, (y - 2) * 16);
                break;
            }
            if (pos != prePos)
            {
                RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
            }
            else return;
        }

        private static void HandleJungleTeleport(Player player, bool syncData = false)
        {
            Vector2 prePos = player.position;
            Vector2 pos = prePos;
            for (int y = Main.maxTilesY; y > Main.worldSurface - 150; --y)
            {
                for (int x = 0; x < Main.maxTilesX; ++x)
                {
                    if (Main.tile[x, y] == null) continue;
                    if (Main.tile[x, y].TileType != 233) continue;
                    pos = new Vector2((x) * 16, (y - 2) * 16);
                    break;
                }
            }
            if (pos != prePos)
            {
                RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
            }
            else return;
        }

        private static void HandleJungleTeleportLeft(Player player, bool syncData = false)
        {
            Vector2 prePos = player.position;
            Vector2 pos = prePos;
            for (int y = Main.maxTilesY; y > 0; --y)
            {
                for (int x = Main.maxTilesX; x > 0; --x)
                {
                    if (Main.tile[x, y] == null) continue;
                    if (Main.tile[x, y].TileType != 384) continue;
                    pos = new Vector2((x) * 16, (y - 2) * 16);
                    break;
                }
            }
            if (pos != prePos)
            {
                RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
            }
            else return;
        }

        private static void HandleTempleTeleport(Player player, bool syncData = false)
        {
            Vector2 prePos = player.position;
            Vector2 pos = prePos;
            for (int x = 0; x < Main.tile.Width; ++x)
            {
                for (int y = 0; y < Main.tile.Height; ++y)
                {
                    if (Main.tile[x, y] == null) continue;
                    if (Main.tile[x, y].TileType != 237) continue;
                    pos = new Vector2((x + 2) * 16, y * 16);
                    break;
                }
            }
            if (pos != prePos)
            {
                RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
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

            //Kill hooks
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
            //Leave dust
            for (int index = 0; index < 70; ++index)
                Main.dust[Dust.NewDust(player.position, player.width, player.height, 15, player.velocity.X * 0.2f, player.velocity.Y * 0.2f, 150, Color.Cyan, 1.2f)].velocity *= 0.5f;
            Main.TeleportEffect(player.getRect(), 1);
            Main.TeleportEffect(player.getRect(), 3);
        }
    }
}
