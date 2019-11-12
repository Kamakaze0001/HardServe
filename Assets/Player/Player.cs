﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
	//Event broadcasting
	public delegate void WeaponChange();
	public static event WeaponChange WeaponChanged;

	//BulletPrefabs
	[SerializeField]
	Shot_Sprinkle sprinkleShot;
	[SerializeField]
	Shot_Chocolate chocolateShot;
	[SerializeField]
	Shot_Cherry cherryShot;

	public static int currentWeapon = 0;
	float maxMaxSpeed = 21.0f;
    float maxSpeed = 7.0f;
	int maxHealth = 3;
	int currentHealth = 3;

	float[] shotTimers = { 0.0f, 0.0f, 0.0f };

    float[] maxAmmo    = { 8.0f, 250.0f, 1.0f };
    float[] weaponAmmo = { 0.0f, 0.0f, 0.0f };
	float[] ammoIncScalars = { 2.0f, 10.0f, 1.0f };

	//Amount per second to refill weaponAmmo by
	float[] rechargeRates = { 0.93f, 25.0f, 0.05f };
	float[] rechargeIncScalars = { 0.31f, 8.3f, 0.016f };

	float[] fireRates = { 1.5f, 50.0f, 0.33f };
	float[] fireRatesInScalars = { 0.5f, 16.6f, 0.11f };

	void Start(){
		for (int i = 0; i < 3; i++) {
			weaponAmmo[i] = maxAmmo[i];
		}
	}

    // Update is called once per frame
    void Update(){
		for (int i = 0; i < 3; i++) {
			if (shotTimers[i] > 0.0f){
				shotTimers[i] -= Time.deltaTime;
			}

			if (weaponAmmo[i] < maxAmmo[i]) {
				weaponAmmo[i] += (rechargeRates[i] * Time.deltaTime);
			}
		}

        Vector2 tempVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        GetComponent<Rigidbody2D>().velocity = tempVelocity.SqrMagnitude() > 1.0f ? tempVelocity.normalized * maxSpeed : tempVelocity * maxSpeed;

        Vector2 plrVel = GetComponent<Rigidbody2D>().velocity;

        Animator myAnimator = GetComponent<Animator>();

        myAnimator.SetBool("GoingLeft", plrVel.x < 0.0f);
        myAnimator.SetBool("GoingRight", plrVel.x > 0.0f);
        myAnimator.SetBool("GoingUp", plrVel.y > 0.0f);
        myAnimator.SetBool("GoingDown", plrVel.y < 0.0f);

        if (CanShoot()) {
            if (Input.GetButton("FireU")){
				switch (currentWeapon) {
					case (0): { ShootSprinkle(new Vector2(0.0f, 1.0f)); break; }
					case (1): { ShootChocolate(new Vector2(0.0f, 1.0f)); break; }
					case (2): { ShootCherry(new Vector2(0.0f, 1.0f)); break; }
				}

				weaponAmmo[currentWeapon] -= 1.0f;
            }
            else if(Input.GetButton("FireD")){
				switch (currentWeapon) {
					case (0): { ShootSprinkle(new Vector2(0.0f, -1.0f)); break; }
					case (1): { ShootChocolate(new Vector2(0.0f, -1.0f)); break; }
					case (2): { ShootCherry(new Vector2(0.0f, -1.0f)); break; }
				}

				weaponAmmo[currentWeapon] -= 1.0f;
			}
            else if(Input.GetButton("FireL")){
				switch (currentWeapon) {
					case (0): { ShootSprinkle(new Vector2(-1.0f, 0.0f)); break; }
					case (1): { ShootChocolate(new Vector2(-1.0f, 0.0f)); break; }
					case (2): { ShootCherry(new Vector2(-1.0f, 0.0f)); break; }
				}

				weaponAmmo[currentWeapon] -= 1.0f;
			}
            else if(Input.GetButton("FireR")){
				switch (currentWeapon) {
					case (0): { ShootSprinkle(new Vector2(1.0f, 0.0f)); break; }
					case (1): { ShootChocolate(new Vector2(1.0f, 0.0f)); break; }
					case (2): { ShootCherry(new Vector2(1.0f, 0.0f)); break; }
				}

				weaponAmmo[currentWeapon] -= 1.0f;
			}
        }

        if (Input.GetButtonDown("SwitchLeft")){
            if (currentWeapon == 0) currentWeapon = 2;
            else currentWeapon -= 1;
			WeaponChanged();
        }
        else if (Input.GetButtonDown("SwitchRight")){
            if (currentWeapon == 2) currentWeapon = 0;
            else currentWeapon += 1;
			WeaponChanged();
		}
    }

    bool CanShoot() {
        return (shotTimers[currentWeapon] <= 0.0f && weaponAmmo[currentWeapon] >= 1.0f);
    }

	void ShootSprinkle(Vector2 _direction){
		Vector2 plrVelocity = GetComponent<Rigidbody2D>().velocity;
		
		for (int i = 0; i < 15; i++){
			Vector3 noisyDirection = Quaternion.Euler(0.0f, 0.0f, Random.Range(-22.5f, 22.5f)) * new Vector3(_direction.x, _direction.y, 0.0f);

			GameObject.Instantiate(sprinkleShot, transform.position, Quaternion.identity).Initialise(
				new Vector2(noisyDirection.x, noisyDirection.y),
				plrVelocity
			);
		}

		shotTimers[currentWeapon] = 1.0f / fireRates[currentWeapon];
	}

	void ShootChocolate(Vector2 _direction){
		Vector2 plrVelocity = GetComponent<Rigidbody2D>().velocity;

		GameObject.Instantiate(chocolateShot, transform.position, Quaternion.identity).Initialise(
			_direction,
			plrVelocity
		);

		shotTimers[currentWeapon] = 1.0f / fireRates[currentWeapon];
	}

	void ShootCherry(Vector2 _direction){
		Vector2 plrVelocity = GetComponent<Rigidbody2D>().velocity;

		GameObject.Instantiate(cherryShot, transform.position, Quaternion.identity).Initialise(
			_direction,
			plrVelocity
		);

		shotTimers[currentWeapon] = 1.0f / fireRates[currentWeapon];
	}

	public void AddStats(float _moveSpeed, int _maxHealth, float _maxAmmo, float _rechargeRate, float _fireRate, float _damage, float _shotSpeed, float _range) {
		maxSpeed = Mathf.Min(maxSpeed + (_moveSpeed * 2.3f), maxMaxSpeed);
		maxHealth += _maxHealth;
		maxAmmo[currentWeapon] += _maxAmmo * ammoIncScalars[currentWeapon];
		rechargeRates[currentWeapon] += _rechargeRate * rechargeIncScalars[currentWeapon];
		fireRates[currentWeapon] += _fireRate * fireRatesInScalars[currentWeapon];

		switch (currentWeapon) {
			case 0: {
				Shot_Sprinkle.AddStats(_damage, _shotSpeed, _range);
				break;
			}
			case 1: {
				Shot_Chocolate.AddStats(_damage, _shotSpeed, _range);
				break;
			}
			case 2: {
				Shot_Cherry.AddStats(_damage, _shotSpeed, _range);
				break;
			}
		}
	}

	public void Heal(int _amount) {
		currentHealth = Mathf.Min(currentHealth + _amount, maxHealth);
	}
	 
	public void Damage(int _amount) {
		//TODO: Play animation
		currentHealth -= _amount;
		if (currentHealth <= 0) { 
			//TODO: Kill
		}
	}

	public int Health {
		get { return currentHealth; }
	}

	public float AmmoScale {
		get { return weaponAmmo[currentWeapon] / maxAmmo[currentWeapon]; }
	}
}
