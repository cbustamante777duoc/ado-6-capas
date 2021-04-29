function get(id) {
    return document.getElementById(id).value;
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
                
                //ASIGNAR LOS VALORES
                objConfiguracionGlobal = objConfiguracion;
                objBusquedaGlobal = objBusqueda;

                //TEMPLATE STRING
                contenido += `
                <div class="input-group mb-3">`

                contenido +=`
                    <input type="${objBusqueda.type}" class="form-control" 
                       id="${objBusqueda.id}"
                    placeholder="${objBusqueda.placeholder}" />
                `
                contenido+=`
                <button class="btn btn-primary"
                    onclick="Buscar()"
                    type="button" >Buscar</button>
                </div>    
                `
                

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

function Buscar() {
    //todos objBusqueda esta en los respectivos js
    var objConf = objConfiguracionGlobal;
    var objBus = objBusquedaGlobal;

    var valor = get(objBus.id)

    fetch(`${objBus.url}/?${objBus.nombreParametro}=` + valor)
        .then(res => res.json())
        .then(res => {
            var respuesta = generarTabla(objConf, res);
            document.getElementById("divContenedor").innerHTML = respuesta;

        })

    //pintar({
    //    //ahora cambia esta linea
    //    url: `${objBus.url}/?${objBus.nombreParametro}=` + valor,
    //    id: objConf.id,
    //    cabeceras: objConf.cabeceras,
    //    propiedades: objConf.propiedades

    //}, objBus)

}