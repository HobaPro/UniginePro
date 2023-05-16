using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "550f3c2b8061238eee6655957947a9f08b38348f")]
public class HealthSystem
{
	float maxHealth;
	float health;

	public HealthSystem(float maxHealth, float health){
		this.maxHealth = maxHealth;
		this.health = health;
	}

	float GetMaxHealth(){
		return maxHealth;
	}
	float SetMaxHealth(float maxHealth){
		return this.maxHealth = maxHealth;
	}

	float GetHealth(){
		return health;
	}
	float SetHealth(float health){
		return this.health = health;
	}

	void Damage(float damageAmount){
		this.health -= damageAmount;
	}

	void Healing(float HealAmount){
		this.health += HealAmount;
	}
}