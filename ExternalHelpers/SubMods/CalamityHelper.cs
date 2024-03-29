using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AlchemistNPCRebornAgain.Extensions.SubMods
{
    public static class CalamityHelper
    {
        private static bool _testedForCalamity = false;
        private static Mod _calamityInstance = null;


        private static int _failures = 0;

        [JITWhenModsEnabled("CalamityMod")]
        private static CalamityMod.CalPlayer.CalamityPlayer getCalamityPlayerInternal(Player player)
        {
            try
            {
                return player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool isCalamityMod()
        {
            if (_testedForCalamity)
                return _calamityInstance != null;
            _testedForCalamity = true;
            return ExternalModCache.findMod("CalamityMod", out _calamityInstance) && _calamityInstance != null;
        }

        public static bool getCalamityMod(out Mod calamityMod)
        {
            if (!_testedForCalamity) isCalamityMod();

            calamityMod = _calamityInstance;
            return calamityMod != null;
        }


        private static void attemptToWarn(int errors)
        {
            if (errors == 0)
            {
                ChatHelper.DisplayMessageOnClient(NetworkText.FromLiteral("[AlchemistNPCReborn] It Appears Calamity is Semi-Incompatable with this Version!"), Color.Red, Main.myPlayer);
                ChatHelper.DisplayMessageOnClient(NetworkText.FromLiteral("[AlchemistNPCReborn] Please report this to Ferris on Steam or Discord!"), Color.Red, Main.myPlayer);
            }
            else if (errors == 100)
            {
                ChatHelper.DisplayMessageOnClient(NetworkText.FromLiteral("[AlchemistNPCReborn] It Appears Calamity is Semi-Incompatable with this Version!"), Color.Red, Main.myPlayer);
                ChatHelper.DisplayMessageOnClient(NetworkText.FromLiteral("[AlchemistNPCReborn] Please report this to Ferris on Steam or Discord!"), Color.Red, Main.myPlayer);
                ChatHelper.DisplayMessageOnClient(NetworkText.FromLiteral("[AlchemistNPCReborn] Warnings have been disabled!"), Color.Red, Main.myPlayer);
            }
        }
        [JITWhenModsEnabled("CalamityMod")]
        public static bool getCalamityPlayer(Player player, out CalamityMod.CalPlayer.CalamityPlayer calamityPlayer)
        {
            if (!isCalamityMod() || _failures > 100)
            {
                calamityPlayer = null;
                return false;
            }

            calamityPlayer = getCalamityPlayerInternal(player);
            if (calamityPlayer == null)
            {
                _failures += 1;
                attemptToWarn(_failures);
                return false;
            }

            return true;
        }
    }
}
