using LevisMod.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;

namespace LevisMod
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class LevisMod : Mod
	{
		public static LevisMod Instance;

        public override void Load()
        {
            Instance = this;

            if(!Main.dedServ)
            {
                BleedPlayer.GuillotineKey = KeybindLoader.RegisterKeybind(this, "Noxian Guillotine", "R");
            }
        }

        public override void Unload()
        {
            Instance = null;
            BleedPlayer.GuillotineKey = null;
        }

    }
}
