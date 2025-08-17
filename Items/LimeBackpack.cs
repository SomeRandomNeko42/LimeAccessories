using LimeAccessories.Common.Config;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LimeAccessories.Items
{
	[AutoloadEquip(EquipType.Back)]
	public class ManaTank : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(32, 32);
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(0, 0, 25, 0);
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 100;
		}
		public override void AddRecipes()
		{
			Recipe recipegold = CreateRecipe(1);
			recipegold.AddIngredient(ItemID.ManaCrystal, 2);
			recipegold.AddIngredient(ItemID.BandofStarpower, 1);
			recipegold.AddIngredient(ItemID.GoldBar, 10);
			recipegold.AddIngredient(ItemID.Silk, 10);
			recipegold.AddIngredient(ItemID.Obsidian, 10);
			recipegold.AddTile(TileID.HeavyWorkBench);
			recipegold.Register();
			Recipe recipeplatnium = CreateRecipe(1);
			recipeplatnium.AddIngredient(ItemID.ManaCrystal, 2);
			recipeplatnium.AddIngredient(ItemID.BandofStarpower, 1);
			recipeplatnium.AddIngredient(ItemID.PlatinumBar, 10);
			recipeplatnium.AddIngredient(ItemID.Silk, 10);
			recipeplatnium.AddIngredient(ItemID.Obsidian, 10);
			recipeplatnium.AddTile(TileID.HeavyWorkBench);
			recipeplatnium.Register();
		}
	}
	[AutoloadEquip(EquipType.Back)]
	public class ManaPack : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(32, 32);
			Item.rare = ItemRarityID.LightPurple;
			Item.value = Item.sellPrice(0, 0, 75, 0);
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 200;
			player.magicCuffs = true;
			player.manaMagnet = true;
		}
		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 *= 2;
		}
		public override void AddRecipes()
		{
			Recipe recipecobalt = CreateRecipe(1);
			recipecobalt.AddIngredient<ManaTank>();
			recipecobalt.AddIngredient(ItemID.CelestialCuffs, 1);
			recipecobalt.AddIngredient(ItemID.CrystalShard, 20);
			recipecobalt.AddIngredient(ItemID.CobaltBar, 10);
			recipecobalt.AddTile(TileID.CrystalBall);
			recipecobalt.Register();
			Recipe recipepalladium = CreateRecipe(1);
			recipepalladium.AddIngredient<ManaTank>();
			recipepalladium.AddIngredient(ItemID.CelestialCuffs, 1);
			recipepalladium.AddIngredient(ItemID.CrystalShard, 20);
			recipepalladium.AddIngredient(ItemID.PalladiumBar, 10);
			recipepalladium.AddTile(TileID.CrystalBall);
			recipepalladium.Register();
		}
	}
}
