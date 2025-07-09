using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LimeAccessories.Items
{
	[AutoloadEquip(EquipType.Balloon)]
	public class GreenObsidianHorseshoeBalloon : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(28, 48);
			Item.maxStack = 1;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(0, 4, 0, 0);
		}
		public override void AddRecipes()
		{
			// From horseshoe balloon
			Recipe horseshoeballoonrecipe = CreateRecipe(1);
			horseshoeballoonrecipe.AddIngredient(ItemID.BalloonHorseshoeFart);
			horseshoeballoonrecipe.AddIngredient(ItemID.ObsidianSkull);
			horseshoeballoonrecipe.AddTile(TileID.TinkerersWorkbench);
			horseshoeballoonrecipe.Register();
			// Waste a horseshoe
			Recipe horseshoeballoonaltrecipe = CreateRecipe(1);
			horseshoeballoonaltrecipe.AddIngredient(ItemID.BalloonHorseshoeFart);
			horseshoeballoonaltrecipe.AddIngredient(ItemID.ObsidianHorseshoe);
			horseshoeballoonaltrecipe.AddTile(TileID.TinkerersWorkbench);
			horseshoeballoonaltrecipe.Register();
			// From obsidian horseshoe
			Recipe obsidianhorseshoerecipe = CreateRecipe(1);
			obsidianhorseshoerecipe.AddIngredient(ItemID.FartInABalloon);
			obsidianhorseshoerecipe.AddIngredient(ItemID.ObsidianHorseshoe);
			obsidianhorseshoerecipe.AddTile(TileID.TinkerersWorkbench);
			obsidianhorseshoerecipe.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.fireWalk = true;
			player.noFallDmg = true;
			player.jumpBoost = true;
			player.hasLuck_LuckyHorseshoe = true;
			player.GetJumpState<FartInAJarJump>().Enable();
		}
	}
	[AutoloadEquip(EquipType.Balloon)]
	public class PinkObsidianHorseshoeBalloon : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(28, 48);
			Item.maxStack = 1;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(0, 4, 0, 0);
		}
		public override void AddRecipes()
		{
			// From horseshoe balloon
			Recipe horseshoeballoonrecipe = CreateRecipe(1);
			horseshoeballoonrecipe.AddIngredient(ItemID.BalloonHorseshoeSharkron);
			horseshoeballoonrecipe.AddIngredient(ItemID.ObsidianSkull);
			horseshoeballoonrecipe.AddTile(TileID.TinkerersWorkbench);
			horseshoeballoonrecipe.Register();
			// Waste a horseshoe
			Recipe horseshoeballoonaltrecipe = CreateRecipe(1);
			horseshoeballoonaltrecipe.AddIngredient(ItemID.BalloonHorseshoeSharkron);
			horseshoeballoonaltrecipe.AddIngredient(ItemID.ObsidianHorseshoe);
			horseshoeballoonaltrecipe.AddTile(TileID.TinkerersWorkbench);
			horseshoeballoonaltrecipe.Register();
			// From obsidian horseshoe
			Recipe obsidianhorseshoerecipe = CreateRecipe(1);
			obsidianhorseshoerecipe.AddIngredient(ItemID.SharkronBalloon);
			obsidianhorseshoerecipe.AddIngredient(ItemID.ObsidianHorseshoe);
			obsidianhorseshoerecipe.AddTile(TileID.TinkerersWorkbench);
			obsidianhorseshoerecipe.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.fireWalk = true;
			player.noFallDmg = true;
			player.jumpBoost = true;
			player.hasLuck_LuckyHorseshoe = true;
			player.GetJumpState<TsunamiInABottleJump>().Enable();
		}
	}
	[AutoloadEquip(EquipType.Balloon)]
	public class AmberObsidianHorseshoeBalloon : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(28, 48);
			Item.maxStack = 1;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(0, 4, 0, 0);
		}
		public override void AddRecipes()
		{
			// From horseshoe balloon
			Recipe horseshoeballoonrecipe = CreateRecipe(1);
			horseshoeballoonrecipe.AddIngredient(ItemID.BalloonHorseshoeHoney);
			horseshoeballoonrecipe.AddIngredient(ItemID.ObsidianSkull);
			horseshoeballoonrecipe.AddTile(TileID.TinkerersWorkbench);
			horseshoeballoonrecipe.Register();
			// Waste a horseshoe
			Recipe horseshoeballoonaltrecipe = CreateRecipe(1);
			horseshoeballoonaltrecipe.AddIngredient(ItemID.BalloonHorseshoeHoney);
			horseshoeballoonaltrecipe.AddIngredient(ItemID.ObsidianHorseshoe);
			horseshoeballoonaltrecipe.AddTile(TileID.TinkerersWorkbench);
			horseshoeballoonaltrecipe.Register();
			// From obsidian horseshoe
			Recipe obsidianhorseshoerecipe = CreateRecipe(1);
			obsidianhorseshoerecipe.AddIngredient(ItemID.HoneyBalloon);
			obsidianhorseshoerecipe.AddIngredient(ItemID.ObsidianHorseshoe);
			obsidianhorseshoerecipe.AddTile(TileID.TinkerersWorkbench);
			obsidianhorseshoerecipe.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.fireWalk = true;
			player.noFallDmg = true;
			player.jumpBoost = true;
			player.honeyCombItem = Item;
			player.hasLuck_LuckyHorseshoe = true;
		}
	}
	[AutoloadEquip(EquipType.Balloon)]
	public class BlueObsidianHorseshoeBalloon : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(28, 48);
			Item.maxStack = 1;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(0, 4, 0, 0);
		}
		public override void AddRecipes()
		{
			// From horseshoe balloon
			Recipe horseshoeballoonrecipe = CreateRecipe(1);
			horseshoeballoonrecipe.AddIngredient(ItemID.BlueHorseshoeBalloon);
			horseshoeballoonrecipe.AddIngredient(ItemID.ObsidianSkull);
			horseshoeballoonrecipe.AddTile(TileID.TinkerersWorkbench);
			horseshoeballoonrecipe.Register();
			// Waste a horseshoe
			Recipe horseshoeballoonaltrecipe = CreateRecipe(1);
			horseshoeballoonaltrecipe.AddIngredient(ItemID.BlueHorseshoeBalloon);
			horseshoeballoonaltrecipe.AddIngredient(ItemID.ObsidianHorseshoe);
			horseshoeballoonaltrecipe.AddTile(TileID.TinkerersWorkbench);
			horseshoeballoonaltrecipe.Register();
			// From obsidian horseshoe
			Recipe obsidianhorseshoerecipe = CreateRecipe(1);
			obsidianhorseshoerecipe.AddIngredient(ItemID.CloudinaBalloon);
			obsidianhorseshoerecipe.AddIngredient(ItemID.ObsidianHorseshoe);
			obsidianhorseshoerecipe.AddTile(TileID.TinkerersWorkbench);
			obsidianhorseshoerecipe.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.fireWalk = true;
			player.noFallDmg = true;
			player.jumpBoost = true;
			player.hasLuck_LuckyHorseshoe = true;
			player.GetJumpState<CloudInABottleJump>().Enable();
		}
	}
	[AutoloadEquip(EquipType.Balloon)]
	public class WhiteObsidianHorseshoeBalloon : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(28, 48);
			Item.maxStack = 1;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(0, 4, 0, 0);
		}
		public override void AddRecipes()
		{
			// From horseshoe balloon
			Recipe horseshoeballoonrecipe = CreateRecipe(1);
			horseshoeballoonrecipe.AddIngredient(ItemID.WhiteHorseshoeBalloon);
			horseshoeballoonrecipe.AddIngredient(ItemID.ObsidianSkull);
			horseshoeballoonrecipe.AddTile(TileID.TinkerersWorkbench);
			horseshoeballoonrecipe.Register();
			// Waste a horseshoe
			Recipe horseshoeballoonaltrecipe = CreateRecipe(1);
			horseshoeballoonaltrecipe.AddIngredient(ItemID.WhiteHorseshoeBalloon);
			horseshoeballoonaltrecipe.AddIngredient(ItemID.ObsidianHorseshoe);
			horseshoeballoonaltrecipe.AddTile(TileID.TinkerersWorkbench);
			horseshoeballoonaltrecipe.Register();
			// From obsidian horseshoe
			Recipe obsidianhorseshoerecipe = CreateRecipe(1);
			obsidianhorseshoerecipe.AddIngredient(ItemID.BlizzardinaBalloon);
			obsidianhorseshoerecipe.AddIngredient(ItemID.ObsidianHorseshoe);
			obsidianhorseshoerecipe.AddTile(TileID.TinkerersWorkbench);
			obsidianhorseshoerecipe.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.fireWalk = true;
			player.noFallDmg = true;
			player.jumpBoost = true;
			player.hasLuck_LuckyHorseshoe = true;
			player.GetJumpState<BlizzardInABottleJump>().Enable();
		}
	}
	[AutoloadEquip(EquipType.Balloon)]
	public class YellowObsidianHorseshoeBalloon : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(28, 48);
			Item.maxStack = 1;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(0, 4, 0, 0);
		}
		public override void AddRecipes()
		{
			// From horseshoe balloon
			Recipe horseshoeballoonrecipe = CreateRecipe(1);
			horseshoeballoonrecipe.AddIngredient(ItemID.YellowHorseshoeBalloon);
			horseshoeballoonrecipe.AddIngredient(ItemID.ObsidianSkull);
			horseshoeballoonrecipe.AddTile(TileID.TinkerersWorkbench);
			horseshoeballoonrecipe.Register();
			// Waste a horseshoe
			Recipe horseshoeballoonaltrecipe = CreateRecipe(1);
			horseshoeballoonaltrecipe.AddIngredient(ItemID.YellowHorseshoeBalloon);
			horseshoeballoonaltrecipe.AddIngredient(ItemID.ObsidianHorseshoe);
			horseshoeballoonaltrecipe.AddTile(TileID.TinkerersWorkbench);
			horseshoeballoonaltrecipe.Register();
			// From obsidian horseshoe
			Recipe obsidianhorseshoerecipe = CreateRecipe(1);
			obsidianhorseshoerecipe.AddIngredient(ItemID.SandstorminaBalloon);
			obsidianhorseshoerecipe.AddIngredient(ItemID.ObsidianHorseshoe);
			obsidianhorseshoerecipe.AddTile(TileID.TinkerersWorkbench);
			obsidianhorseshoerecipe.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.fireWalk = true;
			player.noFallDmg = true;
			player.jumpBoost = true;
			player.hasLuck_LuckyHorseshoe = true;
			player.GetJumpState<SandstormInABottleJump>().Enable();
		}
	}
	[AutoloadEquip(EquipType.Balloon)]
	public class BundleOfObsidianHorseshoeBalloons : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(30, 38);
			Item.maxStack = 1;
			Item.rare = ItemRarityID.Cyan;
			Item.value = Item.sellPrice(0, 5, 0, 0);
		}
		public override void AddRecipes()
		{
			// First recipe is the one that shimmer uses, having it as this recipe fixes an issue caused by Calamity
			Recipe RecipeForShimmer = CreateRecipe(1);
			RecipeForShimmer.AddIngredient(ItemID.ObsidianHorseshoe);
			RecipeForShimmer.AddIngredient(ItemID.BlizzardinaBalloon);
			RecipeForShimmer.AddIngredient(ItemID.SandstorminaBalloon);
			RecipeForShimmer.AddIngredient(ItemID.CloudinaBalloon);
			RecipeForShimmer.AddTile(TileID.TinkerersWorkbench);
			RecipeForShimmer.Register();
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ItemID.HorseshoeBundle);
			recipe.AddIngredient(ItemID.ObsidianSkull);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
			Recipe recipe1 = CreateRecipe(1);
			recipe1.AddIngredient(ItemID.BundleofBalloons);
			recipe1.AddIngredient(ItemID.ObsidianHorseshoe);
			recipe1.AddTile(TileID.TinkerersWorkbench);
			recipe1.Register();
			Recipe recipe2 = CreateRecipe(1);
			recipe2.AddIngredient(ItemID.BlizzardinaBalloon);
			recipe2.AddIngredient(ItemID.SandstorminaBalloon);
			recipe2.AddIngredient<BlueObsidianHorseshoeBalloon>();
			recipe2.AddTile(TileID.TinkerersWorkbench);
			recipe2.Register();
			Recipe recipe3 = CreateRecipe(1);
			recipe3.AddIngredient(ItemID.BlizzardinaBalloon);
			recipe3.AddIngredient<YellowObsidianHorseshoeBalloon>();
			recipe3.AddIngredient(ItemID.CloudinaBalloon);
			recipe3.AddTile(TileID.TinkerersWorkbench);
			recipe3.Register();
			Recipe recipe4 = CreateRecipe(1);
			recipe4.AddIngredient<WhiteObsidianHorseshoeBalloon>();
			recipe4.AddIngredient(ItemID.CloudinaBalloon);
			recipe4.AddIngredient(ItemID.SandstorminaBalloon);
			recipe4.AddTile(TileID.TinkerersWorkbench);
			recipe4.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetJumpState<CloudInABottleJump>().Enable();
			player.GetJumpState<BlizzardInABottleJump>().Enable();
			player.GetJumpState<SandstormInABottleJump>().Enable();
			player.hasLuck_LuckyHorseshoe = true;
			player.fireWalk = true;
			player.noFallDmg = true;
			player.jumpBoost = true;
		}
	}
	[AutoloadEquip(EquipType.Balloon)]
	public class MassiveBundleOfObsidianHorseshoeBalloons : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToAccessory(30, 46);
			Item.maxStack = 1;
			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.rare = ItemRarityID.Red;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient<BundleOfObsidianHorseshoeBalloons>();
			recipe.AddIngredient(ItemID.FartInABalloon);
			recipe.AddIngredient(ItemID.HoneyBalloon);
			recipe.AddIngredient(ItemID.SharkronBalloon);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
			Recipe recipe2 = CreateRecipe(1);
			recipe2.AddIngredient(ItemID.BundleofBalloons);
			recipe2.AddIngredient<GreenObsidianHorseshoeBalloon>();
			recipe2.AddIngredient(ItemID.HoneyBalloon);
			recipe2.AddIngredient(ItemID.SharkronBalloon);
			recipe2.AddTile(TileID.TinkerersWorkbench);
			recipe2.Register();
			Recipe recipe3 = CreateRecipe(1);
			recipe3.AddIngredient(ItemID.BundleofBalloons);
			recipe3.AddIngredient(ItemID.FartInABalloon);
			recipe3.AddIngredient<AmberObsidianHorseshoeBalloon>();
			recipe3.AddIngredient(ItemID.SharkronBalloon);
			recipe3.AddTile(TileID.TinkerersWorkbench);
			recipe3.Register();
			Recipe recipe4 = CreateRecipe(1);
			recipe4.AddIngredient(ItemID.BundleofBalloons);
			recipe4.AddIngredient(ItemID.FartInABalloon);
			recipe4.AddIngredient(ItemID.HoneyBalloon);
			recipe4.AddIngredient<PinkObsidianHorseshoeBalloon>();
			recipe4.AddTile(TileID.TinkerersWorkbench);
			recipe4.Register();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.hasLuck_LuckyHorseshoe = true;
			player.fireWalk = true;
			player.noFallDmg = true;
			player.jumpBoost = true;
			player.GetJumpState<BlizzardInABottleJump>().Enable();
			player.GetJumpState<CloudInABottleJump>().Enable();
			player.GetJumpState<FartInAJarJump>().Enable();
			player.GetJumpState<SandstormInABottleJump>().Enable();
			player.GetJumpState<TsunamiInABottleJump>().Enable();
			player.honeyCombItem = Item;
		}
	}
}
