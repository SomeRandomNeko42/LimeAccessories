using LimeAccessories.Buffs;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LimeAccessories
{
	public class LimePlayerHooks : ModPlayer 
	{
		public bool SearedFlowerEquipped;
		public int OmamoriEquipped;
		public bool AirOmamoriEquipped;
		
		public bool PrisionScrollEquipped;
		public int PrisionScrollActiveness = 0;

		private bool AttemptToActivatePrisonScroll()
		{
			if (!PrisionScrollEquipped) { return false; }
			// https://www.desmos.com/calculator/ilj8wbwbie, where X is activeness and H is HP percent + 10
			float HPPercent = MathF.Round(Player.statLife / Player.statLifeMax2 * 100) + 10;
			int Roll = (int)MathF.Round(100 - MathF.Pow((HPPercent * PrisionScrollActiveness), 0.5f));
			if (Main._rand.Next(0,100) < Roll)
			{
				PrisionScrollActiveness += 240;
				if (Main.masterMode) PrisionScrollActiveness += 120;
				return true;
			}
			else
			{
				return false;
			}
		}

		public override void ResetEffects()
		{
			SearedFlowerEquipped = false;
			AirOmamoriEquipped = false;
			PrisionScrollEquipped = false;
			if (PrisionScrollActiveness > 0) PrisionScrollActiveness -= 1;
			OmamoriEquipped = 0;
			base.ResetEffects();
		}
		public override void UpdateDead()
		{
			PrisionScrollActiveness = 0;
		}
		public override void UpdateEquips()
		{
			if (AirOmamoriEquipped)	Player.wingTimeMax = (int)(Player.wingTimeMax * 1.5f);
		}
		public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (proj.DamageType == DamageClass.Magic && SearedFlowerEquipped && !proj.coldDamage)
			{
				target.AddBuff(BuffID.OnFire, 60);
				target.AddBuff(BuffID.OnFire3, 60);
			}
			if (proj.DamageType == DamageClass.Summon && AttemptToActivatePrisonScroll())
			{
				target.AddBuff(BuffID.ShadowFlame, 90);
				target.AddBuff(BuffID.Ichor, 90);
				target.AddBuff(BuffID.CursedInferno, 90);
			}
		}
		public override void OnHurt(Player.HurtInfo info)
		{
			if (AirOmamoriEquipped)
			{
				Player.wingTime += Player.wingTimeMax / 4;
			}
			if (!Player.HasBuff<SpiritRegen>() && !Player.HasBuff<SpiritGuard>() && AttemptToActivatePrisonScroll())
			{
				if (Main._rand.NextBool())
				{
					Player.AddBuff(ModContent.BuffType<SpiritRegen>(), Main._rand.Next(40, 80));
				} else
				{
					Player.AddBuff(ModContent.BuffType<SpiritGuard>(), Main._rand.Next(60, 120));
				}
			}
		}
		public override void ModifyHurt(ref Player.HurtModifiers modifiers)
		{
			if (OmamoriEquipped != 0)
			{
				modifiers.SetMaxDamage((int)(MathF.Round(Player.statLifeMax2 / 100f * OmamoriEquipped)));
			}
		}
	}
}
