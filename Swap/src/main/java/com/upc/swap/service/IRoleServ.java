package com.upc.swap.service;

import java.util.Optional;

import com.upc.swap.entities.Role;
import com.upc.swap.entities.RoleName;

public interface IRoleServ extends CrudServ<Role> {
	public Optional<Role> findByName(RoleName rolName);
}
