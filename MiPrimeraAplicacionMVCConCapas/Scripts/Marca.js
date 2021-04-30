window.onload = function () {
    //listarTipoHabitacion();
    listarMarca();
}

function listarMarca() {
    pintar({
        url: "Marca/listarMarca", id: "divTabla",
        cabeceras: ["Idmarca", "Nombre marca", "Descripcion"],
        propiedades: ["idMarca", "nombreMarca", "descripcion"]
    })       
}

function Buscar() {
    var nombreMarca = get("txtNombreMarca");
    pintar({
        url: "Marca/FiltrarMarca/?nombre=" + nombreMarca,
        id: "divTabla",
        cabeceras: ["Idmarca", "Nombre marca", "Descripcion"],
        propiedades: ["idMarca", "nombreMarca", "descripcion"]
    })

}