
function Enviar_ajax(direccion, datos, inicio_envio, llegada, problemas)
{
    Enviar_ajax_1(direccion, datos, inicio_envio, llegada, problemas, true);
}



function Enviar_ajax_sincrono(direccion, datos, inicio_envio, llegada, problemas)
{
    Enviar_ajax_1(direccion, datos, inicio_envio, llegada, problemas, false);
}



function Enviar_ajax_1(direccion, datos, inicio_envio, llegada, problemas, es_asincrono)
{
    var inicio_envio1 = function(){
        Mostrar_capa_espera();
        if(inicio_envio!="")
            inicio_envio();        
    }; 
    
    var llegada1 = function(datos){
        Ocultar_capa_espera();
        if(llegada!="")
            llegada(datos);        
    }; 
    
    var problemas1 = function(datos){
        Ocultar_capa_espera();
        if(problemas!="")
            problemas(datos);        
    }; 
    
    $.ajax({
        async: es_asincrono,
        type: "POST",
        dataType: "html",
        contentType: "application/x-www-form-urlencoded",
        url: direccion,
        data: datos,
        beforeSend: inicio_envio1,
        success: llegada1,
        timeout: 600000,
        error: problemas1
    });
}



function Enviar_formulario_por_ajax(direccion, formulario, inicio_envio, llegada, problemas)
{   
    var inicio_envio1 = function(){
        Mostrar_capa_espera();
        if(inicio_envio!="")
            inicio_envio();        
    }; 
    
    var llegada1 = function(datos){
        Ocultar_capa_espera();
        if(llegada!="")
            llegada(datos);        
    }; 
    
    var problemas1 = function(datos){
        Ocultar_capa_espera();
        if(problemas!="")
            problemas(datos);        
    }; 
            
    $.ajax({              
        beforeSend: inicio_envio1,
        timeout: 600000,
        error: problemas1,
        success: llegada1,
        
        url: direccion,
        type: "POST",
        data: formulario,
        contentType: false,
        processData: false
    });
}



function Enviar_archivo_por_ajax(direccion, id_control_file, inicio_envio, llegada, problemas)
{       
    var file1 = document.getElementById(id_control_file);
    if(file1.files.length > 0)
    {
        var datos = new FormData();
        datos.append("opcion", "subir_fichero");
        datos.append(id_control_file, file1.files[0]);
        
        var inicio_envio1 = function(){
            Mostrar_capa_espera();
            if(inicio_envio!="")
                inicio_envio();        
        }; 
        
        var llegada1 = function(datos){
            Ocultar_capa_espera();
            if(llegada!="")
                llegada(datos);        
        }; 
        
        var problemas1 = function(datos){
            Ocultar_capa_espera();
            if(problemas!="")
                problemas(datos);        
        }; 
                
        $.ajax({              
            beforeSend: inicio_envio1,
            timeout: 6000000,
            error: problemas1,
            success: llegada1,
            
            url: direccion,
            type: "POST",
            data: datos,
            contentType: false,
            processData: false
        });
    }
}



//RETORNA EL VALOR DE UNA VARIABLE DE NOMBRE "NAME", PASADA COMO PARÁMETRO EN LA DIRECCIÓN DE LA PÁGINA
function Retornar_variable_get(name)
{
    if(name=(new RegExp('[?&]'+encodeURIComponent(name)+'=([^&]*)')).exec(location.search))
      return decodeURIComponent(name[1]);
}



function Inicializar_ventana(id_ventana)
{
    $( id_ventana ).dialog({autoOpen: false, 
                            resizable: false, draggable: true, 
                            position: 
                            { 
                                my: "center", 
                                at: "center", 
                                of: "#capa_fondo"
                            }, 
                            width: "600px",
                            hide: "slide"
                            });
}



function Abrir_ventana_edicion(id_ventana, titulo, funcion_adicional)
{
    $( id_ventana ).dialog( "option", "title", titulo );
    $( id_ventana ).dialog( "open" );
    
    if(funcion_adicional != "")
        funcion_adicional(); //ESTA ES LA FUNCIÓN CON EL CÓDIGO PROPIO DE CADA PÁGINA
}



function Abrir_ventana_controles(id_ventana, titulo)
{
    $( id_ventana ).dialog( "option", "title", titulo );
    $( id_ventana ).dialog( "open" );
}



function Cerrar_ventana_edicion(id_ventana)
{
    $( id_ventana ).dialog( "close" );
    if(Limpiar_ventana != null)
        Limpiar_ventana();
}



function Cerrar_ventana_controles(id_ventana)
{
    $( id_ventana ).dialog( "close" );
}



function Mostrar_mensaje_error(mensaje)
{
    document.getElementById("mensaje_error").innerHTML = mensaje;    
    document.getElementById("capa_mensaje_error").style.display = "block";
}



function Mostrar_capa_espera()
{
    var capa = document.getElementById("ctl00_capa_espera");
    if(capa != null)
        capa.style.display = "block";
}



function Ocultar_capa_espera()
{
    var capa = document.getElementById("ctl00_capa_espera");
    if(capa != null)
        capa.style.display = "none";
}



function Reemplazar_imagen(id_control, ruta_imagen)
{
    document.getElementById(id_control).src=ruta_imagen;
}



function Get_fecha_actual()
{
    var fecha = new Date();
    var dia = fecha.getDate();
    var mes = fecha.getMonth() +1;
    var anno = fecha.getFullYear();
    
    if(dia < 10)
        dia = "0" + dia;
    if(mes < 10)
        mes = "0" + mes;
    
    fecha = dia + "/" + mes+ "/" + anno;
    return fecha;
}



function Get_fecha_hora_actual()
{
    var fecha = new Date();
    var dia = fecha.getDate();
    var mes = fecha.getMonth() +1;
    var anno = fecha.getFullYear();
    
    var hora = fecha.getHours();
    var minuto = fecha.getMinutes();
    
    if(dia < 10)
        dia = "0" + dia;
    if(mes < 10)
        mes = "0" + mes;
    if(hora < 10)
        hora = "0" +hora;
    if(minuto < 10)
        minuto = "0" + minuto;
    
    fecha = dia + "/" + mes+ "/" + anno + " " + hora + ":" + minuto;
    return fecha;
}



function Get_fecha_hora_segundo_actual()
{
    var fecha = new Date();
    var dia = fecha.getDate();
    var mes = fecha.getMonth() +1;
    var anno = fecha.getFullYear();
    
    var hora = fecha.getHours();
    var minuto = fecha.getMinutes();
    var segundos = fecha.getSeconds();
    
    if(dia < 10)
        dia = "0" + dia;
    if(mes < 10)
        mes = "0" + mes;
    if(hora < 10)
        hora = "0" +hora;
    if(minuto < 10)
        minuto = "0" + minuto;
    if(segundos < 10)
        segundos = "0" + segundos;
    
    fecha = dia + "/" + mes+ "/" + anno + " " + hora + ":" + minuto + ":" + segundos;
    return fecha;
}



function Reemplazar_string(texto, cadena_vieja, cadena_nueva) 
{
    return texto.split(cadena_vieja).join(cadena_nueva);
}



function Abrir_ventana_post(url, nombres_campos, valores_campos)
{
    var form = document.createElement("form");
    form.setAttribute("method", "post");
    form.setAttribute("action", url);     
    form.setAttribute("target", "view");
   
    for(var i = 0; i < nombres_campos.length; i++)
    {
        var campo1 = document.createElement("input"); 
        campo1.setAttribute("type", "hidden");
        campo1.setAttribute("name", nombres_campos[i]);
        campo1.setAttribute("value", valores_campos[i]);
        form.appendChild(campo1);       
    }
     
    document.body.appendChild(form);     
    var ventana = window.open('', 'view');     
    form.submit();
    document.body.removeChild(form);  
}


function zfill(valor, cantidad_ceros)
{
    valor = valor.toString();
    cantidad_ceros = cantidad_ceros - valor.length;
    for(var i = 0; i < cantidad_ceros; i++)
    {
        valor = "0" + valor;
    }
    return valor;
}


