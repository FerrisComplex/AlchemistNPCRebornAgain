using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using AlchemistNPCRebornAgain.Extensions;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using AlchemistNPCRebornAgain.Interface;
using AlchemistNPCRebornAgain.Items;

namespace AlchemistNPCRebornAgain
{
	public class AlchemistNPCRebornAgain : Mod
	{
		public AlchemistNPCRebornAgain() {}

        public static Mod Instance;
        internal static AlchemistNPCRebornAgain instance;
        internal static ModConfiguration modConfiguration;
        public static ModKeybind LampLight;
        public static ModKeybind DiscordBuff;
        public static bool SF = false;
        public static bool GreaterDangersense = false;
        public static bool BastScroll = false;
        public static bool Stormbreaker = false;
        public static int DTH = 0;
        public static float ppx = 0f;
        public static float ppy = 0f;
        public static string GithubUserName { get { return "FerrisComplex"; } }
        public static string GithubProjectName { get { return "AlchemistNPCRebornAgain"; } }
        private UserInterface alchemistUserInterface;
        internal ShopChangeUI alchemistUI;
        private UserInterface alchemistUserInterfaceA;
        internal ShopChangeUIA alchemistUIA;
        private UserInterface alchemistUserInterfaceO;
        internal ShopChangeUIO alchemistUIO;
        private UserInterface alchemistUserInterfaceM;
        internal ShopChangeUIM alchemistUIM;
        private UserInterface alchemistUserInterfaceH;
        internal HealingUI alchemistUIH;
        private UserInterface alchemistUserInterfaceDC;
        internal DimensionalCasketUI alchemistUIDC;

        public static ModItem InvalidItemInstance;
        public static ModPrefix InvalidPrefixInstance;
        public static int ReversivityCoinTier1ID;
        public static int ReversivityCoinTier2ID;
        public static int ReversivityCoinTier3ID;
        public static int ReversivityCoinTier4ID;
        public static int ReversivityCoinTier5ID;
        public static int ReversivityCoinTier6ID;

        public override void Load()
        {
            Instance = this;

            
            DiscordBuff = KeybindLoader.RegisterKeybind(this, "DiscordBuffTeleportation", "Q");
            LampLight = KeybindLoader.RegisterKeybind(this, "LampLightToggle", "L");

            instance = this;

            SetTranslation(); 

            if (!Main.dedServ)
            {
                alchemistUI = new ShopChangeUI();
                alchemistUI.Activate();
                alchemistUserInterface = new UserInterface();
                alchemistUserInterface.SetState(alchemistUI);

                alchemistUIA = new ShopChangeUIA();
                alchemistUIA.Activate();
                alchemistUserInterfaceA = new UserInterface();
                alchemistUserInterfaceA.SetState(alchemistUIA);

                alchemistUIO = new ShopChangeUIO();
                alchemistUIO.Activate();
                alchemistUserInterfaceO = new UserInterface();
                alchemistUserInterfaceO.SetState(alchemistUIO);

                alchemistUIM = new ShopChangeUIM();
                alchemistUIM.Activate();
                alchemistUserInterfaceM = new UserInterface();
                alchemistUserInterfaceM.SetState(alchemistUIM);

            }
            if (!Main.dedServ)
            {
                EquipLoader.AddEquipTexture(this, "AlchemistNPCRebornAgain/Items/Armor/somebody0214Robe_Legs", EquipType.Legs, name: "somebody0214Robe_Legs");
            }

            
            ReversivityCoinTier1ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier1Data(this, ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), 999L));
            ReversivityCoinTier2ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier2Data(this, ModContent.ItemType<Items.Misc.ReversivityCoinTier2>(), 999L));
            ReversivityCoinTier3ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier3Data(this, ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), 999L));
            ReversivityCoinTier4ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier4Data(this, ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), 999L));
            ReversivityCoinTier5ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier5Data(this, ModContent.ItemType<Items.Misc.ReversivityCoinTier5>(), 999L));
            ReversivityCoinTier6ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier6Data(this, ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), 999L));
        }

		public override void PostSetupContent()
		{
            InvalidItemInstance = this.FindItem("InvalidItem");
            InvalidPrefixInstance = this.FindPrefix("InvalidPrefix");
            
            ModLoader.TryGetMod("Census", out Mod censusMod);
			if(censusMod != null)
			{
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Alchemist>(), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Brewer>(), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Jeweler>(), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Tinkerer>(), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Architect>(), "Have any 3 other NPC present");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Operator>(), "Defeat Eater of Worlds/Brain of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Musician>(), "Defeat Skeletron");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.YoungBrewer>(), "World state is Hardmode and both Alchemist and Operator are alive");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.OtherworldlyPortal>(), "Not exactly a Town NPC, one of the steps for saving the Explorer");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.Explorer>(), "Defeat Moon Lord and find the way to use all 9 Torn Notes for saving her");
			}
		}

        public override void Unload()
        {
            Instance = null;
            instance = null;
            LampLight = null;
            DiscordBuff = null;
            modConfiguration = null;
        }

        public override void AddRecipeGroups()/* tModPorter Note: Removed. Use ModSystem.AddRecipeGroups */
        {

            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + this.GetLocalizationKey("Misc.evilBossMask"), new int[]
         {
                 ItemID.EaterMask, ItemID.BrainMask
         });
            RecipeGroup.RegisterGroup("AlchemistNPCRebornAgain:EvilMask", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + this.GetLocalizationKey("Misc.cultist"), new int[]
         {
                 ItemID.BossMaskCultist, ItemID.WhiteLunaticHood, ItemID.BlueLunaticHood
         });
            RecipeGroup.RegisterGroup("AlchemistNPCRebornAgain:CultistMask", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + this.GetLocalizationKey("Misc.tier3HardmodeBar"), new int[]
         {
                 ItemID.AdamantiteBar, ItemID.TitaniumBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPCRebornAgain:Tier3Bar", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + this.GetLocalizationKey("Misc.hardmodeComponent"), new int[]
         {
                 ItemID.CursedFlame, ItemID.Ichor
         });
            RecipeGroup.RegisterGroup("AlchemistNPCRebornAgain:HardmodeComponent", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + this.GetLocalizationKey("Misc.evilBar"), new int[]
         {
                 ItemID.DemoniteBar, ItemID.CrimtaneBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPCRebornAgain:EvilBar", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + this.GetLocalizationKey("Misc.evilMushroom"), new int[]
             {
                 ItemID.VileMushroom, ItemID.ViciousMushroom
             });
            RecipeGroup.RegisterGroup("AlchemistNPCRebornAgain:EvilMush", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + this.GetLocalizationKey("Misc.evilComponent"), new int[]
             {
                 ItemID.ShadowScale, ItemID.TissueSample
             });
            RecipeGroup.RegisterGroup("AlchemistNPCRebornAgain:EvilComponent", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + this.GetLocalizationKey("Misc.evilDrop"), new int[]
             {
                 ItemID.RottenChunk, ItemID.Vertebrae
             });
            RecipeGroup.RegisterGroup("AlchemistNPCRebornAgain:EvilDrop", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + this.GetLocalizationKey("Misc.tier2anvil"), new int[]
             {
                 ItemID.MythrilAnvil, ItemID.OrichalcumAnvil
             });
            RecipeGroup.RegisterGroup("AlchemistNPCRebornAgain:AnyAnvil", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + this.GetLocalizationKey("Misc.tier2forge"), new int[]
             {
                 ItemID.AdamantiteForge, ItemID.TitaniumForge
             });
            RecipeGroup.RegisterGroup("AlchemistNPCRebornAgain:AnyForge", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + this.GetLocalizationKey("Misc.tier1anvil"), new int[]
             {
                 ItemID.IronAnvil, ItemID.LeadAnvil
             });
            RecipeGroup.RegisterGroup("AlchemistNPCRebornAgain:AnyPreHMAnvil", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + this.GetLocalizationKey("Misc.CelestialWings"), new int[]
             {
                 ItemID.WingsSolar, ItemID.WingsNebula, ItemID.WingsStardust, ItemID.WingsVortex
             });
            RecipeGroup.RegisterGroup("AlchemistNPCRebornAgain:AnyCelestialWings", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + this.GetLocalizationKey("Misc.LunarHamaxe"), new int[]
             {
                 ItemID.LunarHamaxeSolar, ItemID.LunarHamaxeNebula, ItemID.LunarHamaxeStardust, ItemID.LunarHamaxeVortex
             });
            RecipeGroup.RegisterGroup("AlchemistNPCRebornAgain:AnyLunarHamaxe", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + this.GetLocalizationKey("Misc.tier3Watch"), new int[]
             {
                 ItemID.GoldWatch, ItemID.PlatinumWatch
             });
            RecipeGroup.RegisterGroup("AlchemistNPCRebornAgain:AnyWatch", group);

        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            AlchemistNPCRebornMessageType msgType = (AlchemistNPCRebornMessageType)reader.ReadByte();
            switch (msgType)
            {
                case AlchemistNPCRebornMessageType.TeleportPlayer:
                    TeleportClass.HandleTeleport(reader.ReadInt32(), true, whoAmI);
                    break;
                default:
                    Logger.Error("AlchemistNPCRebornAgain: Unknown Message type: " + msgType);
                    break;
            }
        }

        public enum AlchemistNPCRebornMessageType : byte
        {
            TeleportPlayer
        }

        public override void AddRecipes()/* tModPorter Note: Removed. Use ModSystem.AddRecipes */
        {
            Recipe.Create(ItemID.Sundial)
                .AddIngredient(ItemID.CelestialStone)
                .AddIngredient(ItemID.GoldBar, 10)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.Obsidian, 5)
                .AddIngredient(ItemID.StoneBlock, 10)
                .AddCondition(Condition.NearWater)
                .AddCondition(Condition.NearLava)
                .Register();

            Recipe.Create(ItemID.HoneyBlock, 5)
                .AddIngredient(ItemID.BottledHoney, 10)
                .AddCondition(Condition.NearWater)
                .AddCondition(Condition.NearHoney)
                .Register();

            Recipe.Create(ItemID.CrispyHoneyBlock, 5)
                .AddIngredient(ItemID.BottledHoney, 10)
                .AddCondition(Condition.NearLava)
                .AddCondition(Condition.NearHoney)
                .Register();

            Recipe.Create(ItemID.Stopwatch)
                .AddRecipeGroup("AlchemistNPCRebornAgain:AnyWatch")
                .AddIngredient(ItemID.HermesBoots)
                .AddIngredient(ItemID.Wire, 15)
                .AddIngredient(ItemID.Wood, 5)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.DPSMeter)
                .AddRecipeGroup("AlchemistNPCRebornAgain:EvilBar", 10)
                .AddRecipeGroup("AlchemistNPCRebornAgain:AnyWatch")
                .AddIngredient(ItemID.Wire, 25)
                .AddIngredient(ItemID.Chain)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.LifeformAnalyzer)
                .AddIngredient(ItemID.TallyCounter)
                .AddIngredient(ItemID.BlackLens)
                .AddIngredient(ItemID.AntlionMandible)
                .AddRecipeGroup("AlchemistNPCRebornAgain:EvilDrop")
                .AddRecipeGroup("AlchemistNPCRebornAgain:EvilComponent")
                .AddIngredient(ItemID.Feather)
                .AddIngredient(ItemID.TatteredCloth)
                .AddIngredient(ItemID.Bone)
                .AddIngredient(ItemID.Wire, 25)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.PurificationPowder, 5)
                .AddIngredient(ItemID.Mushroom)
                .AddIngredient(ItemID.Daybloom)
                .AddTile(TileID.Bottles)
                .Register();

            Recipe.Create(ItemID.HallowedSeeds)
                .AddIngredient(ItemID.CorruptSeeds)
                .AddIngredient(ItemID.PurificationPowder)
                .AddIngredient(ItemID.PixieDust)
                .AddTile(TileID.Bottles)
                .Register();

            Recipe.Create(ItemID.HallowedSeeds)
                .AddIngredient(ItemID.CrimsonSeeds)
                .AddIngredient(ItemID.PurificationPowder)
                .AddIngredient(ItemID.PixieDust)
                .AddTile(TileID.Bottles)
                .Register();
        }

        //SBMW:Transtation method
        public void SetTranslation()
        {


            Language.GetOrRegister(this.GetLocalizationKey("Misc.evilBossMask"), () => "Corruption/Crimson boss mask");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.cultist"), () => "Cultist mask/hood");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.tier3HardmodeBar"), () => "Tier 3 Hardmode Bar");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.hardmodeComponent"), () => "Hardmode component");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.evilBar"), () => "Crimson/Corruption bar");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.evilMushroom"), () => "evil mushroom");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.evilComponent"), () => "evil component");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.evilDrop"), () => "evil drop");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.tier2anvil"), () => "tier 2 anvil");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.tier2forge"), () => "tier 2 forge");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.tier1anvil"), () => "tier 1 anvil");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.CelestialWings"), () => "Celestial Wings");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.LunarHamaxe"), () => "Lunar Hamaxe");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.tier3Watch"), () => "tier 3 Watch");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.KingSlime"), () => "King Slime Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.EyeofCthulhu"), () => "Eye of Cthulhu Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.EaterOfWorlds"), () => "Eater Of Worlds Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.BrainOfCthulhu"), () => "Brain Of Cthulhu Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.QueenBee"), () => "Queen Bee Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Skeletron"), () => "Skeletron Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Deerclops"), () => "Deerclops Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.WallOfFlesh"), () => "Wall Of Flesh Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.QueenSlime"), () => "Queen Slime Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Destroyer"), () => "Destroyer Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Twins"), () => "Twins Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.SkeletronPrime"), () => "Skeletron Prime Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Plantera"), () => "Plantera Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.EmpressOfLight"), () => "Empress of Light Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Golem"), () => "Golem Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Betsy"), () => "Betsy Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.DukeFishron"), () => "Duke Fishron Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.MoonLord"), () => "Moon Lord Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.DesertScourge"), () => "Desert Scourge Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Crabulon"), () => "Crabulon Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.HiveMind"), () => "The Hive Mind Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Perforator"), () => "The Perforators Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.SlimeGod"), () => "The Slime God Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Cryogen"), () => "Cryogen Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.BrimstoneElemental"), () => "Brimstone Elemental Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.AquaticScourge"), () => "Aquatic Scourge Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Calamitas"), () => "Calamitas Doppelganger Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.AstrageldonSlime"), () => "Astrum Aureus Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.AstrumDeus"), () => "Astrum Deus Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Leviathan"), () => "The Leviathan Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.PlaguebringerGoliath"), () => "The Plaguebringer Goliath Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Ravager"), () => "Ravager Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Providence"), () => "Providence, the Profaned Goddess Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.StormWeaver"), () => "Storm Weaver Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.CeaselessVoid"), () => "Ceaseless Void Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Signus"), () => "Signus, Envoy of the Devourer Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Polterghast"), () => "Polterghast Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.OldDuke"), () => "The Old Duke Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.DevourerofGods"), () => "The Devourer of Gods Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Bumblebirb"), () => "The Dragonfolly Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Yharon"), () => "Jungle Dragon, Yharon Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.ExoMechs"), () => "Exo Mechs Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.SupremeCalamitas"), () => "Supreme Calamitas Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.DarkMage"), () => "Dark Mage Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.Ogre"), () => "Ogre Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.ThunderBird"), () => "The Great Thunder Bird Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.QueenJellyfish"), () => "The Queen Jellyfish Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.CountEcho"), () => "Count Echo Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.GraniteEnergyStorm"), () => "Granite Energy Storm Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.TheBuriedChampion"), () => "The Buried Champion Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.TheStarScouter"), () => "The Star Scouter Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.BoreanStrider"), () => "Borean Strider Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.CoznixTheFallenBeholder"), () => "Coznix, The Fallen Beholder Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.TheLich"), () => "The Lich Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.AbyssionTheForgottenOne"), () => "Abyssion, The Forgotten One Treasure Bag");
            Language.GetOrRegister(this.GetLocalizationKey("Misc.TheRagnarok"), () => "The Ragnarok Treasure Bag");
            
            
            /*

            //Redemption
            text = LocalizationLoader.CreateTranslation(this, "KingChicken");
            text.SetDefault("The Mighty King Chicken Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ThornBane");
            text.SetDefault("Thorn, Bane of the Forest Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "TheKeeper");
            text.SetDefault("The Keeper Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "XenoCrystal");
            text.SetDefault("Xenomite Crystal Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "IEye");
            text.SetDefault("Infected Eye Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "KingSlayer");
            text.SetDefault("King Slayer III Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "V1");
            text.SetDefault("Vlitch Cleaver Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "V2");
            text.SetDefault("Vlitch Gigipede Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "V3");
            text.SetDefault("Omega Obliterator Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "PZ");
            text.SetDefault("Patient Zero Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ThornRematch");
            text.SetDefault("Thorn, Bane of the Forest Rematch Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Nebuleus");
            text.SetDefault("Nebuleus, Angel of the Cosmos Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //ElementsAwoken
            text = LocalizationLoader.CreateTranslation(this, "Wasteland");
            text.SetDefault("Wasteland Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Infernace");
            text.SetDefault("Infernace Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ScourgeFighter");
            text.SetDefault("Scourge Fighter Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Regaroth");
            text.SetDefault("Regaroth Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "TheCelestials");
            text.SetDefault("The Celestials Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Permafrost");
            text.SetDefault("Permafrost Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Obsidious");
            text.SetDefault("Obsidious Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Aqueous");
            text.SetDefault("Aqueous Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "TempleKeepers");
            text.SetDefault("The Temple Keepers Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Guardian");
            text.SetDefault("The Guardian Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Volcanox");
            text.SetDefault("Volcanox Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "VoidLevi");
            text.SetDefault("Void Leviathan Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Azana");
            text.SetDefault("Azana Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Ancients");
            text.SetDefault("The Ancients Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //SacredTools
            text = LocalizationLoader.CreateTranslation(this, "Decree");
            text.SetDefault("The Decree Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Декри");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "焚炎南瓜宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "FlamingPumpkin");
            text.SetDefault("The Flaming Pumpkin Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Горящей Тыквы");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Jensen");
            text.SetDefault("Jensen, the Grand Harpy Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Дженсен, Великой Гарпии");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "巨型鸟妖詹森宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Araneas");
            text.SetDefault("Araneas Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Аранеи");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Raynare");
            text.SetDefault("Harpy Queen, Raynare Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Рейнейр, Королевы Гарпий");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "鸟妖女王雷纳宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Primordia");
            text.SetDefault("Primordia Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Примордии");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Abaddon");
            text.SetDefault("Abaddon, the Emissary of Nightmares Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Абаддона, Эмиссара Кошмаров");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "梦魇使者亚巴顿宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Araghur");
            text.SetDefault("Araghur, the Flare Serpent Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Арагура, Огненного Змия");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "熔火巨蟒宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Lunarians");
            text.SetDefault("The Lunarians Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Лунарианов");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "月军宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Challenger");
            text.SetDefault("Erazor Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Ирэйзора");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "堕落帝者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Challenger");
            text.SetDefault("Erazor Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Ирэйзора");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "堕落帝者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Spookboi");
            text.SetDefault("Nihilus Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Нигилюса");
            LocalizationLoader.AddTranslation(text);
            

            Language.GetOrRegister(this.GetLocalizationKey("NPCS.OtherworldlyPotal.barrierStabilized"), () => "The Barrier between world is stabilized.");
            Language.GetOrRegister(this.GetLocalizationKey("NPCS.OtherworldlyPotal.name"), () => "Otherworldly Portal");
            Language.GetOrRegister(this.GetLocalizationKey("NPCS.OtherworldlyPotal.open"), () => "I am alive...? I cannot believe this! Thank you!");
            Language.GetOrRegister(this.GetLocalizationKey("NPCS.OtherworldlyPotal.portal"), () => "An Otherworldly Portal was opened.");

            //SpiritMod
            text = LocalizationLoader.CreateTranslation(this, "Scarabeus");
            text.SetDefault("Scarabeus Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Bane");
            text.SetDefault("Vinewrath Bane Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Flier");
            text.SetDefault("Ancient Flier Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Raider");
            text.SetDefault("Starplate Raider Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Infernon");
            text.SetDefault("Infernon Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Dusking");
            text.SetDefault("Dusking Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "EtherialUmbra");
            text.SetDefault("Etherial Umbra Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "IlluminantMaster");
            text.SetDefault("Illuminant Master Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Atlas");
            text.SetDefault("Atlas Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Overseer");
            text.SetDefault("Overseer Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //SpiritMod
            text = LocalizationLoader.CreateTranslation(this, "Sharkron");
            text.SetDefault("Dune Sharkron Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Hypothema");
            text.SetDefault("Hypothema Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Ragnar");
            text.SetDefault("Ragnar Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "AnDio");
            text.SetDefault("Andesia & Dioritus Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Annihilator");
            text.SetDefault("The Annihilator Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Slybertron");
            text.SetDefault("Slybertron Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "SteamTrain");
            text.SetDefault("Steam Train Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //Pinky
            text = LocalizationLoader.CreateTranslation(this, "SunlightTrader");
            text.SetDefault("Sunlight Trader Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "THOFC");
            text.SetDefault("The Heart of the Cavern Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "MythrilSlime");
            text.SetDefault("Mythril Slime Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Valdaris");
            text.SetDefault("Valdaris Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Gatekeeper");
            text.SetDefault("The Gatekeeper Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //AAMod
            text = LocalizationLoader.CreateTranslation(this, "Monarch");
            text.SetDefault("Mushroom Monarch Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Grips");
            text.SetDefault("Grips of Chaos Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Broodmother");
            text.SetDefault("Broodmother Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Hydra");
            text.SetDefault("Hydra Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Serpent");
            text.SetDefault("Subzero Serpent Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Djinn");
            text.SetDefault("Desert Djinn Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Retriever");
            text.SetDefault("Retriever Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "RaiderU");
            text.SetDefault("Raider Ultima Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Orthrus");
            text.SetDefault("Orthrus X Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "EFish");
            text.SetDefault("Emperor Fishron Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Nightcrawler");
            text.SetDefault("Nightcrawler Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Daybringer");
            text.SetDefault("Daybringer Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Yamata");
            text.SetDefault("Yamata Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Akuma");
            text.SetDefault("Akuma Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Zero");
            text.SetDefault("Zero Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Shen");
            text.SetDefault("Shen Doragon Treasure Cache");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ShenGrips");
            text.SetDefault("Shen Doragon Grips Treasure Bag");
            LocalizationLoader.AddTranslation(text);
            */

        }

	}
}
