DELIMITER //
CREATE PROCEDURE create_customer
(IN name VARCHAR(20),phone VARCHAR(20),email VARCHAR(50))
BEGIN
    INSERT INTO customers (customers.name, customers.phone, customers.email) VALUES (name,phone,email);
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE create_customer_user
(IN fname VARCHAR(20),lname VARCHAR(20),customer INT, phone VARCHAR(20), email VARCHAR(50))
BEGIN
    INSERT INTO customer_users (customer_users.first_name, customer_users.last_name, customer_users.customer, customer_users.phone, customer_users.email) VALUES (fname,lname,customer,phone,email);
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE create_employee
(IN fname VARCHAR(20),lname VARCHAR(20), phone VARCHAR(20), email VARCHAR(50))
BEGIN
    INSERT INTO employees (employees.first_name, employees.last_name, employees.phone, employees.email) VALUES (fname,lname,phone,email);
END //
DELIMITER ;
