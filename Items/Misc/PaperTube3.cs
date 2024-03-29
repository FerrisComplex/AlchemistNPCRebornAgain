using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCRebornAgain;

namespace AlchemistNPCRebornAgain.Items.Misc
{
	public class PaperTube3 : ModItem
	{
		public override void SetStaticDefaults()
		{
			Language.GetOrRegister(Mod.GetLocalizationKey("PaperTubeT3Info1"), () => "You need to defeat Golem to unlock leftover post Plantera accessory.");
			Language.GetOrRegister(Mod.GetLocalizationKey("PaperTubeT3Info2"), () => "There was nothing interesting in those blueprints.");
			Language.GetOrRegister(Mod.GetLocalizationKey("PaperTubeT3Info3"), () => "You have found a new accessory blueprint. You can ask Tinkerer about making it now.");
			Language.GetOrRegister(Mod.GetLocalizationKey("PaperTubeT3Info4"), () => "You have found all post Plantera blueprints. Congratulations! Now you may sell all leftover Paper Tubes to Tinkerer.");
			Language.GetOrRegister(Mod.GetLocalizationKey("PaperTubeT3Info5"), () => "Talk to Tinkerer when you will defeat Moon Lord and unlock all accessories.");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 200000;
			Item.rare = 8;
			Item.maxStack = 99;
			Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 4;
			Item.UseSound = SoundID.Item37;
			Item.consumable = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (AlchemistNPCRebornWorld.foundT3)
			{
				return false;
			}
			return true;
		}
		
		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
			var randomAcc = new List<string>();
								
			if (!AlchemistNPCRebornWorld.foundTabi) {
			randomAcc.Add("foundTabi");}
			if (!AlchemistNPCRebornWorld.foundBlackBelt) {
			randomAcc.Add("foundBlackBelt");}
			if (!AlchemistNPCRebornWorld.foundRifleScope) {
			randomAcc.Add("foundRifleScope");}
			if (!AlchemistNPCRebornWorld.foundPaladinShield) {
			randomAcc.Add("foundPaladinShield");}
			if (!AlchemistNPCRebornWorld.foundNecromanticScroll) {
			randomAcc.Add("foundNecromanticScroll");}
			if (NPC.downedGolemBoss)
			{
				if (!AlchemistNPCRebornWorld.foundSunStone) {
				randomAcc.Add("foundSunStone");}
			}
			if (!AlchemistNPCRebornWorld.foundHerculesBeetle) {
			randomAcc.Add("foundHerculesBeetle");}
			if (!AlchemistNPCRebornWorld.foundPygmyNecklace) {
			randomAcc.Add("foundPygmyNecklace");}
			if (randomAcc.Count == 0 && !NPC.downedGolemBoss)
			{
				Main.NewText(Language.GetTextValue(Mod.GetLocalizationKey("PaperTubeT3Info1")), 100,149,237);
				return true;
			}
			if (Main.rand.NextBool(5))
			{
				Main.NewText(Language.GetTextValue(Mod.GetLocalizationKey("PaperTubeT3Info2")), 100,149,237);
				return true;
			}
		
			int acc = Main.rand.Next(randomAcc.Count);
			
			Main.NewText(Language.GetTextValue(Mod.GetLocalizationKey("PaperTubeT3Info3")), 255, 255, 255);
			
			if (randomAcc[acc] == "foundTabi") {
			AlchemistNPCRebornWorld.foundTabi = true;}
			if (randomAcc[acc] == "foundBlackBelt") {
			AlchemistNPCRebornWorld.foundBlackBelt = true;}
			if (randomAcc[acc] == "foundRifleScope") {
			AlchemistNPCRebornWorld.foundRifleScope = true;}
			if (randomAcc[acc] == "foundPaladinShield") {
			AlchemistNPCRebornWorld.foundPaladinShield = true;}
			if (randomAcc[acc] == "foundNecromanticScroll") {
			AlchemistNPCRebornWorld.foundNecromanticScroll = true;}
			if (randomAcc[acc] == "foundSunStone") {
			AlchemistNPCRebornWorld.foundSunStone = true;}
			if (randomAcc[acc] == "foundHerculesBeetle") {
			AlchemistNPCRebornWorld.foundHerculesBeetle = true;}
			if (randomAcc[acc] == "foundPygmyNecklace") {
			AlchemistNPCRebornWorld.foundPygmyNecklace = true;}
			if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.WorldData);
			
			if (randomAcc.Count == 1 && NPC.downedGolemBoss)
			{
				Main.NewText(Language.GetTextValue(Mod.GetLocalizationKey("PaperTubeT3Info4")), 0, 255, 0);
				Main.NewText(Language.GetTextValue(Mod.GetLocalizationKey("PaperTubeT3Info5")), 0, 255, 0);
				AlchemistNPCRebornWorld.foundT3 = true;
				if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.WorldData);
			}
			return true;
		}
	}
}
