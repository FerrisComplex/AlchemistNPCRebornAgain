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
	public class PaperTube2 : ModItem
	{
		public override void SetStaticDefaults()
		{

			Language.GetOrRegister(Mod.GetLocalizationKey("PaperTubeT2Info1"), () => "You need to defeat any mechanical boss to unlock 2 leftover early hardmode accessories.");
			Language.GetOrRegister(Mod.GetLocalizationKey("PaperTubeT2Info2"), () => "There was nothing interesting in those blueprints.");
			Language.GetOrRegister(Mod.GetLocalizationKey("PaperTubeT2Info3"), () => "You have found a new accessory blueprint. You can ask Tinkerer about making it now.");
			Language.GetOrRegister(Mod.GetLocalizationKey("PaperTubeT2Info4"), () => "You have found all early hardmode blueprints. Congratulations! Now you may sell all leftover Paper Tubes to Tinkerer.");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 100000;
			Item.rare = 6;
			Item.maxStack = 99;
			Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 4;
			Item.UseSound = SoundID.Item37;
			Item.consumable = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (AlchemistNPCRebornWorld.foundT2)
			{
				return false;
			}
			return true;
		}
		
		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
			var randomAcc = new List<string>();

			if (!AlchemistNPCRebornWorld.foundPMirror) {
			randomAcc.Add("foundPMirror");}	
			if (!AlchemistNPCRebornWorld.foundPStone) {
			randomAcc.Add("foundPStone");}
			if (!AlchemistNPCRebornWorld.foundGoldRing) {
			randomAcc.Add("foundGoldRing");}
			if (!AlchemistNPCRebornWorld.foundLuckyCoin) {
			randomAcc.Add("foundLuckyCoin");}
			if (!AlchemistNPCRebornWorld.foundDiscountCard) {
			randomAcc.Add("foundDiscountCard");}
			if (NPC.downedMechBossAny)
			{
				if (!AlchemistNPCRebornWorld.foundNeptuneShell) {
				randomAcc.Add("foundNeptuneShell");}
			}
			if (!AlchemistNPCRebornWorld.foundYoyoGlove) {
			randomAcc.Add("foundYoyoGlove");}
			if (!AlchemistNPCRebornWorld.foundBlindfold) {
			randomAcc.Add("foundBlindfold");}
			if (!AlchemistNPCRebornWorld.foundArmorPolish) {
			randomAcc.Add("foundArmorPolish");}
			if (!AlchemistNPCRebornWorld.foundVitamins) {
			randomAcc.Add("foundVitamins");}
			if (!AlchemistNPCRebornWorld.foundBezoar) {
			randomAcc.Add("foundBezoar");}
			if (!AlchemistNPCRebornWorld.foundAdhesiveBandage) {
			randomAcc.Add("foundAdhesiveBandage");}
			if (!AlchemistNPCRebornWorld.foundFastClock) {
			randomAcc.Add("foundFastClock");}
			if (!AlchemistNPCRebornWorld.foundTrifoldMap) {
			randomAcc.Add("foundTrifoldMap");}
			if (!AlchemistNPCRebornWorld.foundMegaphone) {
			randomAcc.Add("foundMegaphone");}
			if (!AlchemistNPCRebornWorld.foundNazar) {
			randomAcc.Add("foundNazar");}
			if (!AlchemistNPCRebornWorld.foundSorcE) {
			randomAcc.Add("foundSorcE");}
			if (!AlchemistNPCRebornWorld.foundWE) {
			randomAcc.Add("foundWE");}
			if (!AlchemistNPCRebornWorld.foundRE) {
			randomAcc.Add("foundRE");}
			if (!AlchemistNPCRebornWorld.foundSumE) {
			randomAcc.Add("foundSumE");}
			if (!AlchemistNPCRebornWorld.foundTitanGlove) {
			randomAcc.Add("foundTitanGlove");}
			if (!AlchemistNPCRebornWorld.foundMoonCharm) {
			randomAcc.Add("foundMoonCharm");}
			if (!AlchemistNPCRebornWorld.foundFrozenTurtleShell) {
			randomAcc.Add("foundFrozenTurtleShell");}
			if (NPC.downedMechBossAny)
			{
				if (!AlchemistNPCRebornWorld.foundMoonStone) {
				randomAcc.Add("foundMoonStone");}
			}
			if (!AlchemistNPCRebornWorld.foundPutridScent) {
			randomAcc.Add("foundPutridScent");}
			if (!AlchemistNPCRebornWorld.foundFleshKnuckles) {
			randomAcc.Add("foundFleshKnuckles");}
			if (!AlchemistNPCRebornWorld.foundMagicQuiver) {
			randomAcc.Add("foundMagicQuiver");}
			if (!AlchemistNPCRebornWorld.foundCobaltShield) {
			randomAcc.Add("foundCobaltShield");}
			if (!AlchemistNPCRebornWorld.foundCrossNecklace) {
			randomAcc.Add("foundCrossNecklace");}
			if (!AlchemistNPCRebornWorld.foundStarCloak) {
			randomAcc.Add("foundStarCloak");}
			if (randomAcc.Count == 0 && !NPC.downedMechBossAny)
			{
				Main.NewText(Language.GetTextValue(Mod.GetLocalizationKey("PaperTubeT2Info1")), 100,149,237);
				return true;
			}
			if (Main.rand.NextBool(5))
			{
				Main.NewText(Language.GetTextValue(Mod.GetLocalizationKey("PaperTubeT2Info2")), 100,149,237);
				return true;
			}
		
			int acc = Main.rand.Next(randomAcc.Count);
			
			Main.NewText(Language.GetTextValue(Mod.GetLocalizationKey("PaperTubeT2Info3")), 255, 255, 255);
			
			if (randomAcc[acc] == "foundPMirror") {
			AlchemistNPCRebornWorld.foundPMirror = true;}
			if (randomAcc[acc] == "foundPStone") {
			AlchemistNPCRebornWorld.foundPStone = true;}
			if (randomAcc[acc] == "foundGoldRing") {
			AlchemistNPCRebornWorld.foundGoldRing = true;}
			if (randomAcc[acc] == "foundLuckyCoin") {
			AlchemistNPCRebornWorld.foundLuckyCoin = true;}
			if (randomAcc[acc] == "foundDiscountCard") {
			AlchemistNPCRebornWorld.foundDiscountCard = true;}
			if (randomAcc[acc] == "foundNeptuneShell") {
			AlchemistNPCRebornWorld.foundNeptuneShell = true;}
			if (randomAcc[acc] == "foundYoyoGlove") {
			AlchemistNPCRebornWorld.foundYoyoGlove = true;}
			if (randomAcc[acc] == "foundBlindfold") {
			AlchemistNPCRebornWorld.foundBlindfold = true;}
			if (randomAcc[acc] == "foundArmorPolish") {
			AlchemistNPCRebornWorld.foundArmorPolish = true;}
			if (randomAcc[acc] == "foundVitamins") {
			AlchemistNPCRebornWorld.foundVitamins = true;}
			if (randomAcc[acc] == "foundBezoar") {
			AlchemistNPCRebornWorld.foundBezoar = true;}
			if (randomAcc[acc] == "foundAdhesiveBandage") {
			AlchemistNPCRebornWorld.foundAdhesiveBandage = true;}
			if (randomAcc[acc] == "foundFastClock") {
			AlchemistNPCRebornWorld.foundFastClock = true;}
			if (randomAcc[acc] == "foundTrifoldMap") {
			AlchemistNPCRebornWorld.foundTrifoldMap = true;}
			if (randomAcc[acc] == "foundMegaphone") {
			AlchemistNPCRebornWorld.foundMegaphone = true;}
			if (randomAcc[acc] == "foundNazar") {
			AlchemistNPCRebornWorld.foundNazar = true;}
			if (randomAcc[acc] == "foundSorcE") {
			AlchemistNPCRebornWorld.foundSorcE = true;}
			if (randomAcc[acc] == "foundWE") {
			AlchemistNPCRebornWorld.foundWE = true;}
			if (randomAcc[acc] == "foundRE") {
			AlchemistNPCRebornWorld.foundRE = true;}
			if (randomAcc[acc] == "foundSumE") {
			AlchemistNPCRebornWorld.foundSumE = true;}
			if (randomAcc[acc] == "foundTitanGlove") {
			AlchemistNPCRebornWorld.foundTitanGlove = true;}
			if (randomAcc[acc] == "foundMoonCharm") {
			AlchemistNPCRebornWorld.foundMoonCharm = true;}
			if (randomAcc[acc] == "foundMoonStone") {
			AlchemistNPCRebornWorld.foundMoonStone = true;}
			if (randomAcc[acc] == "foundFrozenTurtleShell") {
			AlchemistNPCRebornWorld.foundFrozenTurtleShell = true;}
			if (randomAcc[acc] == "foundPutridScent") {
			AlchemistNPCRebornWorld.foundPutridScent = true;}
			if (randomAcc[acc] == "foundFleshKnuckles") {
			AlchemistNPCRebornWorld.foundFleshKnuckles = true;}
			if (randomAcc[acc] == "foundMagicQuiver") {
			AlchemistNPCRebornWorld.foundMagicQuiver = true;}
			if (randomAcc[acc] == "foundCobaltShield") {
			AlchemistNPCRebornWorld.foundCobaltShield = true;}
			if (randomAcc[acc] == "foundCrossNecklace") {
			AlchemistNPCRebornWorld.foundCrossNecklace = true;}
			if (randomAcc[acc] == "foundStarCloak") {
			AlchemistNPCRebornWorld.foundStarCloak = true;}
			if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.WorldData);
			
			if (randomAcc.Count == 1 && NPC.downedMechBossAny)
			{
				Main.NewText(Language.GetTextValue(Mod.GetLocalizationKey("PaperTubeT2Info4")), 0, 255, 0);
				AlchemistNPCRebornWorld.foundT2 = true;
				if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.WorldData);
			}
			return true;
		}
	}
}
