package com.upc.swap.util.request;

import java.util.Date;
import java.util.List;
import java.util.Set;

import javax.validation.constraints.Email;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.PastOrPresent;
import javax.validation.constraints.Size;

import org.springframework.format.annotation.DateTimeFormat;

import io.swagger.annotations.ApiModelProperty;

public class SignUp {
	@NotBlank
    @Size(min = 3, max = 255)
	@ApiModelProperty(value="SignUp User's name")
    private String name;

	@NotBlank
    @Size(min = 3, max = 255)
	private String lastname;
	
    @NotBlank
    @Size(min = 3, max = 30)
    private String username;

    @NotBlank
    @Size(min = 3, max = 255)
    @Email
    private String email;
  
    @NotBlank
    @Size(min = 6, max = 150)
    private String password;
    
    @NotNull @PastOrPresent
    @DateTimeFormat(pattern="yyyy-MM-dd")
    private Date birthday;
    
    @NotBlank
    @Size(min = 6, max = 50)
    private String mobilephone;
    
    @Size(max = 255)
    private String descriptions;
    
    private boolean teach;
    
    private Set<String> role;
    
    private List<Integer> language;
    
    private List<Integer> level;
    
	public List<Integer> getLanguage() {
		return this.language;
	}

	public void setLanguage(List<Integer> language) {
		this.language = language;
	}

	public List<Integer> getLevel() {
		return this.level;
	}

	public void setLevel(List<Integer> level) {
		this.level = level;
	}

	public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
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
		return descriptions;
	}

	public void setDescription(String descriptions) {
		this.descriptions = descriptions;
	}

	public boolean isTeach() {
		return teach;
	}

	public void setTeach(boolean teach) {
		this.teach = teach;
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
    
    public Set<String> getRole() {
    	return this.role;
    }
    
    public void setRole(Set<String> role) {
    	this.role = role;
    }
}
