package com.upc.swap.service;

import java.util.List;
import java.util.Optional;

public interface CrudServ<T> {
	public boolean save(T obj);
	public boolean update(T obj);
	public boolean delete(int id);
	public List<T> getAll();
	public Optional<T> findByid(int id);
}
