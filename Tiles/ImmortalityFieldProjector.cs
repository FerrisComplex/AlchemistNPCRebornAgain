using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.ObjectData;

namespace AlchemistNPCRebornAgain.Tiles
{
	public class ImmortalityFieldProjector : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(1, 2);
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 16, 18 };
			TileObjectData.addTile(Type);
			AddMapEntry(new Color(190, 230, 190), this.GetLocalization("ImmortalityFieldProjector", () => "Immortality Field Projector"));
			DustType = 11;
			TileID.Sets.DisableSmartCursor[Type] = true;
			AnimationFrameHeight = 56;
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
		
		public override void RandomUpdate(int i, int j)
		{
			for (int k = 0; k < 200; k++)
			{
				NPC npc = Main.npc[k];
				{
					if (npc.active && npc.townNPC)
					{
						npc.buffImmune[Mod.Find<ModBuff>("IField").Type] = false;
						npc.AddBuff(Mod.Find<ModBuff>("IField").Type, 3600);
					}
				}
			}
		}
		
		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frame = Main.tileFrame[TileID.FireflyinaBottle];
			frameCounter = Main.tileFrameCounter[TileID.FireflyinaBottle];
		}
		
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ItemType<Items.Placeable.ImmortalityFieldProjector>());
		}
	}
}
