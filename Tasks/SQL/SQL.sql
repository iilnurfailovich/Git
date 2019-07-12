-- создаем БД для хранения информации о сотрудниках.
create database if not exists Corporation;
-- создаем таблицу сотрудников, в которой для каждого сотрудника будет храниться информация о имени, фамилии, должности, зарплате.
use Corporation;
create table if not exists employees (
id int unsigned not null auto_increment primary key,
first_name VARCHAR(30) NOT NULL,
last_name VARCHAR(30) NOT NULL, 
salary int not null
);
-- добавляем сотрудников.
insert into employees ( id, first_name, last_name, salary ) values (null, 'Ivan', 'Codov', 50000);
insert into employees ( id, first_name, last_name, salary ) values (null, 'Max', 'Payne', 25000);
insert into employees ( id, first_name, last_name, salary ) values (null, 'Mussa', 'Halimdgan', 50000);
insert into employees ( id, first_name, last_name, salary ) values (null, 'Jack', 'Hillon', 100000);
insert into employees ( id, first_name, last_name, salary ) values (null, 'Tom', 'Gun', 200000);
insert into employees ( id, first_name, last_name, salary ) values (null, 'Sam', 'Rolton', 75000);
-- в соответствии с правилами нрмализации баз данных, необходимо добавить новую сущность "positions - должности". Создаем.
create table if not exists positions ( 
id int not null auto_increment primary key,
position_name varchar(30)
);
-- добавляем наименование должностей.
insert into positions (id, position_name) values (null, 'Tester');
insert into positions (id, position_name) values (null, 'IT developer');
insert into positions (id, position_name) values (null, 'System architect');
insert into positions (id, position_name) values (null, 'Team lead');
insert into positions (id, position_name) values (null, 'Director');
-- добавляем новое поле в таблицу employees. 
alter table employees add column position_id int(10) not null;
-- после создания таблицы positions дбавляем связь между записями в этой таблице и таблицы employees. 
update employees set position_id=1 where id=2;
update employees set position_id=2 where id in (1,3);
update employees set position_id=3 where id=6;
update employees set position_id=4 where id=4;
update employees set position_id=5 where id=5;
-- далее проставляем внешний ключ для таблицы employees. 
ALTER TABLE employees
    ADD FOREIGN KEY
    fk_position_id (position_id)
    REFERENCES positions (id);
    -- выводим всех сотрудиков вместе с занимаемыми ими должностями.
select employee.first_name, employee.last_name, employee.salary, position.position_name
from employees employee
inner join positions position on employee.position_id=position.id;
-- составляем запросы на выборку данных.
-- все сотрудники с зарплатами меньше 30 000 рублей. 
select * from employees where salary < 30000;
-- всех сотрудники, занимающие определённую должность (к примеру, Tester), с зарплатой меньше 30 000 рублей. 
select * from employees where position_id=1 and salary < 30000;
-- создаем таблицу связей Many-to-many для подчиненных и начальников.
CREATE TABLE chief_subordinate (
    chief_id INT(10) unsigned NULL,
    subordinate_id INT(10) unsigned NOT NULL,

    FOREIGN KEY (chief_id)
      REFERENCES employees(id),

    FOREIGN KEY (subordinate_id)
      REFERENCES employees(id)
) 
-- заполняем таблицу связей.
insert into chief_subordinate values (4,1) ;
insert into chief_subordinate values (4,2) ;
insert into chief_subordinate values (4,3) ;
insert into chief_subordinate values (4,6) ;
insert into chief_subordinate values (5,1) ;
insert into chief_subordinate values (5,2) ;
insert into chief_subordinate values (5,3) ;
insert into chief_subordinate values (5,4) ;
insert into chief_subordinate values (5,6) ;
-- напишем выборку подчиненных для начальника с id = 4.
select c.* -- выбираем все столбцы с таблицы employees для подчиненных.
from chief_subordinate a -- выборка из таблицы связей.
inner join employees b 
on a.chief_id = b.id -- присоединяем таблицу employees для начальников.
inner join employees c 
on a.subordinate_id = c.id -- присоединяем таблицу employees для подчиненных.
where chief_id = 4 -- условие выборки.

