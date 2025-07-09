using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace LimeAccessories.Common.Config
{
	public class LimeClientConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		[DefaultValue(false)]
		public bool DebugMode;
	}
	//public class LimeServerConfig : ModConfig
	//{
	//	public override ConfigScope Mode => ConfigScope.ServerSide;
	//}
}
