using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LevisMod.Content.Projectiles
{
    internal class DiamondAmmoProjectile : ModProjectile
    {
        private int frameTimer;

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;

            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 0;
            AIType = ProjectileID.Bullet;
            Main.projFrames[Projectile.type] = 7;
        }

        public override void AI()
        {
            frameTimer++;
            if (frameTimer >= 7)
            {
                frameTimer = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }

                Lighting.AddLight(Projectile.Center, 0.5f, 0.2f, 0.8f);
            }

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            int num101 = (int)(Projectile.position.X / 16f) - 3;
            int num102 = (int)((Projectile.position.X + (float)Projectile.width) / 16f) + 3;
            int num103 = (int)(Projectile.position.Y / 16f) - 3;
            int num104 = (int)((Projectile.position.Y + (float)Projectile.height) / 16f) + 3;
            if(num101 < 0)
            {
                num101 = 0;
            }
            if (num102 > Main.maxTilesX)
            {
                num102 = Main.maxTilesX;
            }
            if(num103 < 0)
            {
                num103 = 0;
            }
            if(num104 > Main.maxTilesY)
            {
                num104 = Main.maxTilesY;
            }

            for(int num105 = num101; num105 < num102; num105++)
            {
                for(int num106 = num103; num106 < num104; num106++)
                {
                    WorldGen.KillTile(num105, num106, false, false, false);
                }
                
            }
            return true;
        }
    }
}
