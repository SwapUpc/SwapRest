package com.upc.swap.security;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.config.http.SessionCreationPolicy;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter;

import com.upc.swap.security.details.UserDetailServ;
import com.upc.swap.security.jwt.JwtAuthEntryPoint;
import com.upc.swap.security.jwt.JwtAuthTokenFilter;

@Configuration
@EnableWebSecurity
@EnableGlobalMethodSecurity(prePostEnabled = true)
public class RestSecurityConfig extends WebSecurityConfigurerAdapter{
	
	@Autowired
	UserDetailServ userDetailServ;
	
	@Autowired
	private JwtAuthEntryPoint unauthorizedHandler;
	
    @Bean
    public JwtAuthTokenFilter authenticationJwtTokenFilter() {
        return new JwtAuthTokenFilter();
    }
	
	@Autowired
	private BCryptPasswordEncoder coder;
	
	@Bean
	public BCryptPasswordEncoder passwordEncoder() {
		BCryptPasswordEncoder bCrypt  = new BCryptPasswordEncoder();
		return bCrypt;
	}
	
	@Override
	public void configure(AuthenticationManagerBuilder authenticationManagerBuilder)
	throws Exception {
		authenticationManagerBuilder.userDetailsService(userDetailServ)
		.passwordEncoder(coder);
	}
	
	@Bean
	@Override
	public AuthenticationManager authenticationManagerBean() throws Exception {
		return super.authenticationManagerBean();
	}
	
	@Override
	protected void configure(HttpSecurity http) throws Exception {
		http.cors().and().csrf().disable()
		.authorizeRequests()
		.antMatchers("/api/auth/**").permitAll()
		.anyRequest().authenticated()
		.and()
		.logout().permitAll().logoutUrl("/logout").logoutSuccessUrl("/persona/1")                              
        .invalidateHttpSession(true)
        .and()
		.exceptionHandling().authenticationEntryPoint(unauthorizedHandler)
		.and()
		.sessionManagement().sessionCreationPolicy(SessionCreationPolicy.STATELESS)
		.and()
		.addFilterBefore(authenticationJwtTokenFilter(), UsernamePasswordAuthenticationFilter.class);
	
	}
}
