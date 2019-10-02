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

DELIMITER //
CREATE PROCEDURE create_status
(IN title VARCHAR(30))
BEGIN
    INSERT INTO status (status.title) VALUES (title);
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE create_case
(IN short_description VARCHAR(100), description TEXT, customer_user INT, case_employee INT, status INT)
BEGIN
    INSERT INTO cases (cases.short_description, cases.description, cases.customer_user, cases.case_employee, cases.status) VALUES (short_description,description,customer_user,case_employee,status);
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE update_case
(IN id INT, short_description VARCHAR(100), description TEXT, customer_user INT, case_employee INT, status INT, time_spent FLOAT(4), hidden_information TEXT)
BEGIN
    UPDATE cases SET cases.short_description=short_description, cases.description=description, cases.customer_user=customer_user, cases.case_employee=case_employee, cases.status=status, cases.time_spent=time_spent, cases.hidden_information=hidden_information WHERE cases.id=id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE update_customer
(IN id INT, name VARCHAR(20), contact_person INT, phone VARCHAR(20), email VARCHAR(50))
BEGIN
    UPDATE customers SET customers.name=name, customers.contact_person=contact_person, customers.phone=phone, customers.email=email WHERE customers.id=id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE update_customer_contact_person
(IN id INT, contact_person INT)
BEGIN
    UPDATE customers SET customers.contact_person=contact_person WHERE customers.id=id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE update_customer_user
(IN id INT, fname VARCHAR(20), lname VARCHAR(20), phone VARCHAR(20), email VARCHAR(50))
BEGIN
    UPDATE customer_users SET customer_users.first_name=fname, customer_users.last_name=lname, customer_users.phone=phone, customer_users.email=email WHERE customer_users.id=id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE update_employee
(IN id INT, fname VARCHAR(20), lname VARCHAR(20), phone VARCHAR(20), email VARCHAR(50))
BEGIN
    UPDATE employees SET employees.first_name=fname, employees.last_name=lname, employees.phone=phone, employees.email=email WHERE employees.id=id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE delete_customer_user
(IN id INT)
BEGIN
    DELETE FROM customer_users WHERE customer_users.id=id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE delete_case
(IN id INT)
BEGIN
    DELETE FROM cases WHERE cases.id=id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_case
(IN id INT)
BEGIN
    SELECT * FROM cases WHERE cases.id=id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_customer_user
(IN id INT)
BEGIN
    SELECT * FROM customer_users WHERE customer_users.id=id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_customer
(IN id INT)
BEGIN
    SELECT * FROM customers WHERE customers.id=id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_employee
(IN id INT)
BEGIN
    SELECT * FROM employees WHERE employees.id=id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_status
(IN id INT)
BEGIN
    SELECT * FROM status WHERE status.id=id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_all_status
()
BEGIN
    SELECT * FROM status;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_all_cases
()
BEGIN
    SELECT * FROM cases;
END //
DELIMITER ;