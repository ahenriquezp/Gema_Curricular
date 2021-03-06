﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Perfil_Egreso.aspx.cs" Inherits="gema_curricular.web.Perfil_Egreso" %>

<!doctype html>
<html lang="es">
<head runat="server">

	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    
    
    
    <!-- INICIO ARCHIVOS JQUERY-UI -->
    <link rel="stylesheet" href="../js/jquery-ui/jquery-ui-1.11.4.custom/jquery-ui.min.css">
    <script src="../js/jquery-ui/jquery-ui-1.11.4.custom/external/jquery/jquery.js"></script>
    <script src="../js/jquery-ui/jquery-ui-1.11.4.custom/jquery-ui.min.js"></script>
    <!-- FIN ARCHIVOS JQUERY-UI -->
    
    

	<!-- ARCHIVOS CSS BOOTSTRAP 4 -->
 	<link type="text/css" rel="stylesheet" href="../css/bootstrap.min.css">

 	<!-- ARCHIVOS CSS PERSONALIZADOS -->
 	<link type="text/css" rel="stylesheet" href="../css/estilos.css">
 	<link rel="stylesheet" type="text/css" href="../css/perfil_egreso.css">

	<title>Perfil de Egreso</title>

</head>


<body>


	<nav class="navbar navbar-dark bg-dark navbar-expand-md fixed-top" id="barra_navegacion">
		<div class="container">      
		  <a href="#" class="navbar-brand">
		    <strong>PRONOSWORLD</strong>
		  </a>

		  <button type="button" class="navbar-toggler" data-toggle="collapse"
		  data-target="#menu-principal" aria-controls="menu-principal" aria-expanded="false"
		  aria-label="Desplegar menú de navegación">
		  <span class="navbar-toggler-icon"></span>
		  </button>

		  <div class="collapse navbar-collapse" id="menu-principal">
	    	<ul class="navbar-nav ml-auto">
			  <li class="nav-item"><a href="#" class="nav-link active">Inicio</a></li>
			  <li class="nav-item"><a href="#" class="nav-link">¿Quienes somos?</a></li>
			  <li class="nav-item"><a href="#" class="nav-link">Proyectos</a></li>
			</ul>
	      </div>
		</div>
	</nav>	

	<section class="container mt-5 py-3" id="seccion_categoria">
		<div class="row mt-3">
			<div class="col-3">				
			</div>

			<div class="col-6">
				<div class="shadow-lg p-3 mb-5 bg-white rounded">Nombre: 
					<form>
						<div class="form-group">				     
						    <select class="form-control" id="exampleFormControlSelect1">
						      <option>1</option>
						      <option>2</option>
						      <option>3</option>
						      <option>4</option>
						      <option>5</option>
						    </select>
						</div>
				      </form>	
				</div>	

				<div class="shadow-lg p-3 mb-5 bg-white rounded">Descripcion: 
					<form>
						<div class="form-group">				     
						   <textarea class="form-control" rows="3"></textarea>
						</div>
				      </form>	
				</div>			
			</div>

			<div class="col-3">				
			</div>			
		</div>

		<div class="row mt-3">
			<div class="col-12">
				<p class="text-dark-50 bg-danger text-center" style="background-color: #95caff !important;">  
				 <strong> LISTA AMBITOS DE DESEMPEÑO  </strong>      
				</p>
			</div>
		</div>

		<div class="row mt-3">
			<div class="col-12">
				<table class="table table-sm">				  
				  <tbody>
				    <tr>
				      <th scope="row">1</th>
				      <td>Mark</td>
				      <td>Otto</td>
				    </tr>
				    <tr>
				      <th scope="row">2</th>
				      <td>Jacob</td>
				      <td>Thornton</td>
				    </tr>
				  </tbody>
				</table>
			</div>
			
		</div>

		<div class="row mt-3">
			<div class="col-3">				
			</div>

			<div class="col-6">
			  <div class="shadow-lg p-3 mb-5 bg-white rounded">Ambito:
				<div class="input-group">
				  <input type="text" class="form-control" placeholder="" aria-label="" aria-describedby="basic-addon1">
				  <div class="input-group-append">
				    <button class="btn btn-success" type="button">Love it</button>
				  </div>
				</div>
			  </div>
			</div>

			<div class="col-3">				
			</div>
		</div>

		<div class="row mt-3">
			<div class="col-12">
				<p class="text-dark-50 bg-danger text-center" style="background-color: #95caff !important;">  
				 <strong> LISTA DE COMPETENCIAS  </strong>      
				</p>
			</div>
		</div>

		<div class="row mt-3">
				<h2></h2>
				<div class="col col-5">
					<div class="card mt-2 mb-2">
					  <ul class="list-group">
						<li class="list-group-item active">Cras justo odio</li>
						<li class="list-group-item">Dapibus ac facilisis in</li>
						<li class="list-group-item">Morbi leo risus</li>
					  </ul>
					</div>							
				</div>

				<div class="col col-2 align-self-center">
					
					<div class="row mt-2">
						<div class="col col-12 text-center">
							<button type="button" class="btn btn-outline-primary mt-2 mb-2">></button>
						</div>
						
					</div>
					<div class="row mb-2">
						<div class="col col-12 text-center">
							<button type="button" class="btn btn-outline-primary mt-2 mb-2"><</button>
						</div>
					</div>
									
				</div>

				<div class="col col-5">
					<div class="card mt-2 mb-2">
					  <ul class="list-group">
						<li class="list-group-item active">Cras justo odio</li>
						<li class="list-group-item">Dapibus ac facilisis in</li>
						<li class="list-group-item">Morbi leo risus</li>
					  </ul>
					</div>			
				</div>
				
			</div>

			<div class="row mt-3 align-items-center">
				<h2></h2>
				<div class="col-4 offset-8 text-center">					
					<button type="button" class="btn btn-warning mb-2 mt-2">Cancelar</button>
					<button type="button" class="btn btn-success mb-2 mt-2">Aceptar</button>
				</div>
				
			</div>
		</div>		
	</section>


	<!-- SECCION PIE DE PÁGINA -->
	
	<footer class="pie-de-pagina text-center text-md-right bg-dark text-white" id="barra_pie_pagina">
	  <div class="container">
	    <p class="m-0 py-3">Copyright © 2018. Todos los derechos reservados. </p>
	  </div>
	</footer>
	
</body>
</html>