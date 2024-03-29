using System;
using System.Linq;
using Microsoft.Xna.Framework;
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
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Buffs
{
    public class Hate : ModBuff
    {
        public static int count = 0;
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.statLife < player.statLifeMax2)
            {
                if (count >= 12)
                {
                    count = 0;
                    player.statLife += 5;
                    player.HealEffect(5, true);
                }
                count++;
            }
            player.GetDamage(DamageClass.Generic) += 0.15f;
            player.GetCritChance(DamageClass.Melee) += 15;
            player.GetCritChance(DamageClass.Ranged) += 15;
            player.GetCritChance(DamageClass.Magic) += 15;
            player.GetCritChance(DamageClass.Summon) += 15;
            player.lifeRegen += 20;
            player.endurance -= 0.15f;
            player.statDefense -= 30;
            //ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod);
            //if (ThoriumMod != null)
            //{
            //    ThoriumBoosts(player);
            //}
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            if (Calamity != null)
            {
                Calamity.Call("AddRogueCrit", player, 15);
            }
        }

        //private void ThoriumBoosts(Player player)
        //{
        //    ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
        //    ThoriumPlayer.symphonicCrit += 15;
        //    ThoriumPlayer.radiantCrit += 15;
        //}
    }
}
