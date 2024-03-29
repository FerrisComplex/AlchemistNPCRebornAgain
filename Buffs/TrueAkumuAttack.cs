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
	public class TrueAkumuAttack : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = false;
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			ModLoader.TryGetMod("CalamityMod", out Mod CalamityMod);
			if (CalamityMod != null)
			{
				if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.AkumuSphere>()] == 0)
				{
					for (int h = 0; h < 1; h++) {
					Vector2 vel = new Vector2(0, -1);
					vel *= 0f;
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.Center.X, player.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.AkumuSphere>(), 1500, 0, player.whoAmI);
					}
				}
			}
			if (CalamityMod == null)
			{
				if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.AkumuSphere>()] == 0)
				{
					for (int h = 0; h < 1; h++) {
					Vector2 vel = new Vector2(0, -1);
					vel *= 0f;
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),player.Center.X, player.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.AkumuSphere>(), 1000, 0, player.whoAmI);
					}
				}
			}
		}
	}
}
