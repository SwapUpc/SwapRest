package com.upc.swap.service.implement;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;

import com.upc.swap.entities.User;
import com.upc.swap.repository.IUserRepo;
import com.upc.swap.service.IUserServ;

@Service
public class UserServImpl implements IUserServ {

	@Autowired
	private IUserRepo userRepo;
	
	@Autowired
	private BCryptPasswordEncoder encoder;
	
	@Override
	public boolean save(User obj) {
		String pass;
		boolean flag = false;
		try {
			pass = obj.getPassword();
			obj.setPassword(encoder.encode(pass));
			User user = userRepo.save(obj);
			if(user != null)
				flag = true;
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}
		return flag;
	}

	@Override
	public boolean update(User obj) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean delete(int id) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public List<User> getAll() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Optional<User> findByid(int id) {
		return userRepo.findById(id);
	}

	@Override
	public Optional<User> findByUsername(String username) {
		return userRepo.findByUsername(username);
	}

	@Override
	public boolean existsByUsername(String username) {
		return userRepo.existsByUsername(username);
	}

	@Override
	public boolean existsByEmail(String email) {
		return userRepo.existsByEmail(email);
	}

}
