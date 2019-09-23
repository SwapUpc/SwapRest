package com.upc.swap.service.implement;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.upc.swap.entities.Lesson;
import com.upc.swap.repository.ILessonRepo;
import com.upc.swap.service.ILessonServ;

@Service
public class LessonServImpl implements ILessonServ {

	@Autowired
	ILessonRepo lessonRepo;
	
	@Override
	public boolean save(Lesson obj) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean update(Lesson obj) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean delete(int id) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public List<Lesson> getAll() {
		return lessonRepo.findAll();
	}

	@Override
	public Optional<Lesson> findByid(int id) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Lesson> findByStudent(int id) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Lesson> findByTeacher(int id) {
		// TODO Auto-generated method stub
		return null;
	}

}
