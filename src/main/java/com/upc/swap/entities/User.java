package com.upc.swap.entities;

import java.io.Serializable;
import java.util.Date;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.JoinTable;
import javax.persistence.ManyToMany;
import javax.persistence.MapKeyJoinColumn;
import javax.persistence.Table;
import javax.persistence.UniqueConstraint;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.PastOrPresent;
import javax.validation.constraints.Size;

import org.springframework.format.annotation.DateTimeFormat;

import io.swagger.annotations.ApiModelProperty;

@Entity
@Table(name="users", uniqueConstraints = {
		@UniqueConstraint(columnNames = {"username"}),
		@UniqueConstraint(columnNames = {"email"})
})
public class User implements Serializable{

	private static final long serialVersionUID = 1L;
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;
	
	@NotBlank(message="El campo no puede estar en blanco")
	@Size(min=3, max=255, message="El campo no tiene la longuitud deseada - entre 3 y 255")
	@Column(name="name")
	@ApiModelProperty(value="user's name")
	private String name;
	
	@NotBlank(message="El campo no puede estar en blanco")
	@Size(min=3, max=255, message="El campo no tiene la longuitud deseada - entre 3 y 255")
	@Column(name="lastname")
	@ApiModelProperty(value="user's lastname")
	private String lastname;
	
	@NotBlank(message="El campo no puede estar en blanco")
	@Size(min=3, max=30, message="El campo no tiene la longuitud deseada - entre 3 y 30")
	@Column(name="username", unique=true)
	@ApiModelProperty(value="unique username")
	private String username;
	
	@NotBlank(message="El campo no puede estar en blanco")
	@Size(min=3, max=255, message="El campo no tiene la longuitud deseada - entre 3 y 255")
	@Column(name="email", unique=true)
	@ApiModelProperty(value="unique email asociate to one User")
	private String email;
	
	@NotBlank(message="El campo no puede estar en blanco")
	@Size(min=6, max=150, message="El campo no tiene la longuitud deseada - entre 6 y 50")
	@ApiModelProperty(value="User's Password, it must be between 6 and 50 characters")
	private String password;
	
	@NotNull @PastOrPresent
    @DateTimeFormat(pattern="yyyy-MM-dd")
	@ApiModelProperty(value="User's birthday")
	private Date birthday;
	
	@NotBlank(message="El campo no puede estar en blanco")
	@Size(min=6, max=50, message="El campo no tiene la longuitud deseada - entre 6 y 50")
	@ApiModelProperty(value="User's Mobilphone")
	private String mobilephone;
	
	@Size(max=255, message="El campo no tiene la longuitud deseada - 255")
	@ApiModelProperty(value="User's Description")
	private String description;
	
	@ApiModelProperty(value="If User Want to Teach")
	private boolean teach;
	
	@ApiModelProperty(value="User's status (Active, Inactive)")
	private boolean active;
	
	@ManyToMany(fetch = FetchType.LAZY)
	@JoinTable(name = "user_roles", 
		joinColumns = @JoinColumn(name = "user_id"), 
		inverseJoinColumns = @JoinColumn(name = "role_id"))
	private Set<Role> roles = new HashSet<>();
	
	@ManyToMany(fetch = FetchType.LAZY)
	@JoinTable(name = "user_languages",
			joinColumns = @JoinColumn(name = "user_id"),
			inverseJoinColumns = @JoinColumn(name = "level_id"))
	@MapKeyJoinColumn(name="language_id")
    //@ElementCollection
    private Map<Language, Level> language = new HashMap<>();
	
	public User() {}
	
	public User(String name, String lastname, String username, String email, String password,
			Date birthday, String mobilephone, String description, boolean teach, boolean  active) {
		this.name = name;
		this.lastname = lastname;
		this.username = username;
		this.email = email;
		this.password = password;
		this.birthday = birthday;
		this.mobilephone = mobilephone;
		this.description = description;
		this.teach = teach;
		this.active = active;
	}
	
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getUsername() {
		return username;
	}
	public void setUsername(String username) {
		this.username = username;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}
	public boolean isActive() {
		return active;
	}
	public void setActive(boolean active) {
		this.active = active;
	}
	public Set<Role> getRoles() {
		return roles;
	}
	public void setRoles(Set<Role> roles) {
		this.roles = roles;
	}
	public String getLastname() {
		return lastname;
	}
	public void setLastname(String lastname) {
		this.lastname = lastname;
	}
	public Date getBirthday() {
		return birthday;
	}
	public void setBirthday(Date birthday) {
		this.birthday = birthday;
	}
	public String getMobilephone() {
		return mobilephone;
	}
	public void setMobilephone(String mobilephone) {
		this.mobilephone = mobilephone;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public boolean isTeach() {
		return teach;
	}
	public void setTeach(boolean teach) {
		this.teach = teach;
	}

	public Map<Language, Level> getLanguage() {
		return language;
	}

	public void setLanguage(Map<Language, Level> language) {
		this.language = language;
	}
}
