package com.upc.swap.entities;

import java.util.Date;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.ManyToOne;
import javax.persistence.OneToOne;
import javax.persistence.Table;
import javax.validation.constraints.FutureOrPresent;
import javax.validation.constraints.NotNull;

import org.springframework.format.annotation.DateTimeFormat;

import io.swagger.annotations.ApiModelProperty;

@Entity
@Table(name="lessons")
public class Lesson {

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int id;
	
	@ManyToOne
	@ApiModelProperty(value="lesson's student")
	private User student;
	
	@ManyToOne
	@ApiModelProperty(value="lesson's teacher")
	private User teacher;
	
	@NotNull
	@ApiModelProperty(value="lesson's latitude")
	private double latitude;
	
	@NotNull
	@ApiModelProperty(value="lesson's lenght")
	private double lenght;
	
	@NotNull @FutureOrPresent
	@DateTimeFormat(pattern="yyyy-MM-dd")
	@ApiModelProperty(value="lesson's day")
	private Date day;
	
	@NotNull @FutureOrPresent
	@DateTimeFormat(pattern="hh:mm")
	@ApiModelProperty(value="lesson's hour")
	private Date hour;
	
	@OneToOne
	@ApiModelProperty(value="lesson's task")
	private Task task;

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public User getStudent() {
		return student;
	}

	public void setStudent(User student) {
		this.student = student;
	}

	public User getTeacher() {
		return teacher;
	}

	public void setTeacher(User teacher) {
		this.teacher = teacher;
	}

	public double getLatitude() {
		return latitude;
	}

	public void setLatitude(double latitude) {
		this.latitude = latitude;
	}

	public double getLenght() {
		return lenght;
	}

	public void setLenght(double lenght) {
		this.lenght = lenght;
	}

	public Date getDay() {
		return day;
	}

	public void setDay(Date day) {
		this.day = day;
	}

	public Date getHour() {
		return hour;
	}

	public void setHour(Date hour) {
		this.hour = hour;
	}

	public Task getTask() {
		return task;
	}

	public void setTask(Task task) {
		this.task = task;
	}
}
