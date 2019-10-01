CREATE TABLE `customers` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`name` varchar(20) NOT NULL UNIQUE,
	`contact_person` INT,
	`phone` varchar(20) NOT NULL,
	`email` varchar(50) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `customer_users` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`first_name` varchar(20) NOT NULL,
	`last_name` varchar(20) NOT NULL,
	`customer` INT NOT NULL,
	`phone` varchar(20),
	`email` varchar(50) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `cases` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`short_description` varchar(100) NOT NULL,
	`description` TEXT NOT NULL,
	`customer` INT NOT NULL,
	`customer_user` INT,
	`case_employee` INT NOT NULL,
	`status` INT NOT NULL,
	`time_spent` FLOAT(4),
	`hidden_information` TEXT,
	PRIMARY KEY (`id`)
);

CREATE TABLE `employees` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`first_name` varchar(20) NOT NULL,
	`last_name` varchar(20) NOT NULL,
	`phone` varchar(20),
	`email` varchar(50) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `status` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`title` varchar(30) NOT NULL UNIQUE,
	PRIMARY KEY (`id`)
);

ALTER TABLE `customers` ADD CONSTRAINT `customers_fk0` FOREIGN KEY (`contact_person`) REFERENCES `customer_users`(`id`);

ALTER TABLE `customer_users` ADD CONSTRAINT `customer_users_fk0` FOREIGN KEY (`customer`) REFERENCES `customers`(`id`);

ALTER TABLE `cases` ADD CONSTRAINT `case_fk0` FOREIGN KEY (`customer_user`) REFERENCES `customer_users`(`id`);

ALTER TABLE `cases` ADD CONSTRAINT `case_fk1` FOREIGN KEY (`case_employee`) REFERENCES `employees`(`id`);

ALTER TABLE `cases` ADD CONSTRAINT `case_fk2` FOREIGN KEY (`status`) REFERENCES `status`(`id`);

ALTER TABLE `cases` ADD CONSTRAINT `case_fk3` FOREIGN KEY (`customer`) REFERENCES `customers`(`id`);