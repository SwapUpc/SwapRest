package com.upc.swap.service.implement;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.upc.swap.entities.Language;
import com.upc.swap.repository.ILanguageRepo;
import com.upc.swap.service.ILanguageServ;

@Service
public class LanguageServImpl implements ILanguageServ{

	@Autowired
	ILanguageRepo languageRepo;
	
	@Override
	public boolean save(Language obj) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean update(Language obj) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean delete(int id) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public List<Language> getAll() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Optional<Language> findByid(int id) {
		return languageRepo.findById(id);
	}
}
