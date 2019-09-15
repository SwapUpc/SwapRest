package com.upc.swap.service;

import java.util.List;

import com.upc.swap.entities.Lesson;

public interface ILessonServ extends CrudServ<Lesson>{
	public List<Lesson> findByStudent(int id);
	public List<Lesson> findByTeacher(int id);
}
