package com.upc.swap.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.upc.swap.entities.Task;

@Repository
public interface ITaskRepo extends JpaRepository<Task, Integer>{

}
