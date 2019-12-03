using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Values {
	public static Transform bulletHolder, tankHolder, explosionHolder, blockHolder;
	public static class Player {
		public static float hp = 100f;
		public static float speed = 3f;

		public static class Bullet {
			public static float damage = 2f;
			public static float speed = 20f;
			public static float cooldown = 0.05f; 
		}

		public static class StrongBullet {
			public static float damage = 35f;
			public static float speed = 10f;
			public static float cooldown = 0.5f;
		} 
	}
	public static class Enemies {
		public static class Redtank {
			public static float hp = 50f;
			public static float damage = 20f;
			public static float speed = 1.5f;

			public static class StrongBullet {
				public static float damage = 20f;
				public static float speed = 10f;
				public static float cooldown = 0f;
				public static float cooldownMin = 0.5f;
				public static float cooldownMax = 2f;
			}

			public static class Direction {
				public static float cooldownMin = 1f;
				public static float cooldownMax = 3f;
				public static float cooldown = 0;
			}
		}
	}

	public static class Brick {
		public static class Brown {
			public static Texture[] textures = new Texture[5];
			public static float hpstep = 20;
		}

		public static class Steel {
			public static Texture[] textures = new Texture[5];
			public static float hpstep = 200; 
		}
	}

	public static class Trees {
		public static Object[] textures = new Texture[4];
	}

	public static int[,,] level = new int[,,]{
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0},
		    {0,1,0,1,0,1,0,1,0,1,0,1,0},
		    {0,1,2,1,0,1,3,1,0,1,2,1,0},
		    {0,1,0,1,0,1,0,1,0,1,0,1,0},
		    {0,1,0,1,0,0,0,0,0,1,0,1,0},
		    {0,0,0,0,0,1,0,1,0,0,0,0,0},
		    {3,0,1,1,0,0,0,0,0,1,1,0,3},
		    {4,0,0,0,0,1,0,1,0,0,0,0,4},
		    {4,1,0,1,0,1,0,1,0,1,0,1,4},
		    {4,1,0,1,0,1,0,1,0,1,0,1,4},
		    {4,1,2,1,0,0,0,0,0,1,2,1,4},
		    {4,1,0,1,0,1,1,1,0,1,0,1,4},
		    {4,4,4,0,0,1,0,1,0,0,4,4,4}
        },{
            {0,0,0,0,0,0,0,0,0,0,0,0,0},
		    {0,1,0,1,0,1,0,1,0,1,0,1,0},
		    {0,1,2,1,0,1,3,1,0,1,2,1,0},
		    {0,1,0,1,0,1,0,1,0,1,0,1,0},
		    {0,1,0,1,0,0,0,0,0,1,0,1,0},
		    {0,0,0,0,0,1,0,1,0,0,0,0,0},
		    {3,0,1,1,0,0,0,0,0,1,1,0,3},
		    {4,0,0,0,0,1,0,1,0,0,0,0,4},
		    {4,1,0,1,0,1,0,1,0,1,0,1,4},
		    {4,1,0,1,0,1,0,1,0,1,0,1,4},
		    {4,1,2,1,0,0,0,0,0,1,2,1,4},
		    {4,1,0,1,0,1,1,1,0,1,0,1,4},
		    {4,4,4,0,0,1,0,1,0,0,4,4,4}
        }
    }; 
}
