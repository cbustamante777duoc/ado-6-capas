window.onload = function () {
    //listarTipoHabitacion();
    listarMarca();
}

function listarMarca() {
    pintar({
        url: "Marca/listarMarca", id: "divTabla",
        cabeceras: ["Idmarca", "Nombre marca", "Descripcion"],
        propiedades: ["idMarca", "nombreMarca", "descripcion"]
    }, {
        busqueda: true,
         url: "Marca/FiltrarMarca",
        nombreParametro: "nombre",
        id: "txtNombreMarca",
        placeholder: "Ingrese nombre de la marca",
        button: false,
        type: "text"
    })       
}

//function Buscar() {
//    var nombreMarca = get("txtNombreMarca");
//    pintar({
//        url: "Marca/FiltrarMarca/?nombre=" + nombreMarca,
//        id: "divTabla",
//        cabeceras: ["Idmarca", "Nombre marca", "Descripcion"],
//        propiedades: ["idMarca", "nombreMarca", "descripcion"]
//    })

//}