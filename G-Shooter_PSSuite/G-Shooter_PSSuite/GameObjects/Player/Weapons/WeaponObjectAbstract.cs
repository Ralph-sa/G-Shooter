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


	public class WeaponObjectAbstract
	{

		public BulletObjectAbstract[] bulletsArray;
		public int maxBulletCount;

		public float fireCooldown;


		public WeaponObjectAbstract (int maxBullets)
		{
			int maxBulletCount = maxBullets;

		}

		public virtual void Update()
		{


		}






	}

}
