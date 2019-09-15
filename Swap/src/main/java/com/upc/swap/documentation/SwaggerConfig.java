package com.upc.swap.documentation;

import java.util.ArrayList;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import springfox.documentation.builders.PathSelectors;
import springfox.documentation.builders.RequestHandlerSelectors;
import springfox.documentation.service.ApiInfo;
import springfox.documentation.service.Contact;
import springfox.documentation.service.VendorExtension;
import springfox.documentation.spi.DocumentationType;
import springfox.documentation.spring.web.plugins.Docket;
import springfox.documentation.swagger2.annotations.EnableSwagger2;

@Configuration
@EnableSwagger2
public class SwaggerConfig {
	public static final Contact API_CONTACT = 
			new Contact("Swap", "https://github.com/SwapUpc", "danieljimenezcanales@gmail.com");
	public static final ApiInfo API_INFO = 
			new ApiInfo("Swap REST Service",
					"Swap REST Service", 
					"1.0", 
					"http://www.google.com", 
					API_CONTACT, 
					"Free", 
					"http://www.google.com", 
					new ArrayList<VendorExtension>());
	@Bean
	public Docket api() {	
		return new Docket(DocumentationType.SWAGGER_2)
				.apiInfo(API_INFO);
	}
}