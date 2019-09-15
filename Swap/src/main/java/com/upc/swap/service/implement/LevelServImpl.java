package com.upc.swap.service.implement;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.upc.swap.entities.Level;
import com.upc.swap.repository.ILevelRepo;
import com.upc.swap.service.ILevelServ;

@Service
public class LevelServImpl implements ILevelServ{

	@Autowired
	ILevelRepo levelRepo;
	
	@Override
	public boolean save(Level obj) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean update(Level obj) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean delete(int id) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public List<Level> getAll() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Optional<Level> findByid(int id) {
		return levelRepo.findById(id);
	}

}
