using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace AlchemistNPCRebornAgain.Tiles
{
	public class Wellcheers : ModTile
	{
		public static int counter = 0;
		public override void SetStaticDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
			TileObjectData.newTile.CoordinateHeights = new[]{16, 16, 16, 18};
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile(Type);
            AddMapEntry(new Color(200, 200, 200), this.GetLocalization("Wellcheers", () => "Wellcheers"));
			TileID.Sets.DisableSmartCursor[Type] = true;
			AdjTiles = new int[]{ TileID.Books };
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			Tile tile = Main.tile[i, j];
			if (tile.TileFrameX < 66)
			{
				r = 0.9f;
				g = 0.9f;
				b = 0.9f;
			}
		}
		
		public override bool RightClick(int i, int j)
		{
			for (int k = 0; k < 255; k++)
			{
			Player player = Main.player[k];
			if (player.active)
				{
				if (counter != 10 && !Main.dayTime && !NPC.AnyNPCs(125) && !NPC.AnyNPCs(126) && !NPC.AnyNPCs(127) && !NPC.AnyNPCs(134))
					{
					switch (Main.rand.Next(4))
						{
							case 0:						
							player.QuickSpawnItem(((Entity) player).GetSource_FromThis((string) null), Mod.Find<ModItem>("CrimsonCherrySoda").Type);
							counter++;
							break;
							case 1:
							player.QuickSpawnItem(((Entity) player).GetSource_FromThis((string) null), Mod.Find<ModItem>("SapphireBlueberrySoda").Type);
							counter++;
							break;
							case 2:
							player.QuickSpawnItem(((Entity) player).GetSource_FromThis((string) null), Mod.Find<ModItem>("PinkGoldStrawberrySoda").Type);
							counter++;
							break;
							case 3:
							player.QuickSpawnItem(((Entity) player).GetSource_FromThis((string) null), Mod.Find<ModItem>("OnyxGrapeSoda").Type);
							counter++;
							break;
						}
					}
					if (counter == 10 && !Main.dayTime)
					{
						if (Main.netMode == 0)
						{
							switch (Main.rand.Next(3))
							{
							case 0:
							NPC.SpawnOnPlayer(player.whoAmI, NPCID.SkeletronPrime);
							counter = 0;
							break;
							case 1:
							NPC.SpawnOnPlayer(player.whoAmI, NPCID.Retinazer);
							NPC.SpawnOnPlayer(player.whoAmI, NPCID.Spazmatism);
							counter = 0;
							break;
							case 2:
							NPC.SpawnOnPlayer(player.whoAmI, NPCID.TheDestroyer);
							counter = 0;
							break;
							}
						}
						if(Main.netMode != 0)
						{
						Main.player[Main.myPlayer].AddBuff(Mod.Find<ModBuff>("EvilPresence").Type, 1);
						counter = 0;
						}
					}
				}
			}
			return true;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, Mod.Find<ModItem>("Wellcheers").Type);
		}
		
		public override void MouseOver(int i, int j)
		{
			int whoAmI = 0;
			Player player = Main.player[whoAmI];
			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
			player.cursorItemIconID = Mod.Find<ModItem>("Wellcheers").Type;
		}
	}
}
