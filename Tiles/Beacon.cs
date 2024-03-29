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
	public class Beacon : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileSolidTop[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 16 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.addTile(Type);
		
            AddMapEntry(new Color(200, 200, 200), this.GetLocalization("Beacon", () => "Beacon"));
			TileID.Sets.DisableSmartCursor[Type] = true;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		
		public override bool CanPlace (int i, int j)
		{
			Mod mod = ModLoader.GetMod("AlchemistNPCRebornAgain");
			for (int x = 0; x < Main.tile.Width; ++x)
			{
				for (int y = 0; y < Main.tile.Height; ++y)
				{
					if (Main.tile[x, y] == null) continue;
					if ( Main.tile[x, y].TileType != mod.Find<ModTile>("Beacon").Type) continue;
					return false;
						
				}
			}
			return true;
			
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

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, Mod.Find<ModItem>("Beacon").Type);
		}
	}
}
