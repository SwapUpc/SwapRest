package com.upc.swap.repository;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.upc.swap.entities.User;

@Repository
public interface IUserRepo extends JpaRepository<User, Integer>{
	public Optional<User> findByUsername(String username);
	public boolean existsByUsername(String username);
	public boolean existsByEmail(String email);
}
