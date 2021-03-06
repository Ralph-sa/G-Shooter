using System;
using System.Collections.Generic;

using Sce.Pss.Core;
using Sce.Pss.Core.Environment;
using Sce.Pss.Core.Graphics;
using Sce.Pss.Core.Input;

using Sce.Pss.HighLevel.GameEngine2D;
using Sce.Pss.HighLevel.GameEngine2D.Base;



namespace GShooter_PSSuite
{
	

	public class GravityWeaponObject : WeaponObjectAbstract
	{


		public float bulletMaxVelocity;
		public float bulletMaxLife;


		public GravityWeaponObject (int maxBullets) : base(maxBullets)
		{
			bulletsArray =  new SimpleBulletObject[maxBullets];

			for (int i=0; i < maxBullets; ++i)
			{
				bulletsArray[i] = new SimpleBulletObject("/Application/Resources/Sprites/pokeball_color1_ss.png");
			}

			bulletMaxVelocity = 10f;
			bulletMaxLife = 20000f; // in milliseconds,ds
			fireCooldown = 20;

		}

		// player calls this to shoot, handles cooldown
		public void FireWeapon(Vector2 playerPosition, float dt)
		{


			//cooldown
			cooldownCounter += dt;
			if(cooldownCounter > fireCooldown)
			{
				FireBullet(playerPosition);
				cooldownCounter = 0;
			}


		}



		// fires a single bullet
		private void FireBullet(Vector2 playerPosition)
		{
			foreach(BulletObjectAbstract bullet in bulletsArray)
			{
				if(bullet.isAlive == false)
				{
					bullet.velocity = bulletInitialVelocity;
					bullet.sprite.Position = playerPosition;
					bullet.isAlive = true;
					break;
				}

			}
		}

		public override void Update(float dt)
		{

			foreach(BulletObjectAbstract bullet in bulletsArray)
			{
				if(bullet.isAlive == true)
				{
					bullet.Update(dt);
					if(bullet.lifeTime > bulletMaxLife)
					{
						bullet.KillSelf();
					}
				}

			}



		}








	}

}

