package com.upc.swap.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import com.upc.swap.security.details.UserDetail;
import com.upc.swap.security.jwt.JwtProvider;

import io.swagger.annotations.ApiOperation;

@CrossOrigin(origins = "*", maxAge = 3600)
@RestController
public class TestController {
	
	@Autowired
	JwtProvider jwtProvider;
	
	@GetMapping("/api/test/user")
	@ApiOperation(value="User Method")
	@PreAuthorize("hasRole('USER') or hasRole('ADMIN')")
	public String userAccess() {
		Authentication authInfo = SecurityContextHolder.getContext().getAuthentication();
		UserDetail userPrincipal = (UserDetail)authInfo.getPrincipal();
		String name = userPrincipal.getName();
		return ">>> User Contents! " + name;
	}

	@GetMapping("/api/test/pm")
	@ApiOperation(value="PM Method")
	@PreAuthorize("hasRole('PM') or hasRole('ADMIN')")
	public String projectManagementAccess() {
		Authentication authInfo = SecurityContextHolder.getContext().getAuthentication();
		UserDetail userPrincipal = (UserDetail)authInfo.getPrincipal();
		String name = userPrincipal.getName();
		return ">>> Board Management Project " + name;
	}
	
	@GetMapping("/api/test/admin")
	@PreAuthorize("hasRole('ADMIN')")
	@ApiOperation(value="Admin Method")
	public String adminAccess() {
		Authentication authInfo = SecurityContextHolder.getContext().getAuthentication();
		UserDetail userPrincipal = (UserDetail)authInfo.getPrincipal();
		String name = userPrincipal.getName();
		return ">>> Admin Contents " + name;
	}
}
