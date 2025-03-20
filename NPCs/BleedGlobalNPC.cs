using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace LevisMod.NPCs
{
    public class BleedGlobalNPC : GlobalNPC
    {
        public int bleedStacks = 0;
        private int bleedTimer = 0;

        public override bool InstancePerEntity => true;

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if(bleedStacks > 0)
            {
                if (npc.lifeRegen > 0) npc.lifeRegen = 0;

                npc.lifeRegen -= bleedStacks * 8;
                damage = bleedStacks * 20;
            }

            if(bleedTimer > 0)
            {
                bleedTimer--;
            }
            else
            {
                bleedStacks = 0;
            }
        }

        public void applyBleed(NPC npc, int duration)
        {
            if(bleedStacks < 5)
            {
                bleedStacks++;
            }
            bleedTimer = duration;
        }

        public int noxianGuillotine(NPC npc)
        {
            int damage = 0;
            if(bleedStacks == 5)
            {
                return damage = 800;
            } else if(bleedStacks == 4)
            {
                return damage = 600;
            } else if(bleedStacks == 3)
            {
                return damage = 400;
            } else if(bleedStacks == 2)
            {
                return damage = 200;
            } else
            {
                return damage = 100;
            }
        }

        public void setBleedStacks(int stacks)
        {
            bleedStacks = stacks;
        }
    }
}
