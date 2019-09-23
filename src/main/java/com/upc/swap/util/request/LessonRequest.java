package com.upc.swap.util.request;

import java.util.Date;

import javax.persistence.ManyToOne;
import javax.persistence.OneToOne;
import javax.validation.constraints.FutureOrPresent;
import javax.validation.constraints.NotNull;

import org.springframework.format.annotation.DateTimeFormat;
import io.swagger.annotations.ApiModelProperty;

public class LessonRequest {
	@ManyToOne
	@ApiModelProperty(value="lesson's student")
	private int student;
	
	@ManyToOne
	@ApiModelProperty(value="lesson's teacher")
	private int teacher;
	
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
	private int task;

	public int getStudent() {
		return student;
	}

	public void setStudent(int student) {
		this.student = student;
	}

	public int getTeacher() {
		return teacher;
	}

	public void setTeacher(int teacher) {
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

	public int getTask() {
		return task;
	}

	public void setTask(int task) {
		this.task = task;
	}

}
