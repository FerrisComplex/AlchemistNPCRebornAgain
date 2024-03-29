using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.References
{
	public class CodexUmbra : ModItem
	{

		public override void SetDefaults()
		{
			Item.DefaultToStaff(ModContent.ProjectileType<Projectiles.DarkShot>(), 7, 20, 11);
			Item.width = 23;
			Item.height = 16;
			Item.maxStack = 1;
			Item.rare = 3;
			Item.UseSound = SoundID.Item21;

			Item.SetWeaponValues(35, 6, 32);
		}	
	}
}
