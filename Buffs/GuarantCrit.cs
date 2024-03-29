using System;
using System.Linq;
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
using AlchemistNPCRebornAgain.NPCs;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Buffs
{
    public class GuarantCrit : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.persistentBuff[Type] = true;

        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetCritChance(DamageClass.Melee) += 100;
            player.GetCritChance(DamageClass.Ranged) += 100;
            player.GetCritChance(DamageClass.Magic) += 100;
            player.GetCritChance(DamageClass.Summon) += 100;
            player.AddBuff(ModContent.BuffType<GuarantCrit>(), 2);
            if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).GC == false)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            if (Calamity != null)
            {
                Calamity.Call("AddRogueCrit", player, 100);
            }
        }
    }
}
