using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace AlchemistNPCRebornAgain.Tiles
{
    public class MateriaTransmutatorMK2 : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 18 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.addTile(Type);
            
            AddMapEntry(new Color(200, 200, 200), this.GetLocalization("MateriaTransmutatorMK2", () => "Materia Transmutator MK2"));
            TileID.Sets.DisableSmartCursor[Type] = true;
            int[] tempTiles = new int[]
            {
                ModContent.TileType<MateriaTransmutator>(),
                TileID.WorkBenches,
                TileID.Anvils,
                TileID.Furnaces,
                TileID.Hellforge,
                TileID.Bookcases,
                TileID.Sinks,
                TileID.Solidifier,
                TileID.Blendomatic,
                TileID.MeatGrinder,
                TileID.Loom,
                TileID.LivingLoom,
                TileID.FleshCloningVat,
                TileID.GlassKiln,
                TileID.BoneWelder,
                TileID.SteampunkBoiler,
                TileID.Bottles,
                TileID.LihzahrdFurnace,
                TileID.ImbuingStation,
                TileID.DyeVat,
                TileID.Kegs,
                TileID.HeavyWorkBench,
                TileID.Tables,
                TileID.Chairs,
                TileID.CookingPots,
                TileID.DemonAltar,
                TileID.Sawmill,
                TileID.CrystalBall,
                TileID.AdamantiteForge,
                TileID.MythrilAnvil,
                TileID.TinkerersWorkbench,
                TileID.Autohammer,
                TileID.IceMachine,
                TileID.SkyMill,
                TileID.HoneyDispenser,
                TileID.AlchemyTable,
                TileID.LunarCraftingStation
            };
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
            if (ModLoader.GetMod("ThoriumMod") != null)
            {
                Array.Resize(ref adjTiles, adjTiles.Length + 3);
                adjTiles[adjTiles.Length - 1] = ModLoader.GetMod("ThoriumMod").TileType("ThoriumAnvil");
                adjTiles[adjTiles.Length - 2] = ModLoader.GetMod("ThoriumMod").TileType("ArcaneArmorFabricator");
                adjTiles[adjTiles.Length - 3] = ModLoader.GetMod("ThoriumMod").TileType("SoulForge");
            }
            if (ModLoader.GetMod("FargowiltasSouls") != null)
            {
                Array.Resize(ref adjTiles, adjTiles.Length + 1);
                adjTiles[adjTiles.Length - 1] = ModLoader.GetMod("FargowiltasSouls").TileType("CrucibleCosmosSheet");
            }
			*/
            if(ModLoader.TryGetMod("CalamityMod", out Mod Calamity) && Calamity.TryFind<ModTile>("DraedonsForge", out ModTile currTile)) {
                Array.Resize(ref tempTiles, tempTiles.Length + 1);
                tempTiles[tempTiles.Length - 1] = currTile.Type;
            }
            AdjTiles = tempTiles;
            DustType = 111;
            AnimationFrameHeight = 74;
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

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frame = Main.tileFrame[TileID.FireflyinaBottle];
            frameCounter = Main.tileFrameCounter[TileID.FireflyinaBottle];
        }

        public override void KillMultiTile(int i, int j, int TileFrameX, int TileFrameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Placeable.MateriaTransmutatorMK2>());
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            Player player = Main.player[Main.myPlayer];
            player.alchemyTable = true;
        }
    }
}
