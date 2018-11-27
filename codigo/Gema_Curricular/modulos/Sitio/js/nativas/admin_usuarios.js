function Constructor_usuario()
{
    var u = {
            id: document.getElementById("").value,
            rut: document.getElementById("").value,
            nombres: document.getElementById("").value,
            apellido_paterno: document.getElementById("").value,
            apellido_materno: document.getElementById("").value,
            clave: document.getElementById("").value,
            perfil: document.getElementById("").value,
            sexo: document.getElementById("").value,
            fecha_nacimiento: document.getElementById("").value,
            eliminado: document.getElementById("").value 
    };
    
    return u;
}

function Empaquetar_usuario()
{
    var u = Constructor_usuario();
    
    var paquete = u.id + 
        "\t" + u.rut + 
        "\t" + u.nombres + 
        "\t" + u.apellido_paterno + 
        "\t" + u.apellido_materno + 
        "\t" + u.clave + 
        "\t" + u.perfil + 
        "\t" + u.sexo + 
        "\t" + u.fecha_nacimiento + 
        "\t" + u.eliminado;
        
    return paquete;
}

function Desempaquetar_usuario(paquete)
{
    var partes = paquete.split("\t");
    var i = 0;
    
    var u = {
            id: partes[i++],
            rut: partes[i++],
            nombres: partes[i++],
            apellido_paterno: partes[i++],
            apellido_materno: partes[i++],
            clave: partes[i++],
            perfil: partes[i++],
            sexo: partes[i++],
            fecha_nacimiento: partes[i++],
            eliminado: partes[i++] 
    };
    
    return u;
}

function Adicionar_usuario()
{
    if(!Validar_usuario())
    {
        return;
    }
    
    var direccion = "./comunicadores/Comunicador.aspx";
    var datos = {opcion: 1, 
                 paquete: Empaquetar_usuario()};
    
    var inicio_envio = "";
    
    var llegada = function(datos)
    {
        if(datos == "0")
        {
            alert("El usuario se adicionó correctamente");
            Limpiar_ventana();
        }
        else
        {
            Mostrar_mensaje_error(datos);
        }
    };
    
    var problemas = function(obj_error)
    {
        //alert(obj_error.responseText);
        
        Mostrar_mensaje_error("Ocurrió un problema durante la comunicación con el servidor");
    }
    
    Enviar_ajax(direccion, datos, inicio_envio, llegada, problemas);
}

function Validar_usuario()
{
    var u = Constructor_usuario();
    
    if(u.rut == "")
    {
        alert("Debe especificar el rut");
        return false;
    }
    
    
    
    return true;
}


function Limpiar_ventana()
{
    document.getElementById("").value;
}








