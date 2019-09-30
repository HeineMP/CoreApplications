--Create table code. 

CREATE TABLE employees (
	emp_no INT PRIMARY KEY AUTO_INCREMENT,
	birth_date DATE,
	first_name VARCHAR(14),
	last_name VARCHAR(16),
	sex ENUM('M','F'),
	hire_date DATE
);

CREATE TABLE title (
	emp_no INT FOREIGN KEY,
	title VARCHAR(50) PRIMARY KEY,
	from_date DATE,
	to_date DATE
);

CREATE TABLE salaries (
	emp_no INT FOREIGN KEY,
	salary INT,
	from_date DATE KEY,
	to_date DATE KEY,
);

CREATE TABLE dept_manager (
	dept_no CHAR(4) PRIMARY KEY,
	emp_no INT FOREIGN KEY,
	from_date DATE,
	to_date DATE,
);

CREATE TABLE department (
	dept_no CHAR(4) PRIMARY KEY,
	dept_emp VARCHAR(40),
);

CREATE TABLE dept_emp (
	emp_no INT FOREIGN KEY,
	dept_emp INT FOREIGN KEY,
	from_date DATE,
	to_date DATE,
);