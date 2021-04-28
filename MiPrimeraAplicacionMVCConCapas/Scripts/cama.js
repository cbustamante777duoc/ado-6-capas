window.onload = function () {
    listarCama();
}

function listarCama() {
    pintar({
        url: "Cama/listarCama",
        id:"divTabla",
        cabeceras: ["Id cama","nombre","descripcion"],
        propiedades: ["idCama", "nombre","descripcion"]

    }, {
            busqueda: true,
            url: "Cama/FiltrarCama",
            nombreParametro:"nombre",
            id:"txtNombreCama",
            placeholder:"Ingrese nombre de la cama",
            type:"text"
    })
}
