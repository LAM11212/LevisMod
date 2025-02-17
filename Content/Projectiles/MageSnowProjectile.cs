using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevisMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LevisMod.Content.Projectiles
{
    internal class MageSnowProjectile : ModProjectile
    {
        private int frameTimer;

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.aiStyle = 0;
            Main.projFrames[Projectile.type] = 4;
        }

        public override void AI()
        {
            frameTimer++;
            if (frameTimer >= 5)
            {
                frameTimer = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }

                Lighting.AddLight(Projectile.Center, 0.5f, 0.2f, 0.8f);
                Projectile.velocity.Y += (float)System.Math.Sin(Projectile.timeLeft * 0.1f) * 0.3f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for(int i = 0; i < 20; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Snow, Projectile.velocity.X * 0.5f, 
                    Projectile.velocity.Y * 0.5f, 100, default, 1.5f);
            }
            return true;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Frostburn, 60);
        }
    }
}
