using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPCRebornAgain.Items.Summoning
{
    public class CaughtUnicorn : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 46;
            Item.height = 42;
            Item.maxStack = 999;
            Item.rare = 10;
            Item.useStyle = 1;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.consumable = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item44;
			Item.makeNPC = (short)NPCID.Unicorn;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 16));
        }
		
		public override void HoldItem(Player player)
		{
		Player.tileRangeX += 600;
        Player.tileRangeY += 600;
		}
		
		public override bool CanUseItem(Player player)
		{
			Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			return (!Collision.SolidCollision(vector2, player.width, player.height));
		}

		public override bool? UseItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer) {

				int type = NPCID.Unicorn;

				if (Main.netMode != NetmodeID.MultiplayerClient) {
					NPC.SpawnOnPlayer(player.whoAmI, type);
				}
			}
			return true;
		}
		
        public override string Texture
		{
			get { return "Terraria/Images/NPC_86"; }
		}
    }
}
