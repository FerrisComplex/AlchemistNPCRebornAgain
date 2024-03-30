using System.Linq;
using AlchemistNPCRebornAgain.Extensions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.Utilities;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class LightOfCeraSumat : ModItem
	{

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Muramasa);
			Item.damage = 110;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(platinum: 1);
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override bool CanUseItem(Player player)
		{
			ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
			if (Calamity != null)
			{
				if ((bool)Calamity.Call("Downed", "profaned guardians"))
				{
					Item.damage = 120;
				}
				if ((bool)Calamity.Call("Downed", "providence"))
				{
					Item.damage = 150;
				}
				if ((bool)Calamity.Call("Downed", "polterghast"))
				{
					Item.damage = 222;
				}
				if ((bool)Calamity.Call("Downed", "dog"))
				{
					Item.damage = 300;
				}
				if ((bool)Calamity.Call("Downed", "yharon"))
				{
					Item.damage = 400;
				}
				if ((bool)Calamity.Call("Downed", "supreme calamitas"))
				{
					Item.damage = 500;
				}
			}
			return true;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, Mod.Find<ModDust>("JustitiaPale").Type);
			}
		}

		public override void OnHitNPC(Terraria.Player player, NPC target, NPC.HitInfo hit, int damage)
		{
			target.buffImmune[Mod.Find<ModBuff>("CurseOfLight").Type] = false;
			target.AddBuff(Mod.Find<ModBuff>("CurseOfLight").Type, 300);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X, target.position.Y, 0, 0, Mod.Find<ModProjectile>("ExplosionAvenger").Type, damage, 0, Main.myPlayer);
		}
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 81;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.FindItem("HolyAvenger").Type);
			//recipe.AddIngredient(Mod.FindItem("Pommel").Type);
			recipe.AddTile(Mod.Find<ModTile>("MateriaTransmutator").Type);
			recipe.Register();
		}
	}
}
