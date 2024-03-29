using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using AlchemistNPCRebornAgain;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.DataStructures;

namespace AlchemistNPCRebornAgain.Buffs
{
    public class CalamityComb : ModBuff
    {
        private string[] BuffList = {
                "CadancesGrace",
                "YharimPower",
                "TitanScale",
                "FabsolVodkaBuff",
                "Soaring",
                "BoundingBuff"
        };

        public override bool IsLoadingEnabled(Mod mod)
        {
			ModLoader.TryGetMod("CalamityMod", out Calamity);
			return Calamity != null;
        }

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
         
        }

        public override void Update(Player player, ref int buffIndex)
        {

            foreach (string BuffString in BuffList)
            {
                if (Calamity.TryFind<ModBuff>(BuffString, out ModBuff buff))
                    player.buffImmune[buff.Type] = true;
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				ThoriumBoosts(player);
			}
			if (ModLoader.GetMod("Redemption") != null)
			{
				RedemptionBoost(player);
			}
			*/
            if (ModLoader.GetMod("CalamityMod") != null)
            {
                CalamityBoost(player, ref buffIndex);
            }
        }


        private void CalamityBoost(Player player, ref int buffIndex)
        {
            foreach (string BuffString in BuffList)
            {
                if (Calamity.TryFind<ModBuff>(BuffString, out ModBuff buff))
                    buff.Update(player, ref buffIndex);
            }
        }
        private Mod Calamity;

        // IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            Redemptionplayer.GetDamage(DamageClass.druid) += 2;
        }
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            Thoriumplayer.GetDamage(DamageClass.symphonic) += 2;
            Thoriumplayer.GetDamage(DamageClass.radiant) += 2;
        }
		*/
    }
}
