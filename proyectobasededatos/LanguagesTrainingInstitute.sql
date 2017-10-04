DROP DATABASE TrainingInstitute;
CREATE DATABASE TrainingInstitute;
USE TrainingInstitute;

CREATE SCHEMA USUARIOS;
CREATE SCHEMA CLASES;

CREATE TABLE USUARIOS.T_Profesor
(
	id_Profesor BIGINT IDENTITY(1,1) NOT NULL,
	nombre_Profesor varchar(100) NOT NULL,
	telefono_Profesor varchar(30) NOT NULL,
	direccion_Profesor varchar(100) NOT NULL,
	total_Horas int NOT NULL,
	pago_Horas real NOT NULL,
	CONSTRAINT pk_Profesor PRIMARY KEY(id_Profesor)
);

INSERT INTO USUARIOS.T_Profesor (nombre_Profesor,telefono_Profesor,direccion_Profesor,total_Horas,pago_Horas) VALUES ('Jose Perez Lopez', 4443313884, 'Paseo de las aves #502',0,25.50);
SELECT * FROM USUARIOS.T_Profesor

CREATE TABLE CLASES.T_Horario
(
	id_Horario BIGINT IDENTITY(1,1) NOT NULL,
	hora_Inicio time NOT NULL,
	hora_Fin time NOT NULL,
	dias varchar(20) NOT NULL,
	CONSTRAINT pk_Horario PRIMARY KEY(id_Horario),
);

/*Creamos una regla, el campo solo aceptara estos valores*/
CREATE RULE regla_Horario_Dias As @var_dias IN( 'Sabatino','Diario','Terciado'); 
EXEC sp_bindrule 'regla_Horario_Dias','CLASES.T_Horario.dias'

INSERT INTO CLASES.T_Horario (hora_Inicio,hora_Fin,dias) VALUES ('5:00','6:00','Sabatino');
SELECT * FROM CLASES.T_Horario

CREATE TABLE CLASES.T_Curso
(
	id_Curso BIGINT IDENTITY(1,1) NOT NULL,
	nombre_Curso varchar(50) NOT NULL,
	cupo int NOT NULL,
	fecha_Inicio date NOT NULL,
	fecha_Fin date NOT NULL,
	costo_Hora real NOT NULL,
	tipo varchar(20) NOT NULL,
	id_Profesor BIGINT NOT NULL,
	id_Horario BIGINT NOT NULL,
	CONSTRAINT pk_Curso PRIMARY KEY(id_Curso),
	CONSTRAINT fk_Horario FOREIGN KEY(id_Horario) REFERENCES Clases.T_Horario(id_Horario),
	CONSTRAINT fk_Profesor FOREIGN KEY(id_Profesor) REFERENCES USUARIOS.T_Profesor(id_Profesor)
);

CREATE RULE regla_Curso_Tipo As @var_tipo IN( 'Frances','Inglés','Alemán','Japonés','Chino'); 
EXEC sp_bindrule 'regla_Curso_Tipo','CLASES.T_Curso.tipo'

INSERT INTO CLASES.T_Curso (nombre_Curso,cupo,fecha_Inicio,fecha_Fin,costo_Hora, tipo,id_Profesor,id_Horario) VALUES ('Curso 1',15,'2017-09-17','2017-12-17',35.50,'Inglés',1,1);
SELECT * FROM CLASES.T_Curso

CREATE TABLE USUARIOS.T_Alumno
(
	id_Alumno BIGINT IDENTITY(1,1) NOT NULL,
	nombre_Alumno varchar(100) NOT NULL,
	telefono_Alumno varchar(30) NOT NULL,
	correo_Alumno varchar(100) NOT NULL,
	direccion_Alumno varchar(100) NOT NULL,
	adeudo_Alumno int NOT NULL,
	CONSTRAINT pk_Alumno PRIMARY KEY(id_Alumno),
);
drop table USUARIOS.T_Alumno

INSERT INTO USUARIOS.T_Alumno (nombre_Alumno, telefono_Alumno,correo_Alumno, direccion_Alumno ,adeudo_Alumno) VALUES ('Sergio Arturo Torres Ramirez',4443313884,'spartan.blue@hotma','Paseo de las aves#201',0);
SELECT * FROM  USUARIOS.T_Alumno

CREATE TABLE USUARIOS.T_Administrador
(
	id_Administrador BIGINT IDENTITY(1,1) NOT NULL,
	nombre_Administrador varchar(100) NOT NULL,
	telefono_Administrador varchar(50) NOT NULL,
	correo_Administrador varchar(100) NOT NULL,
	direccion_Administrador varchar(100) NOT NULL,
	hora_Ent time NOT NULL,
	hora_Sal time NOT NULL,
	CONSTRAINT pk_Administrador PRIMARY KEY(id_Administrador)
);
INSERT INTO USUARIOS.T_Administrador(nombre_Administrador, telefono_Administrador,correo_Administrador, direccion_Administrador ,hora_Ent,hora_Sal) VALUES ('Sergio Arturo Torres Ramirez',4443313884,'spartan.blue@hotma','Paseo de las aves#201','00:23:00','00:40:02');
SELECT * FROM  USUARIOS.T_Administrador
CREATE TABLE CLASES.T_Comentario
(
	id_Comentario BIGINT IDENTITY(1,1) NOT NULL,
	usuario_Comentario varchar(50) NOT NULL,
	tipo_Usuario varchar(20) NOT NULL,
	comentario varchar(200) NOT NULL,
	CONSTRAINT pk_Comentario PRIMARY KEY(id_Comentario)
);

CREATE RULE regla_Comentario_Tipo_Usuario As @var_tipo_usuario IN( 'Administrador','Alumno','Profesor'); 
EXEC sp_bindrule 'regla_Comentario_Tipo_Usuario','CLASES.T_Comentario.tipo_Usuario'

CREATE TABLE CLASES.T_Recurso
(
	id_Recurso BIGINT IDENTITY(1,1) NOT NULL,
	tipo_Recurso varchar(20) NOT NULL,
	tamaño varchar(20) NOT NULL,
	id_Admnistrador BIGINT NOT NULL,
	id_Comentario BIGINT NOT NULL,
	contenido varchar(200) NOT NULL,
	CONSTRAINT pk_Recurso PRIMARY KEY(id_Recurso),
	CONSTRAINT fk_Administrador FOREIGN KEY(id_Admnistrador) REFERENCES USUARIOS.T_Administrador(id_Administrador),
	CONSTRAINT fk_Comentario FOREIGN KEY(id_Comentario) REFERENCES CLASES.T_Comentario(id_Comentario)
);

CREATE RULE regla_Recurso_Tipo_Recurso As @var_tipo_recurso IN( 'Imágen','Video','Documento','Vacio'); 
EXEC sp_bindrule 'regla_Recurso_Tipo_Recurso','CLASES.T_Recurso.tipo_Recurso'

CREATE TABLE CLASES.T_Asistencia
(
	id_Asistencia BIGINT IDENTITY(1,1) NOT NULL,
	id_Profesor BIGINT NOT NULL,
	num_Horas int NOT NULL,
	fecha_hora datetime NOT NULL,
	CONSTRAINT pk_Asistencia PRIMARY KEY(id_Asistencia),
	CONSTRAINT fk_Profesor1 FOREIGN KEY(id_Profesor) REFERENCES USUARIOS.T_Profesor(id_Profesor)
);

INSERT INTO CLASES.T_Asistencia (id_Profesor,num_Horas,fecha_hora) VALUES (1,4,'18-09-2017')

CREATE TABLE CLASES.T_Pago_Sueldo
(
	id_Pago BIGINT IDENTITY(1,1) NOT NULL,
	horasPagadas BIGINT NOT NULL,
	fecha_hora datetime NOT NULL,
	id_Admnistrador BIGINT NOT NULL,
	id_Profesor BIGINT NOT NULL,
	CONSTRAINT pk_Pago PRIMARY KEY(id_Pago),
	CONSTRAINT fk_Administrador1 FOREIGN KEY(id_Admnistrador) REFERENCES USUARIOS.T_Administrador(id_Administrador),
	CONSTRAINT fk_Profesor2 FOREIGN KEY(id_Profesor) REFERENCES USUARIOS.T_Profesor(id_Profesor)
);
DROP TABLE CLASES.T_Pago_Sueldo
CREATE TABLE CLASES.T_Inscripcion
(
	id_Inscripcion BIGINT IDENTITY(1,1) NOT NULL,
	monto real NOT NULL,
	fecha_hora datetime NOT NULL,
	id_Admnistrador BIGINT NOT NULL,
	id_Alumno BIGINT NOT NULL,
	id_Curso BIGINT NOT NULL,
	CONSTRAINT pk_Inscripcion PRIMARY KEY(id_Inscripcion),
	CONSTRAINT fk_Administrador2 FOREIGN KEY(id_Admnistrador) REFERENCES USUARIOS.T_Administrador(id_Administrador),
	CONSTRAINT fk_Alumno FOREIGN KEY(id_Alumno) REFERENCES USUARIOS.T_Alumno(id_Alumno),
	CONSTRAINT fk_Curso FOREIGN KEY(id_Curso) REFERENCES CLASES.T_Curso(id_Curso)
);


--Al eliminar un alumno de un grupo, aumenta su cupo--
CREATE TRIGGER TR_INCREMENTA_CUPO_CURSO
ON USUARIOS.T_Alumno
AFTER DELETE
AS
BEGIN	
	UPDATE CLASES.T_Curso SET cupo=cupo+1
	WHERE id_Curso=(SELECT id_curso FROM CLASES.T_Inscripcion 
						WHERE  id_Alumno =(SELECT id_Alumno from deleted));
END

DROP TRIGGER  TR_INCREMENTA_CUPO_CURSO

-- Al realizar la inscripcion de un alumno a algun curso, disminuye el cupo del curso--
CREATE TRIGGER TR_DECREMENTA_CUPO_CURSO
ON CLASES.T_Inscripcion
AFTER INSERT AS
BEGIN	
	UPDATE CLASES.T_Curso SET cupo=cupo-1
	WHERE id_Curso=(SELECT id_Curso from inserted)
END

-- Cuando se registra una asistencia del profesor, se aumentan las horas impartidas al profesor--
CREATE TRIGGER TR_INCREMENTA_TOTAL_HORAS_PROFESOR
ON CLASES.T_Asistencia
AFTER INSERT
AS
BEGIN	
	UPDATE USUARIOS.T_Profesor SET total_Horas = total_Horas + (SELECT num_Horas FROM inserted)
	WHERE id_Profesor=(SELECT id_Profesor from inserted)
END
-- Cuando se elimina una asistencia del profesor, se decrementa las horas impartidas al profesor--
CREATE TRIGGER TR_Decrementa_Asis_TOTAL_HORAS_PROFESOR
ON CLASES.T_Asistencia
AFTER DELETE
AS
BEGIN	
	UPDATE USUARIOS.T_Profesor SET total_Horas = total_Horas - (SELECT num_Horas FROM deleted)
	WHERE id_Profesor=(SELECT id_Profesor from deleted)
END

Drop TRIGGER TR_INCREMENTA_TOTAL_HORAS_PROFESOR
-- Al realizar un pago al profesor, descontar las horas pagadas a las horas impartidas--

CREATE TRIGGER TR_DECREMENTA_TOTAL_HORAS_PROFESOR
ON  CLASES.T_Pago_Sueldo
AFTER INSERT
AS
BEGIN	
	UPDATE USUARIOS.T_Profesor SET total_Horas = total_Horas - (SELECT horasPagadas FROM inserted)
	WHERE id_Profesor=(SELECT id_Profesor from inserted)
END

-- Al eliminar un alumno, eliminar del curso --
CREATE TRIGGER TR_ELIMINA_ALUMNO_DE_CURSO
ON USUARIOS.T_Alumno
AFTER DELETE
AS
BEGIN	
	DELETE FROM CLASES.T_Curso 
	WHERE id_Curso =(SELECT id_Curso from CLASES.T_Inscripcion 
					WHERE  id_Alumno = (SELECT id_Alumno from deleted))
END

-- Al eliminar un curso, eliminar las inscripciones

CREATE TRIGGER TR_ELIMINA_INSCRIPCION_CURSO
ON CLASES.T_Curso
AFTER DELETE
AS
BEGIN	
	DELETE FROM CLASES.T_Inscripcion
	WHERE id_Curso =(SELECT id_Curso from deleted)
END


-- Al realizar un update de pago sueldo si el numero de horas pagadas es diferente:
-- Si se modifica por una cantidad menor de horas pagadas sumar la diferencia a total_horas del profesor
-- Si se modifica por una cantidad menor de horas pagadas restar la diferencia a total_horas del profesor


CREATE TRIGGER REVIZA_PAGO_HORAS_PROFESOR
ON  CLASES.T_Pago_Sueldo
FOR UPDATE
AS 
BEGIN
	
	UPDATE  USUARIOS.T_Profesor SET total_Horas = total_Horas + ((SELECT horasPagadas FROM deleted ) - (SELECT horasPagadas FROM inserted)) WHERE id_Profesor = (SELECT id_Profesor FROM inserted)
END

-- Al realizar un update de Asistencia si el numero de horas impartidas es diferente:
-- Si se modifica por una cantidad menor de horas impartidas restar la diferencia a total_horas del profesor
-- Si se modifica por una cantidad mayor de horas impartidas sumar la diferencia a total_horas del profesor


CREATE TRIGGER REVIZA_HORAS_IMPARTIDAS_PROFESOR
ON  CLASES.T_Asistencia
FOR UPDATE
AS 
BEGIN
	
	UPDATE  USUARIOS.T_Profesor SET total_Horas = total_Horas - ((SELECT num_Horas FROM deleted ) - (SELECT num_Horas FROM inserted)) WHERE id_Profesor = (SELECT id_Profesor FROM inserted)
END

DROP TRIGGER REVIZA_PAGO_HORAS_PROFESOR