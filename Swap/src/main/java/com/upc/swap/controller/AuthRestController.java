package com.upc.swap.controller;

import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.upc.swap.entities.Language;
import com.upc.swap.entities.Level;
import com.upc.swap.entities.Role;
import com.upc.swap.entities.RoleName;
import com.upc.swap.entities.User;
import com.upc.swap.repository.IRoleRepo;
import com.upc.swap.security.jwt.JwtProvider;
import com.upc.swap.service.ILanguageServ;
import com.upc.swap.service.ILevelServ;
import com.upc.swap.service.IUserServ;
import com.upc.swap.util.request.SignIn;
import com.upc.swap.util.request.SignUp;
import com.upc.swap.util.response.JwtResponse;

import io.swagger.annotations.ApiOperation;

@CrossOrigin(origins = "*", maxAge = 3600)
@RestController
@RequestMapping("/api/auth")
public class AuthRestController {
	
	@Autowired
	AuthenticationManager authenticationManager;
	
	@Autowired
	IUserServ userServ;
	
	@Autowired
	IRoleRepo rolRepo;
	
	@Autowired
	ILanguageServ languageServ;
	
	@Autowired
	ILevelServ levelServ;
	
	@Autowired
	JwtProvider jwtProvider;
	
	@ApiOperation(value="SignIn Method")
	@PostMapping("/signin")
	public ResponseEntity<?> authenticateUser(@Valid @RequestBody SignIn signIn){
		Authentication authentication = authenticationManager.authenticate(
				new UsernamePasswordAuthenticationToken(
						signIn.getUsername(),
						signIn.getPassword()));
		
		SecurityContextHolder.getContext().setAuthentication(authentication);
		String token = jwtProvider.generateJwtToken(authentication);
		return ResponseEntity.ok(new JwtResponse(token));
	}
	
	@ApiOperation(value="SignUp Method")
	@PostMapping("/signup")
	public ResponseEntity<String> registerUser(@Valid @RequestBody SignUp signUp){
		if(userServ.existsByUsername(signUp.getUsername())) {
			return new ResponseEntity<String>("Fail -> Username is already taken!", HttpStatus.BAD_REQUEST);
		}
		if(userServ.existsByEmail(signUp.getEmail())) {
			return new ResponseEntity<String>("Fail -> Email is already in use!", HttpStatus.BAD_REQUEST);
		}
		
		User user = new User(signUp.getName(), signUp.getLastname(), signUp.getUsername(),
				signUp.getEmail(), signUp.getPassword(), signUp.getBirthday(),
				signUp.getMobilephone(), signUp.getDescription(), signUp.isTeach(), true);
		
		List<Integer> strLanguages = signUp.getLanguage();
		List<Integer> strLevels = signUp.getLevel();
		Set<String> strRoles = signUp.getRole();
		Set<Role> roles = new HashSet<>();
		Map<Language, Level> language = new HashMap<Language, Level>();;
		
		for(int i = 0; i < strLanguages.size(); i++) {
			int ind = strLanguages.get(i);
			int ind2 = strLevels.get(i);
			
			Language lang = languageServ.findByid(ind).get();
			Level lev = levelServ.findByid(ind2).get();
			
			language.put(lang, lev);
		}
		
		strRoles.forEach(role -> {
			switch(role) {
			case "admin":
				Role adminRole = rolRepo.findByName(RoleName.ROLE_ADMIN)
				.orElseThrow(() -> new RuntimeException("Fail! -> Cause: User Role not find"));
				roles.add(adminRole);
				break;
			default:
				Role userRole = rolRepo.findByName(RoleName.ROLE_USER)
				.orElseThrow(() -> new RuntimeException("Fail! -> Cause: User Role not find"));
				roles.add(userRole);
			}
		});
		
		user.setLanguage(language);
		user.setRoles(roles);
		userServ.save(user);
		
		return ResponseEntity.ok().body("User registered successfully!");
	}
}