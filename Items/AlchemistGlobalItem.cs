using Terraria.DataStructures;
using Terraria.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.Utilities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using AlchemistNPCRebornAgain.Interface;
using AlchemistNPCRebornAgain;
using Terraria.GameContent.ItemDropRules;
using Terraria.UI;
using Terraria.GameInput;

namespace AlchemistNPCRebornAgain.Items
{
    public class AlchemistGlobalItem : GlobalItem
    {
        public static bool on = false;
        public static bool stop = false;
        public static bool Luck = false;
        public static bool Luck2 = false;
        public static bool Menacing = false;
        public static bool Lucky = false;
        public static bool Violent = false;
        public static bool Warding = false;
        public static bool PerfectionToken = false;

        public override void HoldItem(Item item, Player player)
        {
            if (item.type == 3258 && NPC.AnyNPCs(ModContent.NPCType<NPCs.Knuckles>()))
            {
                item.damage = 1;
            }
            for (int j = 0; j < player.inventory.Length; j++)
            {
                if (player.inventory[j].type == Mod.Find<ModItem>("DimensionalCasket").Type)
                {
                    var keybinds = PlayerInput.CurrentProfile.InputModes[InputMode.Keyboard].KeyStatus["Inventory"];
                    string keybind = "Escape";
                    if(keybinds.Count > 0)
                    {
                        keybind = keybinds[0];
                    }

                    //Microsoft.Xna.Framework.Input.Keys closeCasket;
                    //if (Enum.TryParse(keybind, out closeCasket) )
                    //{
                    //    if (Main.keyState.IsKeyDown(closeCasket))
                    //    {
                    //        DimensionalCasketUI.k = -1;
                    //        DimensionalCasketUI.forcetalk = false;
                    //    }
                    //}
                    //if (DimensionalCasketUI.forcetalk == true)
                    //{
                    //    Main.player[Main.myPlayer].talkNPC = DimensionalCasketUI.k;
                    //}
                }
            }
		}

        public override void UpdateInventory(Item item, Player player)
        {
            if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).BoomBox)
            {
                if (player.inventory[49].createTile != -1 && player.inventory[49].accessory)
                {
                    bool r = false;
                    player.ApplyEquipFunctional(player.inventory[49], r);
                }
            }

            if (item.type == ItemType<Items.Misc.LuckCharm>())
            {
                Luck = true;
            }
            if (item.type == ItemType<Items.Misc.LuckCharmT2>())
            {
                Luck = true;
                Luck2 = true;
            }
            if (item.type == ItemType<Items.Misc.PerfectionToken>())
            {
                PerfectionToken = true;
            }
            if (item.type == ItemType<Items.Misc.MenacingToken>())
            {
                Menacing = true;
            }
            if (item.type == ItemType<Items.Misc.LuckyToken>())
            {
                Lucky = true;
            }
            if (item.type == ItemType<Items.Misc.ViolentToken>())
            {
                Violent = true;
            }
            if (item.type == ItemType<Items.Misc.WardingToken>())
            {
                Warding = true;
            }
        }

        public override int ChoosePrefix(Item item, UnifiedRandom rand)
        {
            if (Luck == true && PerfectionToken == false)
            {
                if (item.CountsAsClass(DamageClass.Melee))
                {
                    if (Main.rand.Next(10) == 0)
                        return 59;

                    if (Main.rand.Next(20) == 0)
                        return 81;
                }
                if (item.CountsAsClass(DamageClass.Ranged) && !item.consumable)
                {
                    if (Main.rand.Next(10) == 0)
                        return 20;

                    if (Main.rand.Next(20) == 0)
                        return 82;
                }
                if (item.CountsAsClass(DamageClass.Magic))
                {
                    if (Main.rand.Next(10) == 0)
                        return 28;

                    if (Main.rand.Next(20) == 0)
                        return 83;
                }
                if (item.CountsAsClass(DamageClass.Summon))
                {
                    if (Main.rand.Next(10) == 0)
                        return 57;

                    if (Main.rand.Next(20) == 0)
                        return 83;
                }
                if (item.CountsAsClass(DamageClass.Throwing) && !item.consumable)
                {
                    if (Main.rand.Next(10) == 0)
                        return 20;

                    if (Main.rand.Next(20) == 0)
                        return 82;
                }
            }
            if (Luck2 == true && !Menacing && !Lucky && !Violent && !Warding)
            {
                if (item.accessory)
                {
                    if (Main.rand.Next(10) == 0)
                        return 72;

                    else if (Main.rand.Next(10) == 0)
                        return 68;

                    else if (Main.rand.Next(10) == 0)
                        return 65;
                }
            }
            if (PerfectionToken == true)
            {
                if (item.type == Mod.Find<ModItem>("LastTantrum").Type)
                {
                    return 59;
                }
                if (ModLoader.TryGetMod("CalamityMod", out Mod Calamity) != null)
                {
                    if (item.type == ModLoader.GetMod("CalamityMod").Find<ModItem>("P90").Type)
                    {
                        return 57;
                    }
                    if (item.type == ModLoader.GetMod("CalamityMod").Find<ModItem>("ColdheartIcicle").Type)
                    {
                        return 15;
                    }
                    if (item.type == ModLoader.GetMod("CalamityMod").Find<ModItem>("HalibutCannon").Type)
                    {
                        return 17;
                    }
                }
                if (item.damage > 3 && item.useTime <= 4 && item.useAnimation <= 4 && item.maxStack == 1)
                {
                    return Mod.Find<ModPrefix>("Ancient").Type;
                }
                if (item.damage > 3 && item.CountsAsClass(DamageClass.Melee) && item.maxStack == 1)
                {
                    return Mod.Find<ModPrefix>("Primal").Type;
                }
                if (item.damage > 3 && item.CountsAsClass(DamageClass.Magic) && item.maxStack == 1)
                {
                    return Mod.Find<ModPrefix>("Arcana").Type;
                }
                if (item.damage > 3 && item.CountsAsClass(DamageClass.Summon) && item.maxStack == 1)
                {
                    return Mod.Find<ModPrefix>("Demiurgic").Type;
                }
                if (item.damage > 3 && (item.CountsAsClass(DamageClass.Ranged) || item.CountsAsClass(DamageClass.Throwing)) && item.maxStack == 1)
                {
                    return Mod.Find<ModPrefix>("Immortal").Type;
                }
                if (item.damage > 3)
                {
                    if (item.CountsAsClass(DamageClass.Melee))
                    {
                        return 81;
                    }
                    if (item.CountsAsClass(DamageClass.Ranged) && !item.consumable && item.useTime <= 3)
                    {
                        return 59;
                    }
                    if (item.CountsAsClass(DamageClass.Ranged) && !item.consumable && item.knockBack <= 0)
                    {
                        return 60;
                    }
                    if (item.CountsAsClass(DamageClass.Ranged) && !item.consumable && item.knockBack > 0)
                    {
                        return 82;
                    }
                    if (item.CountsAsClass(DamageClass.Magic) && item.knockBack <= 0)
                    {
                        return 60;
                    }
                    if (item.CountsAsClass(DamageClass.Magic) && item.useTime <= 2)
                    {
                        return 59;
                    }
                    if (item.CountsAsClass(DamageClass.Magic) && item.mana <= 4)
                    {
                        return 59;
                    }
                    if (item.CountsAsClass(DamageClass.Magic) && item.knockBack > 0)
                    {
                        return 83;
                    }
                    if (item.CountsAsClass(DamageClass.Summon))
                    {
                        return 83;
                    }
                    if (item.CountsAsClass(DamageClass.Throwing) && !item.consumable && item.useTime <= 3)
                    {
                        return 59;
                    }
                    if (item.CountsAsClass(DamageClass.Throwing) && !item.consumable)
                    {
                        return 82;
                    }
                }
            }
            if (item.accessory)
            {
                if (Menacing)
                {
                    return 72;
                }
                if (Lucky)
                {
                    return 68;
                }
                if (Violent)
                {
                    return 80;
                }
                if (Warding)
                {
                    return 65;
                }
            }
            return -1;
        }

        public override void PreReforge(Item item)
        {
            Player player = Main.player[Main.myPlayer];
            if (Main.player[Main.myPlayer].HasItem(Mod.Find<ModItem>("PerfectionToken").Type) && item.damage > 3)
            {
                Item[] inventory = Main.player[Main.myPlayer].inventory;
                for (int k = 0; k < inventory.Length; k++)
                {
                    if (inventory[k].type == Mod.Find<ModItem>("PerfectionToken").Type)
                    {
                        inventory[k].stack--;
                        return;
                    }
                }
            }
            if (Main.player[Main.myPlayer].HasItem(Mod.Find<ModItem>("MenacingToken").Type))
            {
                Item[] inventory = Main.player[Main.myPlayer].inventory;
                for (int k = 0; k < inventory.Length; k++)
                {
                    if (inventory[k].type == Mod.Find<ModItem>("MenacingToken").Type)
                    {
                        inventory[k].stack--;
                        return;
                    }
                }
            }
            if (Main.player[Main.myPlayer].HasItem(Mod.Find<ModItem>("LuckyToken").Type))
            {
                Item[] inventory = Main.player[Main.myPlayer].inventory;
                for (int k = 0; k < inventory.Length; k++)
                {
                    if (inventory[k].type == Mod.Find<ModItem>("LuckyToken").Type)
                    {
                        inventory[k].stack--;
                        return;
                    }
                }
            }
            if (Main.player[Main.myPlayer].HasItem(Mod.Find<ModItem>("ViolentToken").Type))
            {
                Item[] inventory = Main.player[Main.myPlayer].inventory;
                for (int k = 0; k < inventory.Length; k++)
                {
                    if (inventory[k].type == Mod.Find<ModItem>("ViolentToken").Type)
                    {
                        inventory[k].stack--;
                        return;
                    }
                }
            }
            if (Main.player[Main.myPlayer].HasItem(Mod.Find<ModItem>("WardingToken").Type))
            {
                Item[] inventory = Main.player[Main.myPlayer].inventory;
                for (int k = 0; k < inventory.Length; k++)
                {
                    if (inventory[k].type == Mod.Find<ModItem>("WardingToken").Type)
                    {
                        inventory[k].stack--;
                        return;
                    }
                }
            }
            return;
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier4 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
            {
                ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
                if (Calamity != null)
                {
                    if ((bool)Calamity.Call("Downed", "supreme calamitas"))
                    {
                        return false;
                    }
                }
                if (Main.rand.NextFloat() >= .25f)
                {
                    return false;
                }
            }

            else if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier3 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
            {
                if (Main.rand.Next(2) == 0)
                    return false;
            }

            else if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier2 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
            {
                if (Main.rand.Next(4) == 0)
                    return false;
            }

            else if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).AlchemistCharmTier1 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
            {
                if (Main.rand.Next(10) == 0)
                    return false;
            }
            return true;
        }

        public override bool CanConsumeAmmo(Item weapon, Item ammo, Player player)
        {
            if (player.HasBuff(Mod.Find<ModBuff>("DemonSlayer").Type))
            {
                return Main.rand.NextFloat() >= .25f;
            }
            return true;
        }

        public override float UseTimeMultiplier(Item item, Player player)
        {
            if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).GolemBooster == 1 && item.useTime > 3)
            {
                return 1.1f;
            }
            if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).Symbiote == true && item.useTime > 3)
            {
                if (!Main.hardMode)
                {
                    return 1.1f;
                }
                if (Main.hardMode && !NPC.downedMoonlord)
                {
                    return 1.15f;
                }
                if (NPC.downedMoonlord)
                {
                    return 1.2f;
                }
            }
            return base.UseTimeMultiplier(item, player);
        }

        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
            if (player.HasBuff(Mod.Find<ModBuff>("DemonSlayer").Type) && item.CountsAsClass(DamageClass.Throwing) && Main.rand.Next(3) == 0)
            {
                Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y - 12, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
            }
            if (modPlayer.Rampage == true && type == 14)
            {
                type = Mod.Find<ModProjectile>("Chloroshard").Type;
            }
            if (modPlayer.Rampage == true && type == 1)
            {
                type = Mod.Find<ModProjectile>("ChloroshardArrow").Type;
            }
            if (modPlayer.DeltaRune && item.CountsAsClass(DamageClass.Melee) && Main.rand.NextBool(20))
            {
                Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, velocity.X, velocity.Y, Mod.Find<ModProjectile>("RedWave").Type, 1111, 1f, player.whoAmI);
            }
            if (modPlayer.DeltaRune && item.CountsAsClass(DamageClass.Magic) && Main.rand.NextBool(30))
            {
                float numberProjectiles = 9;
                float rotation = MathHelper.ToRadians(8);
                Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .5f;
                    Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),vector.X, vector.Y, perturbedSpeed.X, perturbedSpeed.Y, Mod.Find<ModProjectile>("MM").Type, 1337, knockback, player.whoAmI);
                }
            }
            if (modPlayer.Barrage)
            {
                SoundEngine.PlaySound(SoundID.Item91, player.position);
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(5));
                int p = Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, Mod.Find<ModProjectile>("EnergyBall").Type, item.damage / 5, 1f, player.whoAmI);
                if (item.useTime > 10)
                {
                    Vector2 perturbedSpeed2 = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(4));
                    Vector2 perturbedSpeed3 = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(4));
                    Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, Mod.Find<ModProjectile>("EnergyBall").Type, item.damage / 4, 1f, player.whoAmI);
                    Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, perturbedSpeed3.X, perturbedSpeed3.Y, Mod.Find<ModProjectile>("EnergyBall").Type, item.damage / 4, 1f, player.whoAmI);
                }
            }
            return base.Shoot(item, player, source, position, velocity, type, damage, knockback);
        }

        public override bool? UseItem(Item item, Player player)
        {
            AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
            if (modPlayer.Barrage && item.damage > 0 && Main.GameUpdateCount % 6 == 0)
            {
                SoundEngine.PlaySound(SoundID.Item91, player.position);
                float num1 = 9f;
                Vector2 vector2 = new Vector2(player.position.X + (float)player.width * 0.5f, player.position.Y + (float)player.height * 0.5f);
                float f1 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
                float f2 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
                if ((double)player.gravDir == -1.0)
                    f2 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector2.Y;
                float num4 = (float)Math.Sqrt((double)f1 * (double)f1 + (double)f2 * (double)f2);
                float num5;
                if (float.IsNaN(f1) && float.IsNaN(f2) || (double)f1 == 0.0 && (double)f2 == 0.0)
                {
                    f1 = (float)player.direction;
                    f2 = 0.0f;
                    num5 = num1;
                }
                else
                    num5 = num1 / num4;
                float SpeedX = f1 * num5;
                float SpeedY = f2 * num5;
                Vector2 perturbedSpeed = new Vector2(SpeedX, SpeedY).RotatedByRandom(MathHelper.ToRadians(5));
                Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),vector2.X, vector2.Y, perturbedSpeed.X, perturbedSpeed.Y, Mod.Find<ModProjectile>("EnergyBall").Type, item.damage / 5, 1f, player.whoAmI);
            }
            if (item.type == 1991 || item.type == 3183)
            {
                for (int v = 0; v < 200; ++v)
                {
                    NPC npc = Main.npc[v];
                    if (npc.active && npc.townNPC)
                    {
                        if (AlchemistNPCRebornAgain.modConfiguration.CatchNPC)
                        {
                            if (npc.type == ModContent.NPCType<NPCs.Alchemist>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.AlchemistHorcrux>();
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Brewer>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.BrewerHorcrux>();
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Architect>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.ArchitectHorcrux>();
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Jeweler>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.JewelerHorcrux>();
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Explorer>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.RealityPiercer>();
                            }
                            if (npc.type == ModContent.NPCType<NPCs.OtherworldlyPortal>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.NotesBook>();
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Operator>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.APMC>();
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Musician>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.MusicianHorcrux>();
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Tinkerer>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.TinkererHorcrux>();
                            }
                        }
                        if (!AlchemistNPCRebornAgain.modConfiguration.CatchNPC)
                        {
                            if (npc.type == ModContent.NPCType<NPCs.Alchemist>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Brewer>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Architect>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Jeweler>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Explorer>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == ModContent.NPCType<NPCs.OtherworldlyPortal>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Operator>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Musician>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Tinkerer>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                        }
                    }
                }
            }
            if (modPlayer.KeepBuffs == 1 && (item.buffTime > 0))
            {
                if (modPlayer.AlchemistCharmTier4)
                {
                    player.AddBuff(item.buffType, item.buffTime * 2 + ((item.buffTime * 2) / 2), true);
                }
                else if (modPlayer.AlchemistCharmTier3)
                {
                    player.AddBuff(item.buffType, item.buffTime * 2 + (((item.buffTime * 2) / 20) * 7), true);
                }
                else if (modPlayer.AlchemistCharmTier2)
                {
                    player.AddBuff(item.buffType, item.buffTime * 2 + ((item.buffTime * 2) / 4), true);
                }
                else if (modPlayer.AlchemistCharmTier1)
                {
                    player.AddBuff(item.buffType, item.buffTime * 2 + ((item.buffTime * 2) / 10), true);
                }
                else player.AddBuff(item.buffType, item.buffTime * 2, true);
            }
            if (modPlayer.KeepBuffs == 0 && (item.buffTime > 0))
            {
                if (modPlayer.AlchemistCharmTier4)
                {
                    player.AddBuff(item.buffType, item.buffTime + (item.buffTime / 2), true);
                }
                else if (modPlayer.AlchemistCharmTier3)
                {
                    player.AddBuff(item.buffType, item.buffTime + ((item.buffTime / 20) * 7), true);
                }
                else if (modPlayer.AlchemistCharmTier2)
                {
                    player.AddBuff(item.buffType, item.buffTime + (item.buffTime / 4), true);
                }
                else if (modPlayer.AlchemistCharmTier1)
                {
                    player.AddBuff(item.buffType, item.buffTime + (item.buffTime / 10), true);
                }
            }
            return base.UseItem(item, player);
        }

        public override void PickAmmo(Item weapon, Item ammo, Player player, ref int type, ref float speed, ref StatModifier damage, ref float knockback)
        {
            if (type == ProjectileID.Bullet && player.GetModPlayer<AlchemistNPCRebornPlayer>().Rampage)
            {
                type = Mod.Find<ModProjectile>("Chloroshard").Type;
            }
            if (type == 1 && player.GetModPlayer<AlchemistNPCRebornPlayer>().Rampage)
            {
                type = Mod.Find<ModProjectile>("ChloroshardArrow").Type;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            //SBMW:Vanilla
            string KingSlime = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.KingSlime");
            string EyeofCthulhu = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EyeofCthulhu");
            string EaterOfWorlds = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EaterOfWorlds");
            string BrainOfCthulhu = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BrainOfCthulhu");
            string QueenBee = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.QueenBee");
            string Skeletron = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Skeletron");
            string Deerclops = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Deerclops");
            string WallOfFlesh = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.WallOfFlesh");
            string QueenSlime = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.QueenSlime");
            string Destroyer = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Destroyer");
            string Twins = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Twins");
            string SkeletronPrime = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.SkeletronPrime");
            string Plantera = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Plantera");
            string EmpressOfLight = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EmpressOfLight");
            string Golem = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Golem");
            string Betsy = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Betsy");
            string DukeFishron = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.DukeFishron");
            string MoonLord = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.MoonLord");

            //SBMW:CalamityMod
            string DesertScourge = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.DesertScourge");
            string Crabulon = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Crabulon");
            string HiveMind = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.HiveMind");
            string Perforator = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Perforator");
            string SlimeGod = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.SlimeGod");
            string Cryogen = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Cryogen");
            string BrimstoneElemental = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BrimstoneElemental");
            string AquaticScourge = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.AquaticScourge");
            string Calamitas = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Calamitas");
            string AstrageldonSlime = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.AstrageldonSlime");
            string AstrumDeus = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.AstrumDeus");
            string Leviathan = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Leviathan");
            string PlaguebringerGoliath = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.PlaguebringerGoliath");
            string Ravager = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Ravager");
            string Providence = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Providence");
            string StormWeaver = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.StormWeaver");
            string CeaselessVoid = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.CeaselessVoid");
            string Signus = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Signus");
            string Polterghast = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Polterghast");
            string OldDuke = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.OldDuke");
            string DevourerofGods = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.DevourerofGods");
            string Bumblebirb = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Bumblebirb");
            string Yharon = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Yharon");
            string ExoMechs = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.ExoMechs");
            string SupremeCalamitas = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.SupremeCalamitas");

            //SBMW:ThoriumMod
            string DarkMage = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.DarkMage");
            string Ogre = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Ogre");
            string ThunderBird = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.ThunderBird");
            string QueenJellyfish = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.QueenJellyfish");
            string CountEcho = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.CountEcho");
            string GraniteEnergyStorm = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.GraniteEnergyStorm");
            string TheBuriedChampion = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.TheBuriedChampion");
            string TheStarScouter = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.TheStarScouter");
            string BoreanStrider = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.BoreanStrider");
            string CoznixTheFallenBeholder = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.CoznixTheFallenBeholder");
            string TheLich = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.TheLich");
            string AbyssionTheForgottenOne = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.AbyssionTheForgottenOne");
            string TheRagnarok = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.TheRagnarok");

            //ElementsAwoken
            string Wasteland = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Wasteland");
            string Infernace = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Infernace");
            string ScourgeFighter = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.ScourgeFighter");
            string Regaroth = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Regaroth");
            string TheCelestials = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.TheCelestials");
            string Permafrost = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Permafrost");
            string Obsidious = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Obsidious");
            string Aqueous = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Aqueous");
            string TempleKeepers = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.TempleKeepers");
            string Guardian = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Guardian");
            string Volcanox = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Volcanox");
            string VoidLevi = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.VoidLevi");
            string Azana = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Azana");
            string Ancients = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Ancients");

            //Redemption
            string KingChicken = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.KingChicken");
            string ThornBane = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.ThornBane");
            string TheKeeper = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.TheKeeper");
            string XenoCrystal = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.XenoCrystal");
            string IEye = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.IEye");
            string KingSlayer = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.KingSlayer");
            string V1 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.V1");
            string V2 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.V2");
            string V3 = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.V3");
            string PZ = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.PZ");
            string ThornRematch = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.ThornRematch");
            string Nebuleus = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Nebuleus");

            //SacredTools
            string Decree = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Decree");
            string FlamingPumpkin = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.FlamingPumpkin");
            string Jensen = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Jensen");
            string Araneas = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Araneas");
            string Raynare = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Raynare");
            string Primordia = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Primordia");
            string Abaddon = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Abaddon");
            string Araghur = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Araghur");
            string Lunarians = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Lunarians");
            string Challenger = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Challenger");
            string Spookboi = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Spookboi");

            //SpiritMod
            string Scarabeus = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Scarabeus");
            string Bane = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Bane");
            string Flier = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Flier");
            string Raider = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Raider");
            string Infernon = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Infernon");
            string Dusking = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Dusking");
            string EtherialUmbra = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EtherialUmbra");
            string IlluminantMaster = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.IlluminantMaster");
            string Atlas = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Atlas");
            string Overseer = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Overseer");

            //Enigma
            string Sharkron = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Sharkron");
            string Hypothema = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Hypothema");
            string Ragnar = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Ragnar");
            string AnDio = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.AnDio");
            string Annihilator = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Annihilator");
            string Slybertron = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Slybertron");
            string SteamTrain = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.SteamTrain");

            //pinky
            string SunlightTrader = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.SunlightTrader");
            string THOFC = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.THOFC");
            string MythrilSlime = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.MythrilSlime");
            string Valdaris = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Valdaris");
            string Gatekeeper = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Gatekeeper");

            //AAMod
            string Monarch = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Monarch");
            string Grips = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Grips");
            string Broodmother = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Broodmother");
            string Hydra = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Hydra");
            string Serpent = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Serpent");
            string Djinn = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Djinn");
            string Retriever = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Retriever");
            string RaiderU = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.RaiderU");
            string Orthrus = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Orthrus");
            string EFish = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.EFish");
            string Nightcrawler = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Nightcrawler");
            string Daybringer = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Daybringer");
            string Yamata = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Yamata");
            string Akuma = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Akuma");
            string Zero = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Zero");
            string Shen = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.Shen");
            string ShenGrips = Language.GetTextValue("Mods.AlchemistNPCRebornAgain.ShenGrips");

            if (item.type == ItemID.KingSlimeBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "KingSlime", KingSlime);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.EyeOfCthulhuBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "EyeofCthulhu", EyeofCthulhu);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.EaterOfWorldsBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "EaterOfWorlds", EaterOfWorlds);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.BrainOfCthulhuBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "BrainOfCthulhu", BrainOfCthulhu);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.QueenBeeBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "QueenBeeBossBag", QueenBee);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.SkeletronBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Skeletron", Skeletron);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.DeerclopsBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Deerclops", Deerclops);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.WallOfFleshBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "WallOfFleshBoss", WallOfFlesh);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.QueenSlimeBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "QueenSlime", QueenSlime);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.DestroyerBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Destroyer", Destroyer);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.TwinsBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Twins", Twins);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.SkeletronPrimeBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "SkeletronPrime", SkeletronPrime);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.PlanteraBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Plantera", Plantera);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.FairyQueenBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Empress of Light", EmpressOfLight);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.GolemBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Golem", Golem);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.BossBagBetsy)
            {
                TooltipLine line = new TooltipLine(Mod, "Betsy", Betsy);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.FishronBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "DukeFishron", DukeFishron);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.MoonLordBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "MoonLord", MoonLord);
                line.OverrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            if (Calamity != null)
            {
                if (Calamity.TryFind<ModItem>("DesertScourgeBag", out ModItem currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "DesertScourge", DesertScourge);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("CrabulonBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "Crabulon", Crabulon);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("HiveMindBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "HiveMind", HiveMind);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("PerforatorBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "Perforator", Perforator);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("SlimeGodBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "SlimeGod", SlimeGod);

                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("CryogenBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "Cryogen", Cryogen);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("BrimstoneWaifuBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "BrimstoneElemental", BrimstoneElemental);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("AquaticScourgeBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "AquaticScourge", AquaticScourge);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("CalamitasBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "Calamitas", Calamitas);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("AstrageldonBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "AstrageldonSlime", AstrageldonSlime);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("AstrumDeusBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "AstrumDeus", AstrumDeus);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("LeviathanBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "Leviathan", Leviathan);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("PlaguebringerGoliathBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "PlaguebringerGoliath", PlaguebringerGoliath);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("RavagerBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "Ravager", Ravager);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("ProvidenceBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "Providence", Providence);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("StormWeaverBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "StormWeaver", StormWeaver);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("CeaselessVoidBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "CeaselessVoid", CeaselessVoid);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("SignusBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "Signus", Signus);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("PolterghastBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "Polterghast", Polterghast);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("OldDukeBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "OldDuke", OldDuke);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("DevourerofGodsBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "DevourerofGods", DevourerofGods);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("BumblebirbBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "Bumblebirb", Bumblebirb);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("YharonBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "Yharon", Yharon);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("DraedonTreasureBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "ExoMechs", ExoMechs);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (Calamity.TryFind<ModItem>("SCalBag", out currItem) && item.type == currItem.Type)
                {
                    TooltipLine line = new TooltipLine(Mod, "SupremeCalamitas", SupremeCalamitas);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            if (ModLoader.GetMod("ThoriumMod") != null)
            {
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("DarkMageBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "DarkMage", DarkMage);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("OgreBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Ogre", Ogre);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("ThunderBirdBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "ThunderBird", ThunderBird);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("JellyFishBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "QueenJellyfish", QueenJellyfish);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("CountBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "CountEcho", CountEcho);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("GraniteBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "GraniteEnergyStorm", GraniteEnergyStorm);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("HeroBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "TheBuriedChampion", TheBuriedChampion);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "TheStarScouter", TheStarScouter);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("BoreanBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "BoreanStrider", BoreanStrider);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("BeholderBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "CoznixTheFallenBeholder", CoznixTheFallenBeholder);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("LichBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "TheLich", TheLich);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("AbyssionBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "AbyssionTheForgottenOne", AbyssionTheForgottenOne);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("RagBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "TheRagnarok", TheRagnarok);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
            if (ModLoader.GetMod("AAMod") != null)
            {
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("MonarchBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Monarch", Monarch);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("GripBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Grips", Grips);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("BroodBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Broodmother", Broodmother);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("HydraBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Hydra", Hydra);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("SerpentBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Serpent", Serpent);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("DjinnBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Djinn", Djinn);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("RetrieverBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Retriever", Retriever);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("RaiderBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "RaiderU", RaiderU);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("OrthrusBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Orthrus", Orthrus);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("EFishBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "EFish", EFish);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("DBBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Daybringer", Daybringer);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("NCBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Nightcrawler", Nightcrawler);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("YamataBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Yamata", Yamata);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("AkumaBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Akuma", Akuma);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("ZeroBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Zero", Zero);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("ShenCache")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Shen", Shen);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("GripSBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "ShenGrips", ShenGrips);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
            if (ModLoader.GetMod("ElementsAwoken") != null)
            {
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("WastelandBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Wasteland", Wasteland);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("InfernaceBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Infernace", Infernace);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("ScourgeFighterBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "ScourgeFighter", ScourgeFighter);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("RegarothBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Regaroth", Regaroth);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("TheCelestialBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "TheCelestials", TheCelestials);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("PermafrostBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Permafrost", Permafrost);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("ObsidiousBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Obsidious", Obsidious);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("AqueousBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Aqueous", Aqueous);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("TempleKeepersBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "TempleKeepers", TempleKeepers);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("GuardianBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Guardian", Guardian);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("VolcanoxBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Volcanox", Volcanox);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("VoidLeviathanBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "VoidLevi", VoidLevi);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("AzanaBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Azana", Azana);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("AncientsBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Ancients", Ancients);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
            if (ModLoader.GetMod("Redemption") != null)
            {
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("KingChickenBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "KingChicken", KingChicken);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("ThornBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "ThornBane", ThornBane);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("TheKeeperBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "TheKeeper", TheKeeper);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("XenomiteCrystalBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "XenoCrystal", XenoCrystal);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("InfectedEyeBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "IEye", IEye);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("SlayerBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "KingSlayer", KingSlayer);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("VlitchCleaverBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "V1", V1);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("VlitchGigipedeBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "V2", V2);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("OmegaOblitBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "V3", V3);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("PZBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "PZ", PZ);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("ThornPZBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "ThornRematch", ThornRematch);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("NebBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Nebuleus", Nebuleus);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
            if (ModLoader.GetMod("SacredTools") != null)
            {
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("DecreeBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Decree", Decree);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("PumpkinBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "FlamingPumpkin", FlamingPumpkin);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("HarpyBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Jensen", Jensen);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("AraneasBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Araneas", Araneas);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("HarpyBag2")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Raynare", Raynare);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("PrimordiaBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Primordia", Primordia);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("OblivionBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Abaddon", Abaddon);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("SerpentBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Araghur", Araghur);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("LunarBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Lunarians", Lunarians);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("ChallengerBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Challenger", Challenger);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("SpookboiBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Spookboi", Spookboi);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
            if (ModLoader.GetMod("SpiritMod") != null)
            {
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("BagOScarabs")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Scarabeus", Scarabeus);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("ReachBossBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Bane", Bane);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("FlyerBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Flier", Flier);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("SteamRaiderBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Raider", Raider);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("InfernonBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Infernon", Infernon);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("DuskingBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Dusking", Dusking);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("SpiritCoreBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "EqualityComparer", EtherialUmbra);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("IlluminantBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "IlluminantMaster", IlluminantMaster);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("AtlasBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Atlas", Atlas);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("OverseerBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Overseer", Overseer);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
            if (ModLoader.GetMod("Laugicality") != null)
            {
                if (item.type == (ModLoader.GetMod("Laugicality").ItemType("DuneSharkronTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Sharkron", Sharkron);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Laugicality").ItemType("HypothemaTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Hypothema", Hypothema);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Laugicality").ItemType("RagnarTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Ragnar", Ragnar);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Laugicality").ItemType("AnDioTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "AnDio", AnDio);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Laugicality").ItemType("AnnihilatorTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Annihilator", Annihilator);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Laugicality").ItemType("SlybertronTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Slybertron", Slybertron);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Laugicality").ItemType("SteamTrainTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "SteamTrain", SteamTrain);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
            if (ModLoader.GetMod("pinkymod") != null)
            {
                if (item.type == (ModLoader.GetMod("pinkymod").ItemType("STBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "SunlightTrader", SunlightTrader);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("pinkymod").ItemType("HOTCTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "THOFC", THOFC);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("pinkymod").ItemType("MythrilBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "MythrilSlime", MythrilSlime);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("pinkymod").ItemType("Valdabag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Valdaris", Valdaris);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("pinkymod").ItemType("GatekeeperTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Gatekeeper", Gatekeeper);
                    line.OverrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
			*/
        }

        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (!ItemID.Sets.BossBag[item.type]) return;
                
            
            if (Main.rand.NextBool(150))
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("TimeTwistBraclet").Type));
            
            if (Main.hardMode && Main.rand.NextBool(150))
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("SuspiciousLookingScythe").Type));
                
            if (NPC.downedPlantBoss && Main.rand.NextBool(150))
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("HeartofYuiS").Type));
                
            if (Main.hardMode && Main.rand.NextBool(150))
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("StatsChecker").Type));

            if (NPC.downedPlantBoss && Main.rand.NextBool(200))
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("BanHammer").Type));
                
            if (NPC.downedPlantBoss && Main.rand.NextBool(150))
            {
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("PinkGuyHead").Type));
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("PinkGuyBody").Type));
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("PinkGuyLegs").Type));
            }
            if (NPC.downedPlantBoss && Main.rand.NextBool(150))
            {
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("BlackCatHead").Type));
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("BlackCatBody").Type));
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("BlackCatLegs").Type));
            }
            if (NPC.downedPlantBoss && Main.rand.NextBool(150))
            {
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("Skyline222Hair").Type));
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("Skyline222Body").Type));
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("Skyline222Legs").Type));
            }
            if (NPC.downedPlantBoss && Main.rand.NextBool(150))
            {
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("somebody0214Hood").Type));
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("somebody0214Robe").Type));
            }
            if (NPC.downedPlantBoss && Main.rand.NextBool(250))
            {
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("BloodMoonCirclet").Type));
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("BloodMoonDress").Type));
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("BloodMoonStockings").Type));
            }
            if (NPC.downedMoonlord && Main.rand.NextBool(300))
                itemLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("StrangeTopHat").Type));
        }

        public override void VerticalWingSpeeds(Item item, Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
            if (modPlayer.BetsyBooster == 1)
            {
                maxCanAscendMultiplier += 1f;
                maxAscentMultiplier += 1f;
            }
        }

        public override void HorizontalWingSpeeds(Item item, Player player, ref float speed, ref float acceleration)
        {
            AlchemistNPCRebornPlayer modPlayer = player.GetModPlayer<AlchemistNPCRebornPlayer>();
            if (modPlayer.BetsyBooster == 1)
            {
                speed += 0.1f;
                acceleration += 0.1f;
            }
            if (player.HasBuff(Mod.Find<ModBuff>("Exhausted").Type))
            {
                speed *= 0.8f;
                acceleration *= 0.8f;
            }
            if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).chargetime >= 390)
            {
                speed *= 0.75f;
                acceleration *= 0.75f;
            }
            else if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).chargetime >= 210)
            {
                speed *= 0.9f;
                acceleration *= 0.9f;
            }
        }

        protected override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }

        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
    }
}
