

CREATE TABLE asignatura(
	id int IDENTITY(1,1) NOT NULL,
	nombre varchar(max) NOT NULL,
	peso float NOT NULL,
 CONSTRAINT PK_asignatura PRIMARY KEY CLUSTERED 
(
	id ASC
)
);

--------------------------------------------------------------------------------

CREATE TABLE carrera(
	id int IDENTITY(1,1) NOT NULL,
	id_nombre_facultad int NOT NULL,
	id_nombre_carrera int NOT NULL,
 CONSTRAINT PK_carrera PRIMARY KEY CLUSTERED 
(
	id ASC
)
);

--------------------------------------------------------------------------------

CREATE TABLE nombre_grupo(
	id int IDENTITY(1,1) NOT NULL,
	nombre varchar(max) NOT NULL,
	id_categoria int NOT NULL,
 CONSTRAINT PK_nombre_grupo PRIMARY KEY CLUSTERED 
(
	id ASC
)
);

--------------------------------------------------------------------------------

CREATE TABLE seccion(
	id int IDENTITY(1,1) NOT NULL,
	
	id_nombre int NOT NULL,
    id_nombre_sede int NOT NULL,
    id_facultad int NOT NULL,
    id_entidad_carrera int NOT NULL,
    anno int NOT NULL,
    nivel int NOT NULL,
    id_periodo int NOT NULL,

 CONSTRAINT PK_seccion PRIMARY KEY CLUSTERED 
(
	id ASC
)
);


--------------------------------------------------------------------------------


CREATE TABLE usuario(
	id int IDENTITY(1,1) NOT NULL,
	
	rut varchar(max) NOT NULL,
    nombres varchar(max) NOT NULL,
    apellido_paterno varchar(max) NOT NULL,
    apellido_materno varchar(max) NOT NULL,
    clave varchar(max) NOT NULL,
    id_perfil int NOT NULL,
    sexo varchar(1) NOT NULL,
    fecha_nacimiento datetime NOT NULL,
    fecha_creacion datetime NOT NULL,
    eliminado bit NOT NULL,
    

 CONSTRAINT PK_usuario PRIMARY KEY CLUSTERED 
(
	id ASC
)
);

--------------------------------------------------------------------------------


CREATE TABLE categoria(
	id int IDENTITY(1,1) NOT NULL,
	nombre varchar(MAX) NOT NULL,
    id_tipo_categoria int NOT NULL,
    peso float NOT NULL,
 CONSTRAINT PK_categoria PRIMARY KEY CLUSTERED 
(
	id ASC
)
);

--------------------------------------------------------------------------------

CREATE TABLE relacion_categorias(
	id_padre int NOT NULL,
	id_hija int NOT NULL    
);

--------------------------------------------------------------------------------

CREATE TABLE perfil_egreso(
	id int IDENTITY(1,1) NOT NULL,
	nombre varchar(MAX) NOT NULL,
    descripcion varchar(MAX) NOT NULL,
    peso float NOT NULL,
 CONSTRAINT PK_perfil_egreso PRIMARY KEY CLUSTERED 
(
	id ASC
)
);

--------------------------------------------------------------------------------

CREATE TABLE rel_perf_eg_amb_des(
	id_perfil_egreso int  NOT NULL,
    ambito varchar(MAX) NOT NULL
);

--------------------------------------------------------------------------------

CREATE TABLE rel_perf_eg_cat(
	id_perfil int NOT NULL,
	id_categoria int NOT NULL    
);

--------------------------------------------------------------------------------



