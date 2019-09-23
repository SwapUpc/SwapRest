package com.upc.swap.security.details;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.upc.swap.entities.User;
import com.upc.swap.service.IUserServ;

@Service
public class UserDetailServ implements UserDetailsService{
	
	@Autowired
	private IUserServ userServ;
	
	@Override
	@Transactional
	public UserDetails loadUserByUsername(String username) 
			throws UsernameNotFoundException {
		
		User user = userServ.findByUsername(username)
				.orElseThrow(() ->
				new UsernameNotFoundException(
				"User Not Found with -> username or email: " + username));
		
		return UserDetail.build(user);
	}

}
