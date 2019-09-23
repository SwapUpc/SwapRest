package com.upc.swap.service;

import java.util.Optional;

import com.upc.swap.entities.User;

public interface IUserServ extends CrudServ<User>{
	public Optional<User> findByUsername(String username);
	public boolean existsByUsername(String username);
	public boolean existsByEmail(String email);
}
