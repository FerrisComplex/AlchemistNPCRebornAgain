using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.NPCs
{
    [AutoloadHead]
    public class OtherworldlyPortal : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 7;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.BoundMechanic);
            NPC.townNPC = true;
            NPC.width = 50;
            NPC.height = 114;
            NPC.damage = 1;
            NPC.defense = 500;
            NPC.lifeMax = 500;
            NPC.knockBackResist = 0.1f;
            NPC.noGravity = true;
            NPC.rarity = 5;
        }

        public override string GetChat()
        {
            string barrierStabilized = Language.GetTextValue(Mod.GetLocalizationKey("NPCS.OtherworldlyPotal.barrierStabilized"));
            Main.NewText(barrierStabilized, 55, 55, 255);
            NPC.Transform(ModContent.NPCType<NPCs.Explorer>());
            return Language.GetTextValue(Mod.GetLocalizationKey("NPCS.OtherworldlyPotal.open"));
        }

        public override List<string> SetNPCNameList() => new List<string>()
        {
            Language.GetTextValue(Mod.GetLocalizationKey("NPCS.OtherworldlyPotal.name"))
        };


        const int Frame_P11 = 0;
        const int Frame_P12 = 1;
        const int Frame_P13 = 2;
        const int Frame_P14 = 3;
        const int Frame_P15 = 4;
        const int Frame_P16 = 5;
        const int Frame_P17 = 6;

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter < 12)
            {
                NPC.frame.Y = Frame_P11 * frameHeight;
            }
            else if (NPC.frameCounter < 24)
            {
                NPC.frame.Y = Frame_P12 * frameHeight;
            }
            else if (NPC.frameCounter < 36)
            {
                NPC.frame.Y = Frame_P13 * frameHeight;
            }
            else if (NPC.frameCounter < 48)
            {
                NPC.frame.Y = Frame_P14 * frameHeight;
            }
            else if (NPC.frameCounter < 60)
            {
                NPC.frame.Y = Frame_P15 * frameHeight;
            }
            else if (NPC.frameCounter < 72)
            {
                NPC.frame.Y = Frame_P16 * frameHeight;
            }
            else if (NPC.frameCounter < 84)
            {
                NPC.frame.Y = Frame_P17 * frameHeight;
            }
            else
            {
                NPC.frameCounter = 0;
            }
        }

        public override void AI()
        {
            Lighting.AddLight(NPC.position, 0.1f, 0.2f, 0.7f);

            if (Main.rand.Next(2) == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    int dustType = Main.rand.Next(51, 54);
                    int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
                    Dust dust = Main.dust[dustIndex];
                    dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                    dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                    dust.scale *= 0.95f;
                    dust.noGravity = true;
                }
            }

            if (NPC.aiStyle == 0)
            {
                for (int index = 0; index < (int)byte.MaxValue; ++index)
                {
                    if (Main.player[index].active && Main.player[index].talkNPC == NPC.whoAmI)
                    {
                        NPC.Transform(ModContent.NPCType<NPCs.Explorer>());
                        return;
                    }
                }
            }
        }
    }
}
