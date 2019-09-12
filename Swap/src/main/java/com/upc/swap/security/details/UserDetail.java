package com.upc.swap.security.details;

import java.util.Collection;
import java.util.Date;
import java.util.List;
import java.util.stream.Collectors;

import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.google.common.base.Objects;
import com.upc.swap.entities.User;

public class UserDetail implements UserDetails {

	private static final long serialVersionUID = 1L;

	private int id;
	private String name;
	private String lastname;
	private String username;
	private String email;
	@JsonIgnore
	private String password;
	private Date birthday;
	private String mobilephone;
	private String description;
	private boolean teach;
	
	private Collection<? extends GrantedAuthority> authorities;
	
	public UserDetail(int id, String name, String lastname, String username,
			String email, String password, Date birthday, String mobilephone,
			String description, boolean teach, Collection<? extends GrantedAuthority> authorities) {
		this.id = id;
		this.name = name;
		this.lastname = lastname;
		this.username = username;
		this.email = email;
		this.password = password;
		this.birthday = birthday;
		this.mobilephone = mobilephone;
		this.description = description;
		this.teach = teach;
		this.authorities = authorities;
	}
	
	public static UserDetail build(User user) {
		List<GrantedAuthority> authorities = user.getRoles().stream().map(
				role -> new SimpleGrantedAuthority(role.getName().name()))
				.collect(Collectors.toList());
		return new UserDetail(
				user.getId(),
				user.getName(),
				user.getLastname(),
				user.getUsername(),
				user.getEmail(),
				user.getPassword(),
				user.getBirthday(),
				user.getMobilephone(),
				user.getDescription(),
				user.isTeach(),
				authorities
		);
	}
	
	public int getId() {
		return id;
	}
	
	public String getName() {
		return name;
	}
	
	public String getLastname() {
		return lastname;
	}
	
	public String getEmail() {
		return email;
	}
	
	@Override
	public String getPassword() {
		return password;
	}

	@Override
	public String getUsername() {
		return username;
	}
	
	public Date getBirthday() {
		return birthday;
	}
	
	public String getMobilephone() {
		return mobilephone;
	}
	
	public String getDescription() {
		return description;
	}
	
	public boolean isTeach() {
		return teach;
	}
	
	@Override
	public Collection<? extends GrantedAuthority> getAuthorities() {
		return authorities;
	}

	@Override
	public boolean isAccountNonExpired() {
		return true;
	}

	@Override
	public boolean isAccountNonLocked() {
		return true;
	}

	@Override
	public boolean isCredentialsNonExpired() {
		return true;
	}

	@Override
	public boolean isEnabled() {
		return true;
	}
	
	@Override
	public boolean equals(Object o) {
		if (this == o) return true;
		if (o == null || getClass() != o.getClass()) return false;
		
		UserDetail user = (UserDetail) o;
		return Objects.equal(id, user.id);
	}

}
