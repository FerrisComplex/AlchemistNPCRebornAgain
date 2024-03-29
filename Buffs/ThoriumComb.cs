using System.Linq;
using System;
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
	public class ThoriumComb : ModBuff
	{
		public override bool IsLoadingEnabled(Mod mod)
		{
			ModLoader.TryGetMod("ThoriumMod", out Mod Thorium);
			return Thorium != null;
		}
		
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
        
		private static readonly List<ModBuff> BuffTypes = new List<ModBuff>(); // these will not change once generated/found so we can just cache like this
		private static bool _setup = false;
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (!_setup)
			{
				_setup = true;
				var ml = ModLoader.GetMod("ThoriumMod");
				if (ml != null)
				{
					if (ml.TryFind<ModBuff>("AssassinBuff", out var buff1)) BuffTypes.Add(buff1);
					if (ml.TryFind<ModBuff>("BloodRush", out var buff2)) BuffTypes.Add(buff2);
					if (ml.TryFind<ModBuff>("Frenzy", out var buff3)) BuffTypes.Add(buff3);
					if (ml.TryFind<ModBuff>("RadiantBoost", out var buff4)) BuffTypes.Add(buff4);
					if (ml.TryFind<ModBuff>("HolyBonus", out var buff5)) BuffTypes.Add(buff5);
					if (ml.TryFind<ModBuff>("CreativityDrop", out var buff6)) BuffTypes.Add(buff6);
					if (ml.TryFind<ModBuff>("EarwormBuff", out var buff7)) BuffTypes.Add(buff7);
					if (ml.TryFind<ModBuff>("InspirationReach", out var buff8)) BuffTypes.Add(buff8);
					if (ml.TryFind<ModBuff>("HydrationBuff", out var buff9)) BuffTypes.Add(buff9);
				}
			}

			foreach (var v in BuffTypes)
				if (v != null)
				{
					player.buffImmune[v.Type] = true;
					v.Update(player, ref buffIndex);
				}

		}
	}
}
