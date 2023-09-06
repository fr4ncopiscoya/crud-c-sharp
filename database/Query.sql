use [crud-ncapas];

create table alumnos(
alu_id INT PRIMARY KEY,
alu_name NVARCHAR (30),
alu_lastname NVARCHAR (30),
alu_sexo NVARCHAR (12)
);

SELECT * FROM alumnos;