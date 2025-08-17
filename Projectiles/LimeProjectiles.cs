using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace LimeAccessories.Projectiles
{
	public class MadnessBullet : ModProjectile
	{
		private NPC HomingTarget
		{
			get => Projectile.ai[1] == 0 ? null : Main.npc[(int)Projectile.ai[1] - 1];
			set
			{
				Projectile.ai[1] = value == null ? 0 : value.whoAmI + 1;
			}
		}
		private readonly float homingDistance = 800;
		public override void SetDefaults()
		{
			Projectile.width = 8;
			Projectile.height = 8;
			
			Projectile.ignoreWater = true;
			Projectile.friendly = true;
			Projectile.light = 0.5f;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 600;
		}

		public override void AI()
		{
			// Timer
			Projectile.ai[0] += 1f;
			// Lighting
			Lighting.AddLight(Projectile.Center, 0.4f, 0f, 0f);
			// Velocity cap
			float maxVelocity = MathF.Min(Projectile.ai[0]/7.5f, 30);
			if (maxVelocity < 0) maxVelocity = 0;

			// Target isnt valid, drop it
			if (HomingTarget != null && !IsValidTarget(HomingTarget))
				HomingTarget = null;
			// Target
			if (HomingTarget == null)
			{
				float SqrMaxDist = homingDistance * homingDistance;
				foreach (NPC target in Main.ActiveNPCs)
				{
					if (IsValidTarget(target))
					{
						float sqrToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);
						if (sqrToTarget < SqrMaxDist)
						{
							SqrMaxDist = sqrToTarget;
							HomingTarget = target;
						}
					}
				}
			}
			// Home in
			if (HomingTarget != null)
			{
				float targetAngle = Projectile.AngleTo(HomingTarget.Center);
				Projectile.velocity = Projectile.velocity.ToRotation().AngleTowards(targetAngle, MathHelper.ToRadians(3)).ToRotationVector2() * maxVelocity;
			}
			// Rotation
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
		}
		public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < 5; i++) // Creates a splash of dust around the position the projectile dies.
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 
					DustID.Clentaminator_Red, Projectile.velocity.X / 4 * 3, Projectile.velocity.Y / 4 * 3);
				dust.noGravity = true;
				dust.scale *= 0.9f;
			}
		}
		public bool IsValidTarget(NPC target) => 
			target.CanBeChasedBy() && Collision.CanHit(Projectile.Center, 1, 1, target.position, target.width, target.height);
	}
}
