using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPCRebornAgain.Items.Summoning
{
	public class NotesBook : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 30;
			Item.value = 5000000;
			Item.rare = 11;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = 4;
            Item.consumable = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.makeNPC = (short)ModContent.NPCType<NPCs.OtherworldlyPortal>();
		}

		public override void HoldItem(Player player)
		{
			Player.tileRangeX += 600;
			Player.tileRangeY += 600;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (Main.myPlayer == player.whoAmI)
			{
				Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
				if (!NPC.AnyNPCs(ModContent.NPCType<NPCs.Explorer>()) && !NPC.AnyNPCs(ModContent.NPCType<NPCs.OtherworldlyPortal>()) && Main.eclipse && !Collision.SolidCollision(vector2, player.width, player.height))
				{
					return true;
				}
			}
			return false;
		}

		public override bool? UseItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer) {

				int type = ModContent.NPCType<NPCs.OtherworldlyPortal>();

				if (Main.netMode != NetmodeID.MultiplayerClient) {
					NPC.SpawnOnPlayer(player.whoAmI, type);
				}
			}
			return true;
		}

		public override void OnConsumeItem(Player player)
		{
            Main.NewText(Language.GetTextValue(Mod.GetLocalizationKey("NPCS.OtherworldlyPotal.portal")), 255, 255, 255);
		}
	}
}
