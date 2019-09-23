package com.upc.swap.repository;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.upc.swap.entities.Role;
import com.upc.swap.entities.RoleName;

@Repository
public interface IRoleRepo extends JpaRepository<Role, Integer> {
	public Optional<Role> findByName(RoleName rolName);
}
