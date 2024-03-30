using System;
using AlchemistNPCRebornAgain.Extensions;
using Terraria;
using Terraria.ModLoader;

namespace AlchemistNPCRebornAgain.ExternalHelpers
{

    public static class AlchemistHelper
    {
        public static NPCShop AddModItemToShop(this NPCShop shop, Mod mod, string itemName, int price)
        {
            if (mod != null && ExternalModCache.GetOrCreateModItem(mod, itemName, out var output))
                shop.Add(new Item(output.Type) { shopCustomPrice = price });
                
            

            return shop;
        }

        public static NPCShop AddModItemToShop(this NPCShop shop, Mod mod, string itemName, int price, params Condition[] condition)
        {
            if (mod != null && ExternalModCache.GetOrCreateModItem(mod, itemName, out var output))
                shop.Add(new Item(output.Type) { shopCustomPrice = price }, condition);

            return shop;
        }

        public static NPCShop AddModItemToShop(this NPCShop shop, Mod mod, string itemName, int price, Func<bool> predicate)
        {
            if (mod != null && ExternalModCache.GetOrCreateModItem(mod, itemName, out var output))
                shop.Add(new Item(output.Type) { shopCustomPrice = price }, new Condition("", predicate));

            return shop;
        }

        public static NPCShop AddModItemToShop<T>(this NPCShop shop, int price) where T : ModItem
        {
            shop.Add(new Item(ModContent.ItemType<T>()) { shopCustomPrice = price });
            return shop;
        }

        public static NPCShop AddModItemToShop<T>(this NPCShop shop, int price, params Condition[] condition) where T : ModItem
        {
            shop.Add(new Item(ModContent.ItemType<T>()) { shopCustomPrice = price }, condition);
            return shop;
        }

        public static NPCShop AddModItemToShop<T>(this NPCShop shop, int price, Func<bool> predicate) where T : ModItem
        {
            shop.Add(new Item(ModContent.ItemType<T>()) { shopCustomPrice = price }, new Condition("", predicate));
            return shop;
        }

        public static void OpenShop(ref string Shop, string shop, ref bool visible)
        {
            Shop = shop;
            visible = false;
            //NPCLoader.OnChatButtonClicked(firstButton: true);
            NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
            string _ = "";
            npc.ModNPC.SetChatButtons(ref _, ref _);
            //Main.playerInventory = true;
            //Main.stackSplit = 9999;
            //Main.npcChatText = "";
            //Main.SetNPCShopIndex(1);
            //Main.instance.shop[Main.npcShop].SetupShop(Shop, npc);
        }
    }
}
