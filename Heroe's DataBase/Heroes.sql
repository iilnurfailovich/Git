CREATE DATABASE [Heroes]

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Heroes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

use Heroes

create table Superheroes (
id bigint not null identity primary key,
name varchar(30) not null,
true_name varchar(30) not null,
year_of_birth numeric(4),
plase_of_birth varchar(30) not null
);

insert into superheroes values ('One punch man', 'Saitama', 1993, 'unknown');
insert into superheroes values ('Batman', 'Bruce', 1972, 'Gotham');
insert into superheroes values ('Superman', 'Clarke', 1980, 'Krypton');
insert into superheroes values ('Flash', 'Barry', 1989, 'Central City');
insert into superheroes values ('Iron man', 'Tony', 1970, 'New York');
insert into superheroes values ('Spider man', 'Peter', 2001, 'New York');
insert into superheroes values ('Captain marvel', 'Carol', 1985, 'Boston');

create table Superpowers (
id bigint not null identity primary key,
superpower_name varchar(30) not null
);

insert into superpowers values ('levitation');
insert into superpowers values ('hyperspeed');
insert into superpowers values ('invulnerability');
insert into superpowers values ('superhuman power');
insert into superpowers values ('high intelligence');
insert into superpowers values ('superhuman reflex');

create table Superhero_Superpowers (
Superhero_id bigint not null,
Superpower_id bigint not null,
usage_assessment bigint,
foreign key(superhero_id) references Superheroes(id),
foreign key(superpower_id) references Superpowers(id)
);

insert into Superhero_Superpowers values (1,4,10);
insert into Superhero_Superpowers values (2,5,6);
insert into Superhero_Superpowers values (3,1,5);
insert into Superhero_Superpowers values (3,2,6);
insert into Superhero_Superpowers values (3,3,7);
insert into Superhero_Superpowers values (3,4,9);
insert into Superhero_Superpowers values (3,6,3);
insert into Superhero_Superpowers values (4,2,10);
insert into Superhero_Superpowers values (5,1,5);
insert into Superhero_Superpowers values (5,5,8);
insert into Superhero_Superpowers values (6,5,4);
insert into Superhero_Superpowers values (6,6,8);
insert into Superhero_Superpowers values (7,1,8);
insert into Superhero_Superpowers values (7,3,9);
insert into Superhero_Superpowers values (7,4,10);

select b.Name from  superheroes b
inner join superhero_superpowers a
on a.superhero_id = b.id 
Group by b.id, b.name
having COUNT(Superpower_id) > 2

select b.name, COUNT(Superpower_id)  from Superheroes b
inner join superhero_superpowers a
on a.superhero_id = b.id 
where usage_assessment > 5
GROUP BY Superhero_id, b.name
ORDER BY COUNT(Superpower_id) ASC;