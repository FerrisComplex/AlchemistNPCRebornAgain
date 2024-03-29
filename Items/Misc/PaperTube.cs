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
    public class PaperTube : ModItem
    {
        public override void SetStaticDefaults()
        {
            Language.GetOrRegister(Mod.GetLocalizationKey("PaperTubeInfo1"), () => "There was nothing interesting in those blueprints.");
            Language.GetOrRegister(Mod.GetLocalizationKey("PaperTubeInfo2"), () => "You have found a new accessory blueprint. You can ask Tinkerer about making it now.");
            Language.GetOrRegister(Mod.GetLocalizationKey("PaperTubeInfo3"), () => "You have found all prehardmode blueprints. Congratulations! Now you may sell all leftover Paper Tubes to Tinkerer.");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 50000;
            Item.rare = 4;
            Item.maxStack = 99;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 4;
            Item.UseSound = SoundID.Item37;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            if (AlchemistNPCRebornWorld.foundT1)
            {
                return false;
            }

            return true;
        }

        public override bool? UseItem(Player player) /* tModPorter Suggestion: Return null instead of false */
        {
            var randomAcc = new List<string>();

            if (!AlchemistNPCRebornWorld.foundAglet)
                randomAcc.Add("foundAglet");


            if (!AlchemistNPCRebornWorld.foundClimbingClaws)
                randomAcc.Add("foundClimbingClaws");


            if (!AlchemistNPCRebornWorld.foundShoeSpikes)
                randomAcc.Add("foundShoeSpikes");


            if (!AlchemistNPCRebornWorld.foundAnklet)
                randomAcc.Add("foundAnklet");


            if (!AlchemistNPCRebornWorld.foundBalloon)
                randomAcc.Add("foundBalloon");


            if (!AlchemistNPCRebornWorld.foundHermesBoots)
                randomAcc.Add("foundHermesBoots");


            if (!AlchemistNPCRebornWorld.foundFlippers)
                randomAcc.Add("foundFlippers");


            if (!AlchemistNPCRebornWorld.foundFrogLeg)
                randomAcc.Add("foundFrogLeg");


            if (!AlchemistNPCRebornWorld.foundCloud)
                randomAcc.Add("foundCloud");


            if (!AlchemistNPCRebornWorld.foundBlizzard)
                randomAcc.Add("foundBlizzard");


            if (!AlchemistNPCRebornWorld.foundSandstorm)
                randomAcc.Add("foundSandstorm");


            if (!AlchemistNPCRebornWorld.foundPuffer)
                randomAcc.Add("foundPuffer");


            if (!AlchemistNPCRebornWorld.foundTsunami)
                randomAcc.Add("foundTsunami");


            if (!AlchemistNPCRebornWorld.foundWWB)
                randomAcc.Add("foundWWB");


            if (!AlchemistNPCRebornWorld.foundIceSkates)
                randomAcc.Add("foundIceSkates");


            if (!AlchemistNPCRebornWorld.foundFlyingCarpet)
                randomAcc.Add("foundFlyingCarpet");


            if (!AlchemistNPCRebornWorld.foundDivingHelmet)
                randomAcc.Add("foundDivingHelmet");


            if (!AlchemistNPCRebornWorld.foundLavaCharm)
                randomAcc.Add("foundLavaCharm");


            if (!AlchemistNPCRebornWorld.foundHorseshoe)
                randomAcc.Add("foundHorseshoe");


            if (!AlchemistNPCRebornWorld.foundCMagnet)
                randomAcc.Add("foundCMagnet");


            if (!AlchemistNPCRebornWorld.foundHTFL)
                randomAcc.Add("foundHTFL");


            if (!AlchemistNPCRebornWorld.foundAnglerEarring)
                randomAcc.Add("foundAnglerEarring");


            if (!AlchemistNPCRebornWorld.foundTackleBox)
                randomAcc.Add("foundTackleBox");


            if (!AlchemistNPCRebornWorld.foundJFNeck)
                randomAcc.Add("foundJFNeck");


            if (!AlchemistNPCRebornWorld.foundFlowerBoots)
                randomAcc.Add("foundFlowerBoots");


            if (!AlchemistNPCRebornWorld.foundString)
                randomAcc.Add("foundString");


            if (!AlchemistNPCRebornWorld.foundGreenCW)
                randomAcc.Add("foundGreenCW");


            if (!AlchemistNPCRebornWorld.foundFeralClaw)
                randomAcc.Add("foundFeralClaw");


            if (!AlchemistNPCRebornWorld.foundMagmaStone)
                randomAcc.Add("foundMagmaStone");


            if (!AlchemistNPCRebornWorld.foundSharkTooth)
                randomAcc.Add("foundSharkTooth");


            if (!AlchemistNPCRebornWorld.foundPanicNecklace)
                randomAcc.Add("foundPanicNecklace");


            if (!AlchemistNPCRebornWorld.foundObsidianRose)
                randomAcc.Add("foundObsidianRose");


            if (!AlchemistNPCRebornWorld.foundShackle)
                randomAcc.Add("foundShackle");


            if (Main.rand.NextBool(5))
            {
                Main.NewText(Language.GetTextValue(Mod.GetLocalizationKey("PaperTubeInfo1")), 100, 149, 237);
                return true;
            }

            var acc = Main.rand.Next(randomAcc.Count);
            Main.NewText(Language.GetTextValue(Mod.GetLocalizationKey("PaperTubeInfo2")), 255, 255, 255);

            if (randomAcc[acc] == "foundAglet")
                AlchemistNPCRebornWorld.foundAglet = true;


            if (randomAcc[acc] == "foundClimbingClaws")
                AlchemistNPCRebornWorld.foundClimbingClaws = true;


            if (randomAcc[acc] == "foundShoeSpikes")
                AlchemistNPCRebornWorld.foundShoeSpikes = true;


            if (randomAcc[acc] == "foundAnklet")
                AlchemistNPCRebornWorld.foundAnklet = true;


            if (randomAcc[acc] == "foundBalloon")
                AlchemistNPCRebornWorld.foundBalloon = true;


            if (randomAcc[acc] == "foundHermesBoots")
                AlchemistNPCRebornWorld.foundHermesBoots = true;


            if (randomAcc[acc] == "foundFlippers")
                AlchemistNPCRebornWorld.foundFlippers = true;


            if (randomAcc[acc] == "foundFrogLeg")
                AlchemistNPCRebornWorld.foundFrogLeg = true;


            if (randomAcc[acc] == "foundCloud")
                AlchemistNPCRebornWorld.foundCloud = true;


            if (randomAcc[acc] == "foundBlizzard")
                AlchemistNPCRebornWorld.foundBlizzard = true;


            if (randomAcc[acc] == "foundSandstorm")
                AlchemistNPCRebornWorld.foundSandstorm = true;


            if (randomAcc[acc] == "foundPuffer")
                AlchemistNPCRebornWorld.foundPuffer = true;


            if (randomAcc[acc] == "foundTsunami")
                AlchemistNPCRebornWorld.foundTsunami = true;


            if (randomAcc[acc] == "foundWWB")
                AlchemistNPCRebornWorld.foundWWB = true;


            if (randomAcc[acc] == "foundIceSkates")
                AlchemistNPCRebornWorld.foundIceSkates = true;


            if (randomAcc[acc] == "foundFlyingCarpet")
                AlchemistNPCRebornWorld.foundFlyingCarpet = true;


            if (randomAcc[acc] == "foundDivingHelmet")
                AlchemistNPCRebornWorld.foundDivingHelmet = true;


            if (randomAcc[acc] == "foundLavaCharm")
                AlchemistNPCRebornWorld.foundLavaCharm = true;


            if (randomAcc[acc] == "foundHorseshoe")
                AlchemistNPCRebornWorld.foundHorseshoe = true;


            if (randomAcc[acc] == "foundCMagnet")
                AlchemistNPCRebornWorld.foundCMagnet = true;


            if (randomAcc[acc] == "foundHTFL")
                AlchemistNPCRebornWorld.foundHTFL = true;


            if (randomAcc[acc] == "foundAnglerEarring")
                AlchemistNPCRebornWorld.foundAnglerEarring = true;


            if (randomAcc[acc] == "foundTackleBox")
                AlchemistNPCRebornWorld.foundTackleBox = true;


            if (randomAcc[acc] == "foundJFNeck")
                AlchemistNPCRebornWorld.foundJFNeck = true;


            if (randomAcc[acc] == "foundFlowerBoots")
                AlchemistNPCRebornWorld.foundFlowerBoots = true;


            if (randomAcc[acc] == "foundString")
                AlchemistNPCRebornWorld.foundString = true;


            if (randomAcc[acc] == "foundGreenCW")
                AlchemistNPCRebornWorld.foundGreenCW = true;


            if (randomAcc[acc] == "foundFeralClaw")
                AlchemistNPCRebornWorld.foundFeralClaw = true;


            if (randomAcc[acc] == "foundMagmaStone")
                AlchemistNPCRebornWorld.foundMagmaStone = true;


            if (randomAcc[acc] == "foundSharkTooth")
                AlchemistNPCRebornWorld.foundSharkTooth = true;


            if (randomAcc[acc] == "foundPanicNecklace")
                AlchemistNPCRebornWorld.foundPanicNecklace = true;


            if (randomAcc[acc] == "foundObsidianRose")
                AlchemistNPCRebornWorld.foundObsidianRose = true;


            if (randomAcc[acc] == "foundShackle")
                AlchemistNPCRebornWorld.foundShackle = true;


            if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.WorldData);
            if (randomAcc.Count == 1)
            {
                Main.NewText(Language.GetTextValue(Mod.GetLocalizationKey("PaperTubeInfo3")), 0, 255, 0);
                AlchemistNPCRebornWorld.foundT1 = true;
                if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.WorldData);
            }

            return true;
        }
    }
}
