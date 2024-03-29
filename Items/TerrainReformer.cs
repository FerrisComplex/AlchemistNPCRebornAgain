using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
//using Terraria.World.Generation;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items
{
	public class TerrainReformer : ModItem
	{

		public override void SetDefaults() {
			Item.damage = 100;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 5;
			Item.useAnimation = 10;
			Item.pick = 225;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 100000;
			Item.rare = 10;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.tileBoost += 5;
			Item.useTurn = true;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool? UseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				Item.pick = 225;
				return true;
			}
			if (player.altFunctionUse == 2)
			{
				Item.pick = 0;
				return true;
			}
			return base.UseItem(player);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(10)) {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Electric);
			}
			if (player.altFunctionUse == 2 || (player.altFunctionUse != 2 && Main.mouseRight))
			{
				int range = 32;
				int minTileX = (int)(player.position.X / 16f - (float)range);
				int maxTileX = (int)(player.position.X / 16f + (float)range);
				int minTileY = (int)(player.position.Y / 16f - (float)range);
				int maxTileY = (int)(player.position.Y / 16f + (float)range);
				if (minTileX < 0) {
					minTileX = 0;
				}
				if (maxTileX > Main.maxTilesX) {
					maxTileX = Main.maxTilesX;
				}
				if (minTileY < 0) {
					minTileY = 0;
				}
				if (maxTileY > Main.maxTilesY) {
					maxTileY = Main.maxTilesY;
				}
				for (int i = minTileX; i < maxTileX; ++i)
				{
					for (int j = minTileY; j < maxTileY; ++j)
					{
						if (Main.tile[i, j].TileType == 88 || Main.tile[i, j].TileType == 21 || Main.tile[i, j].TileType == 26 || Main.tile[i, j].TileType == 237 ) continue;
						if (Main.tile[i, j].TileType == null) continue;
						if (!Main.tile[i, j].HasTile) continue;
						if (hitbox.Intersects(new Rectangle(i * 16, j * 16, 16, 16)))
						{
							WorldGen.KillTile(i, j, false, false, false);
						}
					}
				}
			}
		}
	}
}
