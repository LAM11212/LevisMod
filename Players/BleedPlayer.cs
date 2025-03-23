using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameInput;
using Terraria.GameContent.UI.States;
using LevisMod.NPCs;

namespace LevisMod.Players
{
    public class BleedPlayer : ModPlayer
    {
        public static ModKeybind GuillotineKey;

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if(GuillotineKey.JustPressed)
            {
                AttemptExecuteGuillotine();
            }
        }
        private void AttemptExecuteGuillotine()
        {
            foreach(NPC npc in Main.npc)
            {
                if (npc.active && npc.TryGetGlobalNPC<BleedGlobalNPC>(out var bleedNPC))
                {
                    if(bleedNPC.bleedStacks > 0)
                    {
                        int damage = bleedNPC.noxianGuillotine(npc);
                        npc.SimpleStrikeNPC(damage, 0, false, 0);
                        bleedNPC.setBleedStacks(0);
                    }
                }
            }
        }
    }
}
