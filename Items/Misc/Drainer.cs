using System;
using System.Collections.Generic;
using AlchemistNPCRebornAgain.Extensions.SubMods;
using CalamityMod.CalPlayer;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.Chat;

namespace AlchemistNPCRebornAgain.Items.Misc
{
    public class Drainer : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 36;
            Item.maxStack = 1;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = 2;
            Item.value = 100000;
            Item.rare = 9;
            Item.UseSound = SoundID.Item4;
        }

[JITWhenModsEnabled("CalamityMod")]
        public override bool? UseItem(Player player)
        {
            if (CalamityHelper.isCalamityMod())
            {
                try
                {
                    if (CalamityHelper.getCalamityPlayer(player, out var calPlayer))
                    {
                        for (int h = 0; h < 1; h++)
                        {
                            Vector2 vel = new Vector2(0, -1);
                            vel *= 0f;
                            Projectile.NewProjectile(((Entity)player).GetSource_FromThis((string)null), player.Center.X, player.Center.Y, vel.X, vel.Y, Mod.Find<ModProjectile>("Drainer").Type, 0, 0, player.whoAmI);
                        }

                        player.Hurt(PlayerDeathReason.LegacyEmpty(), 2, 0, false, false, -1, false, 0, 0, 0);
                        calPlayer.rage += calPlayer.rageMax / 4;
                        player.statLife = (player.statLife - player.statLifeMax2 / 4);
                        PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
                        if (Main.rand.NextBool(2)) damageSource = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
                        if (player.statLife <= 0) player.KillMe(damageSource, 1.0, 0, false);
                        player.lifeRegenCount = 0;
                        player.lifeRegenTime = 0;
                    }
                }
                catch (Exception) {}
            }

            return true;
        }

        private Vector2 GetLightPosition(Player player)
        {
            Vector2 position = Main.screenPosition;
            position.X += Main.mouseX;
            position.Y += player.gravDir == 1 ? Main.mouseY : Main.screenHeight - Main.mouseY;
            return position;
        }

        public override void AddRecipes()
        {
            if (CalamityHelper.isCalamityMod())
            {
                Recipe recipe = CreateRecipe(1);
                recipe.AddIngredient(ItemID.Spike, 2);
                recipe.AddIngredient(null, "CrystalDust", 10);
                recipe.AddIngredient(ItemID.FragmentSolar, 5);
                recipe.AddIngredient(ItemID.FragmentVortex, 5);
                recipe.AddIngredient(ItemID.FragmentNebula, 5);
                recipe.AddIngredient(ItemID.FragmentStardust, 5);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();
            }
        }
    }
}
