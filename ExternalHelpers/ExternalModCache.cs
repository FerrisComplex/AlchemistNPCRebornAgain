using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace AlchemistNPCRebornAgain.Extensions
{
    /** Example Usage of this Class
     private static void TestCachedMods()
        {
            _hasTestedModCache = true;
            if (ExternalModCache.findMod("CalamityMod", out var calamity) && ExternalModCache.GetOrCreateModItem(calamity, "PlagueHive", out var calamityItem))
                _plagueHiveItem = calamityItem.Type;
            if (ExternalModCache.findMod("FargowiltasSouls", out var fargoSouls) && ExternalModCache.GetOrCreateModItem(fargoSouls, "BeeEnchant", out var fargoItem))
                _beeEnchantmentItem = fargoItem.Type;
        }

        private static bool _hasTestedModCache = false;
        private static int _plagueHiveItem = -10000;
        private static int _beeEnchantmentItem = -10000;

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (target.friendly) return;
            Player player = Main.player[Projectile.owner];
            // Cache and re-use this, significantly faster than the old way for large number of mods
            if (!_hasTestedModCache) TestCachedMods();

            // This should run sooooooo much faster >.>
            for (int index1 = 0; index1 < 8 + player.extraAccessorySlots; ++index1)
            {
                var armor = player.armor[index1].type;
                if (armor == _plagueHiveItem || armor == ItemID.HiveBackpack || armor == _beeEnchantmentItem)
                    modifiers.FinalDamage /= 2;
            }
        }
        **/
    public static class ExternalModCache
    {
        private static Dictionary<Mod, ModCacheContents> _cachedContents = new Dictionary<Mod, ModCacheContents>();

        class ModCacheContents
        {
            public Dictionary<string, int> ModItemIdList = new Dictionary<string, int>();
            public Dictionary<string, int> ModBuffIdList = new Dictionary<string, int>();
            public Dictionary<string, int> ModNPCIdList = new Dictionary<string, int>();

            public Dictionary<string, ModItem> ModItemList = new Dictionary<string, ModItem>();
            public Dictionary<string, ModBuff> ModBuffList = new Dictionary<string, ModBuff>();
            public Dictionary<string, ModNPC> ModNPCList = new Dictionary<string, ModNPC>();
        }

        /** Proxy Method **/
        public static bool findMod(string modName, out Mod output)
        {
            return (ModLoader.TryGetMod(modName, out output));
        }


        private static ModCacheContents getOrCreateModCache(Mod sourceMod)
        {
            if (_cachedContents.TryGetValue(sourceMod, out var val))
                return val;

            var result = new ModCacheContents();
            _cachedContents.Add(sourceMod, result);
            return result;
        }


        public static bool GetOrCreateModNPC(Mod sourceMod, string key, out ModNPC NPCOutput)
        {
            var cache = getOrCreateModCache(sourceMod);
            if (cache.ModNPCList.TryGetValue(key, out NPCOutput))
                return true;
            if (!sourceMod.TryFind<ModNPC>(key, out NPCOutput) || NPCOutput == null)
                return false;
            cache.ModNPCList.Add(key, NPCOutput);
            cache.ModNPCIdList.Add(key, NPCOutput.Type);
            return true;
        }

        public static bool GetOrCreateModNPCId(Mod sourceMod, string key, out int NPCOutput)
        {
            var cache = getOrCreateModCache(sourceMod);
            if (cache.ModNPCIdList.TryGetValue(key, out NPCOutput))
                return true;
            if (!sourceMod.TryFind<ModNPC>(key, out var result) || result == null)
            {
                NPCOutput = -1;
                return false;
            }

            cache.ModNPCList.Add(key, result);
            cache.ModNPCIdList.Add(key, result.Type);
            NPCOutput = result.Type;
            return true;
        }

        public static bool GetOrCreateModItem(Mod sourceMod, string key, out ModItem itemOutput)
        {
            var cache = getOrCreateModCache(sourceMod);
            if (cache.ModItemList.TryGetValue(key, out itemOutput))
                return true;
            if (!sourceMod.TryFind<ModItem>(key, out itemOutput) || itemOutput == null)
                return false;
            cache.ModItemList.Add(key, itemOutput);
            cache.ModItemIdList.Add(key, itemOutput.Type);
            return true;
        }

        public static bool GetOrCreateModItemId(Mod sourceMod, string key, out int itemOutput)
        {
            var cache = getOrCreateModCache(sourceMod);
            if (cache.ModItemIdList.TryGetValue(key, out itemOutput))
                return true;
            if (!sourceMod.TryFind<ModItem>(key, out var result) || result == null)
            {
                itemOutput = -1;
                return false;
            }

            cache.ModItemList.Add(key, result);
            cache.ModItemIdList.Add(key, result.Type);
            itemOutput = result.Type;
            return true;
        }


        public static bool GetOrCreateModBuff(Mod sourceMod, string key, out ModBuff BuffOutput)
        {
            var cache = getOrCreateModCache(sourceMod);
            if (cache.ModBuffList.TryGetValue(key, out BuffOutput))
                return true;
            if (!sourceMod.TryFind<ModBuff>(key, out BuffOutput) || BuffOutput == null)
                return false;
            cache.ModBuffList.Add(key, BuffOutput);
            cache.ModBuffIdList.Add(key, BuffOutput.Type);
            return true;
        }

        public static bool GetOrCreateModBuffId(Mod sourceMod, string key, out int BuffOutput)
        {
            var cache = getOrCreateModCache(sourceMod);
            if (cache.ModBuffIdList.TryGetValue(key, out BuffOutput))
                return true;
            if (!sourceMod.TryFind<ModBuff>(key, out var result) || result == null)
            {
                BuffOutput = -1;
                return false;
            }

            cache.ModBuffList.Add(key, result);
            cache.ModBuffIdList.Add(key, result.Type);
            BuffOutput = result.Type;
            return true;
        }
    }
}
