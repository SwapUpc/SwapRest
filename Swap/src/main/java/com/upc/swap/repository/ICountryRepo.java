package com.upc.swap.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.upc.swap.entities.Country;

@Repository
public interface ICountryRepo extends JpaRepository<Country, Integer>{

}
