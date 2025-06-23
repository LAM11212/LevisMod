using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace LevisMod.Content.Items.Buffs
{
    public class CigaretteBuff : ModBuff
    {

        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 5;
            player.gravity += 0.5f;
            player.jumpSpeedBoost += 10.5f;
        }
    }
}
