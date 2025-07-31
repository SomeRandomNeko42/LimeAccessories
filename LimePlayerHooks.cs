using LimeAccessories.Buffs;
using LimeAccessories.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LimeAccessories
{
	public class LimePlayerHooks : ModPlayer 
	{
		public bool SearedFlowerEquipped;
		public bool HellsSunEquipped;

		public int OmamoriEquipped;
		public bool AirOmamoriEquipped;

		public bool LeachScarfEquipped;
		public bool VampireScarfEquipped;
		public int LeachScarfPunishment;
		public int VampireScarfPunishment;

		public bool PrisionScrollEquipped;
		public int PrisionScrollActiveness = 0;

		public bool LunaticAmuletEquipped;

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
			HellsSunEquipped = false;

			OmamoriEquipped = 0;
			AirOmamoriEquipped = false;

			PrisionScrollEquipped = false;

			LeachScarfEquipped = false;
			VampireScarfEquipped = false;
			
			LunaticAmuletEquipped = false;
		}

		public override void PreUpdate()
		{
			if (PrisionScrollActiveness > 0) PrisionScrollActiveness -= 1;
			if (LeachScarfPunishment > 0) LeachScarfPunishment -= 1;
			if (VampireScarfPunishment > 0) VampireScarfPunishment -= 1;
		}
		public override void UpdateDead()
		{
			PrisionScrollActiveness = 0;
		}
		public override void UpdateEquips()
		{
			if (AirOmamoriEquipped)	Player.wingTimeMax = (int)(Player.wingTimeMax * 1.5f);
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if ((LeachScarfEquipped || VampireScarfEquipped) && target.canGhostHeal 
				&& Player.statLife < Player.statLifeMax2 && !Player.dead)
			{
				int attemptedHeal = damageDone / 10;
				if (Player.lifeSteal < attemptedHeal)
				{
					attemptedHeal = (int)Player.lifeSteal;
				}
				Player.lifeSteal -= attemptedHeal;
				if (attemptedHeal > 0) Player.Heal(attemptedHeal);
			}
		}
		public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
		{
			// Ranged
			if (LunaticAmuletEquipped && proj.type != ModContent.ProjectileType<MadnessBullet>() // Dont let it trigger itself
				&& hit.Crit && Player.ownedProjectileCounts[ModContent.ProjectileType<MadnessBullet>()] < 16
				&& Main._rand.NextBool() && !Player.dead)
			{
				for (int i = 0; i < 8; i++)
				{
					Vector2 direction = new Vector2(0, 20).RotatedBy(2 * MathF.PI / 8 * i, Vector2.Zero);
					Projectile.NewProjectileDirect(Player.GetSource_FromThis(), Player.position + direction, direction / 4,
						ModContent.ProjectileType<MadnessBullet>(), 50, Player.GetKnockback(DamageClass.Ranged).Base);
				}
			}
			// Magic
			if (proj.DamageType == DamageClass.Magic && HellsSunEquipped || (SearedFlowerEquipped && !proj.coldDamage))
			{
				target.AddBuff(BuffID.OnFire, 60);
				target.AddBuff(BuffID.OnFire3, 60);
				if (HellsSunEquipped)
				{
					target.AddBuff(BuffID.CursedInferno, 90);
				}
			}
			// Summon
			if (proj.DamageType == DamageClass.Summon && AttemptToActivatePrisonScroll())
			{
				switch (Main._rand.Next(4))
				{
					case 0:
						target.AddBuff(BuffID.ShadowFlame, Main._rand.Next(80, 100));
						break;
					case 1:
						target.AddBuff(BuffID.Ichor, Main._rand.Next(80, 100));
						break;
					case 2:
						target.AddBuff(BuffID.CursedInferno, Main._rand.Next(80,100));
						break;
					case 3:
						Main.LocalPlayer.AddBuff(ModContent.BuffType<SpiritStrike>(), Main._rand.Next(100, 150));
						break;
				}
			}
		}
		public override void GetHealLife(Item item, bool quickHeal, ref int healValue)
		{
			if (LeachScarfEquipped || LeachScarfPunishment > 0)
			{
				healValue /= 4;
			}
			if (VampireScarfEquipped || VampireScarfPunishment > 0)
			{
				healValue /= 2;
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
				switch (Main._rand.Next(2))
				{
					case 0:
						Player.AddBuff(ModContent.BuffType<SpiritRegen>(), Main._rand.Next(40, 80));
						break;
					case 1:
						Player.AddBuff(ModContent.BuffType<SpiritGuard>(), Main._rand.Next(120, 240));
						break;
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
