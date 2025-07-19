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
