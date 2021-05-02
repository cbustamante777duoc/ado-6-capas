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

//limpiar los datos de formulario entero
function LimpiarDatos(idFormulario) {
    var elementos = document.querySelectorAll("#"+idFormulario+" [name]");

    for (var i = 0; i < elementos.length; i++) {
        elementos[i].value = "";
    }


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
                // PREGUNTA SI EL objBusqueda es true en el archivo cama.js si es lo agrega el boton
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

    fetch(urlAbsoluta).then(res => res.json())
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