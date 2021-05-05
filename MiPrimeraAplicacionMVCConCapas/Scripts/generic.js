//const { Callbacks } = require("jquery");
//recibe el id
function get(id) {
    return document.getElementById(id).value;
}

function set(id, valor) {
    return document.getElementById(id).value = valor;
}

//limpiar los datos por input
function setName(id, valor) {
    return document.getElementsByName(id)[0].value = valor;
}

//limpiar los datos de formulario entero y si hay excepcion las deja tal cual
function LimpiarDatos(idFormulario,excepciones=[]) {
    var elementos = document.querySelectorAll("#"+idFormulario+" [name]");

    for (var i = 0; i < elementos.length; i++) {
        if (!excepciones.includes( elementos[i].name)) 

        elementos[i].value = "";
        
    }


}

//alerta de error
function Error(texto ="Ocurrio un error'") {

    Swal.fire({
        icon: 'error',
        title: 'Error',
        text: texto
        
    })

}

//alerta de existo
function Correcto(texto="Se realizo correctamente") {
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: texto,
        showConfirmButton: false,
        timer: 1500
    })

}


//alerta de confirmacion
function Confirmacion(texto = "Desea guadar los cambios?", title = "Confirmacion", callback) {
    return Swal.fire({
        title: title,
        text: texto,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si',
        cancelButtonText:'No'
    }).then((result) => {
        if (result.isConfirmed) {
            callback();
        }

    })
}

var objConfiguracionGlobal;
var objBusquedaGlobal;

function pintar(objConfiguracion, objBusqueda) {
    //CONFIGURACION URL ABSOLUTA
    var raiz = document.getElementById("hdfOculto").value;
    var urlAbsoluta = window.location.protocol + "//" +
        window.location.host + raiz + objConfiguracion.url;

    fetch(urlAbsoluta)
        .then(res => res.json())
        .then(res => {
            //VALIDACIONES
            var contenido = "";
            if (objBusqueda != undefined && objBusqueda.busqueda == true) {
                if (objBusqueda.placeholder == undefined) 
                    objBusqueda.placeholder = "Ingrese un valor"
                if (objBusqueda.id == undefined)
                    objBusqueda.id = "txtBusqueda"
                if (objBusqueda.type == undefined)
                    objBusqueda.type = "text"
                if (objConfiguracion.id == undefined)
                    objConfiguracion.id = "divTabla"
                if (objBusqueda.button == undefined)
                    objBusqueda.button = true;
                if (objConfiguracion.editar == undefined)
                    objConfiguracion.editar = false;
                if (objConfiguracion.eliminar == undefined)
                    objConfiguracion.eliminar = false;
                if (objConfiguracion.propiedadID == undefined)
                    objConfiguracion.propiedadID = "id";


                
                //ASIGNAR LOS VALORES
                objConfiguracionGlobal = objConfiguracion;
                objBusquedaGlobal = objBusqueda;

                //TEMPLATE STRING
                contenido += `
                <div class="input-group mb-3">`

                contenido +=`
                    <input type="${objBusqueda.type}" class="form-control" 
                       id="${objBusqueda.id}"
                    ${objBusqueda.button == true ? "" : "onkeyup='Buscar()'" } 
                    placeholder="${objBusqueda.placeholder}" />
                `
                // PREGUNTA SI EL objBusqueda es true si es true agrega el boton de buscar
                if (objBusqueda.button==true) {
                    contenido += `
                     <button class="btn btn-primary"
                    onclick="Buscar()"
                    type="button" >Buscar</button>
                             `
                }

              

                contenido += `</div >`;

                

            }

            contenido += "<div id='divContenedor'>";
            //llama de la funcion que pinta la tabla
            contenido += generarTabla(objConfiguracion, res);
           
            contenido += "</div>";
            document.getElementById(objConfiguracion.id).innerHTML = contenido;
            //alert(res)
        })

}

function generarTabla(objConfiguracion, res) {
    var contenido = "";
    contenido += "<table class='table'>";
    contenido += "<tr>";
    for (var j = 0; j < objConfiguracion.cabeceras.length; j++) {
        contenido += "<th>" + objConfiguracion.cabeceras[j] + "</th>"
    }

    //agrega las validaciones de editar y eliminar si es asi agrega otra columna
    if (objConfiguracion.editar == true || objConfiguracion.eliminar == true) {

        contenido += "<th>Operaciones</th>";


    }

    
    contenido += "</tr>";
    var fila;
    var propiedadActual;
    for (var i = 0; i < res.length; i++) {
        fila = res[i]
        contenido += "<tr>";
        for (var j = 0; j < objConfiguracion.propiedades.length; j++) {
            propiedadActual = objConfiguracion.propiedades[j]
            contenido += "<td>" + fila[propiedadActual] + "</td>";
        }
        ////contenido += "<td>" + fila.id + "</td>";  //fila["id"]
        ////contenido += "<td>" + fila.nombre + "</td>";
        ////contenido += "<td>" + fila.descripcion + "</td>";

        //pregunta si editar es true y agrega los iconos
        if (objConfiguracion.editar == true || objConfiguracion.eliminar == true) {

            contenido += "<td>";
            //agregandos los iconos de eliminar y editar
            if (objConfiguracion.editar == true) {

                contenido += `<i class="btn btn-primary" 
                    onclick='Editar(${fila[objConfiguracion.propiedadID]})'> 
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pen" viewBox="0 0 16 16">
                    <path d="m13.498.795.149-.149a1.207 1.207 0 1 1 1.707 1.708l-.149.148a1.5 1.5 0 0 1-.059 2.059L4.854 14.854a.5.5 0 0 1-.233.131l-4 1a.5.5 0 0 1-.606-.606l1-4a.5.5 0 0 1 .131-.232l9.642-9.642a.5.5 0 0 0-.642.056L6.854 4.854a.5.5 0 1 1-.708-.708L9.44.854A1.5 1.5 0 0 1 11.5.796a1.5 1.5 0 0 1 1.998-.001zm-.644.766a.5.5 0 0 0-.707 0L1.95 11.756l-.764 3.057 3.057-.764L14.44 3.854a.5.5 0 0 0 0-.708l-1.585-1.585z" />
                </svg> </i>`
            }

            //pregunta si eliminar es true y agrega los iconos
            if (objConfiguracion.eliminar == true) {

                contenido += `<i class="btn btn-danger" 
                   onclick='Eliminar(${fila[objConfiguracion.propiedadID]})'> 
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
                    <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z" />
                    <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z" />
                </svg> </i>`
            }

            contenido += "</td>";

        }


        contenido += "</tr>";
    }
    contenido += "</table>"

    return contenido;
}

//url absoluta con fetch(listar)
function fetchGet(url, callback) {
    var raiz = document.getElementById("hdfOculto").value;
    var urlAbsoluta = window.location.protocol + "//" +
        window.location.host + raiz + url;
    //devuelde un Json
    fetch(urlAbsoluta).then(res => res.json())
        .then(res => {
            callback(res);
        })
        .catch(err => {
            console.log(err);
        })

}

function fetchGetText(url, callback) {
    var raiz = document.getElementById("hdfOculto").value;
    var urlAbsoluta = window.location.protocol + "//" +
        window.location.host + raiz + url;
    //devuelve un text
    fetch(urlAbsoluta).then(res => res.text())
        .then(res => {
            callback(res);
        })
        .catch(err => {
            console.log(err);
        })

}


// url absoluta con fech(metodo POST "guardar")
function fetchPostText(url,frm, callback) {
    var raiz = document.getElementById("hdfOculto").value;
    var urlAbsoluta = window.location.protocol + "//" +
        window.location.host + raiz + url;

    fetch(url, {
        method: "POST",
        body: frm
    }).then(res => res.text())
        .then(res => {
            callback(res)
        })
        .catch(err => {
            console.log(err);
        })

    /*
    fetch(urlAbsoluta).then(res => res.json())
        .then(res => {
            callback(res);
        })
        .catch(err => {
            console.log(err);
        })*/


}

//funcion la cual busca algun elemento dentro de la lista
function Buscar() {
    //todos objBusqueda esta en los respectivos js
    var objConf = objConfiguracionGlobal;
    var objBus = objBusquedaGlobal;

    //recibe el valor id cama.js
    var valor = get(objBus.id);

    //url absoluta y agrega el contenido de la tabla a divContenedor
    fetchGet(`${objBus.url}/?${objBus.nombreParametro}=` + valor, function (res) {
        var respuesta = generarTabla(objConf, res);
        document.getElementById("divContenedor").innerHTML = respuesta;

    })

   /* fetch(`${objBus.url}/?${objBus.nombreParametro}=` + valor)
        .then(res => res.json())
        .then(res => {
            var respuesta = generarTabla(objConf, res);
            document.getElementById("divContenedor").innerHTML = respuesta;

        })
    */

    //pintar({
    //    //ahora cambia esta linea
    //    url: `${objBus.url}/?${objBus.nombreParametro}=` + valor,
    //    id: objConf.id,
    //    cabeceras: objConf.cabeceras,
    //    propiedades: objConf.propiedades

    //}, objBus)

}

//recupera la informacion para ser editada
function recuperarGenerico(url,idFormulario, excepciones = []) {

    var elementos = document.querySelectorAll("#" + idFormulario + " [name]");

    var nombreName;

    fetchGet(url, function (res) {

        for (var i = 0; i < elementos.length; i++) {
            nombreName = elementos[i].name;
            if (!excepciones.includes(elementos[i].name))

                setName(nombreName, res[nombreName])
        }


    });

    

}