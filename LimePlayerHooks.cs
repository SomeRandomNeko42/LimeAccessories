using LimeAccessories.Buffs;
using LimeAccessories.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
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

		public bool PrisonScrollEquipped;
		public int PrisonScrollActiveness = 0;

		public bool LunaticAmuletEquipped;

		public bool ForgottenEarringEquipped;
		public int ForgottenEarringGracePeriod = 0; // The game will attempt to kill you when joining the game, this stops that
		public float ForgottenEarringCharge;
		public bool LastStandStaggered;
		public bool WasLSSLastTick;

		public int CombatTimer;
		public bool UsingMeleeWeapon;

		private bool AttemptToActivatePrisonScroll()
		{
			if (!PrisonScrollEquipped) { return false; }
			// https://www.desmos.com/calculator/ilj8wbwbie, where X is activeness and H is HP percent + 10
			float HPPercent = MathF.Round(Player.statLife / Player.statLifeMax2 * 100) + 10;
			int Roll = (int)MathF.Round(100 - MathF.Pow((HPPercent * PrisonScrollActiveness), 0.5f));
			if (Main._rand.Next(0,100) < Roll)
			{
				PrisonScrollActiveness += 240;
				if (Main.masterMode) PrisonScrollActiveness += 120;
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

			PrisonScrollEquipped = false;

			LeachScarfEquipped = false;
			VampireScarfEquipped = false;
			
			LunaticAmuletEquipped = false;

			ForgottenEarringEquipped = false;
			WasLSSLastTick = LastStandStaggered;
			LastStandStaggered = false;
		}

		public override void PreUpdate()
		{
			if (PrisonScrollActiveness > 0) PrisonScrollActiveness -= 1;
			if (LeachScarfPunishment > 0) LeachScarfPunishment -= 1;
			if (VampireScarfPunishment > 0) VampireScarfPunishment -= 1;

			if (ForgottenEarringCharge > 100) ForgottenEarringCharge = 100;
			if (ForgottenEarringEquipped && ForgottenEarringCharge < 100)
			{
				ForgottenEarringCharge += 0.01f;
				if (UsingMeleeWeapon && CombatTimer > 0) ForgottenEarringCharge += 0.01f;
			}
			else if (!ForgottenEarringEquipped) ForgottenEarringCharge = 0;

			if (CombatTimer > 0) CombatTimer -= 1;
			if (ForgottenEarringEquipped) ForgottenEarringGracePeriod = 0;
		}
		public override void PostUpdate()
		{
			if (WasLSSLastTick && !LastStandStaggered && ForgottenEarringEquipped)
			{ // Staggered has ended
				Player.Heal(Player.statLifeMax2 / 2);
				Player.AddBuff(ModContent.BuffType<LastStand>(), 1200);
			}
		}
		public override void UpdateDead()
		{
			PrisonScrollActiveness = 0;
		}
		public override void UpdateEquips()
		{
			if (AirOmamoriEquipped)	Player.wingTimeMax = (int)(Player.wingTimeMax * 1.5f);
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			CombatTimer = 60;
			if ((LeachScarfEquipped || VampireScarfEquipped) && target.canGhostHeal 
				&& Player.statLife < Player.statLifeMax2 && !Player.dead)
			{
				int attemptedHeal = damageDone / 10;
				if (Player.lifeSteal < attemptedHeal)
				{
					attemptedHeal = (int)Player.lifeSteal;
				}
				Player.lifeSteal -= attemptedHeal;
				if (Main.masterMode) Player.lifeSteal -= attemptedHeal / 2;
				if (attemptedHeal > 0) Player.Heal(attemptedHeal);
			}
			// Punish not using summon weapons with prison scroll
			if (PrisonScrollEquipped && 
				!(hit.DamageType == DamageClass.Summon || hit.DamageType == DamageClass.SummonMeleeSpeed || hit.DamageType == DamageClass.MagicSummonHybrid))
			{
				PrisonScrollActiveness += 10;
			}
			// Check if we're using melee
			if (hit.DamageType == DamageClass.Melee)
				UsingMeleeWeapon = true;
			else
				UsingMeleeWeapon = false;
		}
		public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
		{
			CombatTimer = 60;
			// Ranged
			if (LunaticAmuletEquipped && proj.type != ModContent.ProjectileType<MadnessBullet>() // Dont let it trigger itself
				&& hit.Crit && Player.ownedProjectileCounts[ModContent.ProjectileType<MadnessBullet>()] < 16
				&& Main._rand.NextBool() && !Player.dead)
			{
				for (int i = 0; i < 8; i++)
				{
					Vector2 direction = new Vector2(0, 30).RotatedBy(2 * MathF.PI / 8 * i, Vector2.Zero);
					Projectile.NewProjectileDirect(Player.GetSource_FromThis(), Player.position + direction, direction / 4,
						ModContent.ProjectileType<MadnessBullet>(), 250, Player.GetKnockback(DamageClass.Ranged).Base);
				}
			}
			// Magic
			if (proj.DamageType == DamageClass.Magic && (HellsSunEquipped || (SearedFlowerEquipped && !proj.coldDamage)))
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
				healValue /= 8;
			}
			if (VampireScarfEquipped || VampireScarfPunishment > 0)
			{
				healValue /= 4;
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
		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genDust, ref PlayerDeathReason damageSource)
		{
			if ((WasLSSLastTick || LastStandStaggered) && (ForgottenEarringGracePeriod < 5 || ForgottenEarringEquipped))
			{
				playSound = false;
				genDust = false;
				Player.statLife = 5;
				return false;
			}
			if (ForgottenEarringCharge >= 100 && ForgottenEarringEquipped)
			{
				ForgottenEarringCharge = 0;
				Player.AddBuff(ModContent.BuffType<Staggered>(), 120);
				Player.statLife = 5;
				return false;
			} else
			{
				return true;
			}
		}
	}
}
