
CREATE NONCLUSTERED INDEX IX_carrera ON carrera 
(
	id_nombre_facultad ASC,
	id_nombre_carrera ASC
);

--------------------------------------------------------------------------------

CREATE NONCLUSTERED INDEX IX_nombre_grupo ON nombre_grupo 
(
	id_categoria ASC
);

--------------------------------------------------------------------------------

CREATE NONCLUSTERED INDEX IX_seccion ON seccion 
(
	id_nombre ASC,
    id_nombre_sede ASC,
    id_facultad ASC,
    id_entidad_carrera ASC,
    anno ASC,
    nivel ASC,
    id_periodo ASC
);

--------------------------------------------------------------------------------

CREATE NONCLUSTERED INDEX IX_categoria ON categoria 
(
    id_tipo_categoria ASC
);

--------------------------------------------------------------------------------

CREATE NONCLUSTERED INDEX IX_relacion_categorias ON relacion_categorias 
(
    id_padre ASC,
    id_hija ASC
);

--------------------------------------------------------------------------------

CREATE NONCLUSTERED INDEX IX_rel_perf_eg_amb_des ON rel_perf_eg_amb_des
(
    id_perfil_egreso ASC
);

--------------------------------------------------------------------------------


CREATE NONCLUSTERED INDEX IX_rel_perf_eg_cat ON rel_perf_eg_cat 
(
    id_perfil ASC,
    id_categoria ASC
);

--------------------------------------------------------------------------------














