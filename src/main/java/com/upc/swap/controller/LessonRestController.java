package com.upc.swap.controller;

import java.util.List;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.upc.swap.entities.Lesson;
import com.upc.swap.service.ILessonServ;

import io.swagger.annotations.ApiOperation;

@CrossOrigin(origins = "*", maxAge = 3600)
@RestController
@RequestMapping("/api/lesson")
public class LessonRestController {
	
	@Autowired
	ILessonServ lessonServ;
	
	@GetMapping("/")
	@ApiOperation(value="Method To return all lessons")
	@PreAuthorize("hasRole('ADMIN')")
	public List<Lesson> viewAllLessons(){
		List<Lesson> listado = lessonServ.getAll();
		return listado;
	}
	
	@PostMapping("/")
	@ApiOperation(value="Method Register a lesson between a student and a teacher")
	@PreAuthorize("hasRole('USER') or hasRole('ADMIN')")
	public ResponseEntity<?> createLesson(@RequestBody @Valid Lesson obj){
		try {
			boolean flag = lessonServ.save(obj);
			if(flag) {
				return new ResponseEntity<Object>(HttpStatus.OK);
			}else {
				return new ResponseEntity<Object>(HttpStatus.INTERNAL_SERVER_ERROR);
			}
		} catch (Exception e) {
			return new ResponseEntity<Object>(HttpStatus.INTERNAL_SERVER_ERROR);
		}
	}
}
