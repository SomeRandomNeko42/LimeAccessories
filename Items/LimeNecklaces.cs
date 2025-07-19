using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace LimeAccessories.Items
{
	[AutoloadEquip(EquipType.Neck)]
	public class HypnotistsPendant : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(24, 34);
			Item.expert = true;
			Item.value = Item.sellPrice(0, 5, 0, 0);
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ItemID.Magiluminescence);
			recipe.AddIngredient(ItemID.BrainOfConfusion);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			Lighting.AddLight(player.Center, 1, 0, 1);
			player.hasMagiluminescence = true;
			player.GetDamage(DamageClass.Generic) += 0.1f;
			player.brainOfConfusionItem = Item;
			player.buffImmune[BuffID.Confused] = true;
			player.buffImmune[BuffID.Cursed] = true;
			player.buffImmune[BuffID.Silenced] = true;
		}
		public override void Update(ref float gravity, ref float maxFallSpeed)
		{
			Lighting.AddLight(Item.Center, 1, 0, 1);
			base.Update(ref gravity, ref maxFallSpeed);
		}
	}
	public class AncientOmamori : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(32, 32);
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(0, 10, 0, 0);
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<LimePlayerHooks>().OmamoriEquipped = 90;
		}
		public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
		{
			if (//incomingItem.type == ModContent.ItemType<AncientOmamori>()
				incomingItem.type == ModContent.ItemType<EarthOmamori>()
				|| incomingItem.type == ModContent.ItemType<WaterOmamori>()
				|| incomingItem.type == ModContent.ItemType<FlameOmamori>()
				|| incomingItem.type == ModContent.ItemType<AirOmamori>()
				)
			{
				return false;
			}
			return true;
		}
		public override void AddRecipes()
		{
			Recipe ToLavaCharm = Recipe.Create(ItemID.LavaCharm, 1);
			ToLavaCharm.AddIngredient<AncientOmamori>();
			ToLavaCharm.AddIngredient(ItemID.HellstoneBar, 10);
			ToLavaCharm.AddIngredient(ItemID.Bone, 20);
			ToLavaCharm.AddTile(TileID.Hellforge);
			ToLavaCharm.Register();
		}
	}
	public class FlameOmamori : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(32, 32);
			Item.value = Item.sellPrice(0, 20, 0, 0);
			Item.rare = ItemRarityID.Yellow;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient<AncientOmamori>();
			recipe.AddIngredient(ItemID.ObsidianRose);
			recipe.AddIngredient(ItemID.LavaCharm);
			recipe.AddIngredient(ItemID.CursedFlame, 10);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddTile(TileID.Hellforge);
			recipe.Register();
			Recipe recipeAlt = CreateRecipe(1);
			recipeAlt.AddIngredient<AncientOmamori>();
			recipeAlt.AddIngredient(ItemID.MoltenSkullRose);
			recipeAlt.AddIngredient(ItemID.CursedFlame, 10);
			recipeAlt.AddIngredient(ItemID.SoulofFright, 10);
			recipeAlt.AddTile(TileID.Hellforge);
			recipeAlt.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			// Increasing damage
			float HPPercent = player.statLife / 100 * player.statLifeMax2;
			float Modifier = 50 - (HPPercent / 100) - (MathF.Pow(HPPercent, 0.75f) * 2);
			if (Modifier > 0) player.GetDamage(DamageClass.Generic) += Modifier / 100;
			// Other stuff
			player.fireWalk = true;
			player.lavaMax += 420;
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.OnFire3] = true;
			// player.GetModPlayer<LimePlayerHooks>().OmamoriEquipped = 90;
		}
		public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
		{
			if (incomingItem.type == ModContent.ItemType<AncientOmamori>()
				|| incomingItem.type == ModContent.ItemType<EarthOmamori>()
				|| incomingItem.type == ModContent.ItemType<WaterOmamori>()
				//|| incomingItem.type == ModContent.ItemType<FlameOmamori>()
				|| incomingItem.type == ModContent.ItemType<AirOmamori>()
				)
			{
				return false;
			}
			return true;
		}
	}
	public class EarthOmamori : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(32, 32);
			Item.value = Item.sellPrice(0, 20, 0, 0);
			Item.rare = ItemRarityID.Yellow;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient<AncientOmamori>();
			recipe.AddIngredient(ItemID.CobaltShield);
			recipe.AddIngredient(ItemID.Ectoplasm, 10);
			recipe.AddIngredient(ItemID.SoulofMight, 10);
			recipe.AddTile(TileID.LihzahrdAltar);
			recipe.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statDefense += 6;
			if (player.statLife < player.statLifeMax2 / 4 * 3) { player.statDefense += 2; }
			if (player.statLife < player.statLifeMax2 / 2) { player.statDefense += 2; }
			if (player.statLife < player.statLifeMax2 / 4) { player.statDefense += 2; }
			player.noKnockback = true;
			player.GetModPlayer<LimePlayerHooks>().OmamoriEquipped = 50;
		}
		public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
		{
			if (incomingItem.type == ModContent.ItemType<AncientOmamori>()
				//|| incomingItem.type == ModContent.ItemType<EarthOmamori>()
				|| incomingItem.type == ModContent.ItemType<WaterOmamori>()
				|| incomingItem.type == ModContent.ItemType<FlameOmamori>()
				|| incomingItem.type == ModContent.ItemType<AirOmamori>()
				)
			{
				return false;
			}
			return true;
		}
	}
	public class WaterOmamori : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(32, 32);
			Item.value = Item.sellPrice(0, 20, 0, 0);
			Item.rare = ItemRarityID.Yellow;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient<AncientOmamori>();
			recipe.AddIngredient(ItemID.CharmofMyths);
			recipe.AddIngredient(ItemID.PanicNecklace);
			recipe.AddIngredient(ItemID.CrossNecklace);
			recipe.AddIngredient(ItemID.Ichor, 100);
			recipe.AddIngredient(ItemID.SoulofSight, 10);
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.lifeRegen += 5; // 2.5 per second
			if (player.statLife < player.statLifeMax2 / 2) { player.lifeRegen += 5; }
			if (player.statLife < player.statLifeMax2 / 4) { player.lifeRegen += 5; }
			player.pStone = true;
			player.panic = true;
			player.longInvince = true;
			player.statLifeMax2 += 100;
			player.GetModPlayer<LimePlayerHooks>().OmamoriEquipped = 80;
		}
		public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
		{
			if (incomingItem.type == ModContent.ItemType<AncientOmamori>()
				|| incomingItem.type == ModContent.ItemType<EarthOmamori>()
				//|| incomingItem.type == ModContent.ItemType<WaterOmamori>()
				|| incomingItem.type == ModContent.ItemType<FlameOmamori>()
				|| incomingItem.type == ModContent.ItemType<AirOmamori>()
				)
			{
				return false;
			}
			return true;
		}
	}
	public class AirOmamori : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(32, 32);
			Item.value = Item.sellPrice(0, 20, 0, 0);
			Item.rare = ItemRarityID.Yellow;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed += 0.15f;
			player.noFallDmg = true;
			player.jumpBoost = true;
			player.GetModPlayer<LimePlayerHooks>().OmamoriEquipped = 80;
			player.GetModPlayer<LimePlayerHooks>().AirOmamoriEquipped = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient<AncientOmamori>();
			recipe.AddIngredient(ItemID.SoulofFlight, 10);
			recipe.AddIngredient(ItemID.Feather, 100);
			recipe.AddIngredient(ItemID.HallowedBar, 5);
			recipe.AddTile(TileID.SkyMill);
			recipe.Register();
		}
		public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
		{
			if (incomingItem.type == ModContent.ItemType<AncientOmamori>()
				|| incomingItem.type == ModContent.ItemType<EarthOmamori>()
				|| incomingItem.type == ModContent.ItemType<WaterOmamori>()
				|| incomingItem.type == ModContent.ItemType<FlameOmamori>()
				//|| incomingItem.type == ModContent.ItemType<AirOmamori>()
				)
			{
				return false;
			}
			return true;
		}
	}
	[AutoloadEquip(EquipType.Neck)]
	public class SweettoothNecklace : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(22, 30);
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(0, 3, 0, 0);
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ItemID.HoneyComb);
			recipe.AddIngredient(ItemID.SharkToothNecklace);
			recipe.AddIngredient(ItemID.PanicNecklace);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
			Recipe recipe1 = CreateRecipe(1);
			recipe1.AddIngredient(ItemID.SweetheartNecklace);
			recipe1.AddIngredient(ItemID.SharkToothNecklace);
			recipe1.AddTile(TileID.TinkerersWorkbench);
			recipe1.Register();
			Recipe recipe2 = CreateRecipe(1);
			recipe2.AddIngredient(ItemID.StingerNecklace);
			recipe2.AddIngredient(ItemID.PanicNecklace);
			recipe2.AddTile(TileID.TinkerersWorkbench);
			recipe2.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.panic = true;
			player.honeyCombItem = Item;
			player.GetArmorPenetration<GenericDamageClass>() += 5;
		}
	}
	[AutoloadEquip(EquipType.Neck)]
	public class LeachScarf : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(28, 28);
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(0, 1, 0, 0);
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ItemID.WormTooth, 10);
			recipe.AddIngredient(ItemID.GlowingMushroom, 40);
			recipe.AddIngredient(ItemID.HealingPotion, 10);
			recipe.AddIngredient(ItemID.BandofRegeneration, 1);
			recipe.AddTile(TileID.Loom);
			recipe.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			LimePlayerHooks limePlayerHooks = player.GetModPlayer<LimePlayerHooks>();
			limePlayerHooks.LeachScarfEquipped = true;
			limePlayerHooks.LeachScarfPunishment = 60 * 30;
		}
	}
	public class VampiricWormScarf: ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(28, 28);
			Item.expert = true;
			Item.value = Item.sellPrice(0, 3, 0, 0);
			Item.neckSlot = 8; // Worm scarf
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ItemID.WormScarf, 1);
			recipe.AddIngredient<LeachScarf>(1);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			LimePlayerHooks limePlayerHooks = player.GetModPlayer<LimePlayerHooks>();
			limePlayerHooks.VampireScarfPunishment = 60 * 30;
			limePlayerHooks.VampireScarfEquipped = true;
			player.endurance += 0.17f;
		}
		public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
		{
			if (incomingItem.type == ItemID.WormScarf || incomingItem.type == ModContent.ItemType<LeachScarf>()) return false;
			return true;
		}
	}
}
