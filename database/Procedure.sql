CREATE PROC SP_Mostrar
AS
SELECT * FROM Alumno

--Insertar datos

CREATE PROC SP_Insertar
@alu_id INT,
@alu_name NVARCHAR (30),
@alu_lastname NVARCHAR (30),
@alu_sexo NVARCHAR (12)
AS
INSERT INTO Alumno Values (@alu_id, @alu_name, @alu_lastname, @alu_sexo)


--Modificar datos

CREATE PROC SP_Modificar
@alu_id INT,
@alu_name NVARCHAR (30),
@alu_lastname NVARCHAR (30),
@alu_sexo NVARCHAR (12)
AS
UPDATE Alumno SET alu_name = @alu_name, alu_lastname = @alu_lastname, alu_sexo = @alu_sexo
WHERE alu_id = @alu_id

-- Eliminar datos

CREATE PROC SP_Eliminar
@alu_id INT
AS
DELETE Alumno WHERE alu_id = @alu_id


--BUSCAR DATOS

CREATE PROC SP_Buscar
@Buscar NVARCHAR (30)
AS
SELECT * FROM Alumno 
WHERE alu_name LIKE @Buscar + '%'

