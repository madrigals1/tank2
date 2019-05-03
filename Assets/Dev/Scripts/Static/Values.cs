public static class Values {
	
	public static class Player {
		public static float hp = 100f;
		public static float speed = 3f; 
	}

	public static class Enemy {
		public static float hp = 50f;
		public static float damage = 20f;
		public static float speed = 1.5f;
		public static float shootCooldownMin = 0.5f;
		public static float shootCooldownMax = 2f;
		public static float shootCooldown = 0;
		public static float dirCooldownMin = 1f;
		public static float dirCooldownMax = 3f;
		public static float dirCooldown = 0;
	}

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
