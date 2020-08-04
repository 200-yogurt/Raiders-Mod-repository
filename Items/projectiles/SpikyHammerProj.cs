using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
namespace RaidersMod.Items.projectiles
{
    class SpikyHammerProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spiky Hammer");
        }
        Vector2 DirectionToGo = Vector2.Zero;
        public override void SetDefaults()
        {
            projectile.aiStyle = -1;
            projectile.damage = 36;
            projectile.knockBack = 1.6f;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.width = projectile.height = 25;
        }
        bool ShouldReturn = false;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            ShouldReturn = true;
            projectile.tileCollide = false;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            ShouldReturn = true;
            projectile.tileCollide = false;
            Main.PlaySound(SoundID.Dig, projectile.position);
            return false;
        }
        int returnTimer = 0;
        public override void AI()
        {
            if(DirectionToGo == Vector2.Zero) DirectionToGo = Vector2.Normalize(Main.MouseWorld - projectile.Center);
            Player player = Main.player[projectile.owner];
            projectile.rotation += 0.38f * (float)projectile.direction;
            if (Vector2.Distance(projectile.Center, player.Center) > 500 || ++returnTimer >= 60 || !player.channel || Vector2.Distance(projectile.Center,DirectionToGo) < 10) ShouldReturn = true;
            if(!ShouldReturn)
            {
                projectile.velocity = DirectionToGo * 26f;
            } else
            {
                projectile.velocity = Vector2.Normalize(player.Center - projectile.Center) * 28f;
                if (projectile.Hitbox.Intersects(player.Hitbox)) projectile.Kill();
            }
        }
    }
}
