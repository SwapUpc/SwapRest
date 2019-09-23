package com.upc.swap.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.upc.swap.entities.Language;

@Repository
public interface ILanguageRepo extends JpaRepository<Language, Integer>{
}
