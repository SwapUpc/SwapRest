package com.upc.swap.service.implement;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.upc.swap.entities.Role;
import com.upc.swap.entities.RoleName;
import com.upc.swap.repository.IRoleRepo;
import com.upc.swap.service.IRoleServ;

@Service
public class RoleServImpl implements IRoleServ {

	@Autowired
	IRoleRepo roleRepo;
	
	@Override
	public boolean save(Role obj) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean update(Role obj) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean delete(int id) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public List<Role> getAll() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Optional<Role> findByid(int id) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Optional<Role> findByName(RoleName rolName) {
		return roleRepo.findByName(rolName);
	}

}
