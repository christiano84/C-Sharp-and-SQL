select * from employee order by sex, first_name, last_name;

select * from employee LIMIT 5;

select first_name AS forename, last_name AS surname from employee;

select distinct first_name from employee;

select count(emp_id) from employee where sex = 'F' and birth_day > '1970-01-01';

select avg(salary) from employee;

select avg(salary) from employee where sex = 'm';

select sum(salary) from employee;

select sum(total_sales), emp_id from works_with group by emp_id;

select sum(total_sales), client_id from works_with group by client_id;

select * from branch_supplier where supplier_name like '%label%';

-- Find any employee born in October
select * from employee where birth_day like '____-10%';

-- Find any clients who are schools

select * from client where client_name like '%school%';

-- Find a list of employee and branch names

select first_name from employee
union
select branch_name from branch;

-- Find a list of all clients & branch suppliers' names

select client_name from client 
union
select supplier_name from branch_supplier;

-- Find a list of all money spent or earned by the company

select salary from employee
union
select total_sales from works_with;


-- Find all branches and the names of their managers

select employee.emp_id, employee.first_name, branch.branch_name
from employee 
join branch
on employee.emp_id = branch.mgr_id

-- Find names of all employees who have sold over 30,000 to a single client

select employee.emp_id, employee.first_name, employee.last_name from employee where employee.emp_id  in  (
    select works_With.emp_id from works_with where works_with.total_sales > 30000
);

-- Find all clients who are handled by the branch
-- that Michael Scott manages
-- Assume you know Michael's ID

select client_name from client where branch_id = (
    select branch_id from branch where mgr_id = 102 limit 1
);

-- % = any # characters, _ = one character

-- Find any client's who are an LLC
SELECT *
FROM client
WHERE client_name LIKE '%LLC';

-- Find any branch suppliers who are in the label business
SELECT *
FROM branch_supplier
WHERE supplier_name LIKE '% Label%';

-- Find any employee born on the 10th day of the month
SELECT *
FROM employee
WHERE birth_day LIKE '_____10%';

-- Find any clients who are schools
SELECT *
FROM client
WHERE client_name LIKE '%Highschool%';


-- Find a list of employee and branch names
SELECT employee.first_name AS Employee_Branch_Names
FROM employee
UNION
SELECT branch.branch_name
FROM branch;

-- Find a list of all clients & branch suppliers' names
SELECT client.client_name AS Non-Employee_Entities, client.branch_id AS Branch_ID
FROM client
UNION
SELECT branch_supplier.supplier_name, branch_supplier.branch_id
FROM branch_supplier;


-- CREATE
--     TRIGGER `event_name` BEFORE/AFTER INSERT/UPDATE/DELETE
--     ON `database`.`table`
--     FOR EACH ROW BEGIN
-- 		-- trigger body
-- 		-- this code is applied to every
-- 		-- inserted/updated/deleted row
--     END;

CREATE TABLE trigger_test (
     message VARCHAR(100)
);




DELIMITER $$
CREATE
    TRIGGER my_trigger BEFORE INSERT
    ON employee
    FOR EACH ROW BEGIN
        INSERT INTO trigger_test VALUES('added new employee');
    END$$
DELIMITER ;
INSERT INTO employee
VALUES(109, 'Oscar', 'Martinez', '1968-02-19', 'M', 69000, 106, 3);


DELIMITER $$
CREATE
    TRIGGER my_trigger BEFORE INSERT
    ON employee
    FOR EACH ROW BEGIN
        INSERT INTO trigger_test VALUES(NEW.first_name);
    END$$
DELIMITER ;
INSERT INTO employee
VALUES(110, 'Kevin', 'Malone', '1978-02-19', 'M', 69000, 106, 3);

DELIMITER $$
CREATE
    TRIGGER my_trigger BEFORE INSERT
    ON employee
    FOR EACH ROW BEGIN
         IF NEW.sex = 'M' THEN
               INSERT INTO trigger_test VALUES('added male employee');
         ELSEIF NEW.sex = 'F' THEN
               INSERT INTO trigger_test VALUES('added female');
         ELSE
               INSERT INTO trigger_test VALUES('added other employee');
         END IF;
    END$$
DELIMITER ;
INSERT INTO employee
VALUES(111, 'Pam', 'Beesly', '1988-02-19', 'F', 69000, 106, 3);


DROP TRIGGER my_trigger;

