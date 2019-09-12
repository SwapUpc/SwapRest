package com.upc.swap.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.upc.swap.entities.Level;

@Repository
public interface ILevelRepo extends JpaRepository<Level, Integer>{

}
