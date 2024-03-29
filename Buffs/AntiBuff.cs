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
    public class AntiBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void ModifyBuffText(ref string buffName, ref string tipLine, ref int rare)
        {
            string tip;
            string tipru;
            string tipch;

            Player player = Main.player[Main.myPlayer];
            AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
            tip = "Active boosts:";
            tipru = "Активные усиления:";
            tipch = "生效增益:";

            if (modPlayer.KingSlimeBooster == 1)
            {
                tip += "\nIncreases jump height and safe fall distance greatly";
                tipru += "\nЗначительно увеличена высота прыжка и безопасное расстояние падения";
                tipch += "\n极大提升跳跃高度和安全坠落距离";
            }
            if (modPlayer.EyeOfCthulhuBooster == 1)
            {
                tip += "\nProvides creatures, treasures and traps detection";
                tipru += "\nОбеспечено обнаружение существ, сокровищ и ловушек";
                tipch += "\n提供生物，宝藏和陷阱的探测能力";

            }
            if (modPlayer.CustomBooster1 == 1)
            {
                tip += "\nGives Shine and Nightvision effects";
                tipru += "\nЭффекты свечения и ночного видения";
                tipch += "\n给予发光和夜视效果";
            }
            if (modPlayer.EaterOfWorldsBooster == 1)
            {
                tip += "\nIncreases melee speed by 5%, movement and mining speed by 25%";
                tipru += "\nУвеличена скорость ближнего боя на 5%, скорость передвижения и добычи на 25%";
                tipch += "\n增加5%近战速度，增加25%移动和挖掘速度";
            }
            if (modPlayer.BrainOfCthulhuBooster == 1)
            {
                tip += "\nIncreases max amount of minions by 1, Heartreach effect";
                tipru += "\nУвеличено максимальное количество миньонов на 1, эффект сердечного магнита";
                tipch += "\n增加1召唤物上限，获得心之彼端效果";
            }
            if (modPlayer.QueenBeeBooster == 1)
            {
                tip += "\nHostile bees do less damage and your regeneration is increased by 6, immunity to poisons";
                tipru += "\nВраждебные пчелы наносят меньше урона, а ваша регенерация увеличивается на 6, иммунитет к яду";
                tipch += "\n敌方蜜蜂的伤害降低并且你的生命再生速度增加6，免疫中毒";
            }
            if (modPlayer.SkeletronBooster == 1)
            {
                tip += "\nSkeletons contact damage is reduced, all damages/critical strike chances are increased by 10%";
                tipru += "\nУрон от контакта со скелетами уменьшен, все повреждения и вероятность критического удара увеличены на 10%";
                tipch += "\n骷髅的接触伤害降低，所有伤害和暴击率提升10%";
            }
            if (modPlayer.CustomBooster2 == 1)
            {
                tip += "\nProvides immunity to fire blocks, Obsidian Skin, Gills and Flipper effects";
                tipru += "\nОбеспечен иммунитет к огненным блокам, дан эффект обсидиановой кожи, жабр и плавников";
                tipch += "\n给予免疫火块，黑曜石皮肤，鱼鳃，脚蹼药剂效果";
            }
            if (modPlayer.WoFBooster == 1)
            {
                tip += "\nIncreases max amount of minions/sentries by 1, defense and DR by 10/10%";
                tipru += "\nУвеличено максимальное количество миньонов/часовых на 1, защита и ДР на 10/10%";
                tipch += "\n增加1召唤物和哨兵炮台上限，10防御力和10%伤害减免";
            }
            if (modPlayer.GSummonerBooster == 1)
            {
                tip += "\nMakes your attacks inflict Shadowflame and makes you immune to it";
                tipru += "\nЗаставляет ваши атаки вызывать пламя теней и делает вас невосприимчивым к нему";
                tipch += "\n让你的攻击能造成暗影炎，你免疫暗影炎";
            }
            if (modPlayer.DarkMageBooster == 1)
            {
                tip += "\nIncreases magic damage by 25%, max mana by 50 and mana regeneration greatly";
                tipru += "\nУвеличен магический урон на 25%, максимальная мана на 50 и значительно увеличена регенерация маны";
                tipch += "\n提升25%魔法伤害，增加50魔法上限并极大提升魔力再生速度";
            }
            if (modPlayer.IceGolemBooster == 1)
            {
                tip += "\nProvides immunity to Chilled, Frozen and Frostburn debuffs";
                tipru += "\nОбеспечена устойчивость к охлаждению, заморозке и обморожению";
                tipch += "\n免疫寒冷，冻结和霜火";
            }
            if (modPlayer.PigronBooster == 1)
            {
                tip += "\nProvides Well Fed";
                tipru += "\nОбеспечена сытость";
                tipch += "\n吃得饱!";
            }
            if (modPlayer.DestroyerBooster == 1)
            {
                tip += "\nIncreases mining speed by 33% and increases max life by 25%";
                tipru += "\nУвеличена скорость добычи на 33% и увеличено максимальное здоровье на 25%";
                tipch += "\n增加33%挖掘速度并提升25%生命上限";
            }
            if (modPlayer.PrimeBooster == 1)
            {
                tip += "\nIncreases armor penetration and melee speed by 15/15%, gives 200% thorns effect";
                tipru += "\nУвеличена бронепробиваемость и скорость ближнего боя на 15/15%, даны 200% шипы";
                tipch += "\n提升15点护甲穿透和15%的近战速度，给予200%的荆棘药剂效果";
            }
            if (modPlayer.TwinsBooster == 1)
            {
                tip += "\nArchery and Ammo Reservation effects, immunity to Cursed Flames and Ichor";
                tipru += "\nЭффекты экономии стрел и боеприпасов, иммунитет к проклятому пламени и ихору";
                tipch += "\n箭术和弹药储备药剂效果，免疫咒焰和脓血";
            }
            if (modPlayer.OgreBooster == 1)
            {
                tip += "\nIncreases defense and damage reduction by 5/5% and provides knockback immunity";
                tipru += "\nУвеличивает защиту и уменьшает получаемый урон на 5/5% и обеспечивает иммунитет к отталкиванию";
                tipch += "\n提升5防御和增加5%伤害减免并免疫击退";
            }
            if (modPlayer.PlanteraBooster == 1)
            {
                tip += "\nDamages and critical strike chances are boosted while you are moving, Philosopher's stone effect";
                tipru += "\nУрон и вероятность критического удара увеличиваются во время движения, эффект философского камня";
                tipch += "\n移动时增加伤害和暴击率，获得炼金石效果(减药水cd)";
            }
            if (modPlayer.GolemBooster == 1)
            {
                tip += "\nIncreases attack speed by 10% and increases melee knockback";
                tipru += "\nУвеличена скорость атаки на 10% и увеличена отдача в ближнем бою";
                tipch += "\n增加10%攻击速度，提升近战击退力";
            }
            if (modPlayer.BetsyBooster == 1)
            {
                tip += "\nYour attacks inflict Daybroken, flight abilities are increased";
                tipru += "\nАтаки наносят дебафф рассвет, длительность полёта увеличена";
                tipch += "\n你的攻击造成破晓，飞行能力提升";
            }
            if (modPlayer.FishronBooster == 1)
            {
                tip += "\n+4% all stats up while on surface, mount is always accelerated";
                tipru += "\n+4% ко всем характеристикам на поверхности, ездовой питомец ускоряен";
                tipch += "\n表面上的所有属性增加";
            }
            if (modPlayer.MartianSaucerBooster == 1)
            {
                tip += "\nProvides immunity to Electrified and Distorted debuffs";
                tipru += "\nОбеспечен иммунитет к дебаффам электрифицирован и искажен";
                tipch += "\n免疫电击和重力扭曲";
            }
            if (modPlayer.CultistBooster == 1)
            {
                tip += "\nReduces damage taken from Pillars enemies, mobs may drop lunar fragments";
                tipru += "\nУменьшен урон, получаемый от врагов-столбов, мобы могут сбрасывать лунные фрагменты";
                tipch += "\n减少受到月柱敌人造成的伤害，小怪可能掉落月柱碎片";
            }
            if (modPlayer.MoonLordBooster == 1)
            {
                tip += "\nYou emit aura which weakens enemies around";
                tipru += "\nВы излучаете ауру, которая ослабляет врагов вокруг";
                tipch += "\n你产生能弱化周围敌人的光环";
            }


            if (Language.ActiveCulture == GameCulture.FromCultureName(GameCulture.CultureName.Chinese) || Language.ActiveCulture == GameCulture.FromCultureName(GameCulture.CultureName.Russian))
            {
				if (Language.ActiveCulture == GameCulture.FromCultureName(GameCulture.CultureName.Chinese))
				{
					tipLine = tipch;
                }
				else
				{
					tipLine = tipru;
				}
            }
            else
            {
                tipLine = tip;
            }
        }

        public override void Update(Player player, ref int buffIndex)
        {
            AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
            if (modPlayer.KingSlimeBooster == 1)
            {
                player.autoJump = true;
                player.jumpSpeedBoost += 2.4f;
                player.extraFall += 30;
            }
            if (modPlayer.EyeOfCthulhuBooster == 1)
            {
                player.findTreasure = true;
                player.detectCreature = true;
                player.dangerSense = true;
            }
            if (modPlayer.CustomBooster1 == 1)
            {
                Lighting.AddLight((int)((double)player.position.X + (double)(player.width / 2)) / 16, (int)((double)player.position.Y + (double)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
                player.nightVision = true;
            }
            if (modPlayer.EaterOfWorldsBooster == 1)
            {
                player.GetAttackSpeed(DamageClass.Melee) += 0.05f;
                player.pickSpeed -= 0.25f;
                player.moveSpeed += 0.25f;
            }
            if (modPlayer.BrainOfCthulhuBooster == 1)
            {
                player.maxMinions += 1;
                player.lifeMagnet = true;
            }
            if (modPlayer.QueenBeeBooster == 1)
            {
                player.lifeRegen += 6;
                player.buffImmune[20] = true;
                player.buffImmune[70] = true;
            }
            if (modPlayer.SkeletronBooster == 1)
            {
                player.GetDamage(DamageClass.Generic) += 0.1f;
                player.GetCritChance(DamageClass.Melee) += 10;
                player.GetCritChance(DamageClass.Ranged) += 10;
                player.GetCritChance(DamageClass.Magic) += 10;
                player.GetCritChance(DamageClass.Summon) += 10;
                 ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
                if (Calamity != null)
                {
                    Calamity.Call("AddRogueCrit", player, 10);
                }
            }
            if (modPlayer.CustomBooster2 == 1)
            {
                player.ignoreWater = true;
                player.accFlipper = true;
                player.gills = true;
                player.lavaImmune = true;
                player.fireWalk = true;
                player.buffImmune[24] = true;
                player.buffImmune[67] = true;
            }
            if (modPlayer.WoFBooster == 1)
            {
                player.statDefense += 10;
                player.endurance += 0.1f;
                player.maxMinions += 1;
                player.maxTurrets += 1;
            }
            if (modPlayer.GSummonerBooster == 1)
            {
                player.buffImmune[153] = true;
            }
            if (modPlayer.DarkMageBooster == 1)
            {
                player.GetDamage(DamageClass.Magic) += 0.25f;
                player.statManaMax2 += 50;
                player.manaRegenBuff = true;
            }
            if (modPlayer.IceGolemBooster == 1)
            {
                player.buffImmune[44] = true;
                player.buffImmune[46] = true;
                player.buffImmune[46] = true;
            }
            if (modPlayer.PigronBooster == 1)
            {
                player.AddBuff(26, 2);
            }
            if (modPlayer.DestroyerBooster == 1)
            {
                player.pickSpeed -= 0.33f;
                player.statLifeMax2 += player.statLifeMax / 4;
            }
            if (modPlayer.PrimeBooster == 1)
            {
                player.GetArmorPenetration(DamageClass.Generic) += 15;
                player.GetAttackSpeed(DamageClass.Melee) += 0.15f;
                if ((double)player.thorns < 1.0)
                    player.thorns = 2f;
            }
            if (modPlayer.TwinsBooster == 1)
            {
                player.archery = true;
                player.ammoPotion = true;
                player.buffImmune[39] = true;
                player.buffImmune[69] = true;
            }
            if (modPlayer.OgreBooster == 1)
            {
                player.statDefense += 5;
                player.endurance += 0.05f;
                player.noKnockback = true;
            }
            if (modPlayer.PlanteraBooster == 1)
            {
                if (player.velocity.X != 0f || player.velocity.Y != 0f)
                {
                    player.pStone = true;
                    player.GetDamage(DamageClass.Generic) += 0.05f;
                    player.GetCritChance(DamageClass.Melee) += 5;
                    player.GetCritChance(DamageClass.Ranged) += 5;
                    player.GetCritChance(DamageClass.Magic) += 5;
                    player.GetCritChance(DamageClass.Summon) += 5;
                     ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
                    if (Calamity != null)
                    {
                        Calamity.Call("AddRogueCrit", player, 5);
                    }
                }
            }
            if (modPlayer.GolemBooster == 1)
            {
                player.kbBuff = true;
            }
            if (modPlayer.FishronBooster == 1)
            {
                player.MountFishronSpecialCounter = 60f;
                if (player.ZoneOverworldHeight)
                {
                    player.statDefense += 4;
                    player.moveSpeed += 0.1f;
                    player.endurance += 0.04f;
                    player.GetDamage(DamageClass.Generic) += 0.04f;
                    player.GetCritChance(DamageClass.Melee) += 4;
                    player.GetCritChance(DamageClass.Ranged) += 4;
                    player.GetCritChance(DamageClass.Magic) += 4;
                    player.GetCritChance(DamageClass.Summon) += 4;
                     ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
                    if (Calamity != null)
                    {
                        Calamity.Call("AddRogueCrit", player, 4);
                    }
                }
            }
            if (modPlayer.MartianSaucerBooster == 1)
            {
                player.buffImmune[164] = true;
                player.buffImmune[144] = true;
            }
        }
    }
}
